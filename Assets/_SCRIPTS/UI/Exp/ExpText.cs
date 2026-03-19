using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpText : MonoBehaviour
{
    protected static ExpText instance;
    public static ExpText Instance => instance;
    [SerializeField] public float _currentExp;
    [SerializeField] protected float _maxExp;
    [SerializeField] protected Text _levelText;
    [SerializeField] protected Image _imageLv;
    [SerializeField] protected DataPlayer _player;
    protected int level = 1;


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
        StartCoroutine(AddExpPerSecond());
    }



    public void LevelUp(int expAdd)
    {
        if (level == 15) return;
        _currentExp += expAdd;
        if(level == 3)
        {
            _player._maxHp = 550f;
        }
        if (level == 6)
        {
            _player._maxHp = 600f;
        }
        if (level == 9)
        {
            _player._maxHp = 650f;
        }
        if (level == 12)
        {
            _player._maxHp = 700f;
        }
        UpdateUI();
        if (_currentExp >= _maxExp)
        {
            _currentExp = 0;
            _maxExp += 3f;
            level++;
            _levelText.text = "LV: " + level.ToString();
            UpdateUI();
        }


    }

    protected IEnumerator AddExpPerSecond()
    {
        while (level <= 15)
        {
            yield return new WaitForSeconds(1);
            int expAdd = 1;
            LevelUp(expAdd);
        }
    }

    protected void UpdateUI()
    {
        _imageLv.fillAmount = _currentExp / _maxExp;
    }
}
