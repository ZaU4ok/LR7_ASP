using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR7_ASP
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DownloadFile(string firstName, string lastName, string fileName)
        {
            string fileContent = $"Ім'я: {firstName}\nПрізвище: {lastName}";

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "File", "files", $"{fileName}.txt");

            await System.IO.File.WriteAllTextAsync(filePath, fileContent, Encoding.UTF8);

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "text/plain", $"{fileName}.txt");
        }
    }
}
