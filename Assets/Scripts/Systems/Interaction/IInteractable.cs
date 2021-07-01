namespace StressPopper.Systems {

    /// <summary>
    /// Handles if a object is interactable.
    /// </summary>
    public interface IInteractable {

        /// <summary>
        /// Called when the object is interacted.
        /// </summary>
        void Interact();
    }
}