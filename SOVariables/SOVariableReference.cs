using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    public abstract class SOVariableReference { }

    [Serializable]
    public abstract class SOVariableReference<T> : SOVariableReference
    {
        public bool UseConstant;
        [SerializeField] private T Constant;
        protected abstract SOVariable<T> base_Variable { get; }

        public SOVariableReference() { }
        public SOVariableReference(T value)
        {
            UseConstant = true;
            Constant = value;
        }

        public void SetValue(T value)
        {
            if (UseConstant) Constant = value;
            else base_Variable?.SetValue(value);
        }

        public T Value => UseConstant ? Constant : base_Variable.Value;

        public static implicit operator T(SOVariableReference<T> original)
        {
            return original.Value;
        }
    }
}