using UnityEngine;

namespace StressPopper.Utility {

    /// <summary>
    /// Removes the object after a set amount of time.
    /// </summary>
    [DisallowMultipleComponent]
    public class KillTimer : MonoBehaviour {

        /// <summary>
        /// The time in seconds to remove the object.
        /// </summary>
        [SerializeField]
        [Tooltip("The time in seconds to remove the object.")]
        private float time = 1F;

        /// <summary>
        /// Called by Unity after the Awake method.
        /// </summary>
        private void Start() {
            Destroy(gameObject, time);
        }
    }
}
