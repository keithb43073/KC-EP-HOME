using Data.Context;
using Domain.Interfaces;
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



    }
}
