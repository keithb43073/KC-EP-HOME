using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class FileTransferController : Controller
    {
        // Services
        private IFileTransferService fileTransferService;

        private IWebHostEnvironment hostEnv;

        // Constructor
        public FileTransferController(IFileTransferService _fileTransferService, IWebHostEnvironment _hostEnv)
        {
            fileTransferService = _fileTransferService;
            hostEnv = _hostEnv;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewFileTransferViewModel model, IFormFile sharedFile)
        {
            try
            {
                if (ModelState.IsValid && sharedFile != null)
                {
                    string fileName = Guid.NewGuid() + Path.GetExtension(sharedFile.FileName);

                    // Absolute file Path with file name
                    string filePath = hostEnv.ContentRootPath + "\\Files\\" + fileName;
                    model.FileUploadURL = "\\Files\\" + fileName;

                    using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                    {
                        sharedFile.CopyTo(fs);
                        fs.Close();
                    }

                    //fileTransferService.CreateFileTransfer
                    ViewBag.Message = "File has been uploaded successfully! :D";
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "File was not uploaded successfully...";
            }


            return View();
        }

    }
}
