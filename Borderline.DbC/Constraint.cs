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

		// TODO: Refactor
		internal Operator<T> Or(params Operator<T>[] operator1)
		{
			if (operator1 == null || !operator1.Any())
			{
				// TODO: Messsage
				throw new ArgumentException();
			}

			if (!Negate)
			{
				var o = operator1.FirstOrDefault(x => x.Result);

				if (o != null)
				{
					return o;
				}

				throw operator1.First().Exception;
			}

			var oo = operator1.FirstOrDefault(x => !x.Result);

			if (oo != null)
			{
				throw oo.Exception;
			}

			return operator1.First();
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