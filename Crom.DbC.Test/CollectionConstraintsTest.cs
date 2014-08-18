// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the CollectionConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Crom.DbC.Test
{
	[TestFixture]
	public class CollectionConstraintsTest
	{
		[Test]
		public void When_empty_expected_and_null_expect_no_exception()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).Is.Empty();
		}

		[Test]
		public void When_empty_expected_and_empty_expect_no_exception()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).Is.Empty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_empty_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new Test
			{
				Property = new List<string> { "Hello World!" }
			};

			Require.That(() => obj.Property).Is.Empty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_not_null_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		public void When_not_null_expected_and_empty_expect_no_exception()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		public void When_not_null_expected_and_not_empty_expect_no_exception()
		{
			var obj = new Test
			{
				Property = new List<string> { "Hello World!" }
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		public void When_null_or_empty_expected_and_null_expect_no_exception()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).Is.NullOrEmpty();
		}

		[Test]
		public void When_null_or_empty_expected_and_empty_expect_no_exception()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).Is.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_null_or_empty_expected_and_not_empty_expect_exception()
		{
			var obj = new Test
			{
				Property = new List<string> { "Hello World!" }
			};

			Require.That(() => obj.Property).Is.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_null_or_empty_not_expected_and_null_expect_exception()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).IsNot.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_null_or_empty_not_expected_and_empty_expect_exception()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).IsNot.NullOrEmpty();
		}

		[Test]
		public void When_null_or_empty_not_expected_and_not_empty_expect_no_exception()
		{
			var obj = new Test
			{
				Property = new List<string> { "Hello World!" }
			};

			Require.That(() => obj.Property).IsNot.NullOrEmpty();
		}

		private class Test
		{
			public IEnumerable<string> Property { get; set; }
		}
	}
}