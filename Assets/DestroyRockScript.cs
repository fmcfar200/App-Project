using UnityEngine;
using System.Collections;

public class DestroyRockScript : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D hit)
	{
		if (hit.gameObject.tag == "Platform")
			Destroy(this.gameObject);
		}
	}

