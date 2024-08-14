using RealWareExcelTools.Core.Modules;
using RealWareExcelTools.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWareExcelTools.Modules
{
    public class ListBuilderImportModule : IRealWareExcelModule
    {
        private readonly ThisAddIn _addIn;

        public ListBuilderImportModule(ThisAddIn addIn)
        {
            this._addIn = addIn;
        }

        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void OnRefreshSettings(AddinSettings addinSettings)
        {

        }
    }
}
