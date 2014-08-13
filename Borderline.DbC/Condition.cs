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
using System.Linq.Expressions;

namespace Borderline.DbC
{
	public class Condition<T>
	{
		private readonly List<Member<T>> members = new List<Member<T>>();

		public Constraint<T> Is
		{
			get
			{
				return new Constraint<T>(this);
			}
		}

		public Constraint<T> IsNot
		{
			get
			{
				return new Constraint<T>(this, true);
			}
		}

		internal IEnumerable<Member<T>> Members
		{
			get
			{
				return members;
			}
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