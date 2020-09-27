using UnityEngine;

// DOOR CONTROLLER CLASS
public class DoorController : MonoBehaviour {
    // PUBLIC INSTANCE VARIABLES
    public bool open;

    // PRIVATE INSTANCE VARIABLES
    private Animator _anim;

    void Awake() {
        this._anim = GetComponent<Animator>();
    }

    void Start() {
        this._anim.SetBool("Open", open);
    }

    // Opens the door if it's closed
    public void Open() {
        if (!open) {
            open = true;
            this._anim.SetBool("Open", open);
        }
    }

    // Close the door if it's open
    public void Close() {
        if (open) {
            open = false;
            this._anim.SetBool("Open", open);
        }
    }

    // Swaps the state of the door
    public void Swap() {
        open = !open;
        this._anim.SetBool("Open", open);
    }
}
