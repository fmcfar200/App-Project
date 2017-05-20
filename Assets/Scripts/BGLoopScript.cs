using UnityEngine;
using System.Collections;

public class BGLoopScript : MonoBehaviour {

	int numBGPanels = 6;
	float minHeight = -2.07f;
	float maxHeight = 0.1f;

	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("Triggered: " + collider.name);

		if (collider.gameObject.tag == "Platform") {

			float widthOfBGPanels = ((BoxCollider2D)collider).size.x;
			Vector3 pos = collider.transform.position;
			pos.x += widthOfBGPanels * numBGPanels - widthOfBGPanels / 2;
			collider.transform.position = pos;
		} else if (collider.gameObject.tag == "Background") {
			float widthOfBGPanels = ((BoxCollider2D)collider).size.x;
			Vector3 pos = collider.transform.position;
			pos.x += (widthOfBGPanels - 22) * numBGPanels - ((widthOfBGPanels - 22) / 2);
			collider.transform.position = pos;
		}

		//LAZER LOOP CODE!!!!! DO NOT DELETE
//					 else if (collider.gameObject.tag == "Trap") {
//			float widthOfBGPanels = ((BoxCollider2D)collider).size.x;
//			Vector3 pos = collider.transform.position;
//			pos.x += (widthOfBGPanels * numBGPanels*5);//(-5)if extra mechanic isnt added. See Notes;
//			pos.y = Random.Range(minHeight,maxHeight);
//			collider.transform.position = pos;
//			Debug.Log("Trap Loop Triggered");
//		}
	}
}
