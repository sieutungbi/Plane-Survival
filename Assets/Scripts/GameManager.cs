using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Action onPlayerDie;

    public AudioClip gameMusic;
    public AudioClip buttonSFX;
    public float _score = 0;
    public bool fireEnable = true;
    private void Start()
    {
        AudioManager.Instance.PlayMusic(gameMusic);
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void ButtonSFX()
    {
        AudioManager.Instance.PlaySFX(buttonSFX); 
    }

    public void DelayRestart()
    {
        _score = 0;
        SceneManager.LoadScene(0);
    }

    public void RestartGame(float delay)
    {
        int currentHS = PlayerPrefs.GetInt("HighScore", 0);
        if (currentHS == 0)
        {
            PlayerPrefs.SetInt("HighScore", (int)_score);
            PlayerPrefs.Save();
        }
        else if (currentHS != 0)
        {
            if (currentHS >= _score)
            {
                PlayerPrefs.SetInt("HighScore", (int)_score);
                PlayerPrefs.Save();
            }
        }
        
        fireEnable = false;
        Invoke(nameof(DelayRestart), delay);
    }
}
