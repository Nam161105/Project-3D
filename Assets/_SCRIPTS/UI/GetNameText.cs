using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetNameText : MonoBehaviour
{
    [SerializeField] protected Text _textName;
    [SerializeField] protected Vector3 _pos;

    private void Start()
    {
        _textName.text = PlayerPrefs.GetString("PlayerName");
    }

    private void Update()
    {
        transform.position = PlayerControll.Instance.transform.position + _pos;
    }
}
