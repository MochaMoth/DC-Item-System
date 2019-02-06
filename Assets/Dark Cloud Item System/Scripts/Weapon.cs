using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public StatData stats;
    public int baseAbs;
    public int absPerLevel;
    public int addonSlots;
    public float currentHealth;
    public float currentExperience;
    public int currentLevel;
}

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public WeaponData data;
}
