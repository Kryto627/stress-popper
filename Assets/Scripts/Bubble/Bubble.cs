using UnityEngine;

namespace StressPopper {

    /// <summary>
    /// Pops the bubble when it is interacted.
    /// </summary>
    public class Bubble : MonoBehaviour {

        /// <summary>
        /// Pops the bubble.
        /// </summary>
        public void Pop() {
            Destroy(gameObject);
        }
    }
}
