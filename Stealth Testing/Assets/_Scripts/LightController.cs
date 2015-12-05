using UnityEngine;
using System.Collections;

// LIGHT CONTROLLER CLASS
public class LightController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private GameController _gameController;
    private Light _parLight;
    private Transform _tr;
	
	void Awake()
	{
		this._parLight = gameObject.GetComponentInParent<Light>();
		this._tr = gameObject.GetComponent<Transform>();

		// Makes the collider in the "Z" the same size
		this._tr.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.x, this._parLight.range / 2);
        this._tr.localScale = new Vector3(this._parLight.spotAngle / 12, this._parLight.spotAngle / 12, this._parLight.range / 2);

		//this._gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			this._gameController = gameControllerObject.GetComponent<GameController>();
		}
		else
		{
			Debug.Log("Light Controller Cannot find 'GameController' script");
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player") // is the collider the player object?
		{
			Vector3 relPlayPos = other.transform.position - transform.position;
			RaycastHit hit;

            if (Physics.Raycast(transform.position, relPlayPos, out hit)) // did a raycast hit the object?
			{
				if(hit.collider.gameObject.tag == "Player") // did the raycast hit the player?
				{
                    // changes player to lit state
					this._gameController.ChangeLight(1);
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
            // changes player to unlit state
			this._gameController.ChangeLight(0);
		}
	}
}