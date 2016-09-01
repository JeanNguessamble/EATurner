using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnerData
{
    interface ITitle
    {
        IEnumerable<Entity.title> GetList(string keyword);
        IEnumerable<Entity.detail> GetDetail(int id);
    }
}
