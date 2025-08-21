using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Leap : MonoBehaviour
{
    public Slider leapSlider;

    public TMP_Text stepCounterText;

    public float time = 10000.0f;
    public float distance = 100.0f;
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

            leapSlider.value = 1 - (timer / time);

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
            timer = time;
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
