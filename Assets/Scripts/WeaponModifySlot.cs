using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponModifySlot : MonoBehaviour
{
    public Weapon myItem;
    public Image myImage;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    public void Click()
    {
        UIMouseFollow follow = FindObjectOfType<UIMouseFollow>();

        if (myItem == null)
        {
            if (follow.myItem != null)
            {
                try
                {
                    myItem = (Weapon)follow.myItem;
                    myImage.sprite = myItem.sprite;
                    follow.RemoveItem();
                }
                catch (System.InvalidCastException)
                {
                    Debug.Log("follow Item not a Weapon");
                    return;
                }
            }
        }
        else
        {
            follow.AssignItem(myItem);
            myItem = null;
            myImage.sprite = null;
        }

        FindObjectOfType<AddonsController>().OnEnable();
        FindObjectOfType<StatController>().OnEnable();
    }

    public void LevelUp()
    {
        if (myItem != null)
        {
            myItem.data.LevelUp();
            FindObjectOfType<AddonsController>().OnEnable();
            FindObjectOfType<StatController>().OnEnable();
        }
    }
}
