using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotTrigger : MonoBehaviour
{
    [SerializeField] protected GameObject _player;
    [SerializeField] protected float _dis;
    [SerializeField] protected Animator _ani;
    [SerializeField] protected Animator _aniEnd;
    [SerializeField] protected Animator _aniLoad;

    [SerializeField] protected TextRun _textRunScript;
    [SerializeField] protected TextRun2 __textRunScript2;
    protected bool _isTriggered = false;

    [Header("Scene Loading")]
    [SerializeField] protected GameObject _sceneLoading;
    [SerializeField] protected Slider _slider;
    [SerializeField] protected int _id;
    private void Update()
    {
        if (!_isTriggered && Vector3.Distance(transform.position, _player.transform.position) <= _dis)
        {
            _isTriggered = true;
            _ani.SetTrigger("First");
            StartCoroutine(EndTutAfterTime());
        }
    }

    protected IEnumerator EndTutAfterTime()
    {
        yield return new WaitForSecondsRealtime(1f);
        string noiDung = "Chào mừng em đến với Thế giới Game HPC !\r\nThầy là giáo viên ngành CNTT.\r\nEm đã bước vào 1 tựa game dành cho các bạn đam mê tạo ra các tựa game yêu thích mà không biết bắt đầu từ đâu...";
        yield return StartCoroutine(_textRunScript.ShowText(noiDung));

        yield return new WaitForSecondsRealtime(2f);
        _aniEnd.SetTrigger("EndTut");
        yield return new WaitForSecondsRealtime(1f);
        string noiDung2 = "Đến với tựa game này, em sẽ di chuyển qua các chướng ngại vật, thu thập thật nhiều vàng, và đến mốc thời gian cụ thể:\r\nHệ thống sẽ hiện các câu hỏi phù hợp với những người mới vào ngành, xác định hướng đi phù hợp\r\nChúc em may mắn !";
        yield return StartCoroutine(__textRunScript2.ShowText(noiDung2));

        yield return new WaitForSecondsRealtime(2f);

        StartCoroutine(StartGameAfterTime());
    }

    protected IEnumerator StartGameAfterTime()
    {  _aniLoad.SetTrigger("Load");
        yield return new WaitForSeconds(2f);
        _sceneLoading.SetActive(true);
        _slider.value = 0;
        StartCoroutine(LoadScenAfterTime(_id));
    }


    protected IEnumerator LoadScenAfterTime(int id)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(id);
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            _slider.value = progress;
            if (asyncOperation.progress > 0.9f)
            {
                _slider.value = 1;
                yield return new WaitForSeconds(0.5f);
            }

            yield return null;
        }
    }
      
}