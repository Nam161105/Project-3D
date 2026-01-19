using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDame : MonoBehaviour
{
    [SerializeField] protected float _dame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IDame isCanTakeDmg = other.GetComponent<IDame>();
            if (isCanTakeDmg != null)
            {
                isCanTakeDmg.TakeDame(_dame);
            }
        }
    }
}
