using MySql.Data.MySqlClient;
using Vrtic.Data.DBUtil;
using Vrtic.Data.Exceptions;
using Vrtic.Data.Model;

namespace Vrtic.Data.Wrapper
{

    internal class WrapperChild
    {
        private static readonly string SELECT =
            @"SELECT d.Osoba_IdOsobe, JMB, Ime, Prezime, DatumRodjenja, Adresa, d.Visina, d.Tezina
              FROM dijete d
              INNER JOIN osoba o ON o.IdOsobe = d.OSOBA_IdOsobe
              WHERE JMB LIKE @str OR Ime LIKE @str OR Prezime LIKE @str OR Adresa LIKE @str";

        private static readonly string SELECT_FROM_GROUP =
            @"SELECT d.Osoba_IdOsobe, JMB, Ime, Prezime, DatumRodjenja, Adresa, d.Visina, d.Tezina
              FROM dijete d
              INNER JOIN osoba o ON o.IdOsobe = d.OSOBA_IdOsobe
              INNER JOIN dijete_has_grupa dg ON d.OSOBA_IdOsobe = dg.DIJETE_OSOBA_IdOsobe
              WHERE GRUPA_IdGrupe = @IdGrupe";

        private static readonly string INSERT =
            @"INSERT INTO dijete
              VALUES (@IdDjeteta, @Visina, @Tezina)";

        private static readonly string INSERT_INTO_GROUP =
            @"INSERT INTO dijete_has_grupa
              VALUES (@IdOsobe, @IdGrupe)";

        private static readonly string UPDATE =
            @"UPDATE dijete
              SET Visina = @Visina, Tezina = @Tezina
              WHERE Osoba_IdOsobe = @Id";

        private static readonly string DELETE =
            @"DELETE FROM dijete
              WHERE Osoba_IdOsobe = @Id";

        private static readonly string DELETE_FROM_GROUP =
            @"DELETE FROM dijete_has_grupa
              WHERE DIJETE_OSOBA_IdOsobe = @IdOsobe AND GRUPA_IdGrupe = @IdGrupe";

        public static List<Child> GetChildren(string filter)
        {
            List<Child> result = new List<Child>();
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader? reader = null;

            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                cmd.Parameters.AddWithValue("@str", filter + "%");
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Child(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetDateTime(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7)));
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja djece.");
            }
            finally
            {
                if(reader != null && conn != null)
                {
                    MySqlUtil.CloseQuietly(reader, conn);
                }
            }
            return result;
        }

        public static void InsertChild(Child child)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                int personId = WrapperPerson.InsertPerson(new Person(child.JMB, child.FirstName, child.LastName,
                                    child.DateOfBirth, child.Address));
                child.Id = personId;
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@IdDjeteta", child.Id);
                cmd.Parameters.AddWithValue("@Visina", child.Height);
                cmd.Parameters.AddWithValue("@Tezina", child.Weight);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom dodavanja djeteta.");
            }
            finally
            {
                if(conn != null)
                {
                    MySqlUtil.CloseQuietly(conn);
                }
            }
        }

        public static void UpdateChild(Child child)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                WrapperPerson.UpdatePerson(new Person(child.Id, child.JMB, child.FirstName, child.LastName, child.DateOfBirth, child.Address));

                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@Visina", child.Height);
                cmd.Parameters.AddWithValue("@Tezina", child.Weight);
                cmd.Parameters.AddWithValue("@Id", child.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom ažuriranja podataka.");
            }
            finally
            {
                if(conn != null)
                {
                    MySqlUtil.CloseQuietly(conn);
                }
            }
        }
    
        public static void DeleteChildById(int id)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom brisanja podataka.");
            }
            finally
            {
                if(conn != null)
                {
                    MySqlUtil.CloseQuietly(conn);
                }
            }
        }
    
        public static List<Child> GetChildrenFromGroup(int groupId)
        {
            List<Child> result = new List<Child>();
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader? reader = null;

            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_FROM_GROUP;
                cmd.Parameters.AddWithValue("@IdGrupe", groupId);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Child(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetDateTime(4), reader.GetString(5), reader.GetInt32(6), reader.GetInt32(7)));
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja djece iz grupe.");
            }
            finally
            {
                if(reader != null && conn != null)
                {
                    MySqlUtil.CloseQuietly(reader, conn);
                }
            }
            return result;
        }

        public static void DeleteChildFromGroup(int childId, int groupId)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_FROM_GROUP;
                cmd.Parameters.AddWithValue("@IdOsobe", childId);
                cmd.Parameters.AddWithValue("@IdGrupe", groupId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom brisanja djeteta iz grupe.");
            }
            finally
            {
                if(conn != null)
                {
                    MySqlUtil.CloseQuietly(conn);
                }
            }
        }

        public static void InsertChildIntoGroup(int userId, int groupId, string typeOfLanguage)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT_INTO_GROUP;
                cmd.Parameters.AddWithValue("@IdOsobe", userId);
                cmd.Parameters.AddWithValue("@IdGrupe", groupId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException(getMessage(typeOfLanguage));
            }
            finally
            {
                if (conn != null)
                {
                    MySqlUtil.CloseQuietly(conn);
                }
            }
        }

        private static String getMessage(string typeOfLanguage)
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
            {
                return "Dijete se vec nalazi u nekoj od grupa.";
            }
            else
            {
                return "The child is already in a group.";
            }
        }

    }
}
