using UnityEngine;

namespace StressPopper.Systems {

    /// <summary>
    /// Makes the object float in a set direction.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Float : MonoBehaviour {

        /// <summary>
        /// The direction the object floats.
        /// </summary>
        [SerializeField]
        [Tooltip("The direction the object floats.")]
        private Vector3 direction = Vector3.zero;

        /// <summary>
        /// The amount of speed the object floats.
        /// </summary>
        [SerializeField]
        [Tooltip("The amount of speed the object floats.")]
        private float speed = 1F;

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
            SetFloatValocity();
        }

        /// <summary>
        /// Sets the object's floating direction and speed.
        /// </summary>
        private void SetFloatValocity() {
            rb.velocity = GetValocity();
        }

        /// <summary>
        /// The object's floating velocity.
        /// </summary>
        /// <returns>The velocity vector.</returns>
        private Vector3 GetValocity() {
            return direction.normalized * speed;
        }
    }
}