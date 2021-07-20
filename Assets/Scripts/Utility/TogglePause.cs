using UnityEngine;

namespace StressPopper {

    public class TogglePause : MonoBehaviour {

        public void Toggle() {
            if (Time.timeScale == 1F) {
                Time.timeScale = 0F;
            } else {
                Time.timeScale = 1F;
            }
        }
    }
}
