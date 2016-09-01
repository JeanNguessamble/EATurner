using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnerData
{
    public class Title : ITitle
    {
        public IEnumerable<Entity.title> GetList(string keyword)
        {
            IEnumerable<Entity.title> records = null;
            using (Access.TitlesEntities db = new Access.TitlesEntities())
            {
                IEnumerable<Access.Title> result = db.Titles.AsEnumerable();
                if (!string.IsNullOrEmpty(keyword)) result = result.Where(w => w.TitleName.ToLower().Contains(keyword.ToLower()));
                records = result.OrderBy(o => o.TitleName).Select(record => new Entity.title
                {
                    id = record.TitleId,
                    name = record.TitleName,
                    processedDateTime = record.ProcessedDateTimeUTC,
                    releaseYear = record.ReleaseYear,
                    sortable = record.TitleNameSortable,
                    typeId = record.TitleTypeId
                }).ToList();
            }
            return records;
        }
        public IEnumerable<Entity.detail> GetDetail(int id)
        {
            IEnumerable<Entity.detail> records = null;
            using (Access.TitlesEntities db = new Access.TitlesEntities())
            {
                records = db.Titles.Where(w => w.TitleId == id).ToList().Select(record => new Entity.detail
                {
                    movie = new Entity.title
                    {
                        id = record.TitleId,
                        name = record.TitleName,
                        processedDateTime = record.ProcessedDateTimeUTC,
                        releaseYear = record.ReleaseYear,
                        sortable = record.TitleNameSortable,
                        typeId = record.TitleTypeId
                    },
                    awards = getAwards(record.Awards),
                    genre = getGenre(record.TitleGenres),
                    description = getDescription(record.StoryLines),
                    otherNames = getOtherNames(record.OtherNames),
                    participiants = getParticipiants(record.TitleParticipants)
                }).ToList();
            }
            return records;
        }
        private string getDescription(ICollection<Access.StoryLine> records)
        {
            if (records == null || records.Count == 0) return null;
            var record = records.FirstOrDefault();
            return record == null ? null : record.Description;
        }
        private IEnumerable<Entity.participiant> getParticipiants(ICollection<Access.TitleParticipant> records)
        {
            if (records == null || records.Count == 0) return null;
            return records.Where(w => w != null && w.Participant != null && !string.IsNullOrEmpty(w.Participant.Name)).Select(s => new Entity.participiant
            {
                role = s.RoleType,
                name = s.Participant == null ? null : s.Participant.Name
            });
        }
        private IEnumerable<Entity.otherName> getOtherNames(ICollection<Access.OtherName> records)
        {
            if (records == null || records.Count == 0) return null;
            return records.Select(s => new Entity.otherName
            {
                language = s.TitleNameLanguage,
                name = s.TitleName
            });
        }
        private string getGenre(ICollection<Access.TitleGenre> records)
        {
            if (records == null || records.Count == 0) return null;
            var record = records.FirstOrDefault();
            return record == null || record.Genre == null ? null : record.Genre.Name;
        }

        private IEnumerable<Entity.award> getAwards(ICollection<Access.Award> records)
        {
            if (records == null || records.Count == 0) return null;
            return records.OrderByDescending(o => o.AwardYear).Select(s => new Entity.award
            {
                name = s.Award1,
                year = s.AwardYear
            });
        }
    }
}
