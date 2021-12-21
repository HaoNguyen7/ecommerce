using System;
using System.Collections.Generic;
using backend_dotnet_r06_mall.Data;
using backend_dotnet_r06_mall.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet_r06_mall.Services
{
    public class BanHangServices
    {
        private readonly BanHangContext _context;

        public BanHangServices(BanHangContext context)
        {
            _context = context;
        }


    }
}