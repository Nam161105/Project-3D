using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowPlayer : MonoBehaviour
{
    protected static CamerFollowPlayer instance;
    public static CamerFollowPlayer Instance => instance;
    [SerializeField] protected GameObject _player;
    [SerializeField] protected float _offsetX;
    [SerializeField] protected float _offsetY;
    [SerializeField] protected float _offsetZ;

    [SerializeField] protected float _timeParallax;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        this.CamFollow();
    }

    protected void CamFollow()
    {
        transform.position = _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ);
    }

    public void CamParallax()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.parallaxSound);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ + 0.5f), _timeParallax * Time.deltaTime);
        StartCoroutine(ParallaxAfterTime());
    }

    protected IEnumerator ParallaxAfterTime()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ - 1f), _timeParallax * Time.deltaTime);
        StartCoroutine(ParallaxAfterTime2());
    }

    protected IEnumerator ParallaxAfterTime2()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ + 1f), _timeParallax * Time.deltaTime);
        StartCoroutine(ParallaxAfterTime3());
    }

    protected IEnumerator ParallaxAfterTime3()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ - 0.5f), _timeParallax * Time.deltaTime);
        StartCoroutine(ParallaxAfterTime4());
    }

    protected IEnumerator ParallaxAfterTime4()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ + 0.5f), _timeParallax * Time.deltaTime);
        StartCoroutine(ParallaxAfterTime5());
    }

    protected IEnumerator ParallaxAfterTime5()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ - 1f), _timeParallax * Time.deltaTime);
        StartCoroutine(ParallaxAfterTime6());
    }

    protected IEnumerator ParallaxAfterTime6()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ + 1f), _timeParallax * Time.deltaTime);
        StartCoroutine(ParallaxAfterTime7());
    }

    protected IEnumerator ParallaxAfterTime7()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + new Vector3(_offsetX, _offsetY, _offsetZ - 0.5f), _timeParallax * Time.deltaTime);
    }
}
