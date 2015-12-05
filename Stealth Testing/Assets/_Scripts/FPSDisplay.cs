using UnityEngine;
using System.Collections;

// DEBUG DISPLAY FPS CLASS
public class FPSDisplay : MonoBehaviour
{
	private float _deltaTime = 0.0f;
	
	void Update()
	{
        this._deltaTime += (Time.deltaTime - this._deltaTime) * 0.1f;
	}
	
	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;
		
		GUIStyle style = new GUIStyle();
		
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color (1.0f, 1.0f, 1.0f, 1.0f);
        float msec = this._deltaTime * 1000.0f;
        float fps = 1.0f / this._deltaTime;
		string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		GUI.Label(rect, text, style);
	}
}