using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] protected GameObject _panelPause;
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
        Time.timeScale = 1;
    }

    public void OutButton()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1;
    }

    public void CancelButton()
    {
        Time.timeScale = 1;
        _panelPause.SetActive(false);
    }
}
