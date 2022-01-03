using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
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

                    fileTransferService.CreateFileTransfer(model);
                    IRestResponse irr = SendSimpleMessage();
                    ViewBag.Message = "File has been uploaded successfully! :D";
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "File was not uploaded successfully...";
            }

            return View();
        }



        public static IRestResponse SendSimpleMessage()
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");

            client.Authenticator = new HttpBasicAuthenticator("api", "ab598f3e1d0ef34a5d18758c3608c489-0be3b63b-8e180a03");

            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox20ae1a06d288434d8468343b2754247f.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandbox20ae1a06d288434d8468343b2754247f.mailgun.org>");
            request.AddParameter("to", "keithcami43@gmail.com");
            request.AddParameter("subject", "Find your file now!");
            request.AddParameter("text", "Email sent by mailgun, ez game!");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}
