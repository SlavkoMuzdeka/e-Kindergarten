using MySql.Data.MySqlClient;
using Vrtic.Data.DBUtil;
using Vrtic.Data.Exceptions;
using Vrtic.Data.Model;

namespace Vrtic.Data.Wrapper
{
    internal class WrapperGroup
    {
        private static readonly string SELECT = @"SELECT * FROM grupa
                                                  WHERE NazivGrupe LIKE @str";

        private static readonly string INSERT = @"INSERT INTO grupa(NazivGrupe, BrojClanova)
                                                  VALUES (@NazivGrupe, @BrojClanova)";

        private static readonly string UPDATE = @"UPDATE grupa 
                                                  SET NazivGrupe = @NazivGrupe
                                                  WHERE IdGrupe = @IdGrupe";

        private static readonly string UPDATE_NUMBER_OF_MEMBERS = @"UPDATE grupa
                                                                    SET BrojClanova = @BrojClanova
                                                                    WHERE IdGrupe = @IdGrupe";

        private static readonly string DELETE = @"DELETE FROM grupa
                                                  WHERE IdGrupe = @IdGrupe";

        
        public static List<Group> GetGroups(string filter)
        {
            List<Group> result = new List<Group>();
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                cmd.Parameters.AddWithValue("@str", filter + "%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Group(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja grupa.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }

        public static bool InsertGroup(Group group)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            bool t = false;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@NazivGrupe", group.Name);
                cmd.Parameters.AddWithValue("@BrojClanova", group.NumberOfMembers);
                cmd.ExecuteNonQuery();
                group.Id = (int)cmd.LastInsertedId;
                t = true;
            }
            catch(Exception)
            {
                throw new DataAccessException("Greška prilikom kreiranja grupe.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return t;
        }

        public static void UpdateGroup(Group group)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@NazivGrupe", group.Name);
                cmd.Parameters.AddWithValue("@IdGrupe", group.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška ažuriranja naziva grupe.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }
   
        public static void DeleteGroupById(int id)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IdGrupe", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Gršska prilikom brisanja grupe.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }
    
        public static void UpdateNumberOfMembers(int numberOfMembers, int groupId)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_NUMBER_OF_MEMBERS;
                cmd.Parameters.AddWithValue("@BrojClanova", numberOfMembers);
                cmd.Parameters.AddWithValue("@IdGrupe", groupId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom ažuriranja broja clanova grupe.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }
    
    }
}
