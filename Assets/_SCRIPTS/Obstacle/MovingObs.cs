using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObs : MonoBehaviour
{
    [SerializeField] protected Transform[] _obs;
    [SerializeField] protected int _index = 0;
    [SerializeField] protected float _speed;

    private void Update()
    {
        this.ObsMove();
    }

    protected void ObsMove()
    {
        if(Vector3.Distance(transform.position, _obs[_index].transform.position) < 1f)
        {
            _index++;
            if(_index >= _obs.Length)
            {
                _index = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, _obs[_index].transform.position, _speed * Time.deltaTime);
    }
}
