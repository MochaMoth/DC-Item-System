using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("References")]
    public ItemDatabase itemDatabase;
    public GameData gameData;
    public int inventorySize = 30;

    static GameController instance;

    private void Awake()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventoryPair empty = new InventoryPair { id = -1 };
            if (gameData.playerInfo.inventory.Count <= i)
                gameData.playerInfo.inventory.Add(empty);
        }
    }

    public static GameController Instance
    {
        get {
            if (instance == null)
                instance = FindObjectOfType<GameController>();
            return instance;
        }
    }

    public void LevelUpWeapon()
    {
        gameData.playerInfo.weaponInventory[0].LevelUp();
        FindObjectOfType<StatController>().OnEnable();
        FindObjectOfType<AddonsController>().OnEnable();
    }
}
