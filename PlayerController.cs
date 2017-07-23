using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 6f;
	float halfScreenWidth;
	float halfPlayerWidth;
	public event System.Action OnPlayerDeath;

	void Start () {	
		halfPlayerWidth = transform.localScale.x / 2f;
		halfScreenWidth = Camera.main.aspect * Camera.main.orthographicSize;
	}
	
	void Update () {
		float input = Input.GetAxisRaw("Horizontal");
		float velocity = input*moveSpeed;
		transform.Translate(Vector2.right * velocity * Time.deltaTime);

		if(transform.position.x < -halfScreenWidth-halfPlayerWidth)
			transform.position = new Vector2(halfScreenWidth+halfPlayerWidth,transform.position.y);
		if(transform.position.x > halfScreenWidth+halfPlayerWidth)
			transform.position = new Vector2(-halfScreenWidth-halfPlayerWidth,transform.position.y);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "asteroid"){
		//	Debug.Log("Crash! " + Time.time);
			if(OnPlayerDeath != null)
				OnPlayerDeath();
			Destroy(this.gameObject);
		}
	}
}