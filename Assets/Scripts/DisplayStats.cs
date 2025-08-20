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

    public void onHover(GameObject button)
    {
        statPanel.gameObject.SetActive(true);

        if (button.name.Contains("Step"))
        {
            distance.text = stepInstance.distance.ToString();
            time.text = stepInstance.time.ToString();
            multiplier.text = stepInstance.multiplier.ToString();
        }else if (button.name.Contains("Jump"))
        {
            distance.text = jumpInstance.distance.ToString();
            time.text = jumpInstance.time.ToString();
            multiplier.text = jumpInstance.multiplier.ToString();
        }

    }

    public void offHover()
    {
        statPanel.gameObject.SetActive(false);
    }

}
