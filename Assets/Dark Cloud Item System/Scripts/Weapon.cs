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
}

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
public class Weapon : Item
{
    public WeaponData data;

    public void LevelUp()
    {
        data.currentLevel++;
        
        data.stats.attack      = data.stats.attack      + data.Attack;
        data.stats.endurance   = data.stats.endurance   + data.Endurance;
        data.stats.speed       = data.stats.speed       + data.Speed;
        data.stats.magic       = data.stats.magic       + data.Magic;
        data.stats.healthPower = data.stats.healthPower + data.HealthPower;
        data.stats.fire        = data.stats.fire        + data.Fire;
        data.stats.ice         = data.stats.ice         + data.Ice;
        data.stats.thunder     = data.stats.thunder     + data.Thunder;
        data.stats.wind        = data.stats.wind        + data.Wind;
        data.stats.holy        = data.stats.holy        + data.Holy;
        data.stats.dragon      = data.stats.dragon      + data.Dragon;
        data.stats.undead      = data.stats.undead      + data.Undead;
        data.stats.marine      = data.stats.marine      + data.Marine;
        data.stats.rock        = data.stats.rock        + data.Rock;
        data.stats.plant       = data.stats.plant       + data.Plant;
        data.stats.beast       = data.stats.beast       + data.Beast;
        data.stats.sky         = data.stats.sky         + data.Sky;
        data.stats.metal       = data.stats.metal       + data.Metal;
        data.stats.mimic       = data.stats.mimic       + data.Mimic;
        data.stats.mage        = data.stats.mage        + data.Mage;

        for (int i = 0; i < data.addons.Count; i++)
            data.addons[i] = new StatData();
    }
}
