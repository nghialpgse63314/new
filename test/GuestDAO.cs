using ProjectC.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectC.DAO
{
    class GuestDAO
    {
        private DBConnection conn;
        DataTable dt;
        SqlCommand cmd;
        public GuestDAO()
        {
            conn = new DBConnection();
            Guest guest = new Guest();
            dt = new DataTable();
            cmd = new SqlCommand();
        }

        private Guest GetGuestFromDataRow(DataRow row)
        {
            Guest guest = new Guest();
            guest.id = int.Parse(row["id"].ToString());
            guest.name = row["name"].ToString().Trim();
            guest.address = row["address"].ToString().Trim();
            guest.phone = int.Parse(row["phone"].ToString());
            guest.roomnumber = int.Parse(row["roomnumber"].ToString());
            guest.roomid = int.Parse(row["roomid"].ToString());
            guest.status = row["status"].ToString().Trim();
            guest.datein = Convert.ToDateTime(row["datein"].ToString());
            guest.dateout = Convert.ToDateTime(row["dateout"].ToString());
            return guest;
        }

        //private Guest GetGuest(DataRow row)
        //{
        //    Guest guest = new Guest();
        //    guest.id = int.Parse(row["id"].ToString());
        //    guest.name = row["name"].ToString().Trim();
        //    guest.address = row["address"].ToString().Trim();
        //    guest.phone = int.Parse(row["phone"].ToString());
        //    guest.roomid = int.Parse(row["roomid"].ToString());

        //    return guest;
        //}




        public List<Guest> GetAll()
        {
            string query = string.Format("select * from Guest,Room where roomid = roomnumber");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = conn.ExecuteSelectQuery(query, sqlParameters);
            List<Guest> list = new List<Guest>();

            foreach (DataRow r in dt.Rows)
            {
                Guest guest = GetGuestFromDataRow(r);
                list.Add(guest);
            }

            return list;
        }





        public bool Add(Guest guest)
        {

            string query = "insert Guest values(@id,@name,@address,@phone,@roomid,@datein,@dateout)";
            SqlParameter[] sqlParameters = new SqlParameter[7];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int) { Value = guest.id };
            sqlParameters[1] = new SqlParameter("@name", SqlDbType.NVarChar) { Value = guest.name };
            sqlParameters[2] = new SqlParameter("@address", SqlDbType.NVarChar) { Value = guest.address };
            sqlParameters[3] = new SqlParameter("@phone", SqlDbType.Int) { Value = guest.phone };
            sqlParameters[4] = new SqlParameter("@roomid", SqlDbType.Int) { Value = guest.roomid };
            sqlParameters[5] = new SqlParameter("@datein", SqlDbType.Date) { Value = guest.datein.Date };
            sqlParameters[6] = new SqlParameter("@dateout", SqlDbType.Date) { Value = guest.dateout.Date };
            try
            {
                conn.ExecuteInsertQuery(query, sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public bool delete(Guest guest)
        {
            string query = "Delete Guest where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int) { Value = guest.id };
            try
            {
                conn.ExecuteUpdateQuery(query, sqlParameters);
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool update(Guest guest)
        {
            string query = "update Guest set roomid = @roomid where id=@id";

            SqlParameter[] sqlParameters = new SqlParameter[2];

            sqlParameters[0] = new SqlParameter("@roomid", SqlDbType.Int) { Value = guest.roomid };
            sqlParameters[1] = new SqlParameter("@id", SqlDbType.Int) { Value = guest.id };
            try
            {
                conn.ExecuteUpdateQuery(query, sqlParameters);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public DataTable Read(int id)
        {
            string query = "select * from Guest where id = @id";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParameters[0].Value = Convert.ToString(id);
            return conn.ExecuteSelectQuery(query, sqlParameters);
        }

      





      

      



    }
}
