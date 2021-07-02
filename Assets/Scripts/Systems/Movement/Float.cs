using UnityEngine;

namespace StressPopper.Systems {

    [RequireComponent(typeof(Rigidbody))]
    public class Float : MonoBehaviour {

        [SerializeField]
        private Vector3 direction = Vector3.zero;

        [SerializeField]
        private float speed = 1F;

        private Rigidbody rb;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        private void Start() {
            SetFloatValocity();
        }

        private void SetFloatValocity() {
            rb.velocity = GetValocity();
        }

        private Vector3 GetValocity() {
            return direction.normalized * speed;
        }
    }
}