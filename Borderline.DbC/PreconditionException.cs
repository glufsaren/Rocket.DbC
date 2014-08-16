// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PreConditionException.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the PreConditionException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	/// <summary>
	/// Thrown when a precondition is violated.
	/// </summary>
	[Serializable]
	public class PreConditionException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PreConditionException"/> class.
		/// </summary>
		/// <param name="memberName">Name of the member.</param>
		public PreConditionException(string memberName)
			: base(string.Format("Precondition failed for: {0}", memberName))
		{
		}
	}
}