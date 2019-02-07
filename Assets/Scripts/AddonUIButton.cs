using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddonUIButton : MonoBehaviour
{
    public Addon myAddon;
    public int myIndex;
    public WeaponModifySlot modifySlot;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
        modifySlot = FindObjectOfType<WeaponModifySlot>();
    }

    public void Initialize(Addon item, int index)
    {
        myAddon = item;
        myIndex = index;
    }

    public void Click()
    {
        UIMouseFollow follow = FindObjectOfType<UIMouseFollow>();

        if (myAddon == null)
        {
            if (follow.myItem != null)
            {
                try
                {
                    myAddon = (Addon)follow.myItem;
                    modifySlot.myItem.data.addons[myIndex] = myAddon.stats;
                    follow.RemoveItem();
                }
                catch
                {
                    Debug.Log("follow Item not an Addon");
                    return;
                }
            }
        }
        else
        {
            if (follow.myItem == null)
            {
                follow.AssignItem(myAddon);
                modifySlot.myItem.data.addons[myIndex] = new StatData();
                myAddon = null;
            }
        }

        FindObjectOfType<AddonsController>().OnEnable();
        FindObjectOfType<StatController>().OnEnable();
    }
}
