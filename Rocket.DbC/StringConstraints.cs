// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the StringConstraints type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Rocket.DbC
{
	/// <summary>
	/// Defines contract constraints for <see cref="string"/>.
	/// </summary>
	public static class StringConstraints
	{
		/// <summary>
		/// Evaluates if a <see cref="string"/> is null or empty. 
		/// If negated the <see cref="string"/> can't be null or empty.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<string> NullOrEmpty(this Constraint<string> constraint)
		{
			constraint.Throw = false;

			return constraint.Or(
				Null(constraint), Empty(constraint));
		}

		/// <summary>
		/// Evaluates if a <see cref="string"/> is empty. If negated the <see cref="string"/> can't be empty.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<string> Empty(this Constraint<string> constraint)
		{
			Func<Member<string>, bool> predicate;

			if (!constraint.Negate)
			{
				predicate = member =>
					IsEmptyOrWhiteSpace(member.Value);
			}
			else
			{
				predicate = member =>
					!IsEmptyOrWhiteSpace(member.Value);
			}

			Func<Member<string>, Exception> exceptionFactory =
				member => new ArgumentException("Precondition failed.", member.Name);

			return constraint.Evaluate(predicate, exceptionFactory, constraint.Throw);
		}

		/// <summary>
		/// Evaluates if a <see cref="string"/> is null. If negated the <see cref="string"/> can't be null.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<string> Null(this Constraint<string> constraint)
		{
			Func<Member<string>, bool> predicate;
			Func<Member<string>, Exception> exceptionFactory;

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value == null;

				exceptionFactory = member =>
					constraint.Condition.CreateException(member.Name);
			}
			else
			{
				predicate = member =>
					member.Value != null;

				exceptionFactory = member =>
					new ArgumentNullException(member.Name);
			}

			return constraint.Evaluate(predicate, exceptionFactory, constraint.Throw);
		}

		/// <summary>
		/// Evaluates if a <see cref="string"/> is equal to a given value. 
		/// If negated the <see cref="string"/> not equal to the given value.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<string> EqualTo(this Constraint<string> constraint, string value)
		{
			Func<Member<string>, bool> predicate = member => member.Value == value;

			if (constraint.Negate)
			{
				predicate = member => member.Value != value;
			}

			return constraint.Evaluate(
				predicate,
				member => constraint.Condition.CreateException(member.Name),
				constraint.Throw);
		}

		private static bool IsEmptyOrWhiteSpace(string value)
		{
			return value != null && (value == string.Empty || value.All(char.IsWhiteSpace));
		}
	}
}