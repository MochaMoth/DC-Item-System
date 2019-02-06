using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatColumn : MonoBehaviour
{
    public GameObject statBlock;

    public void Initialize(Dictionary<string, float> stats)
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        foreach (KeyValuePair<string, float> stat in stats)
        {
            GameObject gob = Instantiate(statBlock, transform);
            Text[] texts = gob.GetComponentsInChildren<Text>();
            texts[0].text = stat.Key + ":";
            texts[1].text = stat.Value.ToString();
        }
    }
}
