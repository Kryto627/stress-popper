using UnityEngine;

namespace StressPopper.Systems {

    /// <summary>
    /// Adds a side-to-side drift to the object.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Drift : MonoBehaviour {

        /// <summary>
        /// The direction of the drifting movement.
        /// </summary>
        [SerializeField]
        [Tooltip("The direction of the drifting movement.")]
        private Vector3 direction = Vector3.zero;

        /// <summary>
        /// The amplitude of the drifting movement.
        /// </summary>
        [SerializeField]
        [Tooltip("The amplitude of the drifting movement.")]
        private float amplitude = 1F;

        /// <summary>
        /// The frequency of the drifting movement.
        /// </summary>
        [SerializeField]
        [Tooltip("The frequency of the drifting movement.")]
        private float frequency = 1F;

        /// <summary>
        /// The object's rigidbody.
        /// </summary>
        private Rigidbody rb;

        /// <summary>
        /// A random offset between 0 and 1.
        /// This value makes the drift differant from object to object.
        /// </summary>
        private float xOffset;

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
            xOffset = Random.value;
        }

        /// <summary>
        /// Called by Unity every fixed framerate frame. 
        /// </summary>
        private void FixedUpdate() {
            Move(GetDriftMovement());
        }

        /// <summary>
        /// Evaluates for the amount and direction of the drift's movement.
        /// </summary>
        /// <returns>The amount of drift.</returns>
        private float Evaluate() {
            return Mathf.PerlinNoise(Time.time * frequency + xOffset, 0F) * 2F - 1F;
        }

        /// <summary>
        /// The drift's movement.
        /// </summary>
        /// <returns>The movement vector.</returns>
        private Vector3 GetDriftMovement() {
            return amplitude * Evaluate() * direction.normalized;
        }

        /// <summary>
        /// Moves the rigidbody.
        /// </summary>
        /// <param name="movement">The movement vector.</param>
        private void Move(Vector3 movement) {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
    }
}