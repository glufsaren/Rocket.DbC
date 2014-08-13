// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constraint.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Constraint type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;

namespace Borderline.DbC
{
	public class Constraint<T>
	{
		public Constraint(Condition<T> condition, bool negate = false)
		{
			Condition = condition;
			Negate = negate;
		}

		internal bool Negate { get; private set; }

		private Condition<T> Condition { get; set; }

		internal Operator<string> Or(Operator<string> operator1, Operator<string> operator2)
		{
			if (!Negate)
			{
				if (operator1.Result || operator2.Result)
				{
					return operator1;
				}

				throw operator1.Exception;
			}

			if (!operator1.Result)
			{
				throw operator1.Exception;
			}

			if (!operator2.Result)
			{
				throw operator2.Exception;
			}

			return operator1;
		}

		internal Operator<T> Evaluate(
								Func<Member<T>, bool> predicate,
								Func<Member<T>, Exception> exceptionFactory,
								bool @throw = true)
		{
			var @operator = new Operator<T>(Condition);

			var members = Condition.Members.Where(member => !predicate(member));

			foreach (var member in members)
			{
				@operator.Result = false;
				@operator.Exception = exceptionFactory(member);

				if (@throw)
				{
					throw @operator.Exception;
				}

				return @operator;
			}

			@operator.Result = true;

			return @operator;
		}
	}
}