using UnityEngine;
using UnityEngine.InputSystem;

namespace StressPopper.Systems {

    /// <summary>
    /// Interacts with interactable objects.
    /// </summary>
    public class Interactor : MonoBehaviour, PlayerInput.IPlayerActions {

        /// <summary>
        /// The collision layer the interactable objects are on.
        /// </summary>
        [SerializeField]
        [Tooltip("The collision layer the interactable object are on.")]
        private LayerMask interactableLayer = default;

        /// <summary>
        /// The player input handler.
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
        /// Called when the player interacts by mouse click or touch.
        /// </summary>
        /// <param name="context">The context of the input event.</param>
        public void OnInteract(InputAction.CallbackContext context) {
            FireInteractionRaycast(GetScreenPosition(context));
        }

        /// <summary>
        /// Finds the screen position from the input event.
        /// </summary>
        /// <param name="context">The context of the input event.</param>
        /// <returns>The screen position.</returns>
        private Vector2 GetScreenPosition(InputAction.CallbackContext context) {

            Vector2 screenPosition = Vector2.zero;

            if (context.control.parent is Mouse control) {
                screenPosition = control.position.ReadValue();
            }

            return screenPosition;
        }

        /// <summary>
        /// Fires a raycast from a screen position.
        /// </summary>
        /// <param name="screenPosition">The screen position.</param>
        private void FireInteractionRaycast(Vector2 screenPosition) {

            Camera camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(screenPosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, interactableLayer)) {
                Interact(hit);
            }
        }

        /// <summary>
        /// Interacts with the collided object.
        /// </summary>
        /// <param name="hit">The raycast event context.</param>
        private void Interact(RaycastHit hit) {

            if (hit.collider.TryGetComponent(out IInteractable interactable)) {
                interactable.Interact();
            }
        }
    }
}
