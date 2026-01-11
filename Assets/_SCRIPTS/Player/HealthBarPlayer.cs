using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarPlayer : MonoBehaviour, IDame
{

    [SerializeField] protected Image _healthBar;
    [SerializeField] protected DataPlayer _healthData;

    private void Start()
    {
        _healthData._currentHp = _healthData._maxHp;
    }
    private void Update()
    {
        this.UpdateHealthBar();
    }
    protected void UpdateHealthBar()
    {
        _healthBar.fillAmount = _healthData._currentHp / _healthData._maxHp;
    }
    public void TakeDame(float dame)
    {
        _healthData._currentHp -= dame;
        if(_healthData._currentHp <= 0)
        {
            this.Die();
        }
        this.UpdateHealthBar();
    }

    protected void Die()
    {
        Debug.Log("Player da chet");
    }

}
