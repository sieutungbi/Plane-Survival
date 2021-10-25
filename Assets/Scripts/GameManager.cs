using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public GameObject scoreTxtPrefab;
    public GameObject canvas;
    public Text scoreTxt;

    private int pointIncreasePerSecond = 10;

    private float _score = 0;

    public Action onPlayerDie;

    //public AudioClip gameMusic;

    private void Start()
    {
        //AudioManager.Instance.PlayMusic(gameMusic);
       
    }

    private void OnEnable()
    {
        StartCoroutine(StartCountingPoint());
        canvas = GameObject.FindGameObjectWithTag("MainCanvas");
        scoreTxt = Instantiate(scoreTxtPrefab, canvas.transform.position, Quaternion.identity).GetComponent<Text>();
    }

    private void OnDisable()
    {
        
    }

    public IEnumerator StartCountingPoint()
    {
       
        while (true)
        {
            _score += (pointIncreasePerSecond * Time.deltaTime);
            print(_score.ToString());
            scoreTxt.text = $"Score: {(int)_score}";
            yield return new WaitForSeconds(1f);
        }
    }
    
    public void RestartGame(float delay)
    {
        StartCoroutine(ReloadGame(delay));

    }

    IEnumerator ReloadGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    
}
