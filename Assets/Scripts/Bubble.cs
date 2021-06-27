using UnityEngine;

namespace StressPopper {

    /// <summary>
    /// Handles the basic bubble object.
    /// </summary>
    public class Bubble : MonoBehaviour, IInteractable {

        /// <summary>
        /// Pops the bubble.
        /// </summary>
        public void Interact() {

            //Destorys the game object.
            Destroy(gameObject);
        }
    }
}
