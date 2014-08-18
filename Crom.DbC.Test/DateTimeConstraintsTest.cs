// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the DateTimeConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using NUnit.Framework;

namespace Crom.DbC.Test
{
	[TestFixture]
	public class DateTimeConstraintsTest
	{
		private static DateTime[] Low
		{
			get
			{
				return new[]
						{
							new DateTime(2013, 01, 01),
							new DateTime(2014, 01, 01)
						};
			}
		}

		private static DateTime[] High
		{
			get
			{
				return new[]
						{
							new DateTime(2014, 01, 01),
							new DateTime(2014, 01, 02)
						};
			}
		}

		private static DateTime[] Between1
		{
			get
			{
				return new[]
						{
							new DateTime(2014, 01, 01),
							new DateTime(2014, 01, 02),
							new DateTime(2014, 01, 03)
						};
			}
		}

		private static DateTime[] Between2
		{
			get
			{
				return new[]
						{
							new DateTime(2013, 01, 01),
							new DateTime(2014, 01, 04)
						};
			}
		}

		private static DateTime[] Between3
		{
			get
			{
				return new[]
						{
							new DateTime(2014, 01, 02),
							new DateTime(2014, 01, 03)
						};
			}
		}

		[Test]
		public void When_equality_expected_and_equal_expect_no_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).Is.EqualTo(new DateTime(2014, 01, 01));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_equality_expected_and_not_equal_expect_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 02)
			};

			Require.That(() => obj.Property).Is.EqualTo(new DateTime(2014, 01, 01));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_equality_not_expected_and_equal_expect_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).IsNot.EqualTo(new DateTime(2014, 01, 01));
		}

		[Test]
		public void When_equality_not_expected_and_not_equal_expect_no_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 02)
			};

			Require.That(() => obj.Property).IsNot.EqualTo(new DateTime(2014, 01, 01));
		}

		[TestCaseSource("Low")]
		public void When_ge_expected_and_fulfilled_expect_no_exception(DateTime constraint)
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).Is.Ge(constraint);
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_ge_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).Is.Ge(new DateTime(2014, 01, 02));
		}

		[TestCaseSource("Low")]
		[ExpectedException(typeof(PreConditionException))]
		public void When_ge_not_expected_and_not_fulfilled_expect_exception(DateTime constraint)
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).IsNot.Ge(constraint);
		}

		[Test]
		public void When_ge_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).IsNot.Ge(new DateTime(2014, 01, 02));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_gt_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).Is.Gt(new DateTime(2014, 01, 02));
		}

		[Test]
		public void When_gt_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 03)
			};

			Require.That(() => obj.Property).Is.Gt(new DateTime(2014, 01, 02));
		}

		[Test]
		public void When_gt_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).IsNot.Gt(new DateTime(2014, 01, 02));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_gt_not_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 03)
			};

			Require.That(() => obj.Property).IsNot.Gt(new DateTime(2014, 01, 02));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_le_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 02)
			};

			Require.That(() => obj.Property).Is.Le(new DateTime(2014, 01, 01));
		}

		[TestCaseSource("High")]
		public void When_le_expected_and_fulfilled_expect_no_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Le(new DateTime(2014, 01, 02));
		}

		[TestCaseSource("High")]
		public void When_le_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = 2
			};

			Require.That(() => obj.Property).IsNot.Le(1);
		}

		[TestCaseSource("High")]
		[ExpectedException(typeof(PreConditionException))]
		public void When_le_not_expected_and_not_fulfilled_expect_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Le(new DateTime(2014, 01, 02));
		}

		[TestCaseSource("High")]
		[ExpectedException(typeof(PreConditionException))]
		public void When_lt_expected_and_not_fulfilled_expect_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Lt(new DateTime(2014, 01, 01));
		}

		[Test]
		public void When_lt_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).Is.Lt(new DateTime(2014, 01, 02));
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_lt_not_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = new DateTime(2014, 01, 01)
			};

			Require.That(() => obj.Property).IsNot.Lt(new DateTime(2014, 01, 02));
		}

		[TestCaseSource("Between3")]
		public void When_lt_not_expected_and_fulfilled_expect_no_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Lt(new DateTime(2014, 01, 02));
		}

		[TestCaseSource("Between1")]
		public void When_between_expected_and_fulfilled_expect_no_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Between(new DateTime(2014, 01, 01), new DateTime(2014, 01, 03));
		}

		[TestCaseSource("Between2")]
		[ExpectedException(typeof(PreConditionException))]
		public void When_between_expected_and_not_fulfilled_expect_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).Is.Between(new DateTime(2014, 01, 01), new DateTime(2014, 01, 03));
		}

		[TestCaseSource("Between1")]
		[ExpectedException(typeof(PreConditionException))]
		public void When_between_not_expected_and_not_fulfilled_expect_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Between(new DateTime(2014, 01, 01), new DateTime(2014, 01, 03));
		}

		[TestCaseSource("Between2")]
		public void When_between_not_expected_and_fulfilled_expect_no_exception(DateTime value)
		{
			var obj = new
			{
				Property = value
			};

			Require.That(() => obj.Property).IsNot.Between(new DateTime(2014, 01, 01), new DateTime(2014, 01, 03));
		}
	}
}