// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace Borderline.DbC.Test
{
	[TestFixture]
	public class ObjectConstraintsTest
	{
		[Test]
		[ExpectedException(typeof(PostConditionException))]
		public void When_an_object_expected_to_be_null_is_not_expect_postcondition_exception()
		{
			var obj = new
			{
				Property = new object()
			};

			Ensure.That(() => obj.Property).Is.Null();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_an_object_expected_to_be_null_is_not_expect_precondition_exception()
		{
			var obj = new
			{
				Property = new object()
			};

			Require.That(() => obj.Property).Is.Null();
		}

		[Test]
		public void When_2()
		{
			var obj = new
			{
				Property = (object)null
			};

			Require.That(() => obj.Property).Is.Null();
		}

		[Test]
		public void When_3()
		{
			var obj = new
			{
				Property = new object()
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_4()
		{
			var obj = new
			{
				Property = (object)null
			};

			Require.That(() => obj.Property).IsNot.Null();
		}
	}
}