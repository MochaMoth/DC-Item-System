using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatData
{
    public string baseItemName;

    [Header("Basic Stats")]
    public float attack;
    public float endurance;
    public float speed;
    public float magic;
    public float healthPower;

    [Header("Elemental Stats")]
    public float fire;
    public float ice;
    public float thunder;
    public float wind;
    public float holy;

    [Header("Anti Stats")]
    public float dragon;
    public float undead;
    public float marine;
    public float rock;
    public float plant;
    public float beast;
    public float sky;
    public float metal;
    public float mimic;
    public float mage;
}

public class Item : ScriptableObject
{
    public Sprite sprite;
}
