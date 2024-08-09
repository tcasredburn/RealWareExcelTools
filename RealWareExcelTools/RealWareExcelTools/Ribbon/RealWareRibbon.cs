using Microsoft.Office.Core;
using System.Runtime.InteropServices;

namespace RealWareExcelTools.Ribbon
{
    [ComVisible(true)]
    public class RealWareRibbon : IRibbonExtensibility
    {
        public string GetCustomUI(string RibbonID)
            => getResourceText("RealWareExcelTools.Ribbon.RealWareRibbon.xml");

        private string getResourceText(string resourceName)
        {
            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    return null;
                }
                using (var reader = new System.IO.StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
