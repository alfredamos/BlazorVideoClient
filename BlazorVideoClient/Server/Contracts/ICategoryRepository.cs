﻿using BlazorVideoClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVideoClient.Server.Contracts
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
    }
}
