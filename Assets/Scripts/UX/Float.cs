using UnityEngine;

namespace StressPopper.Systems {

    /// <summary>
    /// Moves the object up.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Float : MonoBehaviour {

        /// <summary>
        /// The minimum speed the object floats up.
        /// </summary>
        [SerializeField]
        [Tooltip("The minimum speed the object floats up.")]
        private float minimumSpeed = 0F;

        /// <summary>
        /// The maximum speed the object floats up.
        /// </summary>
        [SerializeField]
        [Tooltip("The maximum speed the object floats up.")]
        private float maximumSpeed = 1F;

        /// <summary>
        /// The object's rigidbody.
        /// </summary>
        private Rigidbody rb;

        /// <summary>
        /// Called by Unity when the object is created.
        /// </summary>
        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        /// <summary>
        /// Called by Unity after the Awake method.
        /// </summary>
        private void Start() {
            SetVelocity(Vector3.up, Random.Range(minimumSpeed, maximumSpeed));
        }

        /// <summary>
        /// Set the rigidbody's velocity.
        /// </summary>
        /// <param name="direction">The velocity's direction.</param>
        /// <param name="speed">The velocity's speed.</param>
        private void SetVelocity(Vector3 direction, float speed) {
            rb.velocity = direction.normalized * speed;
        }
    }
}