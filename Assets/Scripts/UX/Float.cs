using UnityEngine;

namespace StressPopper.UX {

    [RequireComponent(typeof(Rigidbody))]
    public class Float : MonoBehaviour {

        public float minimumSpeed = 0F;
        public float maximumSpeed = 1F;

        private Rigidbody rb;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        private void Start() {
            SetVelocity(Vector3.up, Random.Range(minimumSpeed, maximumSpeed));
        }

        private void SetVelocity(Vector3 direction, float speed) {
            rb.velocity = direction.normalized * speed;
        }
    }
}