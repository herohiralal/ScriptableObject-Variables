using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class CharReference : SOVariableReference<char>
    {
        #region Constructors
        public CharReference() { }
        public CharReference(Char value) : base(value) { }
        #endregion

        [Tooltip("Value")] 
        [SerializeField] private CharVariable Variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<Char> base_Variable => Variable;
    }
}