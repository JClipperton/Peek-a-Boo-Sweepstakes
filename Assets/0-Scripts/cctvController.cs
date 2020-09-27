using UnityEngine;

// CCTV CONTROLLER CLASS
public class cctvController : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES
    public int strikeAdd = 1;

    // PRIVATE INSTANCE VARIABLES
    //private GameObject player;
    private GameController _gameController;

    void Awake() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            this._gameController = gameControllerObject.GetComponent<GameController>();
        } else {
            Debug.Log("cctv Controller Class Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Vector3 relPlayPos = other.transform.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, relPlayPos, out hit)) {
                if (hit.collider.gameObject.tag == "Player") {
                    Debug.Log("HEllO");
                    this._gameController.AddStrikes(strikeAdd);
                    //Player.'Number of people looking at look'++;
                }
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            //Player.'Number of people looking at look'--;
        }
    }
}