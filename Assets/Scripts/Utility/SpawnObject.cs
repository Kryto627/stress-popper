using UnityEngine;

namespace StressPopper {

    public class SpawnObject : MonoBehaviour {

        [SerializeField]
        private GameObject prefab;

        public void Spawn() {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
