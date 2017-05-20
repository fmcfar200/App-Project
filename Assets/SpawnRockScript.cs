using UnityEngine;
using System.Collections;

public class SpawnRockScript : MonoBehaviour {

	public GameObject[] spawnPoints = new GameObject[4];
	public GameObject rockPrefab;
 	bool levelFinished = false;
	float nextLevelWait = 3.0f;

	IEnumerator SpawnRocks()
	{
		int spawnNumber = 5;
		float spawnDelay = 1.0f;
		levelFinished = false;

		Debug.Log("Spawning Rocks");
		while(levelFinished == false)
		{
			for (int i=0; i < spawnNumber; i++) 
			{
				yield return new WaitForSeconds (spawnDelay);
				Instantiate (rockPrefab, spawnPoints [Random.Range (0, 4)].transform.position, Quaternion.identity);
			
			}
			levelFinished = true;
		}
		yield return new WaitForSeconds (nextLevelWait);
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		GameManager gameManager = player.GetComponent<GameManager> ();
		gameManager.NextLevel ();
	

	}
}
