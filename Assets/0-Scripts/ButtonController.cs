using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {
    #region Variables and Properties
    [SerializeField] private UnityEvent onPress = default;

    public enum OnPush { OPEN, CLOSE, SWAP, Startmoving, Stopmoving, RESETSTRIKES, ErrorTest }
    public OnPush onPush;
    public Transform target;

    public GameController gameController;
    #endregion Variables and Properties

    void Update() {
        Debug.DrawLine(transform.position, target.position, Color.green);
    }

    /// <summary>
    /// Method to send a message to the target
    /// </summary>
    public void Push() {
        gameController.AddScore(-5000); //Might move this
        onPress.Invoke();
    }
}
