using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Launch : MonoBehaviour
{
    public Slider launchSlider;

    public TMP_Text stepCounterText;

    public float time = 1000000.0f;
    public float distance = 10000.0f;
    public float multiplier = 1.0f;

    private float timer = 0;
    private bool isRunning = false;

    private void Start()
    {
        timer = time;
        UpdateUI();
    }

    private void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;

            launchSlider.value = 1 - (timer / time);

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
            timer = time;
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
