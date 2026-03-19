using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseText : MonoBehaviour
{
    [SerializeField] private Text _myText;
    [SerializeField] private float _speed = 0.05f;

    public IEnumerator ShowText(string fullText)
    {
        _myText.text = "";

        foreach (char letter in fullText.ToCharArray())
        {
            _myText.text += letter;
            yield return new WaitForSecondsRealtime(_speed);
        }
    }
}
