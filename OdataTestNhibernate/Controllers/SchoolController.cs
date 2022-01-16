using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using NHibernate;
using OdataTestNhibernate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OdataTestNhibernate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        protected ISession mSession;

        public SchoolController(ISession pSession)
        {
            mSession = pSession;           
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable Get()
        {
            if (!mSession.Query<School>().Any())
            {
                var school = new School
                {
                    Id = Guid.NewGuid(),
                    Name = "Test School"
                };

                var student = new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice",
                };

                mSession.Save(school);
                mSession.Save(student);
                mSession.Flush();
            }

            return mSession.Query<School>();
        }
    }
}
