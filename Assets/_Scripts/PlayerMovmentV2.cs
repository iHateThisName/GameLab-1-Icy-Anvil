using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Private fields: _isPrivate
//Public fields: IsPrivate
//Scoped variables: isPrivate

public class PlayerMovmentV2 : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;

    private Rigidbody2D _rb;

    public Transform GroundCheckPoint;
    public LayerMask AllowJumpMask;

    [SerializeField] private bool _isGrounded;

    //Coyote time
    [SerializeField] private float CoyoteTime = 0.2f;
    [SerializeField] private float _coyoteCounter;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * MoveSpeed, _rb.velocity.y);
        _isGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, 1f, AllowJumpMask);

        //CoyoteTime
        if (_isGrounded) {
            _coyoteCounter = CoyoteTime;
        } else if (_coyoteCounter > 0) {
            _coyoteCounter -= Time.deltaTime;
        }

        //Normal Jumps
        if (Input.GetKeyDown(KeyCode.Space) && _coyoteCounter > 0f) {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
            _coyoteCounter = -1f;
        }
        //Small Jumps
        if (Input.GetKeyUp(KeyCode.Space) && _rb.velocity.y > 0) {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * .5f);
            _coyoteCounter = -1f;
        }
    }
}
