using TestAPI.Interface;
using TestAPI.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace TestAPI.Repository
{
    public class MembersRepository : IMembers
    {
        private readonly string _connectionString;

        // ✅ Constructor name fixed
        public MembersRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevConnection");
        }
        List<Members> lisMembers = new List<Members>
        {
            new Members{MemberId=1, FirstName="Kirtesh", LastName="Shah", Address="Vadodara" },
            new Members{MemberId=2, FirstName="Nitya", LastName="Shah", Address="Vadodara" },
            new Members{MemberId=3, FirstName="Dilip", LastName="Shah", Address="Vadodara" },
            new Members{MemberId=4, FirstName="Atul", LastName="Shah", Address="Vadodara" },
            new Members{MemberId=5, FirstName="Swati", LastName="Shah", Address="Vadodara" },
            new Members{MemberId=6, FirstName="Rashmi", LastName="Shah", Address="Vadodara" },
        };
        public List<Members> GetAllMember()
        {
            return lisMembers;
        }

        public Members GetMember(int id)
        {
            return lisMembers.FirstOrDefault(x => x.MemberId == id);
        }

        // ✅ Using connection string here
        public int SaveDetails(Members obj)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                   
                    SqlCommand cmd = new SqlCommand("spSaveDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionType", "SAVEDATA");
                    cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd.Parameters.AddWithValue("@Address", obj.Address);
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = Convert.ToInt32(cmd.Parameters["@retval"].Value);
                }
            }
            catch (Exception ex)
            {
                // log exception (don’t swallow it silently)
                throw;
            }

            return result;
        }
        public int SaveEnqueryDetails(Enquery obj)
        {
            int result = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    SqlCommand cmd = new SqlCommand("spSaveDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionType", "SAVEDATA_ENQUERY");
                    cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Subject", obj.Subject);
                    cmd.Parameters.AddWithValue("@Desc", obj.Desc);
                    cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    result = Convert.ToInt32(cmd.Parameters["@retval"].Value);
                }
            }
            catch (Exception ex)
            {
                // log exception (don’t swallow it silently)
                throw;
            }

            return result;
        }
    }
}
