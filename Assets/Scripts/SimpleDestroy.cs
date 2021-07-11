using UnityEngine;

namespace StressPopper.Utility {

    public class SimpleDestroy : MonoBehaviour {

        public void DestroyObject() {
            Destroy(gameObject);
        }
    }
}