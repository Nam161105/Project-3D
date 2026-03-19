using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMapTut : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected float _rotateSpeed;
    protected Rigidbody _rb;
    protected bool _isOnGround;
    protected Animator _animator;

    [SerializeField] protected GameObject _bot;

    [Header("---- BlendTree ----")]
    [SerializeField] protected float _velocity = 0.0f;
    [SerializeField] protected float _accelaction;
    [SerializeField] protected float _decelaction;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isLocked = GameManagerMapTut._isPaused || Vector3.Distance(transform.position, _bot.transform.position) <= 3;

        if (isLocked)
        {
            StopMovement(); 
            return;
        }

        this.Move();
        this.Jump();
    }

    private void FixedUpdate()
    {
        bool isLocked = GameManagerMapTut._isPaused || Vector3.Distance(transform.position, _bot.transform.position) <= 3;

        if (isLocked)
        {
            _rb.velocity = Vector3.zero;
            return;
        }

        float horiInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(horiInput, 0f, vertInput).normalized;
        Vector3 moveSpeed = inputVector * _speed;

        _rb.velocity = new Vector3(moveSpeed.x, _rb.velocity.y, moveSpeed.z);
    }
    protected void StopMovement()
    {
        _velocity = 0f;                   
        _animator.SetFloat("Velocity", 0f); 
    }
    protected void Move()
    {
        bool getKey = Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w") || Input.GetKey("s");
        if (getKey && _velocity < 1.0f)
        {
            _velocity += Time.deltaTime * _accelaction;
        }
        if (!getKey && _velocity > 0.0f)
        {
            _velocity -= Time.deltaTime * _decelaction;
        }
        if (!getKey && _velocity < 0.0f)
        {
            _velocity = 0.0f;
        }
        _animator.SetFloat("Velocity", _velocity);
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
        if (GameManagerMapTut._isPaused) return;
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.jumpClip);
            _animator.SetBool("Jump", true);
            _rb.AddForce(new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z));
            _isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _animator.SetBool("Jump", false);
            _isOnGround = true;
        }
    }
}
