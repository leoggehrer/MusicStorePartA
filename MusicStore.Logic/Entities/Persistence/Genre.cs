//@DomainCode
//MdStart
using System;
using System.Collections.Generic;
using CommonBase.Extensions;

namespace MusicStore.Logic.Entities.Persistence
{
    /// <summary>
    /// Implements the properties and methods of genre model.
    /// </summary>
    [Serializable]
    partial class Genre : IdentityObject, Contracts.Persistence.IGenre
    {
        public string Name { get; set; }

		public void CopyProperties(Contracts.Persistence.IGenre other)
		{
            other.CheckArgument(nameof(other));

            Id = other.Id;
			Name = other.Name;
		}

		public IEnumerable<Track> Tracks { get; set; }
	}
}
//MdEnd