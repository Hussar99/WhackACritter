using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    //Display visual Timer
    public TextMesh displayText;

    // Starting time for the timer
    public float timerDuration;

    //Seconds remaining on the timer
    private float timeRemaining = 0;


    // Use this for initialization
    void Start () {
        //StartTimer();
	}
	
	// Update is called once per frame
	void Update () {
        if (IsTimerRunning())
        {
            // Timer is running, so process

            // Updated the time remining this frame
            timeRemaining = timeRemaining - Time.deltaTime;

            // Check if we ran out of time.
            if (timeRemaining <=0)
            {
                //Set our time exactly 0
                StopTimer();
            }

            //updating the visual display of timer
            displayText.text = Mathf.CeilToInt(timeRemaining).ToString();


        }



	}

    //Start the timer counting
    public void StartTimer()
    {
        timeRemaining = timerDuration;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    // Stop the timer counting
    public void StopTimer()
    {
        timeRemaining = 0;
        displayText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    //Is the timer currently running?
    public bool IsTimerRunning()
    {
        if (timeRemaining !=0)
        {
            return true;
        
        }

        else
        {
            return false;
        }

    }

}
