using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IDame idame = HealthBarPlayer.Instance.gameObject.GetComponent<IDame>();   
            if (idame != null)
            {
                idame.TakeDame(500);
            }
        }
    }
}
