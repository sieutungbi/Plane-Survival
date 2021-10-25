using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{ 
    public TextMeshProUGUI highScoreTxt;
    private void OnEnable()
    {
        highScoreTxt.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
