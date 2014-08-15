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
			Throw = true;
		}

		internal bool Negate { get; private set; }

		internal bool Throw { get; set; }

		private Condition<T> Condition { get; set; }

		// TODO: Refactor
		internal Operator<T> Or(params Operator<T>[] operators)
		{
			if (operators == null || !operators.Any())
			{
				throw new ArgumentException("No Constraints specified.");
			}

			if (!Negate)
			{
				var firstOperator = operators.FirstOrDefault(x => x.Result);

				if (firstOperator != null)
				{
					return firstOperator;
				}

				throw operators.First().Exception;
			}

			var oo = operators.FirstOrDefault(x => !x.Result);

			if (oo != null)
			{
				throw oo.Exception;
			}

			return operators.First();
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