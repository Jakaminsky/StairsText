using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Step : MonoBehaviour
{
    public Slider stepSlider;

    public static float stepCounter = 0;

    public TMP_Text stepCounterText;

    public float speed = 10.0f;
    public float strength = 1.0f;
    public float multiplier = 1.0f;

    private float timer = 0;
    private bool isRunning = false;

    private void Start()
    {
        timer = speed;
        UpdateUI();
    }

    private void Update()
    {
        if (isRunning)
        {
            timer -= Time.deltaTime;

            stepSlider.value = 1 - (timer / speed);

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
            timer = speed;
            isRunning = true;
        }
    }

    private void takeStep()
    {
        stepCounter += strength * multiplier;

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
