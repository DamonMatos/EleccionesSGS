using System.Data;

namespace WSEleccionesSSMA.Helper
{
    public class ArchivosIO
    {
        public String UploadFile(IFormFile file,String _File)
        {
            String Folder = Path.GetDirectoryName(_File);
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            using (var stream = new FileStream(_File, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Folder;
        }

        public async Task<string> UploadFiles(IFormFile _IFormFile, String _File)
        {
            String Folder = Path.GetDirectoryName(_File);
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }

            using (var stream = new FileStream(_File, FileMode.Create))
            {
                await _IFormFile.CopyToAsync(stream);
            }
            return Folder;
        }

        //public void ReadStream(String filePath)
        //{
        //    using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        using (var reader = ExcelReaderFactory.CreateReader(stream))
        //        {
        //            var result = reader.AsDataSet();

        //            // Examples of data access
        //            DataTable table = result.Tables[0];
        //            DataRow row = table.Rows[0];
        //            string cell = row[0].ToString();
        //        }
        //    }

        //}         

    }
}
