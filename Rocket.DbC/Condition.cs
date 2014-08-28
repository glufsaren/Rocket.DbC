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

namespace Rocket.DbC
{
	/// <summary>
	/// Base class for the different condition types.
	/// </summary>
	/// <typeparam name="T">The type of the property to evaluate.</typeparam>
	public abstract class Condition<T>
	{
		private readonly List<Member<T>> members = new List<Member<T>>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Condition{T}"/> class.
		/// </summary>
		protected Condition()
		{
			Throw = true;
		}

		/// <summary>
		/// Gets a <see cref="Constraint{T}"/> for evaluation.
		/// </summary>
		/// <value>
		/// The <see cref="Constraint{T}"/>.
		/// </value>
		public Constraint<T> Is
		{
			get
			{
				return new Constraint<T>(this) { Throw = Throw };
			}
		}

		/// <summary>
		/// Gets a negated <see cref="Constraint{T}"/> for evaluation.
		/// </summary>
		/// <value>
		/// The <see cref="Constraint{T}"/>.
		/// </value>
		public Constraint<T> IsNot
		{
			get
			{
				return new Constraint<T>(this, true) { Throw = Throw };
			}
		}

		internal IEnumerable<Member<T>> Members
		{
			get
			{
				return members;
			}
		}

		internal bool Throw { private get; set; }

		/// <summary>
		/// Perform an or evaluation for the specified constraints.
		/// </summary>
		/// <param name="func">The constraints.</param>
		/// <returns>A <see cref="Operator{T}"/> for chaining.</returns>
		/// <exception cref="System.ArgumentException">When no Constraints specified.</exception>
		public Operator<T> Or(params Func<Condition<T>, Operator<T>>[] func)
		{
			var @operator = new Operator<T>(this);

			@operator.Or(func);

			return @operator;
		}

		/// <summary>
		/// Chains multiple properties for evaluation.
		/// </summary>
		/// <param name="memberExpression">The member expression.</param>
		/// <returns>A <see cref="Condition{T}"/> for chaining.</returns>
		/// <exception cref="System.ArgumentNullException">If <see cref="memberExpression"/> is null.</exception>
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

		internal abstract Exception CreateException(string memberName);

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