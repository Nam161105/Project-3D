using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAddHealth : MonoBehaviour
{
    [SerializeField] protected float _healthAdd;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthBarPlayer.Instance.AddHealth(_healthAdd);
            this.gameObject.SetActive(false);
        }
    }
}
