using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    protected static TimeManager instance;
    public static TimeManager Instance => instance;
    [SerializeField] protected Text _timer;
    protected float _time = 0;
    protected bool _isEnd = false;

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

    private void Update()
    {
        this.TimeRun();
    }

    protected void TimeRun()
    {
        if (!_isEnd)
        {
            _time += Time.deltaTime;
            _timer.text = FormatTime(_time);
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return string.Format("{0:D02}:{1:D02}", minutes, seconds);
    }

    public void ReturnGame()
    {
        _isEnd = true;
        PlayerPrefs.SetFloat("SavedTime", _time);
    }
}
