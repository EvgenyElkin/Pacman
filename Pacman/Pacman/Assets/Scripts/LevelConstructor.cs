using System;
using Assets.Scripts;
using UnityEngine;

public class LevelConstructor : MonoBehaviour
{

    public GameObject RouterPrefab;

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
