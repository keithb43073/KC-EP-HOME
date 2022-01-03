using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class FileTransferRepository : IFileTransferRepository
    {
        private FileTransferContext context;
        public FileTransferRepository(FileTransferContext _context)
        {
            context = _context;
        }



        // Methods
        public void CreateFileTransfer(FileTransfer fileTransfer)
        {
            context.FileTransfer.Add(fileTransfer);
            context.SaveChanges();
        }
    }
}
