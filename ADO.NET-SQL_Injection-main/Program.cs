using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ADO.NET_SQL_Injection.Utils;

namespace ADO.NET_SQL_Injection
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await GetEmployeeById("3");

            await GetAllEmployeesFullNames();

            AddEmployee("Radius Kentov");

            DeleteEmployee("7");

            await FilterByName("o");
        }

        #region Cond.1
        //Parametr olaraq Id daxil edib, LabEmployees table-dakı həmin Id-li employee göstərmək.

        public async static Task GetEmployeeById(string id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string command = $"SELECT Fullname FROM LabEmployees WHERE Id={id}";
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }
        #endregion

        #region Cond.2
        //LabEmployees table-dakı bütün employee-lərin Fullname dəyərlərini göstərmək.

        public async static Task GetAllEmployeesFullNames()
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string command = $"SELECT Fullname FROM LabEmployees";
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }

        #endregion

        #region Cond.3
        //Bir employee Fullname-i daxil edib onu Db-dəki LabEmployees table-a əlavə edirik.

        public static void AddEmployee(string fullname)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string queryString = $"INSERT INTO LabEmployees VALUES('{fullname}')";
                using (SqlCommand com = new SqlCommand(queryString, connection))
                {
                    int resut = com.ExecuteNonQuery();
                    if (resut > 0)
                    {
                        Console.WriteLine("Employee əlavə olundu");
                    }
                    else
                    {
                        Console.WriteLine("Uğursuz cəhd");
                    }

                }
            }
        }

        #endregion

        #region Cond.4
        //Parametr olaraq Id daxil edirik və LabEmployees-dakı həmin Id-ə uyğun row-u silirik.

        public static void DeleteEmployee(string id)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string queryString = $"DELETE FROM LabEmployees WHERE Id={id}";
                using (SqlCommand com = new SqlCommand(queryString, connection))
                {
                    int resut = com.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Cond.5
        //parametr olaraq bir search dəyəri qəbul edəcək və employee-lərin fullname-lərində həmin
        //search dəyəri varsa həmin employee-lərin fullname-lərini ekrana çıxardacaq.

        public async static Task FilterByName(string search)
        {
            using (SqlConnection connection = new SqlConnection(Constants.connectionString))
            {
                connection.Open();
                string command = $"SELECT Fullname FROM LabEmployees WHERE Fullname LIKE '%{search}%'";
                using (SqlCommand sqlCommand = new SqlCommand(command, connection))
                {
                    SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Fullname: {reader["Fullname"]}");
                        }
                    }
                }
            }
        }

        #endregion
    }
}

