// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the IntConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace Borderline.DbC.Test
{
	[TestFixture]
	public class IntConstraintsTest
	{
		[TestCase(0)]
		[TestCase(1)]
		public void When_value_is_greater_than_or_equal_to_ge_constraint(int constraint)
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).Is.Ge(constraint);
		}

		[Test]
		[ExpectedException(typeof(PreconditionException))]
		public void When_value_is_not_greater_than_or_equal_to_ge_constraint()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).Is.Ge(2);
		}

	//	[Test]
	//	[ExpectedException(typeof(PreconditionException))]
	//	public void When_value_is_less_than_ge_constraint()
	//	{
	//		Require.That(() => new { Id = 1 }.Id).Ge(2);
	//	}

	//	[Test]
	//	public void When_value_is_greater_than_gt_constraint()
	//	{
	//		Require.That(() => new { Id = 1 }.Id).Gt(0);
	//	}

	//	[TestCase(1)]
	//	[TestCase(2)]
	//	[ExpectedException(typeof(PreconditionException))]
	//	public void When_value_is_less_than_or_equal_to_gt_constraint(int constraint)
	//	{
	//		Require.That(() => new { Id = 1 }.Id).Gt(constraint);
	//	}

	//	[TestCase(1)]
	//	[TestCase(2)]
	//	public void When_value_is_less_than_or_equal_to_le_constraint(int constraint)
	//	{
	//		Require.That(() => new { Id = 1 }.Id).Le(constraint);
	//	}

	//	[Test]
	//	[ExpectedException(typeof(PreconditionException))]
	//	public void When_value_is_greater_than_lge_constraint()
	//	{
	//		Require.That(() => new { Id = 2 }.Id).Le(1);
	//	}

	//	[Test]
	//	public void When_value_is_less_than_lt_constraint()
	//	{
	//		Require.That(() => new { Id = 0 }.Id).Lt(1);
	//	}

	//	[TestCase(0)]
	//	[TestCase(1)]
	//	[ExpectedException(typeof(PreconditionException))]
	//	public void When_value_is_greater_than_or_equal_to_lt_constraint(int constraint)
	//	{
	//		Require.That(() => new { Id = 1 }.Id).Lt(constraint);
	//	}

	//	[TestCase(1, 1)]
	//	[TestCase(2, 1)]
	//	[ExpectedException(typeof(ArgumentException))]
	//	public void When_bounds_are_invalid_for_between_constraint(int low, int high)
	//	{
	//		Require.That(() => new { Id = 0 }.Id).Between(low, high);
	//	}

	//	[Test]
	//	public void When_value_is_between_between_constraint()
	//	{
	//		Require.That(() => new { Id = 2 }.Id).Between(2, 3);
	//	}

	//	[Test]
	//	[ExpectedException(typeof(PreconditionException))]
	//	public void When_value_is_not_between_between_constraint()
	//	{
	//		Require.That(() => new { Id = 4 }.Id).Between(2, 3);
	//	}

	//	[Test]
	//	public void When_chaining_constraints()
	//	{
	//		Require.That(() => new { Id = 2 }.Id).Ge(2).Le(3);
	//	}
	}
}