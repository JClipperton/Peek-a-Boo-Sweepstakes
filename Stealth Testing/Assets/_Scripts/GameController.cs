using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// GAME CONTROLLER CLASS
public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public GameObject playTextObjects;
	public GameObject overTextObjects;
	public GameObject winTextObjects;

	public Text strikesText;
	public int strikes;

	public Text scoreText;
	public int score;

	public Image lightIM;
	public float lightLevel;

	public Text whatIsText;

	public bool over;

	void Awake ()
	{
		playTextObjects.SetActive(true);
		overTextObjects.SetActive(false);
		winTextObjects.SetActive(false);
		over = false;
	}

	void Start()
	{
		UpdateStrikes();
		UpdateScore();
		UpdateLightImage();
		UpdateWhatIs("");
	}

	void Update()
	{
		if(over)
		{
			if(Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

	// adds Strikes
	public void AddStrikes(int addStrikes)
	{
		strikes += addStrikes;
        GetComponent<AudioSource>().Play();
		UpdateStrikes();
	}
	
	// updates the Strikes display
	void UpdateStrikes()
	{
		strikesText.text = "Strikes: ";
		for (int i = 0; i < strikes; i++)
		{
			strikesText.text += "X";	
		}

		if(strikes == 1)
		{
			StrikeObjectDisable(strikes);
		}
		else if(strikes == 2)
		{
			StrikeObjectDisable(strikes);
		}
		else if (strikes >= 3)
		{
			GameOver();
		}
	}

	// disable all GameObjects with the tag "Strike" + number
	void StrikeObjectDisable(int intput)
	{
		GameObject[] gO = GameObject.FindGameObjectsWithTag("Strike" + intput);
		for (int i = 0; i < gO.Length; i++)
		{
			gO[i].SetActive(false);	
		}
	}
	
	// sets game to finished state
	void GameOver()
	{
		playTextObjects.SetActive(false);
		overTextObjects.SetActive(true);
		over = true;
	}
	
	// adds points to score
	public void AddScore(int addScore)
	{
		score += addScore;
		UpdateScore();
	}
	
	// updates the score display
	void UpdateScore()
	{        
		scoreText.text = score.ToString("C");
	}

	// updates the current light level
	public void ChangeLight(float newLightLevel)
	{
		lightLevel = newLightLevel;
		UpdateLightImage();
	}
	
	// sets the light image to reflect current light level
	void UpdateLightImage ()
	{
		if(lightLevel > 0)
		{
			// lightIM.color = new Color(lightLevel, lightLevel, lightLevel, 1);
            lightIM.color = Color.white;
		}
		else
		{
			lightIM.color = Color.black;
		}
	}
	
	// updates the "What is" text
	public void UpdateWhatIs(string str)
	{
		whatIsText.text = str;
	}

	public void Win()
	{
		if(!over)
		{
			playTextObjects.SetActive(false);
			winTextObjects.SetActive(true);
		}
	}
}
