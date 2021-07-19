using UnityEngine;
using UnityEngine.InputSystem;

namespace StressPopper.Systems {

    public class Interactor : MonoBehaviour {

        public LayerMask interactableLayer = default;

        private void Update() {
            PollMouseInput();
        }

        private void PollMouseInput() {
            if (Mouse.current.leftButton.wasPressedThisFrame) {
                FireInteractionRaycast(Mouse.current.position.ReadValue());
            }
        }

        private void FireInteractionRaycast(Vector2 screenPosition) {

            Camera camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, interactableLayer)) {
                Interact(hit);
            }
        }

        private void Interact(RaycastHit hit) {

            if (hit.collider.TryGetComponent(out IInteractable interactable)) {
                interactable.Interact();
            }
        }
    }
}
