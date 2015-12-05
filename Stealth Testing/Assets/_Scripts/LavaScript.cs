using UnityEngine;
using System.Collections;

public class LavaScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.tag);
		if(other.gameObject.tag == "Player")
		{
			Application.LoadLevel("Level1");
		}
	}
}
