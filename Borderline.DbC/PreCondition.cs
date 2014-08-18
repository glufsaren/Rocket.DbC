// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PreCondition.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the PreCondition type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Crom.DbC
{
	internal class PreCondition<T> : Condition<T>
	{
		internal override Exception CreateException(string memberName)
		{
			return new PreConditionException(memberName);
		}
	}
}