using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Step : MonoBehaviour
{
    public Slider stepSlider;

    public static float stepCounter = 0;

    public TMP_Text stepCounterText;

    private float baseTime = 10.0f;
    public float currentTime = 10.0f;
    public float distance = 1.0f;
    public float multiplier = 1.0f;

    private float timer = 0;
    private bool isRunning = false;

    private void Start()
    {
        Mathf.Clamp(currentTime, baseTime, 0.1f);

        timer = currentTime;
        UpdateUI();
    }

    private void Update()
    {
        currentTime = baseTime * ((Mathf.Pow(0.9570f, TimeUpgrade.upgradeNumStep) - Mathf.Pow(0.9570f, 100)) / (1 - Mathf.Pow(0.9570f, 100)));

        if (isRunning)
        {
            timer -= Time.deltaTime;

            stepSlider.value = 1 - (timer / currentTime);

            if (timer <= 0f)
            {
                takeStep();
                isRunning = false;
            }
        }
    }

    public void onClickStep()
    {
        if (!isRunning)
        {
            timer = currentTime;
            isRunning = true;
        }
    }

    private void takeStep()
    {
        stepCounter += distance * multiplier;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (stepCounterText != null)
        {
            stepCounterText.text = stepCounter.ToString();
        }

        if (stepSlider != null)
        {
            stepSlider.value = 0;
        }
    }

}
