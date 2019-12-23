//@BaseCode
//MdStart
using System;
using System.Collections.Generic;
using CommonBase.Extensions;

namespace MusicStore.Logic.Entities.Persistence
{
    /// <summary>
    /// Implements the properties and methods of artist model.
    /// </summary>
    [Serializable]
    partial class Artist : IdentityObject, Contracts.Persistence.IArtist
    {
        public string Name { get; set; }

		public void CopyProperties(Contracts.Persistence.IArtist other)
		{
            other.CheckArgument(nameof(other));

            Id = other.Id;
			Name = other.Name;
		}

		public IEnumerable<Album> Albums { get; set; }
	}
}
//MdEnd