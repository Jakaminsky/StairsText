using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Leap : MonoBehaviour
{
    public Slider leapSlider;

    public TMP_Text stepCounterText;

    private float baseTime = 10000.0f;
    public float currentTime = 10000.0f;
    public float distance = 100.0f;
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
        currentTime = baseTime * ((Mathf.Pow(0.9698f, TimeUpgrade.upgradeNumJump) - Mathf.Pow(0.9698f, 300)) / (1 - Mathf.Pow(0.9698f, 300)));

        if (isRunning)
        {
            timer -= Time.deltaTime;

            leapSlider.value = 1 - (timer / currentTime);

            if (timer <= 0f)
            {
                takeLeap();
                isRunning = false;
            }
        }
    }

    public void onClickLeap()
    {
        if (!isRunning)
        {
            timer = currentTime;
            isRunning = true;
        }
    }

    private void takeLeap()
    {
        Step.stepCounter += distance * multiplier;

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (stepCounterText != null)
        {
            stepCounterText.text = Step.stepCounter.ToString();
        }

        if (leapSlider != null)
        {
            leapSlider.value = 0;
        }
    }

}
