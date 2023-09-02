using MySql.Data.MySqlClient;
using Vrtic.Data.DBUtil;
using Vrtic.Data.Exceptions;
using Vrtic.Data.Model;

namespace Vrtic.Data.MySql
{
    internal class WrapperUser
    {

        public static string? LogInUser;
        public static int? UserId;

        private static readonly string SELECT =
            @"SELECT v.Osoba_IdOsobe, JMB, Ime, Prezime, DatumRodjenja, Adresa, v.Plata
            FROM `vaspitac` v 
            INNER JOIN `osoba` o ON o.IdOsobe = v.OSOBA_IdOsobe
            WHERE JMB LIKE @str OR Ime LIKE @str OR Prezime LIKE @str OR Adresa LIKE @str";

        private static readonly string SELECT_FROM_GROUP =
            @"SELECT v.Osoba_IdOsobe, JMB, Ime, Prezime, DatumRodjenja, Adresa, v.Plata
              FROM vaspitac v
              INNER JOIN osoba o ON o.IdOsobe = v.OSOBA_IdOsobe
              INNER JOIN vaspitac_has_grupa vg ON v.OSOBA_IdOsobe = vg.VASPITAC_OSOBA_IdOsobe
              WHERE GRUPA_IdGrupe = @IdGrupe";

        private static readonly string SELECT_WITH_USERNAME_PASSWORD =
            @"SELECT OSOBA_IdOsobe, korisnickoIme, Lozinka, Ime, Prezime
            FROM vaspitac v
            INNER JOIN `osoba` o ON o.IdOsobe = v.OSOBA_IdOsobe";

        private static readonly string INSERT =
            @"INSERT INTO vaspitac
              VALUES (@IdVaspitaca, @Plata, @KorisnickoIme, @Lozinka, 0)";

        private static readonly string INSERT_INTO_GROUP =
            @"INSERT INTO vaspitac_has_grupa
              VALUES (@IdOsobe, @IdGrupe)";

        private static readonly string DELETE =
            @"DELETE FROM vaspitac
              WHERE OSOBA_IdOsobe = @IdOsobe";

        private static readonly string DELETE_FROM_GROUP =
            @"DELETE FROM vaspitac_has_grupa
              WHERE VASPITAC_OSOBA_IdOsobe = @IdOsobe AND GRUPA_IdGrupe = @IdGrupe";

        private static readonly string UPDATE_SALARY =
            @"UPDATE vaspitac
              SET Plata = @Plata
              WHERE OSOBA_IdOsobe = @IdOsobe";

        private static readonly string SELECT_COLOR =
            @"SELECT boja 
              FROM vaspitac
              WHERE OSOBA_IdOsobe = @IdOsobe";

        private static readonly string UPDATE_COLOR =
            @"UPDATE vaspitac
              SET boja = @Boja
              WHERE OSOBA_IdOsobe = @IdOsobe";

        public static List<User> GetUsers(string filter)
        {
            List<User> result = new List<User>();
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
                    result.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetDateTime(4), reader.GetString(5), reader.GetInt32(6)));
                }
            }
            catch(Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja podataka o vaspitačima.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }

        public static Boolean IsCredentialsValid(string userName, string password)
        {
            Boolean result = false;
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader? reader = null;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_WITH_USERNAME_PASSWORD;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (userName.Equals(reader.GetString(1)) && password.Equals(reader.GetString(2)))
                    {
                        UserId = reader.GetInt32(0);
                        LogInUser = reader.GetString(3) + " " + reader.GetString(4);
                        result = true;
                    }
                }
            }
            catch(Exception)
            {
                throw new DataAccessException("Greška prilikom provjere kredencijala vaspitača.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }

        public static void InsertUser(User user)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@IdVaspitaca", user.Id);
                cmd.Parameters.AddWithValue("@Plata", user.Salary);
                cmd.Parameters.AddWithValue("@KorisnickoIme", user.UserName);
                cmd.Parameters.AddWithValue("@Lozinka", user.Password);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom dodavanja vaspitača.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        public static void DeleteUserById(int id)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IdOsobe", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom brisanja vastpitača.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        public static void UpdateUserSalary(User user)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_SALARY;
                cmd.Parameters.AddWithValue("@Plata", user.Salary);
                cmd.Parameters.AddWithValue("IdOsobe", user.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greska prilikom ažuriranja plate vaspitača.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }
   
        public static List<User> GetUsersFromGroup(int groupId)
        {
            List<User> result = new List<User>();
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
                    result.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetDateTime(4), reader.GetString(5), reader.GetInt32(6)));
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja vaspitača iz grupe.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }
    
        public static void InsertUserIntoGroup(int userId, int groupId, string typeOfLanguage)
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
                MySqlUtil.CloseQuietly(conn);
            }
        }
   
        public static void DeleteUserFromGroup(int userId, int groupId)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE_FROM_GROUP;
                cmd.Parameters.AddWithValue("@IdOsobe", userId);
                cmd.Parameters.AddWithValue("@IdGrupe", groupId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom brisanja vaspitača iz grupe.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        private static String getMessage(string typeOfLanguage)
        {
            if (("sr-Latn-CS").Equals(typeOfLanguage))
            {
                return "Vaspitač se već nalazi u toj grupi.";
            }
            else
            {
                return "The user is already in this group..";
            }
        }

        public static List<Color> GetColor()
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader? reader = null;
            List<Color> colors = new();
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT_COLOR;
                cmd.Parameters.AddWithValue("@IdOsobe", UserId);
                reader = cmd.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                if (temp == 1)
                {
                    colors.Add(Color.Teal);
                    colors.Add(Color.IndianRed);
                }
                else if (temp == 2)
                {
                    colors.Add(Color.Plum);
                    colors.Add(Color.PaleGreen);
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja boje za formu.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return colors;
        }

        public static bool UpdateColor(int colorNumber)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE_COLOR;
                cmd.Parameters.AddWithValue("@Boja", colorNumber);
                cmd.Parameters.AddWithValue("@IdOsobe", UserId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greska prilikom ažuriranja boje.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return true;
        }

    }
}
