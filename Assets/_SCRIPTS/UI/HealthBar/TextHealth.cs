using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHealth : MonoBehaviour
{
    [SerializeField] protected DataPlayer _player;
    [SerializeField] protected Text _textHealth;

    private void Update()
    {
        this.UpdateTextHealth();
    }

    protected void UpdateTextHealth()
    {
        if(_player._currentHp <= 0)
        {
            _player._currentHp = 0;
        }
        _textHealth.text = _player._currentHp.ToString() + "/" + _player._maxHp.ToString();
    }
}
