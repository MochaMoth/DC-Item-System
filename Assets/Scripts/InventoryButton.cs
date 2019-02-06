using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Item myItem;
    public int myIndex;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    public void Initialize(Item item, int index)
    {
        myItem = item;
        myIndex = index;
    }

    public void Click()
    {
        UIMouseFollow follow = FindObjectOfType<UIMouseFollow>();

        if (myItem == null)
        {
            if (follow.myItem != null)
            {
                myItem = follow.myItem;
                follow.RemoveItem();
                GameController.Instance.gameData.playerInfo.SetItemInInventory(myIndex, myItem);
            }
        }
        else if (follow.myItem == null)
        {
            follow.AssignItem(myItem);
            myItem = null;
            GameController.Instance.gameData.playerInfo.RemoveItemFromInventory(myIndex);
        }

        FindObjectOfType<InventoryController>().OnEnable();
    }
}
