using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TACShilohDistricts.Core.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IContactUsRepository ContactUs { get; set; }
        Task Save();
        
    }
}
