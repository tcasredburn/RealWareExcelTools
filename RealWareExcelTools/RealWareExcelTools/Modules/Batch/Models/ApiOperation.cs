using System.ComponentModel.DataAnnotations;

namespace RealWareExcelTools.Modules.Batch.Models
{
    /// <summary>
    /// Represents the operation to be performed on the API.
    /// </summary>
    public enum ApiOperation
    {
        [Display(Name = "Create new {0}(s)")]
        POST = 0,
        [Display(Name = "Update existing {0}(s)")]
        PUT = 1,
        [Display(Name = "Delete existing {0}(s)")]
        DELETE = 2
    }
}
