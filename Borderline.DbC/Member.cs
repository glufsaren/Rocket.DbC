// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Member.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the Member type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Borderline.DbC
{
	public class Member<T>
	{
		public string Name { get; set; }

		public T Value { get; set; }
	}
}