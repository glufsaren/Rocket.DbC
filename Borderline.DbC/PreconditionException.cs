using System;

namespace Borderline.DbC
{
    public class PreconditionException : Exception
    {
        public PreconditionException(string memberName)
            : base(string.Format("Precondition failed for: {0}", memberName))
        {
        }
    }
}