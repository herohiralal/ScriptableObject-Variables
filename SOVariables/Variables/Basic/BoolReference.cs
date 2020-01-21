using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class BoolReference : SOVariableReference<bool>
    {
        #region Constructors
        public BoolReference() { }
        public BoolReference(bool value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private BoolVariable Variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<bool> base_Variable => Variable;
    }
}