using UnityEngine;
using System.Collections;

// BUTTON CONTROLLER CLASS
public class ButtonController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public enum OnPush { OPEN, CLOSE, SWAP, ErrorTest }
	public OnPush onPush;
	public Transform target;

	void Update()
	{
		Debug.DrawLine(transform.position, target.position, Color.green);
	}

	// PUBLIC METHODS
	// Method to send a message to the target
	public void Push()
	{
		target.SendMessage(FirstCharToUpper(onPush.ToString()));
	}

	
	// returns the input string with the only the first letter of the input in upper case
	public string FirstCharToUpper(string input)
	{
		return input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();
	}
}
