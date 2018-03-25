using System;
using Assets.Scripts;
using UnityEngine;

public class LevelConstructor : MonoBehaviour
{

    public GameObject RouterPrefab;
	public GameObject FoodPrefab;
	public float FoodInterval;
    
    public void Start ()
    {
        foreach (var routerItem in Level1)
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
		private RouterItem[] Level1 = new []
		{
			new RouterItem { X= -1.5f, Y= -0.65f, CanUp=true, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= 1.5f, Y= -0.65f, CanUp=true, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= -1.5f, Y= 1.3f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= 1.5f, Y= 1.3f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X=0.5f, Y= 1.3f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= -0.5f, Y= 1.3f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= -1.5f, Y=0.3f, CanUp=true, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= 1.5f, Y=0.3f, CanUp=true, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -0.5f, Y= 2.3f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X=0.5f, Y= 2.3f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -1.5f, Y= 2.3f, CanUp=true, CanDown=false, CanRight=true, CanLeft=false},
			new RouterItem { X= 1.5f, Y= 2.3f, CanUp=true, CanDown=false, CanRight=false, CanLeft=true},
			new RouterItem { X= -1.5f, Y= 3.25f, CanUp=false, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= 1.5f, Y= 3.25f, CanUp=false, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= -2.4f, Y= 3.25f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= 2.4f, Y= 3.25f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= -4f, Y= 3.25f, CanUp=true, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= 4f, Y= 3.25f, CanUp=true, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= -2.4f, Y=0.3f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= 2.4f, Y=0.3f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= -4f, Y= 2.25f, CanUp=true, CanDown=false, CanRight=true, CanLeft=false},
			new RouterItem { X= 4f, Y= 2.25f, CanUp=true, CanDown=false, CanRight=false, CanLeft=true},
			new RouterItem { X= -2.4f, Y= 2.25f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= 2.4f, Y= 2.25f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= -2.4f, Y= 4.5f, CanUp=false, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= 2.4f, Y= 4.5f, CanUp=false, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= 4f, Y= 4.5f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= -0.5f, Y= 3.25f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X=0.5f, Y= 3.25f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= -4, Y= 4.5f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -0.5f, Y= 4.5f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X=0.5f, Y= 4.5f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -1.45f, Y= -1.6f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= 1.45f, Y= -1.6f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= -0.5f, Y= -1.6f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X=0.5f, Y= -1.6f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -0.5f, Y= -2.6f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X=0.5f, Y= -2.6f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= -1.45f, Y= -2.6f, CanUp=false, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= 1.45f, Y= -2.6f, CanUp=false, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= -2.4f, Y= -2.6f, CanUp=true, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= 2.4f, Y= -2.6f, CanUp=true, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= 2.4f, Y= -1.6f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= -2.4f, Y= -1.6f, CanUp=true, CanDown=true, CanRight=true, CanLeft=true},
			new RouterItem { X= -4f, Y= -1.6f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= 4f, Y= -1.6f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= -4f, Y= -2.6f, CanUp=true, CanDown=false, CanRight=true, CanLeft=false},
			new RouterItem { X= 4f, Y= -2.6f, CanUp=true, CanDown=false, CanRight=false, CanLeft=true},
			new RouterItem { X= -3.4f, Y= -2.6f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= 3.4f, Y= -2.6f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -4f, Y= -4.5f, CanUp=true, CanDown=false, CanRight=true, CanLeft=false},
			new RouterItem { X= 4f, Y= -4.5f, CanUp=true, CanDown=false, CanRight=false, CanLeft=true},
			new RouterItem { X= -0.5f, Y= -4.5f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X=0.5f, Y= -4.5f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= -0.5f, Y= -3.5f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X=0.5f, Y= -3.5f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -1.45f, Y= -3.5f, CanUp=true, CanDown=false, CanRight=true, CanLeft=false},
			new RouterItem { X= 1.45f, Y= -3.5f, CanUp=true, CanDown=false, CanRight=false, CanLeft=true},
			new RouterItem { X= 4f, Y= -3.5f, CanUp=false, CanDown=true, CanRight=false, CanLeft=true},
			new RouterItem { X= -4f, Y= -3.5f, CanUp=false, CanDown=true, CanRight=true, CanLeft=false},
			new RouterItem { X= -3.35f, Y= -3.5f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= 3.35f, Y= -3.5f, CanUp=true, CanDown=false, CanRight=true, CanLeft=true},
			new RouterItem { X= -2.4f, Y= -3.5f, CanUp=true, CanDown=false, CanRight=false, CanLeft=true},
			new RouterItem { X= 2.4f, Y= -3.5f, CanUp=true, CanDown=false, CanRight=true, CanLeft=false}
		};
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
