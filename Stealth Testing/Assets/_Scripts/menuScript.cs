using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {

    public GameObject loadingImage;
	public GameObject playButton;
	public GameObject instructionsText;
	public Text instructionsButtonText;

	private bool _InstuctOn;

	void Awake ()
	{
		this._InstuctOn = false;

		loadingImage.SetActive(false);
		playButton.SetActive(true);
		instructionsText.SetActive(false);
	}

    public void LoadScene(int level)
    {
        loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }

	public void Instuctions()
	{
		if (this._InstuctOn)
		{
			this._InstuctOn = false;
			playButton.SetActive(true);
			instructionsText.SetActive(false);
			instructionsButtonText.text = "How to Play";
		}
		else
		{
			this._InstuctOn = true;
			playButton.SetActive(false);
			instructionsText.SetActive(true);
			instructionsButtonText.text = "Return";
		}

	}
}
