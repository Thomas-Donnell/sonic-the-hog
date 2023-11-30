using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text ringsText;
    public TMP_Text timeText;
    private int rings;
    private float time;
    void Start()
    {
        rings = RingCounter.currentRings;
        time = TimerController.currentTime;
        ringsText.text = "Rings: " + rings;
        timeText.text = "Time: " + MathF.Round(time,2) + "s";
    }

}
