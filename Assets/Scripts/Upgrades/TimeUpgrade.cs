using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TimeUpgrade : MonoBehaviour
{
    public Image upgradePanel;
    private RectTransform panelRect;

    public TMP_Text stepCost;
    public TMP_Text upgradeNumber;
    public Button upgradeButton;

    private float currentUpgradeCost = 0;

    private int totalUpgrades = 0;
    public static int upgradeNumStep = 0;
    public static int upgradeNumJump = 0;
    public static int upgradeNumLeap = 0;
    public static int upgradeNumBound = 0;
    public static int upgradeNumLaunch = 0;

    public TimeUpgradeCosts timeUpgradeCostsInstance;

    private void Start()
    {
        panelRect = upgradePanel.GetComponent<RectTransform>();
        upgradePanel.gameObject.SetActive(false);

        Mathf.Clamp(upgradeNumStep, 0, 100);
        Mathf.Clamp(upgradeNumJump, 0, 200);
        Mathf.Clamp(upgradeNumLeap, 0, 300);
        Mathf.Clamp(upgradeNumBound, 0, 400);
        Mathf.Clamp(upgradeNumLaunch, 0, 500);
        Mathf.Clamp(totalUpgrades, 0, 500);
    }

    private void Update()
    {
        currentUpgradeCost = timeUpgradeCostsInstance.secondColumnValues[totalUpgrades + 1];

        if(totalUpgrades < 500)
        {
            if (upgradePanel.IsActive())
            {
                panelRect.position = Input.mousePosition + new Vector3(105, -55, 0);
            }
        }
        else
        {
            upgradePanel.gameObject.SetActive(false);

            upgradeButton.enabled = false;

            ColorBlock cb = upgradeButton.colors;
            cb.normalColor = Color.red;
            upgradeButton.colors = cb;
        }
    }

    public void onClick()
    {
        upgradeNumStep++;
        upgradeNumJump++;
        upgradeNumLeap++;
        upgradeNumBound++;
        upgradeNumLaunch++;
        totalUpgrades++;

        stepCost.text = FormatNumber(currentUpgradeCost) + " steps";
        upgradeNumber.text = totalUpgrades.ToString() + "/500";
    }

    private string FormatNumber(float number)
    {
        if (Mathf.Abs(number) >= 1e5)
        {
            return number.ToString("0.00E+0");
        }
        else
        {
            float rounded = Mathf.Round(number * 10f) / 10f;
            float clamped = Mathf.Clamp(rounded, 0f, 10000000000.0f);
            return clamped.ToString("F1");
        }
    }

    public void onHover(GameObject button)
    {
        upgradePanel.gameObject.SetActive(true);

        stepCost.text = FormatNumber(currentUpgradeCost) + " steps";
        upgradeNumber.text = totalUpgrades.ToString() + "/500";
    }

    public void offHover()
    {
        upgradePanel.gameObject.SetActive(false);
    }
}
