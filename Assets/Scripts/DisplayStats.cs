using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Image statPanel;
    private RectTransform panelRect;

    public TMP_Text distance;
    public TMP_Text time;
    public TMP_Text multiplier;

    public Step stepInstance;
    public Jump jumpInstance;
    public Leap leapInstance;
    public Bound boundInstance;
    public Launch launchInstance;

    private void Start()
    {
        panelRect = statPanel.GetComponent<RectTransform>();
        statPanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (statPanel.IsActive())
        {
            panelRect.position = Input.mousePosition + new Vector3 (105, -55, 0);
        }
    }

    private string FormatNumber(float number)
    {
        if (Mathf.Abs(number) >= 1e5)
        {
            return number.ToString("0.00E+0");
        }
        else
        {
            return Mathf.RoundToInt((float)number).ToString();
        }
    }

    public void onHover(GameObject button)
    {
        statPanel.gameObject.SetActive(true);

        if (button.name.Contains("Step"))
        {
            distance.text = FormatNumber(stepInstance.distance);
            time.text = FormatNumber(stepInstance.time);
            multiplier.text = FormatNumber(stepInstance.multiplier);
        }
        else if (button.name.Contains("Jump"))
        {
            distance.text = FormatNumber(jumpInstance.distance);
            time.text = FormatNumber(jumpInstance.time);
            multiplier.text = FormatNumber(jumpInstance.multiplier);
        }
        else if (button.name.Contains("Leap"))
        {
            distance.text = FormatNumber(leapInstance.distance);
            time.text = FormatNumber(leapInstance.time);
            multiplier.text = FormatNumber(leapInstance.multiplier);
        }
        else if (button.name.Contains("Bound"))
        {
            distance.text = FormatNumber(boundInstance.distance);
            time.text = FormatNumber(boundInstance.time);
            multiplier.text = FormatNumber(boundInstance.multiplier);
        }
        else if (button.name.Contains("Launch"))
        {
            distance.text = FormatNumber(launchInstance.distance);
            time.text = FormatNumber(launchInstance.time);
            multiplier.text = FormatNumber(launchInstance.multiplier);
        }
    }

    public void offHover()
    {
        statPanel.gameObject.SetActive(false);
    }

}
