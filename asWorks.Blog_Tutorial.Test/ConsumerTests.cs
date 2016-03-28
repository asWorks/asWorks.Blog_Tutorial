using asWorks.Blog_Tutorial.Data;
using asWorks.Blog_Tutorial.Data.Repository;
using asWorks.Blog_Tutorial.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace asWorks.Blog_Tutorial.Test
{
    [TestClass]
    public class ConsumerTests
    {
        private IRepository _repositoy;

        [TestInitialize]
        public void Initialize()
        {
            _repositoy = new BlogRepository();
            //Git - Change

        }
        [TestMethod]
        public void QUeryAllCustomers_NoException()
        {
            var list = _repositoy.All<Customer>();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name {0}", item.CompanyName);
            }
        }

        [TestMethod]
        public void QUeryAllCustomersIncludingOrders_NoException()
        {
            var list = _repositoy.AllIncluding<Customer>(p=>p.Orders).ToList();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name {0}", item.CompanyName);
            }
        }

        [TestMethod]
        public void QUeryAllCustomersCompanyNameANdOrdersCount_NoException()
        {
            var query = _repositoy.AllIncluding<Customer>().Select(s => new { s.CompanyName, s.Orders.Count });

            var list = query.ToList();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name {0}", item.CompanyName);
            }
        }
    }
}
