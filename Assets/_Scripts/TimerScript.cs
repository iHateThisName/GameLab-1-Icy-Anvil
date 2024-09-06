nityusing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using system;

public class TimerScript : MonoBehaviour
{

    public float time;
    public bool timerIsRunning = false;
    public Text timerText;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning) {
            currentTime = currentTime + Time.deltaTime;
        }
        timerText = currentTime.ToString();
    }
}
