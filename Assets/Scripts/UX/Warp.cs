using UnityEngine;

namespace StressPopper {

    public class Warp : MonoBehaviour {

        [SerializeField]
        private float amplitude;

        [SerializeField]
        private float minFrequency;

        [SerializeField]
        private float maxFrequency;

        private float frequencyX;
        private float frequencyY;
        private float frequencyZ;

        private void Start() {
            frequencyX = Random.Range(minFrequency, maxFrequency);
            frequencyY = Random.Range(minFrequency, maxFrequency);
            frequencyZ = Random.Range(minFrequency, maxFrequency);
        }

        private void Update() {
            float scaleX = Evaluate(frequencyX);
            float scaleY = Evaluate(frequencyY);
            float scaleZ = Evaluate(frequencyZ);
            Vector3 scale = new Vector3(scaleX, scaleY, scaleZ) * amplitude;
            transform.localScale = Vector3.one + scale;
        }

        private float Evaluate(float frequency) {
            return (Mathf.PerlinNoise(Time.time * frequency, 0F) * 2F) - 1F;
        }
    }
}