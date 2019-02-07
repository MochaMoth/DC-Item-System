using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SynthesizeButton : MonoBehaviour
{
    public WeaponModifySlot modifySlot;

    Button myButton;

    private void Awake()
    {
        modifySlot = FindObjectOfType<WeaponModifySlot>();
        myButton = GetComponent<Button>();
        UpdateStatus();

        myButton.onClick.AddListener(Click);
    }

    public void UpdateStatus()
    {
        if (modifySlot.myItem == null || modifySlot.myItem.data.currentLevel < 5)
            myButton.interactable = false;
        else
            myButton.interactable = true;
    }

    public void Click()
    {
        SynthSphere sphere = new SynthSphere();
        sphere.stats = new StatData();
        StatData data = modifySlot.myItem.data.stats;
        sphere.stats.baseItemName = data.baseItemName + " Synth Sphere";
        sphere.stats.attack      = data.attack;
        sphere.stats.endurance   = data.endurance;
        sphere.stats.speed       = data.speed;
        sphere.stats.magic       = data.magic;
        sphere.stats.healthPower = data.healthPower;
        sphere.stats.fire        = data.fire;
        sphere.stats.ice         = data.ice;
        sphere.stats.thunder     = data.thunder;
        sphere.stats.wind        = data.wind;
        sphere.stats.holy        = data.holy;
        sphere.stats.dragon      = data.dragon;
        sphere.stats.undead      = data.undead;
        sphere.stats.marine      = data.marine;
        sphere.stats.rock        = data.rock;
        sphere.stats.plant       = data.plant;
        sphere.stats.beast       = data.beast;
        sphere.stats.sky         = data.sky;
        sphere.stats.metal       = data.metal;
        sphere.stats.mimic       = data.mimic;
        sphere.stats.mage        = data.mage;
        //GameController.Instance.gameData.playerInfo.SetItemInInventory(sphere);
        if (GameController.Instance.gameData.playerInfo.AddToInventory(sphere))
        {
            //delete item from modify slot
            //update status
            modifySlot.myItem = null;
            modifySlot.myImage.sprite = null;
            FindObjectOfType<AddonsController>().OnEnable();
            FindObjectOfType<StatController>().OnEnable();
            FindObjectOfType<InventoryController>().OnEnable();
        }
    }
}
