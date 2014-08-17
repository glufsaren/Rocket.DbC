// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the StructConstraints type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	internal static class StructConstraints
	{
		public static Operator<T> EqualTo<T>(Constraint<T> constraint, dynamic value)
		{
			Func<Member<T>, bool> predicate;
			Func<Member<T>, Exception> exceptionFactory = member
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

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}

		public static Operator<T> Ge<T>(Constraint<T> constraint, dynamic value)
		{
			Func<Member<T>, bool> predicate;
			Func<Member<T>, Exception> exceptionFactory = member
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

			return constraint.Evaluate(
				predicate, exceptionFactory, constraint.Throw);
		}

		public static Operator<T> Gt<T>(Constraint<T> constraint, dynamic value)
		{
			Func<Member<T>, bool> predicate;
			Func<Member<T>, Exception> exceptionFactory = member
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

		public static Operator<T> Le<T>(this Constraint<T> constraint, dynamic value)
		{
			Func<Member<T>, bool> predicate;
			Func<Member<T>, Exception> exceptionFactory = member
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

		public static Operator<T> Lt<T>(this Constraint<T> constraint, dynamic value)
		{
			Func<Member<T>, bool> predicate;
			Func<Member<T>, Exception> exceptionFactory = member
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

		public static Operator<T> Between<T>(this Constraint<T> constraint, dynamic low, dynamic high)
		{
			Func<Member<T>, bool> predicate;
			Func<Member<T>, Exception> exceptionFactory = member
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