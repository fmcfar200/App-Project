using UnityEngine;
using System.Collections;

public class GroundMovementScript : MonoBehaviour {
		
	float speed;
	public GameObject playerGO;
	private float playerSpeed;

	void Start()
	{
		playerGO = GameObject.FindGameObjectWithTag("Player");
		if (playerGO == null) {
			Debug.LogError("Cannot find player object!!!!!!");
			return;
		}

	}
	void Update()
	{

	}
	void FixedUpdate()
	{
		playerSpeed = playerGO.GetComponent<PlayerMovementScript> ().movementSpeed;
		speed = -playerSpeed;
		if (playerGO.GetComponent<PlayerDeathScript> ().playerIsDead == true) {
			speed = 0;
		}
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
	}


}
