using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    protected static QuizManager instance;
    public static QuizManager Instance => instance;
    [SerializeField] protected DataQuestion[] _allQuestion;
    [SerializeField] protected GameObject _panelQuiz;
    [SerializeField] protected Text _textQuestion;
    [SerializeField] protected Button[] _buttonAnswer;

    protected DataQuestion _currentQuestion;
    protected int index = 0;

    [Header("CountDownQuestion")]
    [SerializeField] protected Text countdownText;

    [Header("AnimationQuiz")]
    [SerializeField] protected Animator _ani;
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
    public void ShowNextQuestion()
    {
        if(index >= _allQuestion.Length)
        {
            Debug.Log("day du cau hoi");
            return;
        }
        StartCoroutine(QuizStart());

        _currentQuestion = _allQuestion[index];
        _textQuestion.text = _currentQuestion.question;

        List<string> randomAnswers = _currentQuestion.answers.ToList<string>();

        for (int i = 0; i < randomAnswers.Count; i++)
        {
            string temp = randomAnswers[i];
            int randomIndex = Random.Range(i, randomAnswers.Count);
            randomAnswers[i] = randomAnswers[randomIndex];
            randomAnswers[randomIndex] = temp;
        }

        for (int i = 0; i < _buttonAnswer.Length; i++)
        {
            string answerText = randomAnswers[i];
            _buttonAnswer[i].GetComponentInChildren<Text>().text = answerText;

            _buttonAnswer[i].onClick.RemoveAllListeners();

            _buttonAnswer[i].onClick.AddListener(() => OnClickAnswer(answerText));
        }
    }

    void OnClickAnswer(string selectedAnswer)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.buttonClick);
        if (selectedAnswer == _currentQuestion.trueAnswer)
        {
            StartCoroutine(TrueQuesAfterTime());
        }
        else
        {
            StartCoroutine(FalseQuesAfterTime());
        }

        StartCoroutine(CountdownRoutine());
        index++; 
    }

    IEnumerator TrueQuesAfterTime()
    {
        yield return new WaitForSecondsRealtime(1);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.trueQuestion);
        HealthBarPlayer.Instance.AddHealth(50);
    }

    IEnumerator FalseQuesAfterTime()
    {
        yield return new WaitForSecondsRealtime(1);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.falseQuestion);
        IDame dame = HealthBarPlayer.Instance.gameObject.GetComponent<IDame>();
        if (dame != null)
        {
            dame.TakeDame(100);
        }
    }

    IEnumerator CountdownRoutine()
    {
        _ani.SetTrigger("End");
        countdownText.gameObject.SetActive(true);

        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(1f);
            count--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(0.5f);
        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    protected IEnumerator QuizStart()
    {
        _ani.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }
}
