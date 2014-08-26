// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Require.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Require type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Rocket.DbC
{
	/// <summary>
	/// Use <see cref="Require"/> for validation of Postconditions.
	/// </summary>
	public static class Require
	{
		public static Condition<T> That<T>(Expression<Func<T>> memberExpression)
		{
			return new PreCondition<T>().And(memberExpression);
		}
	}
}