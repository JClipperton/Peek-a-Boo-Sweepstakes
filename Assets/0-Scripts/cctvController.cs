using UnityEngine;

public class CctvController : MonoBehaviour {
    #region Variables and Properties
    [SerializeField] private int strikeAdd = 1;
    [SerializeField] private GameController gameController = default;

    private Transform cachedTransform;
    #endregion Variables and Properties

    private void Awake() {
        cachedTransform = transform;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Vector3 relPlayPos = other.transform.position - cachedTransform.position;

            if (Physics.Raycast(cachedTransform.position, relPlayPos, out RaycastHit hit)) {
                if (hit.collider.CompareTag("Player")) {
                    Debug.Log("cctv sees player");
                    gameController.AddStrikes(strikeAdd);
                    //Player.'Number of people looking at look'++;
                }
            }
        }
    }

    /*private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            //Player.'Number of people looking at look'--;
        }
    }*/
}