using UnityEngine;

namespace StressPopper.Utility {

    [DisallowMultipleComponent]
    public class KillTimer : MonoBehaviour {

        public float time = 1F;

        private void Start() {
            Destroy(gameObject, time);
        }
    }
}
