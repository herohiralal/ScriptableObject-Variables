using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class CurveReference : SOVariableReference<AnimationCurve>
    {
        #region Constructors
        public CurveReference() { }
        public CurveReference(AnimationCurve value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private CurveVariable variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<AnimationCurve> BaseVariable => variable;
    }
}