using Malee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Items : ReorderableArray<Item> { }

[CreateAssetMenu(fileName = "New Item Database", menuName = "Items/Database")]
public class ItemDatabase : ScriptableObject
{
    [Reorderable]
    public Items items;

    public Item GetItem(int index)
    {
        if (index < 0 || index >= items.Count)
            return ErrorItem(string.Format("{0} is out of range (0 - {1}). Returning empty item instead.", index, items.Count - 1));

        if (items.Count == 0)
            return ErrorItem(string.Format("Item Database does not have any items assigned to it. Returning empty item instead."));

        return items[index];
    }

    public int GetItemIndex(Item item)
    {
        for (int i = 0; i < items.Count; i++)
            if (items[i].name == item.name)
                return i;

        return -1;
    }

    Item ErrorItem(string err)
    {
        Debug.LogError(err, this);
        return new Item();
    }
}
