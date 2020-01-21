using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class StringReference : SOVariableReference<string>
    {
        #region Constructors
        public StringReference() { }
        public StringReference(string value) : base(value) { }
        #endregion

        [Tooltip("Value")] 
        [SerializeField] private StringVariable Variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<string> base_Variable => Variable;
    }
}