using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] protected float _speed = 4f; 
    [SerializeField] protected float _offsetZ = 5f;
    [SerializeField] protected DataPlayer _player;
    protected Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_player._currentHp <= 0)
        {
            _rb.velocity = Vector3.zero;
            return;
        }
        else
        {
            transform.position = new Vector3(PlayerControll.Instance.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void FixedUpdate()
    {
        if (_player._currentHp <= 0)
        {
            _rb.velocity = Vector3.zero;
            return;
        }
        else
        {
            _rb.velocity = new Vector3(0, 0, _speed);
        }
    }
}
