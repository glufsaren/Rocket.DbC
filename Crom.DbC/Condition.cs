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

namespace Crom.DbC
{
	/// <summary>
	/// Base class for the different condition types.
	/// </summary>
	/// <typeparam name="T">The type of the property to evaluate.</typeparam>
	public abstract class Condition<T>
	{
		private readonly List<Member<T>> members = new List<Member<T>>();

		private bool @throw = true;

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
				return new Constraint<T>(this) { Throw = @throw };
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

		/// <summary>
		/// Perform an or evaluation for the specified constraints.
		/// </summary>
		/// <param name="func">The constraints.</param>
		/// <exception cref="System.ArgumentException">When no Constraints specified.</exception>
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