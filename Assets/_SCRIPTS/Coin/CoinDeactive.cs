using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDeactive : MonoBehaviour
{
    [SerializeField] protected float _lifeTime;

    private void OnEnable()
    {
        StartCoroutine(CoinDeactiveAfterTime());
    }

    protected IEnumerator CoinDeactiveAfterTime()
    {
        yield return new WaitForSeconds(_lifeTime);
        this.gameObject.SetActive(false);   
    }
}
