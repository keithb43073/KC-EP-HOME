using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels
{
    public class NewFileTransferViewModel
    {
        [Required]
        public string Sender { get; set; }

        [Required]
        public string Reciever { get; set; }

        [Required]
        public string Title { get; set; }

        public string Message { get; set; }

        public string Password { get; set; }
    }
}
