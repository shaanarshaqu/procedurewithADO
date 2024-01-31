using System.Data;
using System.Data.SqlClient;

namespace procedurewithADO.Models
{
    public class Users:IUsers
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        public Users(IConfiguration configuration) 
        { 
            _configuration = configuration;
            _connectionstring = _configuration["ConnectionStrings:DefaultConnection"];
        }
        public int AddUsers(UserDTO user)
        {
            using(SqlConnection connect = new SqlConnection(_connectionstring))
            {
                connect.Open();
                using(SqlCommand cmd = new SqlCommand("AddUserss", connect))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@dep_id", user.Dep_Id);

                    SqlParameter sqlParameter = new SqlParameter("@data", SqlDbType.Int);
                    sqlParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(sqlParameter);
                    return cmd.ExecuteNonQuery();


                }
            }
        }
    }
}
