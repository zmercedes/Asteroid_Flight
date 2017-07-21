using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {
	
	uint speed;
	float halfScreenHeight;
	float halfAsteroidSize;

	void Start(){
		speed = (uint)Random.Range(2,10);
		halfScreenHeight = Camera.main.orthographicSize;
		halfAsteroidSize = transform.localScale.y / 2f;
	}

	void Update () {
		transform.Translate(Vector2.down * speed * Time.deltaTime);
		if(transform.position.y < -halfScreenHeight-halfAsteroidSize)
			Destroy(this.gameObject);
	}
}