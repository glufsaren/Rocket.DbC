// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectConstraintsTest.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectConstraintsTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Rocket.DbC.Test
{
	[TestFixture]
	public class ObjectConstraintsTest
	{
		[Test]
		[ExpectedException(typeof(PostConditionException))]
		public void When_null_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = new object()
			};

			Ensure.That(() => obj.Property).Is.Null();
		}

		[Test]
		public void When_null_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = (object)null
			};

			Require.That(() => obj.Property).Is.Null();
		}

		[Test]
		public void When_null_not_expected_and_fulfilled_expect_no_exception()
		{
			var obj = new
			{
				Property = new object()
			};

			Require.That(() => obj.Property).IsNot.Null();
		}

		[Test]
		[ExpectedException(typeof(PreConditionException))]
		public void When_null_not_expected_and_not_fulfilled_expect_exception()
		{
			var obj = new
			{
				Property = (object)null
			};

			Require.That(() => obj.Property).IsNot.Null();
		}
	}
}