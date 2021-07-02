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
        private float offset;

        private void Start() {
            frequencyX = Random.Range(minFrequency, maxFrequency);
            frequencyY = Random.Range(minFrequency, maxFrequency);
            frequencyZ = Random.Range(minFrequency, maxFrequency);
            offset = Random.value;
        }

        private void Update() {
            float scaleX = Evaluate(frequencyX, offset);
            float scaleY = Evaluate(frequencyY, offset);
            float scaleZ = Evaluate(frequencyZ, offset);
            Vector3 scale = new Vector3(scaleX, scaleY, scaleZ) * amplitude;
            transform.localScale = Vector3.one + scale;
        }

        private float Evaluate(float frequency, float offset) {
            return Mathf.PerlinNoise(Time.time * frequency + offset, 0F);
        }
    }
}