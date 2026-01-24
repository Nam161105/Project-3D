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

    //[SerializeField] protected GameObject _sceneLoading;
    //[SerializeField] protected Slider _slider;
    //[SerializeField] protected int _id;
    //[SerializeField] protected Text _textLoading;



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

        _nameNull.gameObject.SetActive(false);
        _maxName.gameObject.SetActive(false);
        PlayerPrefs.SetString("PlayerName", playerName);
        Debug.Log("ten hop le");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //_sceneLoading.SetActive(true);
        //_slider.value = 0;
        //StartCoroutine(LoadScenAfterTime(_id));

    }

    protected IEnumerator NameNullBoardAfterTime()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.falseQuestion);
        _nameNull.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _nameNull.gameObject.SetActive(false);
    }

    protected IEnumerator MaxNameBoardAfterTime()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.falseQuestion);
        _maxName.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        _maxName.gameObject.SetActive(false);
    }
    //protected IEnumerator LoadScenAfterTime(int id)
    //{
    //    AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(id);

    //    while (!asyncOperation.isDone)
    //    {
    //        float slider = Mathf.Clamp01(asyncOperation.progress);
    //        int textLoad = Mathf.RoundToInt(asyncOperation.progress * 100f);

    //        _slider.value = slider;
    //        _textLoading.text = textLoad + "%";
    //        if (asyncOperation.progress > 0.9f)
    //        {
    //            _slider.value = 1;
    //            _textLoading.text = "100%";
    //            yield return new WaitForSeconds(0.5f);
    //        }

    //        yield return null;
    //    }
    //}

}