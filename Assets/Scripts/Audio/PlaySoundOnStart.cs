using UnityEngine;

namespace StressPopper {

    [RequireComponent(typeof(AudioSource))]
    public class PlaySoundOnStart : MonoBehaviour {

        private AudioSource audioSource;

        private void Awake() {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start() {
            audioSource.Play();
        }
    }
}
