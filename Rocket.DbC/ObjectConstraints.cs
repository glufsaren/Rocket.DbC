// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the ObjectConstraints type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Rocket.DbC
{
    /// <summary>
    /// Defines contract constraints for <see cref="object"/>s.
    /// </summary>
    public static class ObjectConstraints
    {
        /// <summary>
        /// Evaluates if an object is null. If negated object can't be null.
        /// </summary>
        /// <typeparam name="T">The type to null check.</typeparam>
        /// <param name="constraint">The constraint.</param>
        /// <returns>
        /// An <see cref="Operator{T}" /> for chaining multiple constraints.
        /// </returns>
        public static Operator<T> Null<T>(this Constraint<T> constraint) where T : class
        {
            Func<Member<T>, bool> predicate;
            Func<Member<T>, Exception> exceptionFactory;

            if (!constraint.Negate)
            {
                predicate = member =>
                    member.Value == null;

                exceptionFactory = member =>
                    constraint.Condition.CreateException(member.Name);
            }
            else
            {
                predicate = member =>
                    member.Value != null;

                exceptionFactory = member =>
                    new ArgumentNullException(member.Name);
            }

            return constraint.Evaluate(predicate, exceptionFactory, constraint.Throw);
        }
    }
}