using System;
using UnityEngine;

namespace Hiralal.AdvancedPatterns.ScriptableObjectVariables
{
    [Serializable]
    public class ByteReference : SOVariableReference<byte>
    {
        #region Constructors
        public ByteReference() { }
        public ByteReference(byte value) : base(value) { }
        #endregion

        [Tooltip("Value")]
        [SerializeField] private ByteVariable Variable = null;

        /// <summary>
        /// Property that the base class uses.
        /// </summary>
        protected override SOVariable<byte> base_Variable => Variable;
    }
}