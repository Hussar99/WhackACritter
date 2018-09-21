﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;
    public float critterSpawnFrequency = 1.0f;
    public Score scoreDisplay;
    public Timer timer;
    public SpriteRenderer button;

    private float lastCritterSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Check if it is time to spawn the next critter.
        float nextSpawnTime = lastCritterSpawn + critterSpawnFrequency;
		if (Time.time >= nextSpawnTime  && timer.IsTimerRunning() == true)
        {
            //It is time!

            // Choose a random criter to spawn.
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            // Spawn the critter!
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            //Get access to our critter script.
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            // tell the critter script the score object and the timer object
            critterScript.scoreDisplay = scoreDisplay;
            critterScript.timer = timer;

            // Update the most recent spawn time to now.
            lastCritterSpawn = Time.time;
        }

        // Update button visability
        if (timer.IsTimerRunning() == true)
        {
            button.enabled = false;
        }
        else // if game is NOT running
        {
            button.enabled = true;
        }

	}


    // Did they click the button?
    private void OnMouseDown()
    {
        
    

        // Only respawn if the game is not running.
    if (timer.IsTimerRunning() == false)
        {
            // STart new game
            timer.StartTimer();
            scoreDisplay.ResetScore();
        }
    }
}
