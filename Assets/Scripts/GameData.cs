using Malee;
using System;
using System.Collections.Generic;
using UnityEngine;

#region GameData Structs
[Serializable]
public struct GameData
{
    public PlayerInfo playerInfo;
}

[Serializable]
public class WeaponDataDictionary : ReorderableArray<WeaponData> { }

[Serializable]
public class AddonDataDictionary : ReorderableArray<StatData> { }

[Serializable]
public struct PlayerInfo
{
    [Reorderable]
    public WeaponDataDictionary weaponInventory;
    [Reorderable]
    public AddonDataDictionary addonInventory;
}
#endregion