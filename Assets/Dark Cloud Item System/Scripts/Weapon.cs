using Malee;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WeaponData
{
    public StatData stats;
    [Reorderable]
    public AddonDataDictionary addons;
    public int baseAbs;
    public int absPerLevel;
    public int addonSlots;
    public float currentHealth;
    public float currentExperience;
    public int currentLevel;

    public float Attack      { get { float ret = stats.attack;      foreach (StatData addon in addons) { ret += addon.attack;      } return ret; } }
    public float Endurance   { get { float ret = stats.endurance;   foreach (StatData addon in addons) { ret += addon.endurance;   } return ret; } }
    public float Speed       { get { float ret = stats.speed;       foreach (StatData addon in addons) { ret += addon.speed;       } return ret; } }
    public float Magic       { get { float ret = stats.magic;       foreach (StatData addon in addons) { ret += addon.magic;       } return ret; } }
    public float HealthPower { get { float ret = stats.healthPower; foreach (StatData addon in addons) { ret += addon.healthPower; } return ret; } }
    public float Fire        { get { float ret = stats.fire;        foreach (StatData addon in addons) { ret += addon.fire;        } return ret; } }
    public float Ice         { get { float ret = stats.ice;         foreach (StatData addon in addons) { ret += addon.ice;         } return ret; } }
    public float Thunder     { get { float ret = stats.thunder;     foreach (StatData addon in addons) { ret += addon.thunder;     } return ret; } }
    public float Wind        { get { float ret = stats.wind;        foreach (StatData addon in addons) { ret += addon.wind;        } return ret; } }
    public float Holy        { get { float ret = stats.holy;        foreach (StatData addon in addons) { ret += addon.holy;        } return ret; } }
    public float Dragon      { get { float ret = stats.dragon;      foreach (StatData addon in addons) { ret += addon.dragon;      } return ret; } }
    public float Undead      { get { float ret = stats.undead;      foreach (StatData addon in addons) { ret += addon.undead;      } return ret; } }
    public float Marine      { get { float ret = stats.marine;      foreach (StatData addon in addons) { ret += addon.marine;      } return ret; } }
    public float Rock        { get { float ret = stats.rock;        foreach (StatData addon in addons) { ret += addon.rock;        } return ret; } }
    public float Plant       { get { float ret = stats.plant;       foreach (StatData addon in addons) { ret += addon.plant;       } return ret; } }
    public float Beast       { get { float ret = stats.beast;       foreach (StatData addon in addons) { ret += addon.beast;       } return ret; } }
    public float Sky         { get { float ret = stats.sky;         foreach (StatData addon in addons) { ret += addon.sky;         } return ret; } }
    public float Metal       { get { float ret = stats.metal;       foreach (StatData addon in addons) { ret += addon.metal;       } return ret; } }
    public float Mimic       { get { float ret = stats.mimic;       foreach (StatData addon in addons) { ret += addon.mimic;       } return ret; } }
    public float Mage        { get { float ret = stats.mage;        foreach (StatData addon in addons) { ret += addon.mage;        } return ret; } }

    public WeaponData()
    {
        stats = new StatData();
        addons = new AddonDataDictionary();
    }

    public void LevelUp()
    {
        currentLevel++;
        
        stats.attack      = Attack + 1;
        stats.endurance   = Endurance + 1;
        stats.speed       = Speed + 1;
        stats.magic       = Magic + 1;
        stats.healthPower = HealthPower + 1;
        stats.fire        = Fire;
        stats.ice         = Ice;
        stats.thunder     = Thunder;
        stats.wind        = Wind;
        stats.holy        = Holy;
        stats.dragon      = Dragon;
        stats.undead      = Undead;
        stats.marine      = Marine;
        stats.rock        = Rock;
        stats.plant       = Plant;
        stats.beast       = Beast;
        stats.sky         = Sky;
        stats.metal       = Metal;
        stats.mimic       = Mimic;
        stats.mage        = Mage;

        for (int i = 0; i < addons.Count; i++)
            addons[i] = new StatData();
    }
}

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public WeaponData data;
}
