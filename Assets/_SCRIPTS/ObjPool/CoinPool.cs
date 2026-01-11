using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    protected static CoinPool instance; 
    public static CoinPool Instance => instance;
    [SerializeField] protected GameObject _coinPrefab;
    [SerializeField] protected List<GameObject> _coins = new List<GameObject>();
    [SerializeField] protected int _initPool;

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
        for (int i = 0; i < _initPool; i++)
        {
            GameObject g = Instantiate(_coinPrefab, transform.position, Quaternion.identity, transform);
            g.SetActive(false);
            _coins.Add(g);
        }
    }
    public GameObject GetCoinPool()
    {
        foreach(GameObject go in _coins)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }
        GameObject g = Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        _coins.Add(g);
        g.SetActive(true);
        return g;
    }
}
