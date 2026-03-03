using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BompDamage : MonoBehaviour
{
    [SerializeField] protected float _dame;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.bombSound);
            CamerFollowPlayer.Instance.CamParallax();
            IDame isCanTakeDmg = other.GetComponent<IDame>();
            if (isCanTakeDmg != null)
            {
                isCanTakeDmg.TakeDame(_dame);
            }
        }

    }
}
