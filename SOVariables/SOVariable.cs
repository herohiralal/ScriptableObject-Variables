using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    public abstract class SOVariable : ScriptableObject { }

    [Serializable]
    public abstract class SOVariable<T> : SOVariable
    {
        public T Value;

        public void SetValue(T value)
        {
            Value = value;
        }
    }
}