using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewQuestion 1", menuName ="QuestionSO/Question")]
public class DataQuestion : ScriptableObject
{
    public string question;
    public string[] answers;
    public string trueAnswer;
}
