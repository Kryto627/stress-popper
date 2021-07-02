using UnityEngine;

namespace StressPopper.Systems {

    [RequireComponent(typeof(Rigidbody))]
    public class Drift : MonoBehaviour {

        [SerializeField]
        private Vector3 direction = Vector3.zero;

        [SerializeField]
        private float amplitude = 1F;

        [SerializeField]
        private float frequency = 1F;

        private Rigidbody rb;
        private float xOffset;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        private void Start() {
            xOffset = Random.value;
        }

        private void FixedUpdate() {
            Move(GetDriftMovement());
        }

        private float Evaluate() {
            return Mathf.PerlinNoise(Time.time * frequency + xOffset, 0F) * 2F - 1F;
        }

        private Vector3 GetDriftMovement() {
            return amplitude * Evaluate() * direction.normalized;
        }

        private void Move(Vector3 movement) {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
    }
}