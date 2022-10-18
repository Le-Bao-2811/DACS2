using DACS2.Share.Consts;
using System.ComponentModel.DataAnnotations;

namespace DACS2.Share.Attributes
{
    public class AppRequiredAttribute : RequiredAttribute
    {
        public AppRequiredAttribute() : base()
        {
            ErrorMessage = AttributeErrMesg.REQUIRED;
        }
    }
}
