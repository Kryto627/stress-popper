using UnityEngine;
using UnityEngine.Events;

namespace StressPopper {

    public class Interactable : MonoBehaviour, IInteractable {

        [Tooltip("Invoked when this object is interacted by the player.")]
        public UnityEvent OnInteracted = new UnityEvent();

        public void Interact() {
            OnInteracted.Invoke();
        }
    }
}
