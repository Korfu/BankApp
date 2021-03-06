﻿using BankApp.Attributes;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BankApp.Services
{
    public class ExcelService : IExcelService
    {
        public void CreateTemplateFile<T>(string path)
        {
            var excelApplication = new Application();
            var workbook = excelApplication.Workbooks.Add();
            var worksheet = (Worksheet)workbook.Worksheets.get_Item(1);
            foreach (var property in typeof(T).GetProperties())
            {
                var excelAttribute = (ExcelMetadataAttribute)property.GetCustomAttributes(typeof(ExcelMetadataAttribute), true).FirstOrDefault();
                if (excelAttribute != null)
                {
                    worksheet.Cells[excelAttribute.ColumnNumber][1] = excelAttribute.Header;
                }
            }
            workbook.SaveAs(path);
            workbook.Close();
            excelApplication.Quit();
        }

        public IEnumerable<T> GetItemsFromTemplate<T>(string path)
        {
            var excel = new Application();
            var workbook = excel.Workbooks.Open(path);
            var worksheet = workbook.Worksheets.get_Item(1);

            var maxRow = worksheet.UsedRange.Rows.Count;
            var result = new List<T>();
            for (int i = 2; i <= maxRow; i++)
            {
                var model = Activator.CreateInstance<T>();
                foreach (var property in typeof(T).GetProperties())
                {
                    var excelAttribute = (ExcelMetadataAttribute)property.GetCustomAttributes(typeof(ExcelMetadataAttribute), true).FirstOrDefault();
                    if (excelAttribute != null)
                    {
                        var value = worksheet.Cells[excelAttribute.ColumnNumber][i].Value.ToString();
                        if (property.PropertyType == typeof(DateTime))
                        {
                            property.SetValue(model, DateTime.ParseExact(value, "dd/MM/yyyy H:mm:ss", null));
                        }
                        else
                        {
                            property.SetValue(model, Convert.ChangeType(value, property.PropertyType));
                        }
                    }
                }
                result.Add(model);
            }

            workbook.Close();
            excel.Quit();
            return result;
        }
    }

    public interface IExcelService
    {
        void CreateTemplateFile<T>(string path);
        IEnumerable<T> GetItemsFromTemplate<T>(string path);
    }
}
