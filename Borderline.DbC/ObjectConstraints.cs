// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectConstraints type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Crom.DbC
{
	/// <summary>
	/// Defines contract constraints for <see cref="object"/>s.
	/// </summary>
	public static class ObjectConstraints
	{
		/// <summary>
		/// Evaluates if an object is null. If negated object can't be null.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<object> Null(this Constraint<object> constraint)
		{
			Func<Member<object>, bool> predicate;
			Func<Member<object>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value == null;
			}
			else
			{
				predicate = member =>
					member.Value != null;
			}

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}
	}
}