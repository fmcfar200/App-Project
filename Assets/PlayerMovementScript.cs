using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	//All speeds and forces
	public float thrusterForce;
	public float movementSpeed = 2.5f;
	float dodgeSpeed = 10f;
	//Flying variables
	bool isFlying = false;
	public Sprite thrusterSprite;
	public Sprite idleSprite;
	public bool canFly = true;
	//Movement variables


	//Input and Graphic changes
	void Update () 
	{
		GameManager gameManager = this.gameObject.GetComponent<GameManager> ();

		if (canFly == true) {
			if (Input.GetMouseButton (0)) {
				isFlying = true;
			}
		}else if (gameManager.beginFalling == true) {

			Debug.Log("Avoid the rocks");
			if(Input.GetKey(KeyCode.RightArrow))
			{
			
				GetComponent<Rigidbody2D>().AddForce(new Vector2(dodgeSpeed,0));
			}
			else if(Input.GetKey (KeyCode.LeftArrow))
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(-dodgeSpeed,0));
			}
		}

	
	}
	//changes to physics
	void FixedUpdate()
	{
		Vector3 pos = transform.position;
		pos.x += movementSpeed * Time.deltaTime;
		transform.position = pos;
		//jump force is applied
		if (isFlying == true) {
			isFlying = false;
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = thrusterSprite;
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, thrusterForce));
		} else {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = idleSprite;
			}




	}

}
