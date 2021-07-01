using UnityEngine;
using UnityEngine.InputSystem;

namespace StressPopper {

    public class Interactor : MonoBehaviour, PlayerInput.IPlayerActions {

        [SerializeField]
        [Tooltip("The layer mask that contains all interactable objects.")]
        private LayerMask interactableLayer = default;

        private PlayerInput playerInput;

        private void Awake() => playerInput = new PlayerInput();

        private void Start() => playerInput.Player.SetCallbacks(this);

        private void OnEnable() => playerInput.Enable();

        private void OnDisable() => playerInput.Disable();

        public void OnInteract(InputAction.CallbackContext context) {

            Vector2 mousePosition = Vector2.zero;

            if (context.control.parent is Mouse control) {
                mousePosition = control.position.ReadValue();
            }

            FireInteractionRaycast(mousePosition);
        }

        private void FireInteractionRaycast(Vector2 mousePosition) {

            Camera camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(mousePosition);

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
