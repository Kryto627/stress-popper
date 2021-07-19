using UnityEngine;
using UnityEngine.Events;

namespace StressPopper.Systems {

    public class Interactable : MonoBehaviour, IInteractable {

        public UnityEvent OnInteracted = new UnityEvent();

        public void Interact() {
            OnInteracted.Invoke();
        }
    }
}
