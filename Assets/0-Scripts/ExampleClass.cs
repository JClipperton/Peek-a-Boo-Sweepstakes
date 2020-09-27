using UnityEngine;

public class ExampleClass : MonoBehaviour {

    public bool move;
    public Transform endMarker;
    public float speed = 1.0F;

    private Transform startMarker;
    private float startTime;
    private float journeyLength;

    void Start() {
        startTime = Time.time;
        startMarker = this.transform;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update() {
        if (move) {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            GetComponent<Transform>().position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        } else {
            startTime = Time.time;
        }
    }
}
