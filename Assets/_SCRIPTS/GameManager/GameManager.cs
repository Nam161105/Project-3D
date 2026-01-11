using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    protected static GameManager instance;
    public static GameManager Instance => instance;
    [SerializeField] protected Text _coinText;
    protected int _coinCount = 0;
    protected bool isPosFound = false;
    private int tries = 0;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnCoinAfterTime());
    }

    protected IEnumerator SpawnCoinAfterTime()
    {
        const float MinDistance = 2.0f; 
        const int MaxTries = 5;     

        while (true)
        {
            yield return new WaitForSeconds(3);

            Vector3 originalPosition = PlayerControll.Instance.transform.position + new Vector3(Random.Range(-4f, 4f), Random.Range(1f, 2.5f), Random.Range(10f, 20f));
            Vector3 spawnPosition = originalPosition;

            while (!isPosFound && tries < MaxTries)
            {
                isPosFound = true;
                Collider[] hitColliders = Physics.OverlapSphere(spawnPosition, MinDistance);
                foreach (var hit in hitColliders)
                {
                    if (hit.gameObject.CompareTag("Coin") && hit.gameObject.CompareTag("Obs"))
                    {
                        isPosFound = false; 
                        break;
                    }
                }

                if (!isPosFound)
                {
                    spawnPosition = originalPosition + new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 2.5f), Random.Range(2f, 5f));
                    tries++;
                }
            }

            if (isPosFound)
            {
                GameObject g = CoinPool.Instance.GetCoinPool();
                g.transform.position = spawnPosition;
                g.transform.rotation = Quaternion.identity;
                g.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("Tam thoi khong tim thay vi tri spawn");
            }
        }
    }

    public void AddScore()
    {
        _coinCount++;
        _coinText.text = _coinCount.ToString();
    }
}
