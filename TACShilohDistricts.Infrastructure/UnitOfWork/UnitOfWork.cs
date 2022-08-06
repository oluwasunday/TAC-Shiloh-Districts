using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TACShilohDistricts.Core.IRepositories;

namespace TACShilohDistricts.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IContactUsRepository _contactUs;

        public IContactUsRepository ContactUs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
