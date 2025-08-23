using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Launch : MonoBehaviour
{
    public Slider launchSlider;

    public TMP_Text stepCounterText;

    private float baseTime = 1000000.0f;
    public float currentTime = 1000000.0f;
    public float distance = 10000.0f;
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
        currentTime = baseTime * ((Mathf.Pow(0.9818f, TimeUpgrade.upgradeNumJump) - Mathf.Pow(0.9818f, 500)) / (1 - Mathf.Pow(0.9818f, 500)));

        if (isRunning)
        {
            timer -= Time.deltaTime;

            launchSlider.value = 1 - (timer / currentTime);

            if (timer <= 0f)
            {
                takeLaunch();
                isRunning = false;
            }
        }
    }

    public void onClickLaunch()
    {
        if (!isRunning)
        {

            timer = currentTime;
            isRunning = true;
        }
    }

    private void takeLaunch()
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

        if (launchSlider != null)
        {
            launchSlider.value = 0;
        }
    }

}
