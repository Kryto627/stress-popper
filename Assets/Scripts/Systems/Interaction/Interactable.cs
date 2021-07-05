using UnityEngine;
using UnityEngine.Events;

namespace StressPopper.Systems {

    /// <summary>
    /// Handles interaction of an object.
    /// </summary>
    public class Interactable : MonoBehaviour, IInteractable {

        /// <summary>
        /// A Unity Event called when the object is interacted by the player.
        /// </summary>
        [Header("Unity Event")]
        public UnityEvent OnInteracted = new UnityEvent();

        /// <summary>
        /// Called when the object is interacted by the player.
        /// </summary>
        public void Interact() {
            OnInteracted.Invoke();
        }
    }
}
