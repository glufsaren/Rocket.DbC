// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the CollectionConstraints type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Borderline.DbC
{
	/// <summary>
	/// Defines the constraints for collections.
	/// </summary>
	public static class CollectionConstraints
	{
		/// <summary>
		/// Evaluates if a collection is null or empty. If negated collection can't be null or empty.
		/// </summary>
		/// <typeparam name="T">The type of the property to evaluate.</typeparam>
		/// <param name="constraint">The constraint.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<IEnumerable<T>> NullOrEmpty<T>(this Constraint<IEnumerable<T>> constraint)
		{
			constraint.Throw = false;

			return constraint.Or(
				Null(constraint), Empty(constraint));
		}

		/// <summary>
		/// Evaluates if a collection is null. If negated collection can't be null.
		/// </summary>
		/// <typeparam name="T">The type of the property to evaluate.</typeparam>
		/// <param name="constraint">The constraint.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<IEnumerable<T>> Null<T>(this Constraint<IEnumerable<T>> constraint)
		{
			Func<Member<IEnumerable<T>>, bool> predicate;
			Func<Member<IEnumerable<T>>, Exception> exceptionFactory = member
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

		/// <summary>
		/// Evaluates if a collection is empty. If negated collection can't be empty.
		/// </summary>
		/// <typeparam name="T">The type of the property to evaluate.</typeparam>
		/// <param name="constraint">The constraint.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<IEnumerable<T>> Empty<T>(this Constraint<IEnumerable<T>> constraint)
		{
			Func<Member<IEnumerable<T>>, bool> predicate;
			Func<Member<IEnumerable<T>>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value == null || !member.Value.Any();
			}
			else
			{
				predicate = member =>
					member.Value != null && member.Value.Any();
			}

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}
	}
}