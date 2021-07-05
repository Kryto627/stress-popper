using UnityEngine;
using DG.Tweening;

namespace StressPopper {

    /// <summary>
    /// Handles the popping effect of the bubbles. 
    /// </summary>
    public class PopEffect : MonoBehaviour {

        /// <summary>
        /// The speed of the scaling effect.
        /// </summary>
        [SerializeField]
        [Tooltip("The speed of scaling effect.")]
        private float scalingSpeed = 0.05F;

        /// <summary>
        /// Start the popping effect.
        /// </summary>
        public void Pop() {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(Vector3.one * 2F, scalingSpeed));
            sequence.onComplete += () => Destroy(gameObject);
        }
    }
}