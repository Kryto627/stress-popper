using System.Collections;
using UnityEngine;

namespace StressPopper.Utility {

    /// <summary>
    /// Spawns an object on a timer. 
    /// </summary>
    public class Spawner : MonoBehaviour {

        /// <summary>
        /// The object to spawn.
        /// </summary>
        [SerializeField]
        [Tooltip("The object to spawn.")]
        private GameObject prefab = null;

        /// <summary>
        /// The delay in seconds between object spawns.
        /// </summary>
        [SerializeField]
        [Tooltip("The delay in seconds between object spawns.")]
        private float spawnDelay = 1F;

        /// <summary>
        /// The random spawn position's bounds.  
        /// </summary>
        [SerializeField]
        [Tooltip("The random spawn position's bounds.  ")]
        private Vector3 size = Vector3.zero;

        /// <summary>
        /// Called by Unity after the Awake method.
        /// </summary>
        private void Start() {
            StartCoroutine(SpawnLoop());
        }

        /// <summary>
        /// Loops forever spawning objects on a timer.
        /// </summary>
        private IEnumerator SpawnLoop() {
            while (true) {
                Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
        }

        /// <summary>
        /// Retrieves a random postion from a set bounds.
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
        /// Called by Unity to draw utility graphics in the scene view. 
        /// </summary>
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}