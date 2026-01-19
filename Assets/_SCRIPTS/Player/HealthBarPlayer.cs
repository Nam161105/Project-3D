using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarPlayer : MonoBehaviour, IDame
{
    protected static HealthBarPlayer instance;
    public static HealthBarPlayer Instance => instance;
    [SerializeField] protected Image _healthBar;
    [SerializeField] protected DataPlayer _healthData;


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

    public void AddHealth(float health)
    {
        _healthData._currentHp += health;
        if (_healthData._currentHp >= _healthData._maxHp)
        {
            _healthData._currentHp = _healthData._maxHp;
        }
    }
    protected void Die()
    {
        Debug.Log("Player da chet");
    }

}
