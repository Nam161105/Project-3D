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
        Time.timeScale = 0f;
        _panelQuiz.SetActive(true);

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
        if (selectedAnswer == _currentQuestion.trueAnswer)
        {
            Debug.Log("chuc mung");
        }
        else
        {
            Debug.Log("sai roi");
        }

        index++; 
        CloseQuiz();
    }

    protected void CloseQuiz()
    {
        _panelQuiz.SetActive(false);
        Time.timeScale = 1;
    }
}
