using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGen : MonoBehaviour {

	public GameObject asteroid;
	public float secondsBetweenGen = 1f;
	float xCoord;
	float halfScreenWidth;
	float halfScreenHeight;
	float halfPlayerWidth;
	float halfPlayerHeight;
	float nextGenTime=0f;

	Vector2 position;

	void Start(){
		halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
		halfScreenHeight = Camera.main.orthographicSize;
		halfPlayerWidth = asteroid.transform.localScale.x /2f;
		halfPlayerHeight = asteroid.transform.localScale.y /2f;
	}
	
	void Update () {
		if(Time.time > nextGenTime){
			xCoord = Random.Range(halfPlayerWidth-halfScreenWidth,halfScreenWidth-halfPlayerWidth);
			position = new Vector2(xCoord,halfScreenHeight+halfPlayerHeight);
			Instantiate(asteroid, position, Quaternion.identity, transform);
			nextGenTime += secondsBetweenGen;
			if(Time.time > 20)
				secondsBetweenGen = .5f;
		}
	}
}