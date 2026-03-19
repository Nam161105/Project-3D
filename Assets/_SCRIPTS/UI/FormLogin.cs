using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormLogin : MonoBehaviour
{
    [SerializeField] protected InputField _inputField;
    [SerializeField] protected int _maxLength;
    [SerializeField] protected GameObject _nameNull;
    [SerializeField] protected GameObject _maxName;

    [SerializeField] protected Animator _aniNullName;
    [SerializeField] protected Animator _aniMaxName;


    public void SaveName()
    {
        string playerName = _inputField.text;
        if (string.IsNullOrEmpty(playerName))
        {
            StartCoroutine(NameNullBoardAfterTime());
            return;
        }
        if (playerName.Length > _maxLength)
        {
            StartCoroutine(MaxNameBoardAfterTime());
            return;
        }

        PlayerPrefs.SetString("PlayerName", playerName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    protected IEnumerator NameNullBoardAfterTime()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.falseQuestion);
        _aniNullName.SetTrigger("Start");
        yield return new WaitForSeconds(2);
        _aniNullName.SetTrigger("End");
    }

    protected IEnumerator MaxNameBoardAfterTime()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.falseQuestion);
        _aniMaxName.SetTrigger("start");
        yield return new WaitForSeconds(2);
        _aniMaxName.SetTrigger("end");
    }
    

}