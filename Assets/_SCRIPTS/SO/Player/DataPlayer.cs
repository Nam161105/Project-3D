using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Health", fileName ="Health")]
public class DataPlayer : ScriptableObject
{
    public float _currentHp;
    public float _maxHp;
}
