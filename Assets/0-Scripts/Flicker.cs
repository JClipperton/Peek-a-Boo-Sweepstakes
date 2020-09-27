using UnityEngine;

public class Flicker : MonoBehaviour {

    public float time;

    public Light _light;
    public GameObject _collider;
    public GameObject _cone;

    private float timer;
    private bool on;

    void start() {
        on = true;
        timer = 0;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= time) {
            on = !on;
            timer = 0;
            _light.enabled = (on);
            _collider.SetActive(on);
            _cone.SetActive(on);
        }
    }
}
