// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectConstraints type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	public static class ObjectConstraints
	{
		public static Operator<object> Null(this Constraint<object> constraint)
		{
			return Null(constraint, true);
		}

		private static Operator<object> Null(this Constraint<object> constraint, bool @throw)
		{
			Func<Member<object>, bool> predicate;
			Func<Member<object>, Exception> exceptionFactory = member
				=> new PreConditionException(member.Name);

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

			return constraint.Evaluate(predicate, exceptionFactory, @throw);
		}
	}
}