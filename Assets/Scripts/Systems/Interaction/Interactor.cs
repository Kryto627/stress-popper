using UnityEngine;
using UnityEngine.InputSystem;

namespace StressPopper.Systems {

    /// <summary>
    /// Interacts with objects.
    /// </summary>
    public class Interactor : MonoBehaviour, PlayerInput.IPlayerActions {

        /// <summary>
        /// The layer mask that contains all interactable objects.
        /// </summary>
        [SerializeField]
        [Tooltip("The layer mask that contains all interactable objects.")]
        private LayerMask interactableLayer = default;

        /// <summary>
        /// The player's input.
        /// </summary>
        private PlayerInput playerInput;

        /// <summary>
        /// Called by Unity when the object is created.
        /// </summary>
        private void Awake() {
            playerInput = new PlayerInput();
        }

        /// <summary>
        /// Called by Unity after the Awake method.
        /// </summary>
        private void Start() {
            playerInput.Player.SetCallbacks(this);
        }

        /// <summary>
        /// Called by Unity when the component is enabled.
        /// </summary>
        private void OnEnable() {
            playerInput.Enable();
        }

        /// <summary>
        /// Called by Unity when the component is disabled.
        /// </summary>
        private void OnDisable() {
            playerInput.Disable();
        }

        /// <summary>
        /// Called when the player clicks or touches the screen.
        /// </summary>
        /// <param name="context"></param>
        public void OnInteract(InputAction.CallbackContext context) {

            Vector2 mousePosition = Vector2.zero;

            if (context.control.parent is Mouse control) {
                mousePosition = control.position.ReadValue();
            }

            FireInteractionRaycast(mousePosition);
        }

        /// <summary>
        /// Fires a raycast at the mouse or touch position.
        /// </summary>
        /// <param name="mousePosition">The mouse or touch position.</param>
        private void FireInteractionRaycast(Vector2 mousePosition) {

            Camera camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, interactableLayer)) {
                Interact(hit);
            }
        }

        /// <summary>
        /// Interacts with the collided object.
        /// </summary>
        /// <param name="hit">The raycast's data.</param>
        private void Interact(RaycastHit hit) {

            if (hit.collider.TryGetComponent(out IInteractable interactable)) {
                interactable.Interact();
            }
        }
    }
}
