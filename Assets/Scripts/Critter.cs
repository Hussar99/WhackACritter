using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter : MonoBehaviour {

    public Vector2 lowerRange;
    public Vector2 upperRange;

    public Score scoreDisplay;

    public int pointValue = 1; // adds a point value

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Random.Range(lowerRange.x, upperRange.x),
            Random.Range(lowerRange.y, upperRange.y),
            0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        scoreDisplay.ChangeValue(pointValue);

        Destroy(gameObject);
    }
}
