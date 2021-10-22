using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Text scoreTxt;

    private int pointIncreasePerSecond = 10;

    private float _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _score += (pointIncreasePerSecond * Time.deltaTime);
        print(_score.ToString());
        scoreTxt.text = $"Score: {(int)_score}";
    }
}
