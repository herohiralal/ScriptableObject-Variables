﻿using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class GradientReference : SOVariableReference<Gradient>
    {
        #region Constructors
        public GradientReference() { }
        public GradientReference(Gradient value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private GradientVariable variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<Gradient> BaseVariable => variable;
    }
}