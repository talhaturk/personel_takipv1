using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip
{
    public class ExcellAktar
    {
        public void ExcellAktarma(DataGridView dgw)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "Excell Dosyaları";
            save.DefaultExt = "xlsx";
            save.Filter = "xlsx Dosyaları (*.xlsx)|*.xlsx|Tüm Dosyalar(*.*)|*.*";

            if(save.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sayfa1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Excel Dışa Aktarım";
                for (int i = 1; i < dgw.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dgw.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dgw.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgw.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgw.Rows[i].Cells[j].Value.ToString();
                    }
                }
                workbook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();
            }
        }
        
    }
}
