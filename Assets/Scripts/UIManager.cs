using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreTxt;
    private int pointIncreasePerSecond = 10;
    public GameObject joyStick, attackButton, buttonPause;
    public bool gameIsPaused;
    
    private void OnEnable()
    {
#if UNITY_EDITOR
        joyStick.SetActive(false); 
        attackButton.SetActive(false);
#else
        joyStick.SetActive(true); 
        attackButton.SetActive(true);
#endif
    }

    private void Update()
    {
        GameManager.Instance._score += (pointIncreasePerSecond * Time.deltaTime);
        //print(_score.ToString());
        scoreTxt.text = $"Score: {((int) GameManager.Instance._score).ToString()}";
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            buttonPause.SetActive(gameIsPaused);
            PauseGame();
        }
    }
    
    public void PauseGame ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
        }
        else 
        {
            Time.timeScale = 1;
        }
    }
}
