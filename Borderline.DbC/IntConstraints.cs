// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines contract constraints for <see cref="int" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	/// <summary>
	/// Defines contract constraints for <see cref="int"/>.
	/// </summary>
	public static class IntConstraints
	{
		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is equal to the property value. If negated not equal to.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<int> EqualTo(this Constraint<int> constraint, int value)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value == value;
			}
			else
			{
				predicate = member =>
					member.Value != value;
			}

			return constraint.Evaluate(predicate, exceptionFactory, constraint.Throw);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is greater than or equal to the property value. If negated less than.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<int> Ge(this Constraint<int> constraint, int value)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value >= value;
			}
			else
			{
				predicate = member =>
					member.Value < value;
			}

			return constraint.Evaluate(predicate, exceptionFactory, constraint.Throw);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is greater than the property value. If negated less than or equal to.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<int> Gt(this Constraint<int> constraint, int value)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value > value;
			}
			else
			{
				predicate = member =>
					member.Value <= value;
			}

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is less than or equal to the property value. If negated greater than.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<int> Le(this Constraint<int> constraint, int value)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value <= value;
			}
			else
			{
				predicate = member =>
					member.Value > value;
			}

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is less than the property value. If negated greater than or equal to.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		/// <exception cref="PreConditionException">When the member value is less than the allowed value.</exception>
		public static Operator<int> Lt(this Constraint<int> constraint, int value)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value < value;
			}
			else
			{
				predicate = member =>
					member.Value >= value;
			}

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}

		/// <summary>
		/// Evaluates if the specified property value is between the specified bounds. If negated outside the bounds.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="low">The low bound.</param>
		/// <param name="high">The high bound.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<int> Between(this Constraint<int> constraint, int low, int high)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> constraint.Condition.CreateException(member.Name);

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value >= low && member.Value <= high;
			}
			else
			{
				predicate = member =>
					member.Value < low || member.Value > high;
			}

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}
	}
}