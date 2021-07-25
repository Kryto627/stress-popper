using UnityEngine;

namespace StressPopper {

    public class SceneLoader : MonoBehaviour {

        public void LoadScene(string sceneName) {
            TransitionManager.Instance.StartTransition(sceneName);
        }
    }
}
