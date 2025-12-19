using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected float _rotateSpeed;
    protected Rigidbody _rb;
    protected bool _isOnGround;
    protected Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        this.Move();
        this.Jump();
    }

    protected void Move()
    {
        if (_rb.velocity.magnitude > 1)
        {
            _rb.velocity.Normalize();
        }

        if(_rb.velocity == Vector3.zero)
        {
            _animator.SetTrigger("Idle");
        }
        else
        {
            _animator.SetTrigger("Walk");
        }

        float horiInput = Input.GetAxis("Horizontal"); 
        float vertInput = Input.GetAxis("Vertical");

        _rb.velocity = new Vector3(horiInput * _speed, _rb.velocity.y, vertInput * _speed);
        this.RotateDir();
    }

    protected void RotateDir()
    {
        float horiInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horiInput, 0f, vertInput).normalized;

        if (movementDirection.magnitude >= 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
        }
    }
    protected void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _animator.SetTrigger("Jump");
            _rb.AddForce(new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z));
            _isOnGround = false;    
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
    }
}
