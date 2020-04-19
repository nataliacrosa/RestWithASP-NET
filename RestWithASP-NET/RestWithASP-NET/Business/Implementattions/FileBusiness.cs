using System.IO;

namespace RestWithASP_NET.Business.Implementattions
{
    public class FileBusiness : IFileBusiness
    {
        public byte[] GetPDFFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullPath = path + "\\Other\\DiagramaCasoUso.pdf";
            return File.ReadAllBytes(fullPath);
        }
    }
}
