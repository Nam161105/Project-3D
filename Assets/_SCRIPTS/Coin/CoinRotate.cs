using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField] protected float _speedRotate;

    private void Update()
    {
        transform.Rotate(0, _speedRotate * Time.deltaTime, 0);   
    }
}
