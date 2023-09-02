using MySql.Data.MySqlClient;
using Vrtic.Data.DBUtil;
using Vrtic.Data.Exceptions;
using Vrtic.Data.Model;
using Vrtic.Data.MySql;

namespace Vrtic.Data.Wrapper
{
    internal class WrapperPerson
    {
        private static readonly string INSERT =
           @"INSERT INTO osoba(JMB, Ime, Prezime, DatumRodjenja, Adresa)
              VALUES (@JMB, @Ime, @Prezime, @DatumRodjenja, @Adresa)";

        private static readonly string UPDATE =
            @"UPDATE osoba
              SET JMB = @JMB, Ime = @Ime, Prezime = @Prezime, DatumRodjenja = @DatumRodjenja, Adresa = @Adresa
              WHERE IdOsobe = @IdOsobe";

        private static readonly string UPDATE_CREDENTIALS_ADMIN =
            @"UPDATE administrator
              SET KorisnickoIme = @KorisnickoIme, Lozinka = @Lozinka
              WHERE OSOBA_IdOsobe = @IdOsobe";

        private static readonly string UPDATE_CREDENTIALS_USER =
            @"UPDATE vaspitac
              SET KorisnickoIme = @KorisnickoIme, Lozinka = @Lozinka
              WHERE OSOBA_IdOsobe = @IdOsobe";

        private static readonly string DELETE =
            @"DELETE FROM osoba
              WHERE IdOsobe = @IdOsobe";

        public static int InsertPerson(Person person)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            int id = 0;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@JMB", person.JMB);
                cmd.Parameters.AddWithValue("@Ime", person.FirstName);
                cmd.Parameters.AddWithValue("@Prezime", person.LastName);
                cmd.Parameters.AddWithValue("@DatumRodjenja", person.DateOfBirth);
                cmd.Parameters.AddWithValue("@Adresa", person.Address);
                cmd.ExecuteNonQuery();
                person.Id = (int)cmd.LastInsertedId;
                id = (int)cmd.LastInsertedId;
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom dodavanja nove osobe.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return id;
        }

        public static void UpdatePerson(Person person)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@JMB", person.JMB);
                cmd.Parameters.AddWithValue("@Ime", person.FirstName);
                cmd.Parameters.AddWithValue("@Prezime", person.LastName);
                cmd.Parameters.AddWithValue("@DatumRodjenja", person.DateOfBirth);
                cmd.Parameters.AddWithValue("@Adresa", person.Address);
                cmd.Parameters.AddWithValue("@IdOsobe", person.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom ažuriranja podataka");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }
    
        public static void DeletePersonById(int id)
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
                throw new DataAccessException("Greška prilikom brisanja podataka.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        public static void UpdateCredentials(string userName, string password, bool personType)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                if (personType)
                {
                    cmd.CommandText = UPDATE_CREDENTIALS_ADMIN;
                    cmd.Parameters.AddWithValue("@IdOsobe", WrapperAdmin.AdminId);
                }
                else
                {
                    cmd.CommandText = UPDATE_CREDENTIALS_USER;
                    cmd.Parameters.AddWithValue("@IdOsobe", WrapperUser.UserId);
                }
                cmd.Parameters.AddWithValue("@KorisnickoIme", userName);
                cmd.Parameters.AddWithValue("@Lozinka", password);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom promjene kredencijala.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }
        
    }
}
