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

namespace Borderline.DbC
{
	public static class StringConstraints
	{
		public static Operator<string> NullOrEmpty(this Constraint<string> constraint)
		{
			return constraint.Or(
				Null(constraint, false), Empty(constraint, false));
		}

		public static Operator<string> Empty(this Constraint<string> constraint)
		{
			return Empty(constraint, true);
		}

		public static Operator<string> Null(this Constraint<string> constraint)
		{
			return Null(constraint, true);
		}

		public static Operator<string> EqualTo(this Constraint<string> constraint, string value)
		{
			Func<Member<string>, bool> predicate = member => member.Value == value;

			if (constraint.Negate)
			{
				predicate = member => member.Value != value;
			}

			return constraint.Evaluate(predicate, member => new PreconditionException(member.Name));
		}

		private static Operator<string> Null(this Constraint<string> constraint, bool @throw)
		{
			Func<Member<string>, bool> predicate;
			Func<Member<string>, Exception> exceptionFactory;

			if (!constraint.Negate)
			{
				predicate = member =>
					member.Value == null;

				exceptionFactory = member =>
					new PreconditionException(member.Name);
			}
			else
			{
				predicate = member =>
					member.Value != null;

				exceptionFactory = member =>
					new ArgumentNullException(member.Name);
			}

			return constraint.Evaluate(predicate, exceptionFactory, @throw);
		}

		private static Operator<string> Empty(this Constraint<string> constraint, bool @throw)
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

			return constraint.Evaluate(predicate, exceptionFactory, @throw);
		}

		private static bool IsEmptyOrWhiteSpace(string value)
		{
			return value != null && (value == string.Empty || value.All(char.IsWhiteSpace));
		}
	}
}