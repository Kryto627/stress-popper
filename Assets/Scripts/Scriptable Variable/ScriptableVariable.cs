using UnityEngine;

namespace StressPopper.Data {

    public abstract class ScriptableVariable<T> : ScriptableObject {

        public T value;
    }
}
