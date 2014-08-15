// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Condition.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Condition type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Borderline.DbC
{
	public class Condition<T>
	{
		private readonly List<Member<T>> members = new List<Member<T>>();

		private bool @throw = true;

		public Constraint<T> Is
		{
			get
			{
				return new Constraint<T>(this) { Throw = @throw };
			}
		}

		public Constraint<T> IsNot
		{
			get
			{
				return new Constraint<T>(this, true) { Throw = @throw };
			}
		}

		internal IEnumerable<Member<T>> Members
		{
			get
			{
				return members;
			}
		}

		public void Or(params Func<Condition<T>, Operator<T>>[] func)
		{
			if (func == null || !func.Any())
			{
				throw new ArgumentException("No Constraints specified.");
			}

			@throw = false;

			var constraint = new Constraint<T>(this) { Throw = false };

			constraint.Or(
				func.Select(f => f(this)).ToArray());
		}

		public Condition<T> And(Expression<Func<T>> memberExpression)
		{
			if (memberExpression == null)
			{
				throw new ArgumentNullException("memberExpression");
			}

			var member = CreateMember(memberExpression);

			members.Add(member);

			return this;
		}

		private static Member<T> CreateMember(Expression<Func<T>> memberExpression)
		{
			if (!(memberExpression.Body is MemberExpression))
			{
				throw new InvalidOperationException();
			}

			var memberExpressionBody = (MemberExpression)memberExpression.Body;

			return new Member<T>
			{
				Name = memberExpressionBody.Member.Name,
				Value = memberExpression.Compile().Invoke()
			};
		}
	}
}