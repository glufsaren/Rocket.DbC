// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the StringConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Crom.DbC;

using NUnit.Framework;

namespace Borderline.DbC.Test
{
	[TestFixture]
	public class StringConstraintsTest
	{
		[TestCase("")]
		[TestCase(" ")]
		public void When_empty_expected_and_fulfilled_expect_no_exception(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).Is.Empty();
		}

		[TestCase("")]
		[TestCase(" ")]
		[ExpectedException(typeof(ArgumentException))]
		public void When_empty_not_expected_and_not_fulfilled_expect_exception(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).IsNot.Empty();
		}

		[Test]
		public void When_empty_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.Empty();
		}

		[Test]
		public void When_null_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).Is.Null();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_null_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.Null();
		}

		[Test]
		public void When_null_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.Null();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void When_null_not_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).IsNot.Null();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void When_null_or_empty_not_expected_and_null_expect_exception()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).IsNot.NullOrEmpty();
		}

		[TestCase("")]
		[TestCase("  ")]
		[ExpectedException(typeof(ArgumentException))]
		public void When_null_or_empty_not_expected_and_empty_expect_exception(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).IsNot.NullOrEmpty();
		}

		[TestCase(null)]
		[TestCase("")]
		[TestCase("  ")]
		public void When_null_or_empty_expected_and_fulfilled_expect_no_exception(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).Is.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_null_or_empty_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.NullOrEmpty();
		}

		[Test]
		public void When_equal_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.EqualTo("Hello World!");
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_equal_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.EqualTo("Hej Värld!");
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_equal_not_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.EqualTo("Hello World!");
		}

		[Test]
		public void When_equal_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.EqualTo("Hej Värld!");
		}

		[Test]
		public void When_chaining_string_constraints_with_and_expect_no_exception()
		{
			var obj = new { Text = "Hello World!" };

			Require.That(() => obj.Text).IsNot.Null().And.IsNot.Empty();
		}

		[Test]
		public void When_property_have_to_be_not_null_or_not_empty_and_is_not_empty_expect_no_exception()
		{
			var obj = new { Text = "Hello World!" };

			Require.That(() => obj.Text).Or(c => c.IsNot.Null(), c => c.IsNot.Empty());
		}

		[Test]
		public void When_property_have_to_be_not_null_or_not_empty_and_is_null_expect_no_exception()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).Or(c => c.IsNot.Null(), c => c.IsNot.Empty());
		}

		[TestCase("")]
		[TestCase("  ")]
		public void When_property_have_to_be_not_null_or_not_empty_and_is_empty_expect_no_exception(string text)
		{
			var obj = new { Text = text };

			Require.That(() => obj.Text).Or(c => c.IsNot.Null(), c => c.IsNot.Empty());
		}

		[TestCase("")]
		[TestCase("  ")]
		public void When_property_have_to_be_null_or_not_empty_and_is_empty_expect_no_exception(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).Or(c => c.Is.Null(), c => c.Is.Empty());
		}

		[Test]
		public void When_property_have_to_be_null_or_not_empty_and_is_null_expect_no_exception()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).Or(c => c.Is.Null(), c => c.Is.Empty());
		}
	}
}