﻿//@BaseCode
//MdStart
using System;

namespace MusicStore.Logic.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    [Serializable]
    internal abstract partial class IdentityObject : Contracts.IIdentifiable
    {
        /// <inheritdoc />
        public virtual int Id { get; set; }
    }
}
//MdEnd