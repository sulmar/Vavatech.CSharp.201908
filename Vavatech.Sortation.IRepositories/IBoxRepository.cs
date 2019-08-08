using System;
using System.Collections.Generic;
using Vavatech.Sortation.Models;

namespace Vavatech.Sortation.IRepositories
{
    public interface IBoxRepository
    {
        List<Box> Get();
    } 
}
