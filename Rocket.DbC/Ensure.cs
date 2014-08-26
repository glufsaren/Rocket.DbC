// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ensure.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Ensure type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Rocket.DbC
{
	/// <summary>
	/// Use <see cref="Ensure"/> for validation of Postconditions.
	/// </summary>
	public static class Ensure
	{
		/// <summary>
		/// Projects the property that should be used for Precondition checks.
		/// </summary>
		/// <typeparam name="T">The type of the property to check.</typeparam>
		/// <param name="memberExpression">The member expression.</param>
		/// <returns>A <see cref="Condition{T}"/> enabling chaining of multiple properties.</returns>
		public static Condition<T> That<T>(Expression<Func<T>> memberExpression)
		{
			return new PostCondition<T>().And(memberExpression);
		}
	}
}