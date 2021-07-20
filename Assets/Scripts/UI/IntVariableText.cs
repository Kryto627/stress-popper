using StressPopper.Data;
using UnityEngine;
using TMPro;

namespace StressPopper.UI {

    [RequireComponent(typeof(TMP_Text))]
    public class IntVariableText : MonoBehaviour {

        public IntVariable variable;
        public string prefix;

        private TMP_Text text;

        private void Awake() {
            text = GetComponent<TMP_Text>();
        }

        private void Update() {
            text.SetText($"{prefix}{variable.value}");
        }
    }
}
