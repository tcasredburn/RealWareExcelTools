using RealWareExcelTools.Core.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealWareExcelTools.Modules
{
    public class AccountSelectionModule : IRealWareExcelModule
    {
        private readonly ThisAddIn _addIn;

        public AccountSelectionModule(ThisAddIn addIn)
        {
            this._addIn = addIn;
        }

        public void OnStart()
        {
            //throw new NotImplementedException();
        }

        public void OnStop()
        {
            //throw new NotImplementedException();
        }
    }
}
