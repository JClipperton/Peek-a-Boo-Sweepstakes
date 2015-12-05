﻿using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

	// PRIVATE INSTANCE VARIABLES
	private GameController _gameController;
	
	void Awake()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			this._gameController = gameControllerObject.GetComponent<GameController>();
		}
		else
		{
			Debug.Log("cctv Controller Class Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			this._gameController.Win();
		}
	}
}
