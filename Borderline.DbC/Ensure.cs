// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ensure.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Ensure type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Borderline.DbC
{
	public class Ensure
	{
		// TODO: Skall kasta annar fel än Require
		public static Condition<T> That<T>(Expression<Func<T>> memberExpression)
		{
			return new Condition<T>().And(memberExpression);
		}
	}
}