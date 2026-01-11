using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    [SerializeField] protected float _dame;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDame dame = collision.GetComponent<IDame>();
            if (dame != null)
            {
                dame.TakeDame(_dame);
                GameManager.Instance.AddScore();
                this.gameObject.SetActive(false);
            }
        }
    }
}
