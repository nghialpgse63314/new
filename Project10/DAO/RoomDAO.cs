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
    class RoomDAO
    {
        private DBConnection conn;

        public RoomDAO()
        {
            conn = new DBConnection();
            Room roomn = new Room();
        }

        private Room GetRoomFromDataRow(DataRow row)
        {
            Room room = new Room();

            room.roomnumber = int.Parse(row["roomnumber"].ToString());
            room.status = row["status"].ToString().Trim();
            return room;
        }
        public List<Room> GetAll()
        {
            string query = string.Format("select * from Room ");
            SqlParameter[] sqlParameters = new SqlParameter[0];
            DataTable dt = conn.ExecuteSelectQuery(query, sqlParameters);
            List<Room> list = new List<Room>();

            foreach (DataRow r in dt.Rows)
            {
                Room room = GetRoomFromDataRow(r);
                list.Add(room);
            }

            return list;
        }

        public bool AddRoom(Room room)
        {
            string query = "insert Room values(@roomnumber,@status)";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@roomnumber", SqlDbType.Int) { Value = room.roomnumber };
            sqlParameters[1] = new SqlParameter("@status", SqlDbType.NChar) { Value = room.status };
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

        public bool Update(Room room)
        {
            string query = "Update Room set status = @status where roomnumber = @roomnumber";
            SqlParameter[] sqlParameters = new SqlParameter[2];

            sqlParameters[0] = new SqlParameter("@status", SqlDbType.NChar) { Value = room.status };
            sqlParameters[1] = new SqlParameter("@roomnumber", SqlDbType.NVarChar) { Value = room.roomnumber };
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

        public DataTable searchByRoom(int roomnumber)
        {
            string query = "select * from Room where roomnumber = @roomnumber";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@roomnumber", SqlDbType.VarChar);
            sqlParameters[0].Value = Convert.ToString(roomnumber);
            return conn.ExecuteSelectQuery(query, sqlParameters);
        }
        public bool delete(Room room)
        {
            string query = "Delete Room where roomnumber = @roomnumber";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@roomnumber", SqlDbType.Int) { Value = room.roomnumber };
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

    }
}
