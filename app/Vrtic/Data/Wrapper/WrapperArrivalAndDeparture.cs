using MySql.Data.MySqlClient;
using Vrtic.Data.DBUtil;
using Vrtic.Data.Exceptions;
using Vrtic.Data.Model;

namespace Vrtic.Data.Wrapper
{
    internal class WrapperArrivalAndDeparture
    {

        private static readonly string GET_ARRIVAL_DEPARTURE =
            @"SELECT * FROM vrijeme_dolaska_i_odlaska
              WHERE DIJETE_OSOBA_IdOsobe = @IdDjeteta
              ORDER BY EvidentiranoVrijeme DESC";

        private static readonly string INSERT =
            @"INSERT INTO vrijeme_dolaska_i_odlaska(DIJETE_OSOBA_IdOsobe, EvidentiranoVrijeme, Tip)
              VALUES (@IdDjeteta, NOW(), @Tip)";

        private static readonly string DELETE =
            @"DELETE FROM vrijeme_dolaska_i_odlaska
              WHERE DIJETE_OSOBA_IdOsobe = @IdDjeteta";

        private static readonly string GET_ARRIVAL_DEPARTURE_FILTER =
            @"SELECT * FROM vrijeme_dolaska_i_odlaska
              WHERE DIJETE_OSOBA_IdOsobe = @IdDjeteta AND DATE(EvidentiranoVrijeme) >= DATE(@Od) AND DATE(EvidentiranoVrijeme) <= DATE(@Do)
              ORDER BY EvidentiranoVrijeme DESC";

        public static List<DepartureAndArrivalTime> GetArrivalAndDeparture(int childId)
        {
            List<DepartureAndArrivalTime> result = new List<DepartureAndArrivalTime>();
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader? reader = null;

            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = GET_ARRIVAL_DEPARTURE;
                cmd.Parameters.AddWithValue("@IdDjeteta", childId);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new DepartureAndArrivalTime(reader.GetInt32(0), reader.GetInt32(1),
                        reader.GetDateTime(2), reader.GetInt32(3)));
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja vremena odlazaka i dolazaka.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }

        public static void InsertTime(int childId,int type)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = INSERT;
                cmd.Parameters.AddWithValue("@IdDjeteta", childId);
                cmd.Parameters.AddWithValue("@Tip", type);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom evidentiranja vremena.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        public static void DeleteArrivalsAndDepartures(int childId)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = DELETE;
                cmd.Parameters.AddWithValue("@IdDjeteta", childId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom brisanja vremena dolazaka i odlazaka za dijete.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

        public static List<DepartureAndArrivalTime> GetArrivalAndDepartureFilter(int childId, DateTime date1, DateTime date2)
        {
            List<DepartureAndArrivalTime> result = new List<DepartureAndArrivalTime>();
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader? reader = null;

            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = GET_ARRIVAL_DEPARTURE_FILTER;
                cmd.Parameters.AddWithValue("@IdDjeteta", childId);
                cmd.Parameters.AddWithValue("@Od", date1);
                cmd.Parameters.AddWithValue("@Do", date2);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new DepartureAndArrivalTime(reader.GetInt32(0), reader.GetInt32(1),
                        reader.GetDateTime(2), reader.GetInt32(3)));
                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja vremena odlazaka i dolazaka.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(reader, conn);
            }
            return result;
        }
    }
}
