using System.Collections;
using UnityEngine;

namespace StressPopper.Utility {

    public class Spawner : MonoBehaviour {

        [SerializeField]
        private GameObject prefab = null;

        [SerializeField]
        private float spawnDelay = 1F;

        [SerializeField]
        private Vector3 size = Vector3.zero;

        private void Start() {
            StartCoroutine(SpawnLoop());
        }

        private IEnumerator SpawnLoop() {
            while (true) {
                Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        private Vector3 GetRandomPosition() {
            float x = Random.Range(0F, size.x);
            float y = Random.Range(0F, size.y);
            float z = Random.Range(0F, size.z);
            Vector3 offset = new Vector3(x, y, z) - size * 0.5F;
            return transform.position + offset;
        }

        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}