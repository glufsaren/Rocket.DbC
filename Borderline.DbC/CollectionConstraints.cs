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
                throw new PreconditionException(member.Name);
            }

             return member;
         }
    }
}