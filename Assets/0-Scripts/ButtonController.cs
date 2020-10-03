using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour {
    #region Variables and Properties
    [SerializeField] private UnityEvent onPress = default;
    [SerializeField] private GameController gameController;
    #endregion Variables and Properties

    /// <summary>
    /// Invokes onPress when PickUpController calls Push.
    /// </summary>
    public void Push() {
        gameController.AddScore(-5000); //Might move this
        onPress.Invoke();
    }
}
