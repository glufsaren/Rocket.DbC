// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operator.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Operator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Security.Policy;

namespace Rocket.DbC
{
	/// <summary>
	/// Allows chaining of constraints.
	/// </summary>
	/// <typeparam name="T">The type of the property to evaluate.</typeparam>
	public class Operator<T>
	{
		private readonly Condition<T> condition;

		/// <summary>
		/// Initializes a new instance of the <see cref="Operator{T}"/> class.
		/// </summary>
		/// <param name="condition">The condition.</param>
		public Operator(Condition<T> condition)
		{
			this.condition = condition;
		}

		/// <summary>
		/// Gets a <see cref="Condition{T}"/> which allows chaining of constraints.
		/// </summary>
		/// <value>
		/// The <see cref="Condition{T}"/>.
		/// </value>
		public Condition<T> And
		{
			get
			{
				condition.Throw = true;

				return condition;
			}
		}

		internal bool Result { get; set; }

		internal Exception Exception { get; set; }

		/// <summary>
		/// Perform an or evaluation for the specified constraints.
		/// </summary>
		/// <param name="func">The constraints.</param>
		/// <returns>A <see cref="Operator{T}"/> for chaining.</returns>
		/// <exception cref="System.ArgumentException">When no Constraints specified.</exception>
		public Operator<T> Or(params Func<Condition<T>, Operator<T>>[] func)
		{
			if (func == null || !func.Any())
			{
				throw new ArgumentException(
					"No Constraints specified.");
			}

			condition.Throw = false;

			var constraint = new Constraint<T>(condition)
								 {
									 Throw = false
								 };

			constraint.Or(
				func.Select(f => f(condition)).ToArray());

			return this;
		}
	}
}