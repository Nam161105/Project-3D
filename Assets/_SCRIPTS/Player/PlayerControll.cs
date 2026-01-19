using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    protected static PlayerControll instance;
    public static PlayerControll Instance => instance;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _jumpForce;
    [SerializeField] protected float _rotateSpeed;
    protected Rigidbody _rb;
    protected bool _isOnGround;
    protected Animator _animator;

    [Header("---- BlendTree ----")]
    [SerializeField] protected float _velocity = 0.0f;
    [SerializeField] protected float _accelaction;
    [SerializeField] protected float _decelaction;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
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

    private void FixedUpdate()
    {
        float horiInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");

        float maxInput = Mathf.Max(0f, vertInput);

        Vector3 inputVector = new Vector3(horiInput, 0f, maxInput);

        if (inputVector.magnitude > 0.1f)
        {
            inputVector.Normalize();
        }
        Vector3 moveSpeed = inputVector * _speed;

        _rb.velocity = new Vector3(moveSpeed.x, _rb.velocity.y, moveSpeed.z);
    }
    protected void Move()
    {
        bool getKey = Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("w");
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

        float maxRotate = Mathf.Max(0f, vertInput);

        Vector3 movementDir = new Vector3(horiInput, 0f, maxRotate);

        if (movementDir.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDir.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotateSpeed * Time.deltaTime);
        }
    }
    protected void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _animator.SetBool("Jump", true);
            _rb.AddForce(new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z));
            _isOnGround = false;
        }
    }
    protected void GetInput()
    {

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
