using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class FileTransferService : IFileTransferService
    {
        private IFileTransferRepository blogsRepo;
        public FileTransferService(IFileTransferRepository _blogsRepo)
        {
            blogsRepo = _blogsRepo;
        }



        // Methods



    }
}
