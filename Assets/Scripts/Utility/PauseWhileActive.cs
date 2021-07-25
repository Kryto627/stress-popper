using UnityEngine;

namespace StressPopper {

    public class PauseWhileActive : MonoBehaviour {

        private void OnEnable() {
            Time.timeScale = 0F;
        }

        private void OnDisable() {
            Time.timeScale = 1F;
        }
    }
}
