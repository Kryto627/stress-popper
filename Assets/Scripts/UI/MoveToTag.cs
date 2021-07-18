using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace StressPopper {

    public class MoveToTag : MonoBehaviour {

        public string objectTag;
        public float transitionTime;
        public Ease transitionEase;
        public UnityEvent OnComplete;

        private void Start() {
            GameObject targetObject = GameObject.FindGameObjectWithTag(objectTag);
            Vector3 targetPosition = targetObject.transform.position;
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.DOMove(targetPosition, transitionTime).SetEase(transitionEase).onComplete += () => OnComplete.Invoke();
        }
    }
}
