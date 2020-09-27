using UnityEngine;

public class LavaScript : MonoBehaviour {
    public Transform spawnpoint;
    public GameController gameController;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            other.transform.position = spawnpoint.transform.position; // resets player position
            gameController.AddScore(-150000);
        }
    }
}
