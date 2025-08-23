using System.Collections.Generic;
using UnityEngine;

public class TimeUpgradeCosts : MonoBehaviour
{
    public List<float> secondColumnValues;

    void Start()
    {
        TextAsset csvFile = Resources.Load<TextAsset>("upgrade_costs");
        string[] lines = csvFile.text.Split('\n');

        secondColumnValues = new List<float>();

        foreach (string line in lines)
        {
            string[] values = line.Split(',');
            if (values.Length > 1)
            {
                if (float.TryParse(values[1], out float number))
                {
                    secondColumnValues.Add(number);
                }
            }
        }

        secondColumnValues.Add(-1);
    }
}
