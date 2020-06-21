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
        public IEnumerable<ROOM> GetRoomByTitle(int price,string location,string typeRoom,int page, int pageSize)
        {
            int type_int = -1;
            IQueryable<ROOM> model = db.ROOMs;
            if (price != 0)
            {
                model = model.Where(x => x.price == price);
            }
            else if(!string.IsNullOrEmpty(location))
            {
                model = model.Where(x => x.address.ToLower().Contains(location.ToLower()));
            }
            else if(!string.IsNullOrEmpty(typeRoom))
            {
                model = model.Where(x => x.TYPEROOM.name.ToLower().Contains(typeRoom.ToLower()));
            }
            else if( price != 0 && !string.IsNullOrEmpty(location))
            {
                model = model.Where(x => x.price == price && x.address.ToLower().Contains(location.ToLower()));
            }
            else if(price != 0 && !string.IsNullOrEmpty(typeRoom))
            {
                model = model.Where(x => x.price == price && x.TYPEROOM.name.ToLower().Contains(typeRoom.ToLower()));
            }
            else if(!string.IsNullOrEmpty(typeRoom) && !string.IsNullOrEmpty(location))
            {
                model = model.Where(x => x.address.ToLower().Contains(location.ToLower()) && x.TYPEROOM.name.ToLower() == typeRoom.ToLower());
            }
            else if(price != 0 && !string.IsNullOrEmpty(location) && !string.IsNullOrEmpty(typeRoom))
            {
                model = model.Where(x => x.price == price && x.address.ToLower().Contains(location.ToLower()) && x.TYPEROOM.name.ToLower().Contains(typeRoom.ToLower()));
            }
           
            return model.OrderByDescending(x => x.createdate).ToPagedList(page, pageSize);
        }

    }
}
