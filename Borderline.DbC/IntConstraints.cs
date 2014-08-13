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
		public static Operator<int> EqualTo(this Constraint<int> constraint, int value)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> new PreconditionException(member.Name);

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

			return constraint.Evaluate(predicate, exceptionFactory);
		}

		/// <summary>
		/// Apply a "greater than or equal" constraint to the member value.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="value">The constraint value.</param>
		/// <exception cref="PreconditionException">When the member value is less than the allowed value.</exception>
		public static Operator<int> Ge(this Constraint<int> constraint, int value)
		{
			Func<Member<int>, bool> predicate;
			Func<Member<int>, Exception> exceptionFactory = member
				=> new PreconditionException(member.Name);

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

			return constraint.Evaluate(predicate, exceptionFactory);
		}
		
		/// <summary>
		/// Apply a "greater than" constraint to the member value.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="value">The constraint value.</param>
		/// <exception cref="PreconditionException">When the member value is less than or equal to the allowed value.</exception>
		//public static Operator<int> Gt(this Constraint<int> constraint, int value)
		//{
		//	if (member.Value <= value)
		//		throw new PreconditionException(member.Name);

		//	return member;
		//}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="value">The constraint value.</param>
		/// <exception cref="PreconditionException">When the member value is less than the allowed value.</exception>
		//public static Operator<int> Le(this Constraint<int> constraint, int value)
		//{
		//	if (member.Value > value)
		//		throw new PreconditionException(member.Name);

		//	return member;
		//}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="value">The constraint value.</param>
		/// <exception cref="PreconditionException">When the member value is less than the allowed value.</exception>
		//public static Operator<int> Lt(this Constraint<int> constraint, int value)
		//{
		//	if (member.Value >= value)
		//		throw new PreconditionException(member.Name);

		//	return member;
		//}

		//public static Operator<int> Between(this Constraint<int> constraint, int low, int high)
		//{
		//	if (low >= high)
		//		throw new ArgumentException("Low should be lower than high.");

		//	member.Ge(low);
		//	member.Le(high);

		//	return member;
		//}
	}
}