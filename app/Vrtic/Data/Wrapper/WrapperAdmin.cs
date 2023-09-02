using MySql.Data.MySqlClient;
using Vrtic.Data.DBUtil;
using Vrtic.Data.Exceptions;

namespace Vrtic.Data.Wrapper
{
    internal class WrapperAdmin
    {
        public static string? LogInAdmin;
        public static int? AdminId;

        private static readonly string SELECT_ADMIN_WITH_USERNAME_PASSWORD =
            @"SELECT OSOBA_IdOsobe, korisnickoIme, Lozinka, Ime, Prezime
            FROM administrator a
            INNER JOIN `osoba` o ON o.IdOsobe = a.OSOBA_IdOsobe";

        private static readonly string SELECT_COLOR =
            @"SELECT boja 
              FROM administrator
              WHERE OSOBA_IdOsobe = @IdOsobe";

        private static readonly string UPDATE_COLOR =
            @"UPDATE administrator
              SET boja = @Boja
              WHERE OSOBA_IdOsobe = @IdOsobe";

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
                cmd.CommandText = SELECT_ADMIN_WITH_USERNAME_PASSWORD;
                reader = cmd.ExecuteReader();
                reader.Read();
                if (userName.Equals(reader.GetString(1)) && password.Equals(reader.GetString(2)))
                {
                    LogInAdmin = reader.GetString(3) + " " + reader.GetString(4);
                    AdminId = reader.GetInt32(0);
                    result = true;
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom provjere kredencijala admina.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
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
                cmd.Parameters.AddWithValue("@IdOsobe", AdminId);
                reader = cmd.ExecuteReader();
                reader.Read();
                int temp = reader.GetInt32(0);
                if (temp == 1)
                {
                    colors.Add(Color.Teal);
                    colors.Add(Color.IndianRed);
                }
                else if(temp == 2)
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
                cmd.Parameters.AddWithValue("@IdOsobe", AdminId);
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
