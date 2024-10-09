﻿using System.Collections.Generic;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;

namespace RealWareExcelTools.Controller
{
    /// <summary>
    /// Handles excel operations and features.
    /// </summary>
    public class ExcelController
    {
        private readonly ThisAddIn _addIn;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelController"/> class.
        /// </summary>
        public ExcelController(ThisAddIn addIn)
        {
            _addIn = addIn;
        }

        public void CreateNewSheet(string workSheetName, DataTable data)
        {
            if(_addIn.Application.Workbooks.Count == 0)
                _addIn.Application.Workbooks.Add();

            Excel.Worksheet newWorksheet = _addIn.Application.Worksheets.Add();
            newWorksheet.Name = workSheetName;

            if(data == null)
                newWorksheet.Cells[1, 1] = "No results found";
            else
                insertDataTableValuesToWorksheet(data, newWorksheet);

            // Autofit the columns
            newWorksheet.Columns.AutoFit();
        }

        public List<string> GetSheetNames()
        {
            var worksheetNames = new List<string>();
            foreach (Excel.Worksheet sheet in _addIn.Application.Worksheets)
                worksheetNames.Add(sheet.Name);
            return worksheetNames;
        }

        private void insertDataTableValuesToWorksheet(DataTable dataTable, Excel.Worksheet worksheet)
        {
            // Add column headers
            for (int col = 0; col < dataTable.Columns.Count; col++)
                worksheet.Cells[1, col + 1] = dataTable.Columns[col].ColumnName;

            // Add rows
            for (int row = 0; row < dataTable.Rows.Count; row++)
                for (int col = 0; col < dataTable.Columns.Count; col++)
                    worksheet.Cells[row + 2, col + 1] = dataTable.Rows[row][col];
        }
    }
}
