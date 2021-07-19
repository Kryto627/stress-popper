using UnityEngine;

namespace StressPopper.Data {

    public class IncrementIntVariable : MonoBehaviour {

        public IntVariable variable;
        public int amount;

        public void Increment() {
            variable.value += amount;
            Debug.Log($"Incrementing {variable.name} by {amount}.", this);
        }
    }
}
