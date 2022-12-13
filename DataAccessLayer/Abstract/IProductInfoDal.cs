﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Abstract
{
    public interface IProductInfoDal : IRepository<ProductInfo>
    {
    }
}
