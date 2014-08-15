// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PreconditionException.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the PreconditionException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	[Serializable]
	public class PreconditionException : Exception
	{
		public PreconditionException(string memberName)
			: base(string.Format("Precondition failed for: {0}", memberName))
		{
		}
	}
}