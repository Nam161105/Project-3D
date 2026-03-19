using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLookPlayer : MonoBehaviour
{
    [SerializeField] protected Transform _player;

    private void Update()
    {
        transform.LookAt(_player);
    }
}
