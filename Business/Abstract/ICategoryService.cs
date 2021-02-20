﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();    //tümünü listeler
        Category GetById(int categoryId);   //kategorinin detayına götürür
   
    }
}
