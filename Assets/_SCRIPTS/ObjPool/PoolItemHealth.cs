using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolItemHealth : MonoBehaviour
{
    protected static PoolItemHealth instance;
    public static PoolItemHealth Instance => instance;
    [SerializeField] protected GameObject _itemHealthPrefab;
    [SerializeField] protected List<GameObject> _items = new List<GameObject>();
    [SerializeField] protected int _initPool;

    private void Awake()
    {
        if (instance == null)
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
            GameObject g = Instantiate(_itemHealthPrefab, transform.position, Quaternion.identity, transform);
            g.SetActive(false);
            _items.Add(g);
        }
    }
    public GameObject GetItemPool()
    {
        foreach (GameObject go in _items)
        {
            if (!go.activeSelf)
            {
                go.SetActive(true);
                return go;
            }
        }
        GameObject g = Instantiate(_itemHealthPrefab, transform.position, Quaternion.identity);
        _items.Add(g);
        g.SetActive(true);
        return g;
    }
}
