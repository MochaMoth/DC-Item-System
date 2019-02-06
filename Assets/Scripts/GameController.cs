using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("References")]
    public ItemDatabase itemDatabase;
    public GameData gameData;

    static GameController instance;

    public static GameController Instance
    {
        get {
            if (instance == null)
                instance = FindObjectOfType<GameController>();
            return instance;
        }
    }
}
