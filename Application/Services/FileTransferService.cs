using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class FileTransferService : IFileTransferService
    {
        private IFileTransferRepository filesRepo;
        public FileTransferService(IFileTransferRepository _filesRepo)
        {
            filesRepo = _filesRepo;
        }



        // Methods
        public void CreateFileTransfer(NewFileTransferViewModel model)
        {
            filesRepo.CreateFileTransfer(
                new Domain.Models.FileTransfer()
                {
                    Sender = model.Sender,
                    Reciever = model.Reciever,
                    Title = model.Title,
                    Message = model.Message,
                    Password = model.Password,
                    FileUploadURL = model.FileUploadURL
                });
        }
    }
}
