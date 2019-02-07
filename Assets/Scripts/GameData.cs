using Malee;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Addon,
    Consumable,
    Key
}

#region GameData Structs
[Serializable]
public struct GameData
{
    public PlayerInfo playerInfo;
}

[System.Serializable]
public struct InventoryPair
{
    public ItemType itemType;
    public int id;
}

[Serializable]
public class WeaponDataDictionary : ReorderableArray<WeaponData> { }

[Serializable]
public class AddonDataDictionary : ReorderableArray<StatData> { }

[Serializable]
public class InventoryPairs : ReorderableArray<InventoryPair> { }

[Serializable]
public struct PlayerInfo
{
    [Reorderable]
    public InventoryPairs inventory;
    [Reorderable]
    public WeaponDataDictionary weaponInventory;
    [Reorderable]
    public AddonDataDictionary addonInventory;

    public Item GetItemFromInventory(int index)
    {
        InventoryPair pair = inventory[index];
        switch (pair.itemType)
        {
            case ItemType.Addon:
                Addon addon = UnityEngine.Object.Instantiate((Addon)GameController.Instance.itemDatabase.GetItem(addonInventory[pair.id].baseItemName));
                addon.stats = addonInventory[pair.id];
                return addon;

            case ItemType.Weapon:
                Weapon weapon = UnityEngine.Object.Instantiate((Weapon)GameController.Instance.itemDatabase.GetItem(weaponInventory[pair.id].stats.baseItemName));
                weapon.data = weaponInventory[pair.id];
                return weapon;
        }

        Debug.LogError(string.Format("Can't receive items of type '{0}'. Returning empty Item instead.", pair.itemType));
        return new Item();
    }

    public void RemoveItemFromInventory(int index)
    {
        InventoryPair pair = inventory[index];
        switch (pair.itemType)
        {
            case ItemType.Addon:
                addonInventory.RemoveAt(pair.id);
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].itemType == ItemType.Addon && inventory[i].id >= pair.id)
                        inventory[i] = new InventoryPair { id = inventory[i].id - 1, itemType = inventory[i].itemType };
                }
                break;

            case ItemType.Weapon:
                weaponInventory.RemoveAt(pair.id);
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].itemType == ItemType.Weapon && inventory[i].id >= pair.id)
                        inventory[i] = new InventoryPair { id = inventory[i].id - 1, itemType = inventory[i].itemType };
                }
                break;
        }

        inventory[index] = new InventoryPair { id = -1 };
    }

    public void SetItemInInventory(int index, Item item)
    {
        if (item == null)
        {
            InventoryPair empty = new InventoryPair { id = -1 };
            inventory[index] = empty;
        }
        else
        {
            InventoryPair newPair = new InventoryPair();
            try
            {
                Weapon weapon = (Weapon)item;
                newPair.itemType = ItemType.Weapon;
                weaponInventory.Add(((Weapon)item).data);
                newPair.id = weaponInventory.Count - 1;
            } catch { }

            try
            {
                Addon addon = (Addon)item;
                newPair.itemType = ItemType.Addon;
                addonInventory.Add(((Addon)item).stats);
                newPair.id = addonInventory.Count - 1;
            } catch { }

            inventory[index] = newPair;
        }
    }

    public bool AddToInventory(Item item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].id == -1)
            {
                SetItemInInventory(i, item);
                return true;
            }
        }

        return false;
    }
}
#endregion