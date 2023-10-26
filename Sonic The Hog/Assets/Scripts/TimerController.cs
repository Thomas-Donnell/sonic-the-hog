using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText; // Reference to the Text UI element
    public float startTime = 0f; // Initial time for the timer
    private float currentTime = 0f;
    private bool isRunning = false;

    void Start()
    {
        // Initialize the timer
        currentTime = startTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime += Time.deltaTime; // Increment the timer

            // Update the text to display the current time
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + currentTime.ToString("F2"); // Format the time with two decimal places
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        UpdateTimerText();
    }
}
