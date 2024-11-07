using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using RealWareExcelTools.Core.Providers;
using RealWareExcelTools.WinCore.Factory;
using RealWareExcelTools.WinCore.Models.Batch;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealWareExcelTools.WinCore.Views.Batch
{
    public partial class BatchValueBuilder : DevExpress.XtraEditors.XtraUserControl, IScriptDataProvider
    {
        PopupMenu popupMenu;

        public IDataProvider DataProvider { get; private set; }

        public IExcelProvider ExcelProvider { get; private set; }


        public BatchValueBuilder()
        {
            InitializeComponent();
        }

        public BatchValueBuilder(IDataProvider dataProvider, IExcelProvider excelProvider) : this()
        {
            SetProviders(dataProvider, excelProvider);
        }

        public void SetProviders(IDataProvider dataProvider, IExcelProvider excelProvider)
        {
            this.DataProvider = dataProvider;
            this.ExcelProvider = excelProvider;
        }

        public void InitializeAddScriptDropdown(BarManager barManager, List<ChangeValueScriptInfo> scripts)
        {
            popupMenu = new PopupMenu(barManager);

            dropDownButton1.DropDownControl = popupMenu;

            foreach (var scriptName in scripts.Select(x=>x.ScriptName))
            {
                var changeValueScript = scripts.FirstOrDefault(x => x.ScriptName == scriptName);

                BarButtonItem btn = new BarButtonItem(barManager, scriptName);
                var link = popupMenu.AddItem(btn);

                btn.ItemClick += (s, e) =>
                {
                    link.Visible = false;

                    var script = BatchValueScriptFactory.Create(scriptName, !changeValueScript.IsDatabaseOnly, this);

                    var item = new LayoutControlItem();

                    item.Control = script;
                    item.TextVisible = false;
                    item.SizeConstraintsType = SizeConstraintsType.Custom;
                    item.MinSize = script.Size;
                    item.MaxSize = new System.Drawing.Size(0, script.Size.Height);

                    layoutControlGroup1.AddItem(item);

                    script.DeleteScriptEvent += (src, args) =>
                    {
                        link.Visible = true;
                        layoutControlGroup1.Remove(item);
                        layoutControl1.Controls.Remove(script);
                    };
                };
            }
        }
    }
}
