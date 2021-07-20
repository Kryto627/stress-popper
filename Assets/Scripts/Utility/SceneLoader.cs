using UnityEngine;
using UnityEngine.SceneManagement;

namespace StressPopper {

    public class SceneLoader : MonoBehaviour {

        public void LoadScene(string sceneName) {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
