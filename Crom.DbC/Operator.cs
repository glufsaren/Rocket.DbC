// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operator.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Operator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Crom.DbC
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
				return condition;
			}
		}

		internal bool Result { get; set; }

		internal Exception Exception { get; set; }
	}
}