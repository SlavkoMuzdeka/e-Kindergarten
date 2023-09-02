using MySql.Data.MySqlClient;
using Vrtic.Data.DBUtil;
using Vrtic.Data.Exceptions;
using Vrtic.Data.Model;

namespace Vrtic.Data.Wrapper
{
    internal class WrapperMembershipFee
    {

        private static readonly string INSERT_PAID =
            @"INSERT INTO clanarina(TipUsluge, Iznos, Placeno, Datum, DIJETE_OSOBA_IdOsobe, DatumPlacanja)
              VALUES (@TipUsluge, @Iznos, 1, @Datum, @DIJETE_OSOBA_IdOsobe, NOW())";

        private static readonly string INSERT_NOT_PAID =
            @"INSERT INTO clanarina(TipUsluge, Iznos, Placeno, Datum, DIJETE_OSOBA_IdOsobe)
              VALUES (@TipUsluge, @Iznos, 0, @Datum, @DIJETE_OSOBA_IdOsobe)";

        private static readonly string SELECT =
            @"SELECT * FROM clanarina
              WHERE DIJETE_OSOBA_IdOsobe = @IdDjeteta
              ORDER BY Datum DESC";

        private static readonly string UPDATE =
            @"UPDATE clanarina
              SET Placeno = 1, DatumPlacanja = NOW()
              WHERE IdClanarine = @IdClanarine AND DIJETE_OSOBA_IdOsobe = @IdDjeteta";

        private static readonly string DELETE =
            @"DELETE FROM clanarina
              WHERE DIJETE_OSOBA_IdOsobe = @IdDjeteta";

        public static bool InsertMembershipFee(MembershipFee mF)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                if (mF.IsPaid)
                {
                    cmd.CommandText = INSERT_PAID;
                }
                else
                {
                    cmd.CommandText = INSERT_NOT_PAID;
                }
                cmd.Parameters.AddWithValue("@TipUsluge", mF.Type);
                cmd.Parameters.AddWithValue("@Iznos", mF.Amount);
                cmd.Parameters.AddWithValue("@Datum", mF.MonthToPay);
                cmd.Parameters.AddWithValue("@DIJETE_OSOBA_IdOsobe", mF.ChildId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom kreiranja članarine.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
            return true;
        }

        public static List<MembershipFee> GetMembershipFees(int childId)
        {
            List<MembershipFee> result = new();
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            MySqlDataReader? reader = null;

            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = SELECT;
                cmd.Parameters.AddWithValue("@IdDjeteta", childId);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.IsDBNull(6))
                    {
                        result.Add(new MembershipFee(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                        false, reader.GetDateTime(4)));
                    }
                    else
                    {
                        result.Add(new MembershipFee(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                        true, reader.GetDateTime(4), reader.GetDateTime(6)));
                    }

                }
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom čitanja podataka o članarinama.");
            }
            finally
            {
                if (reader != null && conn != null)
                {
                    MySqlUtil.CloseQuietly(reader, conn);
                }
            }
            return result;
        }

        public static void UpdateMembershipFee(int membershipFeeId, int childId)
        {
            MySqlConnection? conn = null;
            MySqlCommand cmd;
            try
            {
                conn = MySqlUtil.GetConnection();
                cmd = conn.CreateCommand();
                cmd.CommandText = UPDATE;
                cmd.Parameters.AddWithValue("@IdClanarine", membershipFeeId);
                cmd.Parameters.AddWithValue("@IdDjeteta", childId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new DataAccessException("Greška prilikom ažuriranja podataka o članarini.");
            }
            finally
            {
                if (conn != null)
                {
                    MySqlUtil.CloseQuietly(conn);
                }
            }
        }

        public static void DeleteMembershipFees(int childId)
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
                throw new DataAccessException("Greška prilikom brisanja članarina za dijete.");
            }
            finally
            {
                MySqlUtil.CloseQuietly(conn);
            }
        }

    }
}
