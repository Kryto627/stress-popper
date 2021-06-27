using UnityEngine;
using UnityEngine.InputSystem;

namespace StressPopper {

    /// <summary>
    /// Handles interaction with interactable objects.
    /// </summary>
    public class Interactor : MonoBehaviour, PlayerInput.IPlayerActions {

        /// <summary>
        /// The interactable object's layer mask.
        /// </summary>
        [SerializeField]
        [Tooltip("The interactable object's layer mask.")]
        private LayerMask interactionLayer = default;

        /// <summary>
        /// The interactor's maximum reach.
        /// </summary>
        [SerializeField]
        [Tooltip("The interactor's maximum reach.")]
        private float interactionDistance = 100F;

        /// <summary>
        /// Handles the player's input.
        /// </summary>
        private PlayerInput playerInput;

        /// <summary>
        /// The mouse's current position.
        /// </summary>
        private Vector2 mousePosition = Vector2.zero;

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
        /// Called by Unity when this component is enabled.
        /// </summary>
        private void OnEnable() {
            playerInput.Enable();
        }

        /// <summary>
        /// Called by Unity when this component is disabled.
        /// </summary>
        private void OnDisable() {
            playerInput.Disable();
        }

        /// <summary>
        /// Called when the mouse position changes.
        /// </summary>
        /// <param name="context">The context of the input action.</param>
        public void OnMousePosition(InputAction.CallbackContext context) {
            mousePosition = context.ReadValue<Vector2>();
        }

        /// <summary>
        /// Called when the player interacts.
        /// </summary>
        /// <param name="context">The context of the input action.</param>
        public void OnInteract(InputAction.CallbackContext context) {

            Camera camera = Camera.main;
            Ray ray = camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out var hit, interactionDistance, interactionLayer)) {

                if (hit.collider.TryGetComponent(out IInteractable interactable)) {

                    interactable.Interact();
                }
            }
        }
    }
}
