using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    public abstract class SOVariable : ScriptableObject { }

    [Serializable]
    public abstract class SOVariable<T> : SOVariable
    {
        public T value;
        public Action<T> SetValue = null;

        private void Awake() => SetValue += UpdateValue;
        private void OnDestroy() => SetValue -= UpdateValue;

        private void UpdateValue(T newValue)
        {
            value = newValue;
        }
    }
}