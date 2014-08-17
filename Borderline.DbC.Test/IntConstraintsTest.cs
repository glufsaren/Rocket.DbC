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
		[Test]
		public void When_equal_expect_no_exception()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).Is.EqualTo(1);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_not_equal_expect_exception()
		{
			var obj = new
			{
				Property = 2
			};

			Require.That(() => obj.Property).Is.EqualTo(1);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_not_equal_expect_no_exception()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).IsNot.EqualTo(1);
		}

		[Test]
		public void When_not_1()
		{
			var obj = new
			{
				Property = 2
			};

			Require.That(() => obj.Property).IsNot.EqualTo(1);
		}

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
		[ExpectedException(typeof(PreConditionException))]
		public void When_value_is_not_greater_than_or_equal_to_ge_constraint()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).Is.Ge(2);
		}

		[TestCase(0)]
		[TestCase(1)]
		[ExpectedException(typeof(PreConditionException))]
		public void When_1(int constraint)
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).IsNot.Ge(constraint);
		}

		[Test]
		public void When_2()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).IsNot.Ge(2);
		}

		[Test]
		public void When_()
		{
			var obj = new
			{
				Property = 5
			};

			Require.That(() => obj.Property).Or(c => c.Is.EqualTo(5), c => c.Is.EqualTo(10));
		}

		[Test]
		public void When_1()
		{
			var obj = new
			{
				Property = 5
			};

			Require.That(() => obj.Property).Or(c => c.Is.EqualTo(5), c => c.IsNot.EqualTo(10));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_value_is_less_than_ge_constraint()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).Is.Gt(2);
		}

		[Test]
		public void When_value_is_less_than_ge_constraint_3()
		{
			var obj = new
			{
				Property = 3
			};

			Require.That(() => obj.Property).Is.Gt(2);
		}

		[Test]
		public void When_value_is_less_than_ge_constraint_2()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).IsNot.Gt(2);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_value_is_less_than_ge_constraint_4()
		{
			var obj = new
			{
				Property = 3
			};

			Require.That(() => obj.Property).IsNot.Gt(2);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_le_a()
		{
			var obj = new
			{
				Property = 2
			};

			Require.That(() => obj.Property).Is.Le(1);
		}

		[TestCase(1)]
		[TestCase(2)]
		public void When_le_b(int value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Le(2);
		}

		[Test]
		public void When_le_c()
		{
			var obj = new
			{
				Property = 2
			};

			Require.That(() => obj.Property).IsNot.Le(1);
		}

		[TestCase(1)]
		[TestCase(2)]
		[ExpectedException(typeof(PreConditionException))]
		public void When_le_d(int value)
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
		public void When_lt_a(int value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Lt(1);
		}

		[Test]
		public void When_lt_b()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).Is.Lt(2);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_lt_c()
		{
			var obj = new
			{
				Property = 1
			};

			Require.That(() => obj.Property).IsNot.Lt(2);
		}

		[TestCase(2)]
		[TestCase(3)]
		public void When_lt_d(int value)
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
		public void When_between_a(int value)
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
		public void When_between_b(int value)
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
		public void When_between_c(int value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Between(1, 3);
		}

		[TestCase(0)]
		[TestCase(4)]
		public void When_between_d(int value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Between(1, 3);
		}
	}
}