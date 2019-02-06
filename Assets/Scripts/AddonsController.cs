using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddonsController : MonoBehaviour
{
    public GameObject backgroundImages;
    public GameObject foregroundButtons;

    public void OnEnable()
    {
        WeaponData weapon = GameController.Instance.gameData.playerInfo.weaponInventory[0];

        for (int i = 0; i < backgroundImages.transform.childCount; i++)
        {
            if (weapon.addonSlots > i)
            {
                backgroundImages.transform.GetChild(i).gameObject.SetActive(true);
                foregroundButtons.transform.GetChild(i).gameObject.SetActive(true);

                if (!string.IsNullOrEmpty(weapon.addons[i].baseItemName))
                    backgroundImages.transform.GetChild(i).GetComponent<Image>().sprite = GameController.Instance.itemDatabase.GetItem(weapon.addons[i].baseItemName).sprite;
                else
                    backgroundImages.transform.GetChild(i).GetComponent<Image>().sprite = null;
            }
            else
            {
                backgroundImages.transform.GetChild(i).gameObject.SetActive(false);
                foregroundButtons.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
