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
	/// <summary>
	/// Encapsulates information used for evaluating constraints.
	/// </summary>
	/// <typeparam name="T">The type of the property to evaluate.</typeparam>
	public class Constraint<T>
	{
		internal Constraint(Condition<T> condition, bool negate = false)
		{
			Condition = condition;
			Negate = negate;
			Throw = true;
		}

		internal bool Negate { get; private set; }

		internal bool Throw { get; set; }

		internal Condition<T> Condition { get; private set; }

		internal Operator<T> Or(params Operator<T>[] operators)
		{
			if (operators == null || !operators.Any())
			{
				throw new ArgumentException("No Constraints specified.");
			}

			return !Negate
				? EvaluateOperators(operators)
				: EvaluateNegatedOperators(operators);
		}

		internal Operator<T> Evaluate(
								Func<Member<T>, bool> predicate,
								Func<Member<T>, Exception> exceptionFactory,
								bool @throw)
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

		private static Operator<T> EvaluateOperators(Operator<T>[] operators)
		{
			var @operator = operators.FirstOrDefault(o => o.Result);

			if (@operator != null)
			{
				return @operator;
			}

			throw operators.First().Exception;
		}

		private static Operator<T> EvaluateNegatedOperators(Operator<T>[] operators)
		{
			var @operator = operators.FirstOrDefault(o => !o.Result);

			if (@operator != null)
			{
				throw @operator.Exception;
			}

			return operators.First();
		}
	}
}