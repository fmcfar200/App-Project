using UnityEngine;
using System.Collections;

public class PlayerDeathScript : MonoBehaviour {

	public bool playerIsDead = false;


	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "Trap") 
		{
			Debug.Log("player is dead");
			playerIsDead = true;

		}
		
	}
	void FixedUpdate()
	{
		if (playerIsDead == true) {

			PlayerMovementScript playerMove = GetComponent<PlayerMovementScript>();
			playerMove.movementSpeed = 0;
			Color deathCol = this.gameObject.GetComponent<SpriteRenderer>().color;
			deathCol.a = 0.5f;
			this.gameObject.GetComponent<SpriteRenderer>().color = deathCol;
		}
	}
}
