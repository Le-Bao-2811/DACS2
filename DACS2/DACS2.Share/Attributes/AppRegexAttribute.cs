using DACS2.Share.Consts;
using System.ComponentModel.DataAnnotations;

namespace DACS2.Share.Attributes
{
    public class AppRegexAttribute : RegularExpressionAttribute
    {
        public AppRegexAttribute(string pattern) : base(pattern)
        {
            ErrorMessage = AttributeErrMesg.REGEX;
        }
    }
}
