using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] protected Animator _aniButton;
    [SerializeField] protected Animator _aniTut;

    private void Start()
    {
        StartCoroutine(ButtonMainMenu());
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Tutorial()
    {
        _aniButton.SetTrigger("End");
        _aniTut.SetTrigger("start");

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        _aniTut.SetTrigger("end");
        _aniButton.SetTrigger("Start");
    }
    protected IEnumerator ButtonMainMenu()
    {
        yield return new WaitForSeconds(1);
        _aniButton.SetTrigger("Start");
    }
}
