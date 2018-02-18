using System;
using Assets.Scripts;
using UnityEngine;

public class LevelConstructor : MonoBehaviour
{

    public GameObject RouterPrefab;
	public GameObject FoodPrefab;
	public float FoodInterval;
	
    public RouterItem[] Items;
    
    public void Start ()
    {
        foreach (var routerItem in Items)
        {
            var router = Instantiate(RouterPrefab, new Vector3(routerItem.X, routerItem.Y, 0f), Quaternion.identity);
            var routerController = router.GetComponent<RouterController>();
            routerController.CanDown = routerItem.CanDown;
            routerController.CanLeft = routerItem.CanLeft;
            routerController.CanRight = routerItem.CanRight;
            routerController.CanUp = routerItem.CanUp;
        }
		GenerateFood(new Vector2(-4f, -4.5f), new Vector2(4f, -4.5f));
	}

		private void GenerateFood(Vector2 @from, Vector2 @to)
		{
			if(@from.x == @to.x)
			{
				var startY = Math.Min(@from.y, @to.y);
				var finishY = Math.Max(@from.y, @to.y);
				for(var y = startY; y <= finishY; y += FoodInterval)
				{
					var food = Instantiate(FoodPrefab, new Vector3(@from.x, y, 0f), Quaternion.identity);
				}
			}
			else
			{
				var startX = Math.Min(@from.x, @to.x);
				var finishX = Math.Max(@from.x, @to.x);
				for(var x = startX; x <= finishX; x += FoodInterval)
				{
					var food = Instantiate(FoodPrefab, new Vector3(x, @from.y, 0f), Quaternion.identity);
				}
			}
		}
}

[Serializable]
public class RouterItem
{
    public float X;
    public float Y;
    public bool CanUp;
    public bool CanDown;
    public bool CanRight;
    public bool CanLeft;
}
