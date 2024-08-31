using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplaySpeed : MonoBehaviour {

    private Rigidbody2D _rb;
    public TextMeshProUGUI SpeedText;
    public int CurrentSpeed { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        CurrentSpeed = Mathf.RoundToInt(_rb.velocity.magnitude);
        if (SpeedText != null) SpeedText.text = "Speed: " + CurrentSpeed.ToString("F0");
    }
}
