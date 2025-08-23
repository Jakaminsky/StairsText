using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public Slider jumpSlider;

    public TMP_Text stepCounterText;

    private float baseTime = 1000.0f;
    public float currentTime = 1000.0f;
    public float distance = 10.0f;
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
        currentTime = baseTime * ((Mathf.Pow(0.9551f, TimeUpgrade.upgradeNumJump) - Mathf.Pow(0.9551f, 200)) / (1 - Mathf.Pow(0.9551f, 200)));

        if (isRunning)
        {
            timer -= Time.deltaTime;

            jumpSlider.value = 1 - (timer / currentTime);

            if (timer <= 0f)
            {
                takeJump();
                isRunning = false;
            }
        }
    }

    public void onClickJump()
    {
        if (!isRunning)
        {
            timer = currentTime;
            isRunning = true;
        }
    }

    private void takeJump()
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

        if (jumpSlider != null)
        {
            jumpSlider.value = 0;
        }
    }

}
