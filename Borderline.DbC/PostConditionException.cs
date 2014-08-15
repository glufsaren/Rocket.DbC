// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostConditionException.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the PostConditionException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	[Serializable]
	public class PostConditionException : Exception
	{
		public PostConditionException(string memberName)
			: base(string.Format("Postcondition failed for: {0}", memberName))
		{
		}
	}
}