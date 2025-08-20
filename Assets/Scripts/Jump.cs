using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public Slider jumpSlider;

    public TMP_Text stepCounterText;

    public float time = 10.0f;
    public float distance = 10.0f;
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

            jumpSlider.value = 1 - (timer / time);

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
            timer = time;
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
