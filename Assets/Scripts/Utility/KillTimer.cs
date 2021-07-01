using UnityEngine;

namespace StressPopper.Utility {

    /// <summary>
    /// Kills the object after some time passes. 
    /// </summary>
    [DisallowMultipleComponent]
    public class KillTimer : MonoBehaviour {

        /// <summary>
        /// The time the object will be alive in seconds.
        /// </summary>
        [SerializeField]
        [Tooltip("The time the object will be alive in seconds.")]
        private float time = 1F;

        /// <summary>
        /// Called by Unity when the object is created.
        /// </summary>
        private void Start() {
            Destroy(gameObject, time);
        }
    }
}
