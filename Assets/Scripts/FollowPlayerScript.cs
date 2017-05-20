using UnityEngine;
using System.Collections;

public class FollowPlayerScript : MonoBehaviour {

	Transform player;
	float offSetx;
	GameManager gameManager;
	public GameObject playerObj;

	void Start()
	{
		gameManager = playerObj.GetComponent<GameManager> ();
		GameObject player_GO = GameObject.FindGameObjectWithTag ("Player");
		if (player_GO == null) {
			Debug.LogError("Player not Found!!!!!");
			return;
		}
		player = player_GO.transform;

		offSetx = transform.position.x - player.position.x;
	}
	void Update	()
	{

		if (gameManager.followPlayer == true) {
			if (player != null) {
				Vector3 pos = transform.position;
				pos.x = player.position.x + offSetx;
				transform.position = pos;
			}
		} 

	}

}
