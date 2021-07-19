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

        /*private void Start() {
            StartCoroutine(KillAfterSoundEffect());
        }

        private IEnumerator KillAfterSoundEffect() {
            audioSource.clip = sounds[Random.Range(0, sounds.Length)];
            audioSource.Play();
            yield return new WaitUntil(() => !audioSource.isPlaying);
            Destroy(gameObject);
        }*/
    }
}
