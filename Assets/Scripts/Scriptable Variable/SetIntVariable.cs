using UnityEngine;

namespace StressPopper.Data {

    public class SetIntVariable : MonoBehaviour {

        public IntVariable variable;
        public int value;

        private void Start() {
            variable.value = value;
            Debug.Log($"Setting {variable.name}'s value to {value}.", this);
        }
    }
}
