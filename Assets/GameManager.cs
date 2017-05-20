using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class GameManager : MonoBehaviour {

	public int levelNum = 0;
	public string nextLevelType;
	//positions
	Vector3 playerPos;

	string[] levelTypes = new string[]{"Dodge","Fly"}; // Note to self >>> Add level types when prev level is complete.


	bool findLazers = false;
	public bool followPlayer = true;
	bool startDodge = false;
	public bool beginFalling;

	GameObject player;
	public GameObject centrePoint;

	void Start () 
	{

		levelNum = 1;
		player = this.gameObject;
		if (player == null) {
			Debug.LogError("PLAYER MISSING");
			return;
		}
		followPlayer = true;
	}

	//Changes to physics.
	void FixedUpdate()
	{
		playerPos = this.gameObject.transform.position;

	}
	//Trigger is activated to start the next level
	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Level Trigger") 
		{
			if (nextLevelType != "Dodge") 
			{
				NextLevel ();
			}
		}
	}
	//Selects the next level from random after a level is completed.
	public void NextLevel()
	{
		Debug.Log("Level Complete");
		levelNum++;
		nextLevelType = levelTypes [Random.Range (0, levelTypes.Length)];
		Debug.Log (nextLevelType);
		if (nextLevelType == "Fly") {
			findLazers = true;
			followPlayer = true;
			StartFlyLevel();
		
		} 
		if (nextLevelType == "Dodge") {
			startDodge = true;
			followPlayer = false;
			StartDodgeLevel();
		
		}
		nextLevelType = " ";
	}

	// Used to initialize the flying level 
	void StartFlyLevel()
	{
		PlayerMovementScript playerMov = this.gameObject.GetComponent<PlayerMovementScript> ();
		GameObject lazers = GameObject.FindGameObjectWithTag("Trap");
		if(lazers == null)
		{
			Debug.LogError("NO LAZERS FOUND!!!");
			return;
		}
		else
		{
			Debug.Log ("Lazers found");
			Vector3 lazerPos = lazers.transform.position;
			lazerPos.x = (playerPos.x + 15 );
			lazers.transform.position = lazerPos;
		}
		findLazers = false;
		playerMov.canFly = true;
		playerMov.movementSpeed = 2.5f;
	}
	//used to initialize the dodge level
	void StartDodgeLevel()
	{
		startDodge = false;
		PlayerMovementScript playerMov = this.gameObject.GetComponent<PlayerMovementScript> ();
		GameObject rockSpawner = GameObject.Find ("Spawner");
		SpawnRockScript rockScript = rockSpawner.GetComponent<SpawnRockScript> ();


		if (rockSpawner == null) {
			Debug.LogError ("SPAWNER NOT FOUND");
		} else {
			playerMov.canFly = false;
			playerMov.movementSpeed = 0;
			beginFalling = true;
			rockScript.StartCoroutine("SpawnRocks");
			}

	}





}


