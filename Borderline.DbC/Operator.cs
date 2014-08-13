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

			////condition.Operator = this;
		}

		public Condition<T> And
		{
			get
			{
				////Type = "AND";

				return condition;
			}
		}

		public bool Result { get; set; }

		public Exception Exception { get; set; }

		////private string Type { get; set; }

		////public members<T> Or
		////{
		////    get
		////    {
		////        Type = "OR";

		////        return condition;
		////    }
		////}

		////internal Member<T> Constraint
		////{
		////	get
		////	{
		////		return condition;
		////	}
		////}
	}
}