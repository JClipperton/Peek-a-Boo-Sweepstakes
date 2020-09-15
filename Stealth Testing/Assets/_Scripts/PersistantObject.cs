using UnityEngine;
using System.Collections;
// PERSISTANT OBJECT CLASS
public class PersistantObject : MonoBehaviour {

	public int Score;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
