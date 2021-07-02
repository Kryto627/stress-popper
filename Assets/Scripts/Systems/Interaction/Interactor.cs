using UnityEngine;
using UnityEngine.InputSystem;

namespace StressPopper.Systems {

    public class Interactor : MonoBehaviour, PlayerInput.IPlayerActions {

        [SerializeField]
        private LayerMask interactableLayer = default;

        private PlayerInput playerInput;

        private void Awake() {
            playerInput = new PlayerInput();
        }

        private void Start() {
            playerInput.Player.SetCallbacks(this);
        }

        private void OnEnable() {
            playerInput.Enable();
        }

        private void OnDisable() {
            playerInput.Disable();
        }

        public void OnInteract(InputAction.CallbackContext context) {
            FireInteractionRaycast(GetScreenPosition(context));
        }

        private Vector2 GetScreenPosition(InputAction.CallbackContext context) {

            Vector2 screenPosition = Vector2.zero;

            if (context.control.parent is Mouse control) {
                screenPosition = control.position.ReadValue();
            }

            return screenPosition;
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
