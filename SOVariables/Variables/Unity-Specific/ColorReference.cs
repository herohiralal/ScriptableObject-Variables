using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class ColorReference : SOVariableReference<Color>
    {
        #region Constructors
        public ColorReference() { }
        public ColorReference(Color value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private ColorVariable Variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<Color> base_Variable => Variable;
    }
}