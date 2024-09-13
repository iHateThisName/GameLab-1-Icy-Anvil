using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float _speed = 4f;
    public float _jumpForce = 500f;

    //Movment
    private bool _jumpPressed = false;
    private bool _APressed = false;
    private bool _DPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //// Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            _APressed = true;
        }

        if (Input.GetKey(KeyCode.D)) {
            _DPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            _jumpPressed = true;
        }
    }

    void FixedUpdate() {
        if (_APressed) {
            _rb.velocity = new Vector2(-_speed, _rb.velocity.y);
            _APressed = false;
        }
        else if (_DPressed) {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
            _DPressed = false;
        }
        else _rb.velocity = new Vector2(0, _rb.velocity.y);

        if (_jumpPressed) {
            Debug.Log("Space is pressed");
            _rb.AddForce(transform.up * _jumpForce);
            _jumpPressed = false;
        }
    }
}
