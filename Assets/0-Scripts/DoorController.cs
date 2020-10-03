using UnityEngine;

public class DoorController : MonoBehaviour {
    #region Variables and Properties
    [SerializeField] private bool doorStart = false;
    [SerializeField] private Animator animator = default;

    private bool open;
    #endregion Variables and Properties

    void Awake() {
        open = doorStart;
        animator.SetBool("Open", open);
    }

    /// <summary>
    /// Opens the door
    /// </summary>
    public void Open() {
        open = true;
        animator.SetBool("Open", open);
    }

    /// <summary>
    /// Close the door
    /// </summary>
    public void Close() {
        open = false;
        animator.SetBool("Open", open);
    }

    /// <summary>
    /// Swaps the state of the door
    /// </summary>
    public void Swap() {
        open = !open;
        animator.SetBool("Open", open);
    }
}
