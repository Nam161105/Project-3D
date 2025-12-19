using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowPlayer : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected float _offsetX;
    [SerializeField] protected float _offsetY;
    [SerializeField] protected float _offsetZ;
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        this.CamFollow();    
    }

    protected void CamFollow()
    {
        transform.position = _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ);
    }
}
