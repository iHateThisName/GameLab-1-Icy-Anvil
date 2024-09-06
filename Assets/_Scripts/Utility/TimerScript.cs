using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    public float time;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText;
    private float _currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning) {
            _currentTime = _currentTime + Time.deltaTime;
        }
        timerText.text = _currentTime.ToString();
    }
}
