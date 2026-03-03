using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardEndGame : MonoBehaviour
{
    protected static BoardEndGame instance;
    public static BoardEndGame Instance => instance;
    [SerializeField] protected GameObject _boardTimeOfPlayer;
    [SerializeField] protected GameObject _setting;
    [SerializeField] protected Text _timeText;
    [SerializeField] protected Text _playerText;
    [SerializeField] protected Text _coinText;

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
    public void ActiveInfoPlayer()
    {
        Time.timeScale = 0;
        TimeManager.Instance.ReturnGame();
        float savedTime = PlayerPrefs.GetFloat("SavedTime", 0);

        int min = Mathf.FloorToInt(savedTime / 60);
        int sec = Mathf.FloorToInt(savedTime % 60);

        _timeText.text = string.Format("{0:00} : {1:00}", min, sec);

        _playerText.text = PlayerPrefs.GetString("PlayerName");
        _coinText.text = PlayerPrefs.GetInt("Coin").ToString();
        _setting.SetActive(false);
        _boardTimeOfPlayer.SetActive(true);
    }
}
