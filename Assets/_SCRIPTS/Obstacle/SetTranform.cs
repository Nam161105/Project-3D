using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTranform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCheck"))
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerCheck"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
