using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeActive : MonoBehaviour
{
    [SerializeField] protected GameObject _explosion;
    private void OnEnable()
    {
        StartCoroutine(ActiveObs());
    }

    protected IEnumerator ActiveObs()
    {
        yield return new WaitForSeconds(1);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.explosion);
        Instantiate(_explosion, transform.position, Quaternion.identity);
        StartCoroutine(DeactiveObs());
    }

    protected IEnumerator DeactiveObs()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
    public void ActiveObj()
    {
        this.gameObject.transform.position = transform.position + new Vector3(Random.Range(-3f, 4f), 0f, 0f);
        this.gameObject.SetActive(true);
    }
}
