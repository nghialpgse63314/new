using ProjectC.DAO;
using ProjectC.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectC.BLL
{
    class RoomBLL
    {
        private RoomDAO roomDAO;

        public RoomBLL()
        {
            roomDAO = new RoomDAO();
        }

        public List<Room> GetRoomList()
        {
            return roomDAO.GetAll();
        }

        public void insertRoom(int roomnumber, string status)
        {

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new Exception("status is not allow null");
            }
            roomDAO.AddRoom(new Room { roomnumber = roomnumber, status = status });
            
           
        }

        public void UpdateRoom(string status, int roomnumber)
        {      
          
              roomDAO.Update(new Room { status = status, roomnumber = roomnumber });
            
        
        }

        public Room getRoom(int roomnumber)
        {
            Room room = new Room();
            DataTable dataTable = new DataTable();
            dataTable = roomDAO.searchByRoom(roomnumber);

            foreach (DataRow dr in dataTable.Rows)
            {
               
                room.roomnumber = Int32.Parse(dr["roomnumber"].ToString());
                room.status = dr["status"].ToString();
            }
            return room;
        }


        public void deleteRoom(int roomnumber)
        {
            
            roomDAO.delete(new Room { roomnumber = roomnumber });
        }
    }
}
