using UnityEngine;
using UnityEngine.Events;

namespace StressPopper.Systems {

    /// <summary>
    /// Invokes a Unity Event is the object is interacted.
    /// </summary>
    public class Interactable : MonoBehaviour, IInteractable {

        /// <summary>
        /// A Unity Event called when the object is interacted.
        /// </summary>
        [Tooltip("Invoked when this object is interacted by the player.")]
        public UnityEvent OnInteracted = new UnityEvent();

        /// <summary>
        /// Called when the object is interacted.
        /// </summary>
        public void Interact() {
            OnInteracted.Invoke();
        }
    }
}
