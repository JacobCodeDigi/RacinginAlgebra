using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MathsMenu : MonoBehaviour
{
    public GameObject WrongAnswer;
    public GameObject RightAnswer;
    public GameObject Maths;
    public Text Points;
    
    public void Answer()
    {
        WrongAnswer.gameObject.SetActive(true);
        PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points") - 1);
        Points.gameObject.SetActive(true);
        Points.text = "You have " + PlayerPrefs.GetFloat("Points").ToString() + " points!";
        Time.timeScale = 1f;
    }

    public void Answer1()
    {
        RightAnswer.gameObject.SetActive(true);
        PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points") + 1);
        Points.gameObject.SetActive(true);
        Points.text = "You have " + PlayerPrefs.GetFloat("Points").ToString() + " points!";
        Time.timeScale = 1f;
    }

    public void Answer2()
    {
        WrongAnswer.gameObject.SetActive(true);
        PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points") - 1);
        Points.gameObject.SetActive(true);
        Points.text = "You have " + PlayerPrefs.GetFloat("Points").ToString() + " points!";
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player triggered");
        Maths.gameObject.SetActive( true );
        Time.timeScale = 0f;
    }
}

