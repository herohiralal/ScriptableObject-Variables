﻿using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class IntegerReference : SOVariableReference<int>
    {
        #region Constructors
        public IntegerReference() { }
        public IntegerReference(int value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private IntegerVariable variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<int> BaseVariable => variable;
    }
}