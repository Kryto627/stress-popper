using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace StressPopper {

    [RequireComponent(typeof(Slider))]
    public class AudioMixerSlider : MonoBehaviour {

        [SerializeField]
        private AudioMixer audioMixer;

        [SerializeField]
        private string parameterName;

        private Slider slider;

        private void Awake() {
            slider = GetComponent<Slider>();
        }

        private void Start() {
            audioMixer.GetFloat(parameterName, out float volume);
            slider.SetValueWithoutNotify(volume);
        }

        private void OnEnable() {
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDisable() {
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        private void OnValueChanged(float value) {
            audioMixer.SetFloat(parameterName, value);
        }
    }
}
