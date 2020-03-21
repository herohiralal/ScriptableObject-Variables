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
        [SerializeField] private ColorVariable variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<Color> BaseVariable => variable;
    }
}