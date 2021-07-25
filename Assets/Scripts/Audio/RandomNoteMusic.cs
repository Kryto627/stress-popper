using System.Collections;
using UnityEngine;

namespace StressPopper {

    [RequireComponent(typeof(AudioSource))]
    public class RandomNoteMusic : MonoBehaviour {

        [SerializeField]
        private AudioClip[] audioClips;

        [SerializeField]
        private Vector2 waitRange;

        private AudioSource audioSource;

        private void Awake() {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start() {
            StartCoroutine(RandomMusicLoop());
        }

        private IEnumerator RandomMusicLoop() {
            while (true) {
                yield return new WaitForSeconds(Random.Range(waitRange.x, waitRange.y));
               // audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
            }
        }
    }
}
