using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] protected GameObject _panelPause;
    [SerializeField] protected DataPlayer _player;
    public void ButtonPause()
    {
        Time.timeScale = 0;
        _panelPause.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _panelPause.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _player.ResetHealth();  
        PlayerPrefs.SetString("Coin", 0.ToString());
        Time.timeScale = 1;
    }

    public void OutButton()
    {
        _player.ResetHealth();
        PlayerPrefs.DeleteKey("PlayerName");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        Time.timeScale = 1;
    }

    public void CancelButton()
    {
        Time.timeScale = 1;
        _panelPause.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void SoundButton()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClick);
    }

    public void MouseButton()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.mouseClick);
    }
}
