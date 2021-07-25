using UnityEngine;

namespace StressPopper {

    public class ToggleGameObject : MonoBehaviour {

        [SerializeField]
        private GameObject targetObject;

        public void Toggle() {
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}