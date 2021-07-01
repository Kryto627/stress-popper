using UnityEngine;

namespace StressPopper {

    public class Float : MonoBehaviour {

        [SerializeField]
        [Tooltip("The object's rigidbody.")]
        private Rigidbody targetRigidbody = null;

        [SerializeField]
        [Tooltip("The direction the object moves.")]
        private Vector3 direction = Vector3.zero;

        [SerializeField]
        [Tooltip("The speed of the object's movement. X is the minimum speed, Y is the maximum speed.")]
        private Vector2 speedRange = Vector2.zero;

        private void Start() {
            float speed = Random.Range(speedRange.x, speedRange.y);
            Vector3 velocity = direction.normalized * speed;
            targetRigidbody.velocity = velocity;
        }
    }
}