﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public List<GameObject> critterPrefabs;

    public float critterSpawnFrequency = 1.0f;
    public Score scoreDisplay;

    private float lastCritterSpawn = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // Check if it is time to spawn the next critter.
        float nextSpawnedTime = lastCritterSpawn + critterSpawnFrequency;
		if (Time.time >= nextSpawnedTime)
        {
            //It is time!

            // Choose a random criter to spawn.
            int critterIndex = Random.Range(0, critterPrefabs.Count);
            GameObject prefabToSpawn = critterPrefabs[critterIndex];

            // Spawn the critter!
            GameObject spawnedCritter = Instantiate(prefabToSpawn);

            //Get access to our critter script.
            Critter critterScript = spawnedCritter.GetComponent<Critter>();

            // tell the critter script the score object
            critterScript.scoreDisplay = scoreDisplay;

            // Update the most recent spawn time to now.
            lastCritterSpawn = Time.time;
        }
	}
}
