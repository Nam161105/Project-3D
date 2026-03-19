using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IDame dame = HealthBarPlayer.Instance.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakeDame(500);
            }
        }
    }
}
