// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the StringConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using NUnit.Framework;

namespace Borderline.DbC.Test
{
	[TestFixture]
	public class StringConstraintsTest
	{
		[TestCase("")]
		[TestCase(" ")]
		public void When_text_is_empty_and_empty_is_required_expect_no_exception(string text)
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
		public void When_text_is_empty_and_not_empty_is_required_expect_exception(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).IsNot.Empty();
		}

		[Test]
		public void When_text_is_not_empty_and_not_empty_is_required_expect_no_exception()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.Empty();
		}

		[Test]
		public void When_1()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).Is.Null();
		}

		[Test]
		[ExpectedException(typeof(PreconditionException))]
		public void When_2()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.Null();
		}

		[Test]
		public void When_3()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.Null();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void When_4()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).IsNot.Null();
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void When_5()
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
		public void When_6(string text)
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
		public void When_7(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).Is.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreconditionException))]
		public void When_8()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.NullOrEmpty();
		}

		[Test]
		public void When_9()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.EqualTo("Hello World!");
		}

		[Test]
		[ExpectedException(typeof(PreconditionException))]
		public void When_10()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).Is.EqualTo("Hej Värld!");
		}

		[Test]
		[ExpectedException(typeof(PreconditionException))]
		public void When_11()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.EqualTo("Hello World!");
		}

		[Test]
		public void When_12()
		{
			var obj = new
			{
				Text = "Hello World!"
			};

			Require.That(() => obj.Text).IsNot.EqualTo("Hej Värld!");
		}

		[Test]
		public void When_And()
		{
			var obj = new
						  {
							  Text = "Hello World!"
						  };

			Require.That(() => obj.Text).IsNot.Null().And.IsNot.Empty();
		}

		[Test]
		public void When_Or()
		{
			var obj = new
			{
				Text = "APA"
			};

			Require.That(() => obj.Text).IsNot.Null().Or(c => c.IsNot.Empty());
		}

		[Test]
		[ExpectedException(typeof(ArgumentNullException))]
		public void When_Or_1()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).IsNot.Null().Or(c => c.IsNot.Empty());
		}

		[TestCase("")]
		[TestCase("  ")]
		[ExpectedException(typeof(ArgumentException))]
		public void When_Or_2(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).IsNot.Null().Or(c => c.IsNot.Empty());
		}

		[TestCase("")]
		[TestCase("  ")]
		public void When_Or_3(string text)
		{
			var obj = new
			{
				Text = text
			};

			Require.That(() => obj.Text).Is.Null().Or(c => c.Is.Empty());
		}

		[Test]
		public void When_Or_4()
		{
			var obj = new
			{
				Text = (string)null
			};

			Require.That(() => obj.Text).Is.Null().Or(c => c.Is.Empty());
		}

		//[TestCase("")]
		//[TestCase(" ")]
		//[ExpectedException(typeof(ArgumentException))]
		//public void When_text_is_empty_expect_exception(string value)
		//{
		//	var obj = new
		//	{
		//		Text = value
		//	};

		//	Require.That(() => obj.Text).IsNotNull().And.IsNotEmpty();
		//}

		////[TestCase("Not")]
		////[ExpectedException(typeof(PreconditionException))]
		////public void When_text_is_not_equal_to_expected_expect_exception(string value)
		////{
		////    var obj = new
		////    {
		////        Text = value
		////    };

		////    Require.That(() => obj.Text).IsEqualTo("Hello").Or.IsEqualTo("World");
		////}

		////[TestCase("Not")]
		////[TestCase("Not not")]
		////[TestCase("not not not")]
		////[TestCase("not not not not")]
		////public void When_text_is_equal_to_expected_expect_no_exception(string value)
		////{
		////    var obj = new
		////    {
		////        Text = value
		////    };

		////    Require.That(() => obj.Text)
		////        .IsEqualTo("Not").Or
		////        .IsEqualTo("Not not").Or
		////        .IsEqualTo("not not not").Or
		////        .IsEqualTo("not not not not");
		////}
	}
}