using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TurnerData;

namespace TurnerApi.Controllers
{
    public class TitleController : ApiController
    {
        public IEnumerable<Entity.title> Get()
        {
            return new TurnerData.Title { }.GetList(null);
        }
        public IEnumerable<dynamic> Get(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            int id = ConvertToInt(value);
            if (id > 0) return new TurnerData.Title { }.GetDetail(id);
            else return new TurnerData.Title { }.GetList(value);
        }
        public IEnumerable<Entity.title> Search(string value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            return new TurnerData.Title { }.GetList(value);
        }
        int ConvertToInt(string value)
        {
            int rValue = 0;
            try { rValue = Convert.ToInt32(value); }
            catch { }
            return rValue;
        }
    }
}
