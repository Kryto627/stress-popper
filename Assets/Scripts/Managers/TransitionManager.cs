using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

namespace StressPopper {

    public class TransitionManager : MonoBehaviour {

        public static TransitionManager Instance { private set; get; }

        private CanvasGroup transitionCanvasGroup;

        private void Awake() {
            if (Instance != null) {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start() {
            transitionCanvasGroup = GetComponentInChildren<CanvasGroup>();
        }

        public void StartTransition(string sceneName) {
            var tween = transitionCanvasGroup.DOFade(1F, 1F);
            tween.onComplete += () => OnFadeComplete(sceneName);
        }

        private void OnFadeComplete(string sceneName) {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation operation) {
            transitionCanvasGroup.DOFade(0F, 1F);
        }
    }
}
