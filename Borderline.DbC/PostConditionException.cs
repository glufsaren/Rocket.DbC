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
	/// <summary>
	/// Thrown when a postcondition is violated.
	/// </summary>
	[Serializable]
	public class PostConditionException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PostConditionException"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member.</param>
		public PostConditionException(string memberName)
			: base(string.Format("Postcondition failed for: {0}", memberName))
		{
		}
	}
}