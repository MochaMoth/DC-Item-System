using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddonUIButton : MonoBehaviour
{
    public Addon myAddon;
    public int myIndex;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    public void Initialize(Addon item, int index)
    {
        myAddon = item;
        myIndex = index;
    }

    public void Click()
    {
        UIMouseFollow follow = FindObjectOfType<UIMouseFollow>();
        Debug.Log("Click!");

        if (myAddon == null)
        {
            if (follow.myItem != null)
            {
                try
                {
                    myAddon = (Addon)follow.myItem;
                    GameController.Instance.gameData.playerInfo.weaponInventory[0].addons[myIndex] = myAddon.stats;
                    follow.RemoveItem();
                }
                catch
                {
                    Debug.Log("follow Item not an Addon");
                }
            }
        }
        else
        {
            follow.AssignItem(myAddon);
            GameController.Instance.gameData.playerInfo.weaponInventory[0].addons[myIndex] = new StatData();
            myAddon = null;
        }

        FindObjectOfType<AddonsController>().OnEnable();
        FindObjectOfType<StatController>().OnEnable();
    }
}
