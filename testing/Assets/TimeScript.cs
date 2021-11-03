using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeScript : MonoBehaviour
{
    //Declaring variables for game
    public GameObject playerTarget;
    public float timer;
    public float seconds;
    public float minutes;
    public float hours;
    public bool start;
    public Text Stopwatch;
    public Text Highscore;
    public Text Points;
    public Quaternion originalrotation;
    float rotationResetSpeed = 1.0f;
    float three_points = 40.0f;
    float two_points = 60.0f;
    float one_point = 120.0f;

    void Start() { //Happens on start of the game
        start = false;
        timer = 0;
        playerTarget.transform.rotation = Quaternion.identity;
        PlayerPrefs.SetFloat("Highscore", 10000); //Setting the highscore to an insane high number so that their highscore will always come below it initally
        PlayerPrefs.SetFloat("Points", 0);
        Points.gameObject.SetActive( false );
    }


    void Update() { 
        StopwatchCounter(); //On every frame, run this function
        if(Input.GetKeyDown(KeyCode.R)) //Combined restart.cs into this script, fixed a bug so that it just teleports the player back to the start and resets like outofbounds,
                                        //instead of restarting the whole scene (which would mean that the highscore would be lost)
                                        //This had to be moved here as it is easier and more functional because it references and needs certain variables set
        {
            playerTarget.transform.position = new Vector3(1562.02f, 1.202606f, 1627.04f);
            playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerTarget.transform.rotation = originalrotation;
            Stopwatch.text = "00:00";
            start = false;
            timer = 0f;  
        }
    }

    public void StopwatchCounter() {
        if(start) { //On start, go
            timer += Time.deltaTime; //Starts counting 
            seconds = (int)(timer % 60);
            minutes = (int)((timer / 60) % 60); // Translating the timer into time units people understand
            
            Stopwatch.text = minutes.ToString("00") + ":" + seconds.ToString("00"); //Outputting minutes and seconds
        }
    }

    void OnTriggerEnter(Collider other) { //Changed script so it's being applied on player, this means we can just set a seperate function 
                                          //For each thing that the player encounters, instead of having different scripts for each object all going back to the player  
        if(other.tag == "start")
        {
            start = !start; //This begins StopwatchCounter()
            timer = 0f; //Resetting timer
            Points.gameObject.SetActive( false ); //Hiding point displayer
        }
        if(other.tag == "outofbounds") //Is triggered when player goes off track
        {
            start = false; //Stops the counting and resetting it
            playerTarget.transform.position = new Vector3(1562.02f, 1.202606f, 1627.04f);
            playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            playerTarget.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            playerTarget.transform.rotation = originalrotation; //These 4 lines are freezing and moving the player object back to the startline
            Stopwatch.text = "00:00"; //Reset stopwatch text
        }
        if(other.tag == "finishline")
        {
            if(timer < three_points & timer < two_points & timer < one_point) { //These 3 if statements compare the score of the timer and see if it is under the value of the one for three points, if it is, it's awarded the points
                Debug.Log("Three points");
                PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points")+3);
            }
            if (timer < two_points & timer < one_point & timer > three_points) { //Fixed bug where if player highscore fell under any of the three conditions, 
                                                                                //only condition with the one point would be used
                                                                                //because it lacked the parameters to check if it is still bigger then the requirements for the other scores
                                                                                //Actual fix involves multiple checks using & (operator for and which allows you to check multiple conditions) 
                                                                                //to make sure the timer count is between them, not just below one requirement
                Debug.Log("2 Points");
                PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points")+2); //Changed it so it now adds it onto existing number, before it was PlayerPrefs.SetFloat("Points", 2) which set the score to 2, not adding it on top
            }
            if (timer < one_point & timer > two_points & timer > three_points) {
                Debug.Log("One point");
                PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points")+1);
            }
            if(timer < PlayerPrefs.GetFloat("Highscore")) { //This if condition is here so the highscore doesn't update everytime, 
                                                            //only if it is a better score (Hence the <, meaning quicker time) then the previous high score
                PlayerPrefs.SetFloat("Highscore", timer);
            }
            Highscore.text = "Highscore: " + Mathf.Round(PlayerPrefs.GetFloat("Highscore")).ToString() + " seconds"; //Outputting highscore time
            Points.gameObject.SetActive( true );
            Points.text = "You have " + PlayerPrefs.GetFloat("Points").ToString() + " points!"; //Outputting how many points the player has now
            timer = 0f; //Reset timer
            start = false; //Stop timer
        }
    }
}