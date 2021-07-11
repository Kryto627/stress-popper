using UnityEngine;

namespace StressPopper {

    public class SpawnUIObject : MonoBehaviour {

        public GameObject prefab;

        public void SpawnObject() {
            Camera camera = Camera.main;
            Canvas canvas = FindObjectOfType<Canvas>();
            Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
            Instantiate(prefab, screenPosition, Quaternion.identity, canvas.transform);
        }
    }
}
