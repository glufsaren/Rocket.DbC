// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Require.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Require type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;

namespace Borderline.DbC
{
	public static class Require
	{
		public static Condition<T> That<T>(Expression<Func<T>> memberExpression)
		{
			return new Condition<T>().And(memberExpression);
		}
	}
}