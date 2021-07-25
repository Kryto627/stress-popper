using UnityEngine;

namespace StressPopper {

    [RequireComponent(typeof(AudioSource))]
    public class RandomAudioClip : MonoBehaviour {

        [SerializeField]
        private AudioClip[] sounds;

        private AudioSource audioSource;

        private void Awake() {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
        }
    }
}
