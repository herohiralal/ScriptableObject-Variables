using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class FloatReference : SOVariableReference<float>
    {
        #region Constructors
        public FloatReference() { }
        public FloatReference(float value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private FloatVariable variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<float> BaseVariable => variable;
    }
}