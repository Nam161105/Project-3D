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

    [Header("HealthPlayer")]
    [SerializeField] protected DataPlayer _player;


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
        if (_player._currentHp <= 0)
        {
            return;
        }
        this.Move();
        this.Jump();
    }

    private void FixedUpdate()
    {
        if (_player._currentHp <= 0)
        {
            _rb.velocity = new Vector3(0, 0, 0);
            return;
        }
        float horiInput = Input.GetAxis("Horizontal");
        float vertInput = 1;

        Vector3 inputVector = new Vector3(horiInput, 0f, vertInput);

        if (inputVector.magnitude > 0.1f)
        {

            inputVector.Normalize();
        }
        Vector3 moveSpeed = inputVector * _speed;

        _rb.velocity = new Vector3(moveSpeed.x, _rb.velocity.y, moveSpeed.z);
    }
    protected void Move()
    {
        if (_velocity < 1.0f)
        {
            _velocity += Time.deltaTime * _accelaction;
        }
        else
        {
            _velocity = 1.0f; 
        }

        _animator.SetFloat("Velocity", _velocity);

        this.RotateDir();
    }

    protected void RotateDir()
    {
        float horiInput = Input.GetAxis("Horizontal");
        float vertInput = 1f;

        Vector3 movementDir = new Vector3(horiInput, 0f, vertInput);

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
            AudioManager.Instance.PlaySFX(AudioManager.Instance.jumpClip);
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
        if (collision.gameObject.CompareTag("Obs"))
        {
            CamerFollowPlayer.Instance.CamParallax();
            IDame dame = HealthBarPlayer.Instance.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakeDame(250);
            }
        }
    }

}
