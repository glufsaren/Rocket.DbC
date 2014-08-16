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

namespace Borderline.DbC.Test
{
	[TestFixture]
	public class CollectionConstraintsTest
	{
		[Test]
		public void When_1()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).Is.Empty();
		}

		[Test]
		public void When_2()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).Is.Empty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_3()
		{
			var obj = new Test
			{
				Property = new List<string> { "Hello World!" }
			};

			Require.That(() => obj.Property).Is.Empty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_4()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		public void When_5()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		public void When_6()
		{
			var obj = new Test
			{
				Property = new List<string> { "Hello World!" }
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		public void When_7()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).Is.NullOrEmpty();
		}

		[Test]
		public void When_8()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).Is.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_9()
		{
			var obj = new Test
			{
				Property = new List<string> { "Hello World!" }
			};

			Require.That(() => obj.Property).Is.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_10()
		{
			var obj = new
			{
				Property = (IEnumerable<string>)null
			};

			Require.That(() => obj.Property).IsNot.NullOrEmpty();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_11()
		{
			var obj = new
			{
				Property = Enumerable.Empty<string>()
			};

			Require.That(() => obj.Property).IsNot.NullOrEmpty();
		}

		[Test]
		public void When_12()
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