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

    [Header("Quiz")]
    [SerializeField] protected float _timer;
    [SerializeField] protected float _targetTime;

    [Header("HealthPlayer")]
    [SerializeField] protected DataPlayer _player;

    [Header("Time Spawn Coin")]
    [SerializeField] protected float _timeCoin;

    [Header("Time Spawn Item")]
    [SerializeField] protected float _timeItem;

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
        StartCoroutine(SpawnItemAfterTime());
    }
    private void Update()
    {
        if (_player._currentHp <= 0) return;
        _timer += Time.deltaTime;
        if(_timer >= _targetTime)
        {
            QuizManager.Instance.ShowNextQuestion();
            _timer = 0;
        }
    }
    protected IEnumerator SpawnCoinAfterTime()
    {
        const float MinDistance = 2.0f; 
        const int MaxTries = 5;     

        while (true)
        {
            yield return new WaitForSeconds(_timeCoin);

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

    protected IEnumerator SpawnItemAfterTime()
    {
        const float MinDistance = 2.0f;
        const int MaxTries = 5;

        while (true)
        {
            yield return new WaitForSeconds(_timeItem);

            Vector3 originalPosition = PlayerControll.Instance.transform.position + new Vector3(Random.Range(-4f, 4f), Random.Range(0.5f, 0.7f), Random.Range(17f, 20f));
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
                    spawnPosition = originalPosition + new Vector3(Random.Range(-2f, 2f), Random.Range(-0.2f, 0.2f), Random.Range(1f, 3f));
                    tries++;
                }
            }

            if (isPosFound)
            {
                GameObject g = PoolItemHealth.Instance.GetItemPool();
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

    public void AddScore(int coin)
    {
        _coinCount += coin;
        _coinText.text = _coinCount.ToString();
        PlayerPrefs.SetInt("Coin", _coinCount);
    }

}
