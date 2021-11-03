using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScoreScript : MonoBehaviour
{
    public Text HighScore;
    float CurrentTime = 0;
    bool isActive = false;
    // Start is called before the first frame update
    private void Update()
    {
        if (isActive)
        {
            CurrentTime += Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            HighScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
            isActive = !isActive;
        }
    }
}