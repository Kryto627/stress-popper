using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace StressPopper {

    public class TweenSequence : MonoBehaviour {

        [SerializeField]
        private TweenElement[] elements;

        [SerializeField]
        private bool playOnStart = false;

        [SerializeField]
        private bool loop = false;

        [SerializeField]
        private UnityEvent OnSequenceComplete;

        private Sequence sequence;

        private void Start() {
            sequence = DOTween.Sequence();
            foreach (TweenElement element in elements) {
                if (element.SequenceType == SequenceType.APPEND) {
                    sequence.Append(element.GetTween(gameObject)); 
                } else if (element.SequenceType == SequenceType.JOIN) {
                    sequence.Join(element.GetTween(gameObject));
                }
            }
            sequence.onComplete += () => OnSequenceComplete.Invoke();
            if (!playOnStart) {
                sequence.Pause(); 
            }

            if (loop) {
                sequence.SetLoops(int.MaxValue);
            }
        }

        public void Play() {
            sequence.Restart();
            sequence.Play();
        }
    }

    [System.Serializable]
    public class TweenElement {

        [SerializeField]
        private TweenElementType actionType = TweenElementType.MOVE;

        [SerializeField]
        private SequenceType sequenceType = SequenceType.APPEND;

        [SerializeField]
        private Vector3 target = Vector3.one;

        [SerializeField]
        private float time = 1F;

        [SerializeField]
        private Ease ease = Ease.Unset;

        public SequenceType SequenceType => sequenceType;

        public Tween GetTween(GameObject gameObject) {
            if (actionType == TweenElementType.MOVE) {
                return gameObject.transform.DOMove(target, time).SetEase(ease);
            } else if (actionType == TweenElementType.LOCAL_MOVE) {
                return gameObject.transform.DOLocalMove(target, time).SetEase(ease);
            } else if (actionType == TweenElementType.ROTATE) {
                return gameObject.transform.DORotate(target, time).SetEase(ease);
            } else if (actionType == TweenElementType.SCALE) {
                return gameObject.transform.DOScale(target, time).SetEase(ease);
            }

            return null;
        }
    }

    public enum TweenElementType {
        MOVE, LOCAL_MOVE, ROTATE, SCALE
    }

    public enum SequenceType {
        APPEND, JOIN, 
    }
}