using UnityEngine;
using DG.Tweening;

namespace StressPopper.UX {

    public class Warp : MonoBehaviour {

        public Vector3 warpAxis;
        public float warpAmount;
        public float warpTime;

        private void Start() {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(Vector3.one + warpAxis * warpAmount, warpTime));
            sequence.SetLoops(int.MaxValue, LoopType.Yoyo);
        }
    }
}