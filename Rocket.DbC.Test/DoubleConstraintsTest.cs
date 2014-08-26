// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DoubleConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the DoubleConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rocket.DbC.Test
{
	[TestFixture]
	public class DoubleConstraintsTest
	{
		[TestCase(5)]
		[TestCase(10)]
		public void When_equality_expected_with_or_and_equal_expect_no_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Or(c => c.Is.EqualTo(5), c => c.Is.EqualTo(10));
		}

		[Test]
		public void When_equality_not_expected_with_or_and_no_equality_expect_no_exception()
		{
			var obj = new
			{
				Property = 5d
			};

			Require.That(() => obj.Property).Or(c => c.Is.EqualTo(5), c => c.IsNot.EqualTo(10));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_equality_not_expected_with_or_and_equality_expect_exception()
		{
			var obj = new
			{
				Property = 10d
			};

			Require.That(() => obj.Property).Or(c => c.Is.EqualTo(5), c => c.IsNot.EqualTo(10));
		}

		[Test]
		public void When_equality_expected_and_equal_expect_no_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).Is.EqualTo(1);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_equality_expected_and_not_equal_expect_exception()
		{
			var obj = new
			{
				Property = 2d
			};

			Require.That(() => obj.Property).Is.EqualTo(1);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_equality_not_expected_and_equal_expect_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).IsNot.EqualTo(1);
		}

		[Test]
		public void When_equality_not_expected_and_not_equal_expect_no_exception()
		{
			var obj = new
			{
				Property = 2d
			};

			Require.That(() => obj.Property).IsNot.EqualTo(1);
		}

		[TestCase(0)]
		[TestCase(1)]
		public void When_ge_expected_and_fulfilled_expect_no_exception(double constraint)
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).Is.Ge(constraint);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_ge_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).Is.Ge(2);
		}

		[TestCase(0)]
		[TestCase(1)]
		[ExpectedException(typeof(PreConditionException))]
		public void When_ge_not_expected_and_not_fulfilled_expect_exception(double constraint)
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).IsNot.Ge(constraint);
		}

		[Test]
		public void When_ge_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).IsNot.Ge(2);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_gt_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).Is.Gt(2);
		}

		[Test]
		public void When_gt_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = 3d
			};

			Require.That(() => obj.Property).Is.Gt(2);
		}

		[Test]
		public void When_gt_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).IsNot.Gt(2);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_gt_not_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = 3d
			};

			Require.That(() => obj.Property).IsNot.Gt(2);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_le_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = 2d
			};

			Require.That(() => obj.Property).Is.Le(1);
		}

		[TestCase(1)]
		[TestCase(2)]
		public void When_le_expected_and_fulfilled_expect_no_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Le(2);
		}

		[Test]
		public void When_le_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = 2d
			};

			Require.That(() => obj.Property).IsNot.Le(1);
		}

		[TestCase(1)]
		[TestCase(2)]
		[ExpectedException(typeof(PreConditionException))]
		public void When_le_not_expected_and_not_fulfilled_expect_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Le(2);
		}

		[TestCase(1)]
		[TestCase(2)]
		[ExpectedException(typeof(PreConditionException))]
		public void When_lt_expected_and_not_fulfilled_expect_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Lt(1);
		}

		[Test]
		public void When_lt_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).Is.Lt(2);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_lt_not_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = 1d
			};

			Require.That(() => obj.Property).IsNot.Lt(2);
		}

		[TestCase(2)]
		[TestCase(3)]
		public void When_lt_not_expected_and_fulfilled_expect_no_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Lt(2);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		public void When_between_expected_and_fulfilled_expect_no_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Between(1, 3);
		}

		[TestCase(0)]
		[TestCase(4)]
		[ExpectedException(typeof(PreConditionException))]
		public void When_between_expected_and_not_fulfilled_expect_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Between(1, 3);
		}

		[TestCase(1)]
		[TestCase(2)]
		[TestCase(3)]
		[ExpectedException(typeof(PreConditionException))]
		public void When_between_not_expected_and_not_fulfilled_expect_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Between(1, 3);
		}

		[TestCase(0)]
		[TestCase(4)]
		public void When_between_not_expected_and_fulfilled_expect_no_exception(double value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Between(1, 3);
		}
	}
}