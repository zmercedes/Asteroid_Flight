using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGen : MonoBehaviour {

	public GameObject asteroid;
	public float secondsBetweenGen = 1.5f;
	public float decreasingGenTime = 30f;
	public float decreaseGenBy = .25f;
	float xCoord;
	float halfScreenWidth;
	float halfScreenHeight;
	float halfPlayerWidth;
	float halfPlayerHeight;
	float nextGenTime=0f;
	float nextDecreaseTime;

	Vector2 position;

	void Start(){
		nextDecreaseTime = decreasingGenTime;
		halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
		halfScreenHeight = Camera.main.orthographicSize;
		halfPlayerWidth = asteroid.transform.localScale.x /2f;
		halfPlayerHeight = asteroid.transform.localScale.y /2f;
	}
	
	void Update () {
		if(Time.time > nextGenTime){
			xCoord = Random.Range(halfPlayerWidth-halfScreenWidth,halfScreenWidth-halfPlayerWidth);
			position = new Vector3(xCoord,halfScreenHeight+halfPlayerHeight,0);
			Instantiate(asteroid, position, Quaternion.identity, transform);
			nextGenTime += secondsBetweenGen;
		} 
	}

	// have to rework difficulty
	void FixedUpdate(){
		if(Time.timeSinceLevelLoad == nextDecreaseTime && secondsBetweenGen > .25){
			print("Time decreased! " + Time.timeSinceLevelLoad);
			secondsBetweenGen -= decreaseGenBy;
			nextDecreaseTime += decreasingGenTime;
		}
	}
}