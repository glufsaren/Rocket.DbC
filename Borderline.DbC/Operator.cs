// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operator.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Operator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	public class Operator<T>
	{
		private readonly Condition<T> condition;

		public Operator(Condition<T> condition)
		{
			this.condition = condition;
		}

		public Condition<T> And
		{
			get
			{
				return condition;
			}
		}

		public bool Result { get; set; }

		public Exception Exception { get; set; }

		public void Or(Func<Condition<T>, Operator<T>> func)
		{
			var operator1 = this;
			var operator2 = func(condition);


		}
	}
}