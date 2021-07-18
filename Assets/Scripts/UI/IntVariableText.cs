using StressPopper.Data;
using UnityEngine;
using UnityEngine.UI;

namespace StressPopper.UI {

    [RequireComponent(typeof(Text))]
    public class IntVariableText : MonoBehaviour {

        public IntVariable variable;
        public string prefix;

        private Text text;

        private void Awake() {
            text = GetComponent<Text>();
        }

        private void Update() {
            text.text = $"{prefix}{variable.value}";
        }
    }
}
