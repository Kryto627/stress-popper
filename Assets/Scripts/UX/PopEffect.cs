using UnityEngine;
using DG.Tweening;

namespace StressPopper.UX {

    public class PopEffect : MonoBehaviour {

        public float scalingSpeed = 0.05F;

        public void Pop() {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(Vector3.one * 2F, scalingSpeed));
            sequence.onComplete += () => Destroy(gameObject);
        }
    }
}