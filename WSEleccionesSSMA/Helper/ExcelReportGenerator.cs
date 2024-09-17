using ClosedXML.Excel;
using WSEleccionesSSMA.Models;

namespace WSEleccionesSSMA.Helper
{
    public class ExcelReportGenerator
    {
        public MemoryStream GenerarReporteSimple(List<Difusion> Resultado, String NombreHoja)
        {
            int fila = 0;
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(NombreHoja);
                worksheet.Style.Fill.BackgroundColor = XLColor.White;
                worksheet.Cell(2, 2).Value = "Items";
                worksheet.Cell(2, 3).Value = "Numero de Documento";
                worksheet.Cell(2, 4).Value = "Nombre Completo";
                worksheet.Cell(2, 5).Value = "Fecha Registro Padron";

                var headerRange = worksheet.Range("B2:E2");
                headerRange.Style.Font.Bold = true;
                headerRange.Style.Font.FontColor = XLColor.White;
                headerRange.Style.Fill.BackgroundColor = XLColor.Orange;
                headerRange.Style.Alignment.JustifyLastLine = true;
                headerRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                headerRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                worksheet.Rows(2, 2).Height = 28;

                fila = 3;
                int _Fila = fila;
                int Contador = 1;
                foreach (var x in Resultado)
                {
                    worksheet.Cell(fila, 2).Value = Contador;
                    worksheet.Cell(fila, 3).Value = x.NumeroDocumento;
                    worksheet.Cell(fila, 4).Value = x.NombreCompleto;
                    worksheet.Cell(fila, 5).Value = x.FechaRegistroPadron;
                    fila++; Contador++;
                }


                fila = fila-1;
                String Rango = String.Format("B{0}:E{1}", _Fila, fila);
                var _headerRange = worksheet.Range(Rango);              
                _headerRange.Style.Fill.BackgroundColor = XLColor.White;
                _headerRange.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                _headerRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                _headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                _headerRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                _headerRange.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                _headerRange.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                _headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                _headerRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                worksheet.Column("C").Width = 22; 
                worksheet.Column("D").Width = 50;
                worksheet.Column("E").Width = 30;

                var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);
                return stream;
                
            }
        }
    }
}
