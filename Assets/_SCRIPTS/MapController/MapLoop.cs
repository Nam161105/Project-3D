using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoop : MonoBehaviour
{
    [SerializeField] protected GameObject[] maps;
    [SerializeField] protected float _mapLength;

    private void Update()
    {
        this.LoopMap();
    }

    protected void LoopMap()
    {
        if (PlayerControll.Instance.transform.position.z > maps[0].transform.position.z + (_mapLength / 2))
        {
            maps[2].transform.position = new Vector3(maps[2].transform.position.x, maps[2].transform.position.y, maps[1].transform.position.z + _mapLength);
        }

        if (PlayerControll.Instance.transform.position.z > maps[1].transform.position.z + (_mapLength / 2))
        {
            maps[0].transform.position = new Vector3(maps[0].transform.position.x, maps[0].transform.position.y, maps[2].transform.position.z + _mapLength);
        }

        if (PlayerControll.Instance.transform.position.z > maps[2].transform.position.z + (_mapLength / 2))
        {
            maps[1].transform.position = new Vector3(maps[1].transform.position.x, maps[1].transform.position.y, maps[0].transform.position.z + _mapLength);
        }
    }
}
