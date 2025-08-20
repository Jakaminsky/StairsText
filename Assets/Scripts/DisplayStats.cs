using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    public Image statPanel;
    private RectTransform panelRect;

    public TMP_Text strength;
    public TMP_Text speed;
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
            strength.text = stepInstance.strength.ToString();
            speed.text = stepInstance.speed.ToString();
            multiplier.text = stepInstance.multiplier.ToString();
        }else if (button.name.Contains("Jump"))
        {
            strength.text = jumpInstance.strength.ToString();
            speed.text = jumpInstance.speed.ToString();
            multiplier.text = jumpInstance.multiplier.ToString();
        }

    }

    public void offHover()
    {
        statPanel.gameObject.SetActive(false);
    }

}
