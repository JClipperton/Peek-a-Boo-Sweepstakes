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
	//public int score;

	public Image seenDark;
	public Image seenLight;
	public float lightLevel;

	public Text whatIsText;

	public bool over;

	public int loiteringPenalty;
	public float loiteringInterval;

    public AudioSource loseMoneySound;

	public PersistantObject scoreHandler;

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

		AddScore(-loiteringPenalty);
		StartCoroutine(LoiteringLoop());
	}

	void Update()
	{
		if(over)
		{
			if(Input.GetKeyDown(KeyCode.R)) // restarts level
			{
				Application.LoadLevel(0);
			}
		}
	}

	// adds Strikes
	public void AddStrikes(int addStrikes)
	{
		strikes += addStrikes;
        GetComponent<AudioSource>().Play();
        this.AddScore(-50000);
		UpdateStrikes();
	}
	
	// updates the Strikes display
	void UpdateStrikes()
	{
		strikesText.text = "STRIKES: ";
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
	void StrikeObjectDisable(int input)
	{
		GameObject[] objectsToStrike = GameObject.FindGameObjectsWithTag("Strike" + input);
		for (int i = 0; i < objectsToStrike.Length; i++)
		{
			objectsToStrike[i].SendMessage("StartMoveToEnd");	
		}
	}

	// enable all GameObjects with the tag "Strike#" 
	void StrikeObjectEnable()
	{
		for(int j = 1; j <= 2; j++)
		{
			GameObject[] objectsToStrike = GameObject.FindGameObjectsWithTag("Strike" + j);
			Debug.Log("j = " + j);
			Debug.Log(objectsToStrike.Length);
			for (int i = 0; i < objectsToStrike.Length; i++)
			{
				objectsToStrike[i].SendMessage("StartMoveToStart");
			}
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
        if (addScore < 0)
        {
            loseMoneySound.Play();
        }
		scoreHandler.Score += addScore;
		UpdateScore();
		if (scoreHandler.Score <= 0)
		{
			GameOver();
		}
	}
	
	// updates the score display
	void UpdateScore()
	{        
		scoreText.text = scoreHandler.Score.ToString("C");
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
			seenLight.enabled = true;
			seenDark.enabled = false;
		}
		else
		{
			seenLight.enabled = false;
			seenDark.enabled = true;
		}
	}
	
	// updates the "What is" text
	public void UpdateWhatIs(string str)
	{
		whatIsText.text = str;
	}

    // Resolves level win state
	public void Win()
	{
        if (Application.loadedLevel == 1) // if first level is active...
        {
            Application.LoadLevel(2); // load next level
        }
		else if (Application.loadedLevel == 2)
		{
			Application.LoadLevel(3);
		}
		else if(!over)
		{
			playTextObjects.SetActive(false);
			winTextObjects.SetActive(true);
		}
	}

	public void Resetstrikes()
	{
		strikes = 0;
		UpdateStrikes();
		AddScore(-10000);
		StrikeObjectEnable();
	}

	//
	IEnumerator LoiteringLoop()
	{
		while(true)
		{
			AddScore(loiteringPenalty);
			yield return new WaitForSeconds(loiteringInterval);
		}
	}
}
