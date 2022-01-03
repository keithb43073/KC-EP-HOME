using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IFileTransferService
    {
        // To implement Methods
        void CreateFileTransfer(NewFileTransferViewModel model);
    }
}
