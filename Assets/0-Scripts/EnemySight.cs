using UnityEngine;
using System.Collections;

//ENEMY SIGHT CLASS
public class EnemySight : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int strikeAdd = 1;
	public float disableTime = 2.0f;
	
	// PRIVATE INSTANCE VARIABLES
    //private GameObject _player;
	private GameController _gameController;
	private float _disableTimer = 0f;
	private bool _disabled = false;
	
	void Awake()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			this._gameController = gameControllerObject.GetComponent<GameController>();
		}
		else
		{
			Debug.Log("Enemy Sight Class Cannot find 'GameController' script");
		}
	}

	void Update()
	{
		if(this._disableTimer >= disableTime)
		{
			this._disabled = false;
		}
		
		if(!this._disabled && this._disableTimer > 0)
		{
			this._disableTimer = 0;
			enableSight();
		}
		else if(this._disabled)
		{
			this._disableTimer += Time.deltaTime;
		}
	}

	void OnTriggerEnter(Collider other)
	{
        // check if object is player && checks if player is lit
		if(other.gameObject.tag == "Player" && this._gameController.lightLevel > 0)
		{
			Vector3 relPlayPos = other.transform.position - transform.position;
			RaycastHit hit;
			if(Physics.Raycast(transform.position, relPlayPos, out hit))
			{
				//Debug.Log(hit.collider.gameObject.name);
				if(hit.collider.gameObject.tag == "Player")
				{
					// Player.'Number of people looking at look'++;

					this._gameController.AddStrikes(strikeAdd);
					this._disabled = true;
					disableSight();
				}
			}
		}
	}
	
    /*
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			// Player.'Number of people looking at look'--;
		}
	}
     * */

	void disableSight()
	{
		gameObject.GetComponent<MeshCollider>().enabled = false;
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.GetComponentInParent<EnemyAI>().enabled = false;
		gameObject.GetComponentInParent<UnityEngine.AI.NavMeshAgent>().enabled = false;
	}

	void enableSight()
	{
		gameObject.GetComponent<MeshCollider>().enabled = true;
		gameObject.GetComponent<MeshRenderer>().enabled = true;
		gameObject.GetComponentInParent<EnemyAI>().enabled = true;
		gameObject.GetComponentInParent<UnityEngine.AI.NavMeshAgent>().enabled = true;
	}
}