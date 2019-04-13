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
    class GuestBLL
    {
        private GuestDAO guestDAO;
        DataTable dt;
        public GuestBLL()
        {
            guestDAO = new GuestDAO();
            dt = new DataTable();
        }

        public List<Guest> GetCustomerList()
        {
            return guestDAO.GetAll();
        }

        public void insertGuest(int id, string name, string address, int phone, int roomid,DateTime datein,DateTime dateout)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new Exception("Id is not allow null");
            }
                guestDAO.Add(new Guest { id = id, name = name, address = address, phone = phone, roomid = roomid,datein = datein,dateout = dateout });
            
        }

        public void updateGuest(int id,DateTime datein, DateTime dateout)
        {
            guestDAO.update(new Guest { id = id ,datein = datein, dateout = dateout });
          
        }

        public void deleteCustomer(int id)
        {
           guestDAO.delete(new Guest { id = id });
        }


        public DataTable GetPersons(int id)
        {
            try
            {
                GuestDAO guestDAO = new GuestDAO();
                return guestDAO.Read(id);
            }
            catch
            {
                throw;
            }
        }

       






    }
}
