using System.Collections;
using UnityEngine;

namespace StressPopper.Utility {

    /// <summary>
    /// Spawns objects in a zone after a delay.
    /// </summary>
    public class Spawner : MonoBehaviour {

        /// <summary>
        /// The object that spawns.
        /// </summary>
        [SerializeField]
        [Tooltip("The object that spawns.")]
        private GameObject prefab = null;

        /// <summary>
        /// The spawn delay in seconds.
        /// </summary>
        [SerializeField]
        [Tooltip("The spawn delay in seconds.")]
        private float spawnDelay = 1F;

        /// <summary>
        /// The zone's size the object spawn within.
        /// </summary>
        [SerializeField]
        [Tooltip("The zone's size the object spawn within.")]
        private Vector3 size = Vector3.zero;

        /// <summary>
        /// Called by Unity after the Awake method.
        /// </summary>
        private void Start() {
            StartCoroutine(SpawnLoop());
        }

        /// <summary>
        /// Loops and spawns objects after a set delay.
        /// </summary>
        private IEnumerator SpawnLoop() {
            while (true) {
                Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        /// <summary>
        /// Retrieves a random position within the zone.
        /// </summary>
        /// <returns>The random position.</returns>
        private Vector3 GetRandomPosition() {
            float x = Random.Range(0F, size.x);
            float y = Random.Range(0F, size.y);
            float z = Random.Range(0F, size.z);
            Vector3 offset = new Vector3(x, y, z) - size * 0.5F;
            return transform.position + offset;
        }

        /// <summary>
        /// Called bu Unity to draw a utility guidelines.
        /// </summary>
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}