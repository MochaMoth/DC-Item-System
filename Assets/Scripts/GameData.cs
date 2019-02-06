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
public struct WeaponDataTable
{
    public WeaponData weaponData;
}

[Serializable]
public class WeaponDataDictionary : ReorderableArray<WeaponDataTable> { }

[Serializable]
public struct PlayerInfo
{
    [Reorderable]
    public WeaponDataDictionary weaponInventory;
}
#endregion