
namespace StressPopper.Systems {

    /// <summary>
    /// Handles the interaction of an object.
    /// </summary>
    public interface IInteractable {

        /// <summary>
        /// Called when the object is interacted with by the player.
        /// </summary>
        void Interact();
    }
}