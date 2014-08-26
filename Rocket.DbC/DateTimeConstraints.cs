// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines contract constraints for <see cref="DateTime" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.DbC
{
	/// <summary>
	/// Defines contract constraints for <see cref="DateTime"/>.
	/// </summary>
	public static class DateTimeConstraints
	{
		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is equal to the property value. If negated not equal to.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<DateTime> EqualTo(this Constraint<DateTime> constraint, DateTime value)
		{
			return StructConstraints.EqualTo(constraint, value);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is greater than or equal to the property value. If negated less than.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<DateTime> Ge(this Constraint<DateTime> constraint, DateTime value)
		{
			return StructConstraints.Ge(constraint, value);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is greater than the property value. If negated less than or equal to.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<DateTime> Gt(this Constraint<DateTime> constraint, DateTime value)
		{
			return StructConstraints.Gt(constraint, value);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is less than or equal to the property value. If negated greater than.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<DateTime> Le(this Constraint<DateTime> constraint, DateTime value)
		{
			return StructConstraints.Le(constraint, value);
		}

		/// <summary>
		/// Evaluates if the specified <see cref="value"/> is less than the property value. If negated greater than or equal to.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="value">The constraint value.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		/// <exception cref="PreConditionException">When the member value is less than the allowed value.</exception>
		public static Operator<DateTime> Lt(this Constraint<DateTime> constraint, DateTime value)
		{
			return StructConstraints.Lt(constraint, value);
		}

		/// <summary>
		/// Evaluates if the specified property value is between the specified bounds. If negated outside the bounds.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="low">The low bound.</param>
		/// <param name="high">The high bound.</param>
		/// <returns>An <see cref="Operator{T}"/> for chaining multiple constraints.</returns>
		public static Operator<DateTime> Between(this Constraint<DateTime> constraint, DateTime low, DateTime high)
		{
			return StructConstraints.Between(constraint, low, high);
		}
	}
}