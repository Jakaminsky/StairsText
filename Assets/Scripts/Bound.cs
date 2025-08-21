using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Bound : MonoBehaviour
{
    public Slider boundSlider;

    public TMP_Text stepCounterText;

    public float time = 100000.0f;
    public float distance = 1000.0f;
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

            boundSlider.value = 1 - (timer / time);

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
            timer = time;
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
