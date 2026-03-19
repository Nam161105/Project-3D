using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObsTag : MonoBehaviour
{
    [SerializeField] protected UnityEvent _onActiveObs;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onActiveObs.Invoke();
        }
    }
}
