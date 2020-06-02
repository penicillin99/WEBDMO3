using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class RoomDAO
    {
        // create connection string
        WebDbContext db = null;
        
        public RoomDAO()
        {
            // init connection string
            db = new WebDbContext();
        }

        // Slect with title room and sort with crate date


            // lấy ra danh sách phòng theo cái title truyền vào

            // lay ra 1 list chứa title thỏa mản
        public IEnumerable<ROOM> GetRoomByTitle(string title,int page, int pageSize)
        {
            IQueryable<ROOM> model = db.ROOMs;
            if (!string.IsNullOrEmpty(title))
            {
                model = model.Where(x => x.title.Contains(title));
            }

            return model.OrderByDescending(x => x.createdate).ToPagedList(page, pageSize);
        }

    }
}
