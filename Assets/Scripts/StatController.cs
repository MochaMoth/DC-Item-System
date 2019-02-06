using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatController : MonoBehaviour
{
    public StatColumn basicStatsColumn;
    public StatColumn magicStatsColumn;
    public StatColumn antiStatsColumn;

    public void OnEnable()
    {
        //TODO: Update to be dynamic
        Dictionary<string, float> stats = new Dictionary<string, float>();
        WeaponData data = GameController.Instance.gameData.playerInfo.weaponInventory[0];
        stats.Add("Level", data.currentLevel);
        stats.Add("Attack", data.Attack);
        stats.Add("Endurance", data.Endurance);
        stats.Add("Speed", data.Speed);
        stats.Add("Magic", data.Magic);
        stats.Add("WHP", data.HealthPower);
        basicStatsColumn.Initialize(stats);

        stats = new Dictionary<string, float>();
        stats.Add("Fire", data.Fire);
        stats.Add("Ice", data.Ice);
        stats.Add("Thunder", data.Thunder);
        stats.Add("Wind", data.Wind);
        stats.Add("Holy", data.Holy);
        magicStatsColumn.Initialize(stats);

        stats = new Dictionary<string, float>();
        stats.Add("Dragon", data.Dragon);
        stats.Add("Undead", data.Undead);
        stats.Add("Marine", data.Marine);
        stats.Add("Rock", data.Rock);
        stats.Add("Plant", data.Plant);
        stats.Add("Beast", data.Beast);
        stats.Add("Sky", data.Sky);
        stats.Add("Metal", data.Metal);
        stats.Add("Mimic", data.Mimic);
        stats.Add("Mage", data.Mage);
        antiStatsColumn.Initialize(stats);
    }
}
