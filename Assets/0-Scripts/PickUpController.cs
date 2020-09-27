using UnityEngine;

// BUTTON CONTROLLER CLASS
public class PickUpController : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES
    public Transform pickUpCheck;
    public float pickUpRange;

    //PRIVATE INSTANCE VARIABLES
    private GameController _gameController;
    private bool canActivate;

    void Awake() {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            this._gameController = gameControllerObject.GetComponent<GameController>();
        } else {
            Debug.Log("Cannot find 'GameController' script");
        }

        //Makes sure game controller is found
        canActivate = false;
    }

    void Update() {
        RaycastHit hit;
        int layerMask = 1 << 8;

        if (Physics.Raycast(transform.position, transform.forward, out hit, pickUpRange, layerMask)) {
            //Debug.Log(hit.collider.gameObject.tag);

            if (hit.collider.gameObject.tag == "PickUp") {
                canActivate = true;
                this._gameController.UpdateWhatIs("Press 'E' to Pick up " + hit.collider.gameObject.name);
            } else if (hit.collider.gameObject.tag == "Button") {
                canActivate = true;
                this._gameController.UpdateWhatIs("Press 'E' to Push " + hit.collider.gameObject.name);
            }

            if (canActivate && Input.GetButtonDown("Submit")) {
                if (hit.collider.gameObject.tag == "PickUp") {
                    Destroy(hit.collider.gameObject);
                } else if (hit.collider.gameObject.tag == "Button") {
                    hit.collider.gameObject.SendMessage("Push");
                }
            }
        } else {
            canActivate = false;
            this._gameController.UpdateWhatIs("");
        }
        Debug.DrawLine(transform.position, pickUpCheck.position);
    }
}
