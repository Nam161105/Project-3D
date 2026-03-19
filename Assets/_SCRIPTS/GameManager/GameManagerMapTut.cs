using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMapTut : MonoBehaviour
{
    [SerializeField] protected float _timeActiveTut;
    [SerializeField] protected Animator _ani;
    public static bool _isPaused = false;

    private void Start()
    {
        StartCoroutine(ActiveTutBoard());
    }

    protected IEnumerator ActiveTutBoard()
    {
        _isPaused = true;
        _ani.SetTrigger("TutFirst");
        yield return new WaitForSeconds(_timeActiveTut);
        _isPaused = false;
    }
}
