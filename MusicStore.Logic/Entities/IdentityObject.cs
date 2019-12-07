using System;

namespace MusicStore.Logic.Entities
{
    /// <inheritdoc />
    /// <summary>
    /// Implements the properties and methods of identifiable model.
    /// </summary>
    [Serializable]
	abstract partial class IdentityObject : Contracts.IIdentifiable
    {
        /// <inheritdoc />
        public int Id { get; set; }
    }
}
