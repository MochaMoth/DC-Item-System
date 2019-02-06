using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject backgroundImages;
    public GameObject foregroundButtons;

    public void OnEnable()
    {
        InventoryPairs inventory = GameController.Instance.gameData.playerInfo.inventory;

        for (int i = 0; i < backgroundImages.transform.childCount; i++)
        {
            if (inventory.Count > i)
            {
                if (inventory[i].id != -1)
                {
                    Item item = GameController.Instance.gameData.playerInfo.GetItemFromInventory(i);
                    backgroundImages.transform.GetChild(i).GetComponent<Image>().sprite = item.sprite;
                    foregroundButtons.transform.GetChild(i).GetComponent<InventoryButton>().Initialize(item, i);
                }
                else
                {
                    backgroundImages.transform.GetChild(i).GetComponent<Image>().sprite = null;
                    foregroundButtons.transform.GetChild(i).GetComponent<InventoryButton>().Initialize(null, i);
                }
            }
            else
            {
                backgroundImages.transform.GetChild(i).GetComponent<Image>().sprite = null;
                foregroundButtons.transform.GetChild(i).GetComponent<InventoryButton>().Initialize(null, i);
            }
        }
    }
}
