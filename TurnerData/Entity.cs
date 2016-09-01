using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnerData
{
    [Serializable]
    public class Entity
    {
        public class title
        {
            public int id { get; set; }
            public string name { get; set; }
            public string sortable { get; set; }
            public int? typeId { get; set; }
            public int? releaseYear { get; set; }
            internal DateTime? processedDateTime { get; set; }
            public string processedDate { get { return processedDateTime == null || !processedDateTime.HasValue ? null : processedDateTime.Value.ToShortDateString(); } }
            public string processedTime { get { return processedDateTime == null || !processedDateTime.HasValue ? null : processedDateTime.Value.ToShortTimeString(); } }
        }
        public class genre
        {
            public string name { get; set; }
        }
        public class participiant
        {
            public string name { get; set; }
            public string role { get; set; }
        }
        public class award
        {
            public int? year { get; set; }
            public string name { get; set; }
        }
        public class otherName
        {
            public string name { get; set; }
            public string language { get; set; }
        }
        public class detail
        {
            public title movie { get; set; }
            public string genre { get; set; }
            public string description { get; set; }
            public IEnumerable<award> awards { get; set; }
            public IEnumerable<otherName> otherNames { get; set; }
            public IEnumerable<participiant> participiants { get; set; }
        }
    }
}
