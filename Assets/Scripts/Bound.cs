using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Bound : MonoBehaviour
{
    public Slider boundSlider;

    public TMP_Text stepCounterText;

    private float baseTime = 100000.0f;
    public float currentTime = 100000.0f;
    public float distance = 1000.0f;
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
        currentTime = baseTime * ((Mathf.Pow(0.9773f, TimeUpgrade.upgradeNumJump) - Mathf.Pow(0.9773f, 400)) / (1 - Mathf.Pow(0.9773f, 400)));

        if (isRunning)
        {
            timer -= Time.deltaTime;

            boundSlider.value = 1 - (timer / currentTime);

            if (timer <= 0f)
            {
                takeBound();
                isRunning = false;
            }
        }
    }

    public void onClickBound()
    {
        if (!isRunning)
        {
            timer = currentTime;
            isRunning = true;
        }
    }

    private void takeBound()
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

        if (boundSlider != null)
        {
            boundSlider.value = 0;
        }
    }

}
