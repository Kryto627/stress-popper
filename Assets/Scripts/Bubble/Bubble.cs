using UnityEngine;

namespace StressPopper {

    public class Bubble : MonoBehaviour {

        public void Pop() {
            Destroy(gameObject);
        }
    }
}
