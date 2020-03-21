using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class Vector2Reference : SOVariableReference<Vector2>
    {
        #region Constructors
        public Vector2Reference() { }
        public Vector2Reference(Vector2 value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private Vector2Variable variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<Vector2> BaseVariable => variable;
    }
}