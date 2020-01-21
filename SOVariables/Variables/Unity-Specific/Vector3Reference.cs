using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class Vector3Reference : SOVariableReference<Vector3>
    {
        #region Constructors
        public Vector3Reference() { }
        public Vector3Reference(Vector3 value) : base(value) { }
        #endregion

        [Tooltip("Value")] 
        [SerializeField] private Vector3Variable Variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<Vector3> base_Variable => Variable;
    }
}