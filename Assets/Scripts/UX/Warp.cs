using UnityEngine;
using DG.Tweening;

namespace StressPopper {

    /// <summary>
    /// Warps the object's scale on the Y axis on a loop.
    /// </summary>
    public class Warp : MonoBehaviour {

        /// <summary>
        /// The axis the object's scale get warped.
        /// </summary>
        [SerializeField]
        [Tooltip("The axis the object's scale get warped.")]
        private Vector3 warpAxis;

        /// <summary>
        /// The amount the object is warped.
        /// </summary>
        [SerializeField]
        [Tooltip("The amount the object is warped.")]
        private float warpAmount;

        /// <summary>
        /// The time in seconds it takes to warp the object.
        /// </summary>
        [SerializeField]
        [Tooltip("The time in seconds to take to warp the object.")]
        private float warpTime;

        /// <summary>
        /// Called by Unity after the Awake method.
        /// </summary>
        private void Start() {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(Vector3.one + (warpAxis * warpAmount), warpTime));
            sequence.SetLoops(int.MaxValue, LoopType.Yoyo);
        }
    }
}