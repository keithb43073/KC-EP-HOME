﻿using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    // Main advantage of interface; they allow flexibility in a well-designed application
    public interface IBlogsService
    {
        // To implement Methods
        public IQueryable<BlogViewModel> GetBlogs();
        public BlogViewModel GetBlog(int id);
        public void AddBlog(AddBlogViewModel model);
        public void DeleteBlog(int id);
        public void UpdateBlog(AddBlogViewModel editedDetails, int id);
    }
}
