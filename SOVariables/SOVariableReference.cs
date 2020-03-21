using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    public abstract class SOVariableReference { }

    [Serializable]
    public abstract class SOVariableReference<T> : SOVariableReference
    {
        // determines whether to use constant or variable
        public bool useConstant;
        
        // constant
        [SerializeField] private T constant;
        // variable
        protected abstract SOVariable<T> BaseVariable { get; }

        // constructors
        protected SOVariableReference() { }
        protected SOVariableReference(T value)
        {
            useConstant = true;
            constant = value;
        }

        // value access
        public T Value
        {
            get => useConstant ? constant : BaseVariable.value;
            set
            {
                if (useConstant || BaseVariable == null) constant = value;
                else BaseVariable.SetValue(value);
            }
        }

        // implicit operator
        public static implicit operator T(SOVariableReference<T> original) => original.Value;

        // add subscriber to value updates
        public void AddListener(Action<T> subscriber)
        { if (BaseVariable != null) BaseVariable.SetValue += subscriber; }
        
        // remove subscriber to value updates
        public void RemoveListener(Action<T> subscriber)
        { if (BaseVariable != null) BaseVariable.SetValue -= subscriber; }
    }
}