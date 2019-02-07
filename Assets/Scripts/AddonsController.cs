using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddonsController : MonoBehaviour
{
    public GameObject backgroundImages;
    public GameObject foregroundButtons;
    public WeaponModifySlot modifySlot;

    public void OnEnable()
    {
        modifySlot = FindObjectOfType<WeaponModifySlot>();
        if (modifySlot.myItem == null)
        {
            for (int i = 0; i < backgroundImages.transform.childCount; i++)
            {
                backgroundImages.transform.GetChild(i).gameObject.SetActive(false);
                foregroundButtons.transform.GetChild(i).gameObject.SetActive(false);
            }

            return;
        }

        WeaponData weapon = modifySlot.myItem.data;

        for (int i = 0; i < backgroundImages.transform.childCount; i++)
        {
            if (weapon.addonSlots > i)
            {
                backgroundImages.transform.GetChild(i).gameObject.SetActive(true);
                foregroundButtons.transform.GetChild(i).gameObject.SetActive(true);

                if (weapon.addons.Count <= i)
                    weapon.addons.Add(new StatData());

                if (!string.IsNullOrEmpty(weapon.addons[i].baseItemName))
                {
                    Addon addon = (Addon)GameController.Instance.itemDatabase.GetItem(weapon.addons[i].baseItemName);
                    addon.stats = weapon.addons[i];
                    backgroundImages.transform.GetChild(i).GetComponent<Image>().sprite = addon.sprite;
                    foregroundButtons.transform.GetChild(i).GetComponent<AddonUIButton>().Initialize(addon, i);
                }
                else
                {
                    backgroundImages.transform.GetChild(i).GetComponent<Image>().sprite = null;
                    foregroundButtons.transform.GetChild(i).GetComponent<AddonUIButton>().Initialize(null, i);
                }
            }
            else
            {
                backgroundImages.transform.GetChild(i).gameObject.SetActive(false);
                foregroundButtons.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
