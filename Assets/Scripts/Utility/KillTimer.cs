using UnityEngine;

namespace StressPopper.Utility {

    [DisallowMultipleComponent]
    public class KillTimer : MonoBehaviour {

        [SerializeField]
        private float time = 1F;

        private void Start() {
            Destroy(gameObject, time);
        }
    }
}
