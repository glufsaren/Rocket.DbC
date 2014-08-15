// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionConstraints.cs" company="Borderline Studios">
//   Copyright © Borderline Studios. All rights reserved.
// </copyright>
// <summary>
//   Defines the CollectionConstraints type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Borderline.DbC
{
    public static class CollectionConstraints
    {
        public static Member<IEnumerable<T>> Any<T>(this Member<IEnumerable<T>> member)
         {
            if (member.Value == null || !member.Value.Any())
            {
                throw new PreConditionException(member.Name);
            }

             return member;
         }
    }
}