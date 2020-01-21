using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class LayerMaskReference : SOVariableReference<LayerMask>
    {
        #region Constructors
        public LayerMaskReference() { }
        public LayerMaskReference(LayerMask value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private LayerMaskVariable Variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<LayerMask> base_Variable => Variable;
    }
}