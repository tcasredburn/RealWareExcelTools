using DevExpress.XtraBars;
using DevExpress.XtraLayout;
using RealWareExcelTools.Core.Providers;
using RealWareExcelTools.WinCore.Factory;
using RealWareExcelTools.WinCore.Models.Batch;
using RealWareExcelTools.WinCore.Views.Batch.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealWareExcelTools.WinCore.Views.Batch
{
    public partial class BatchValueBuilder : DevExpress.XtraEditors.XtraUserControl, IScriptDataProvider
    {
        public event EventHandler<bool?> ScriptChangedEvent;

        public IDataProvider DataProvider { get; private set; }

        public IExcelProvider ExcelProvider { get; private set; }

        public IBatchScriptItem[] GetBatchValueItems() => scriptItems.ToArray();

        private PopupMenu popupMenu;
        private List<IBatchScriptItem> scriptItems = new List<IBatchScriptItem>();

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

                    var script = BatchValueScriptFactory.Create(
                        scriptName, 
                        changeValueScript.ApiPath, 
                        !changeValueScript.IsDatabaseOnly, 
                        changeValueScript.ValueType,
                        this);
                    script.ValidateEvent += (sender, isValid) => 
                    {
                        ScriptChangedEvent?.Invoke(this, isValid);
                    };

                    scriptItems.Add(script.BatchItem);

                    var item = new LayoutControlItem();

                    item.Control = script;
                    item.TextVisible = false;
                    item.SizeConstraintsType = SizeConstraintsType.Custom;
                    item.MinSize = script.Size;
                    item.MaxSize = new System.Drawing.Size(0, script.Size.Height);

                    layoutControlGroup1.AddItem(item);

                    ScriptChangedEvent?.Invoke(this, null);

                    script.DeleteScriptEvent += (src, args) =>
                    {
                        link.Visible = true;
                        layoutControlGroup1.Remove(item);
                        layoutControl1.Controls.Remove(script);
                        scriptItems.Remove(script.BatchItem);
                        ScriptChangedEvent?.Invoke(this, null);
                    };
                };
            }
        }
    }
}
