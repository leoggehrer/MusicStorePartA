using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Contracts
{
	public interface ICopyable<T>
	{
		void CopyProperties(T other);
	}
}
