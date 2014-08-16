// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostCondition.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the PostCondition type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Borderline.DbC
{
	internal class PostCondition<T> : Condition<T>
	{
		internal override Exception CreateException(string memberName)
		{
			return new PostConditionException(memberName);
		}
	}
}