using Microsoft.EntityFrameworkCore;
using EnvanterUygulaması.Models;
using EnvanterUygulaması.Repositories.Abstract;
using Microsoft.Data.SqlClient;

namespace EnvanterUygulaması.Repositories.Concrete
{
    public class DonanimRepository : GenericRepository<Donanimlar> , IDonanimRepository
    {
        var configuration = builder.Configuration;

        var connectionString = configuration.GetConnectionString("MyDbContext");
        private DataContext _context;
        private DbSet<Donanimlar> _dbSet;
        public DonanimRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Donanimlar;
        }

        public List<Donanimlar> AdetSay(int MarkaID, int UstModelID, int AltModelID)
        {
            var donanimListe= new List<Donanimlar>();
            return donanimListe;
        }

        public List<Donanimlar> GetAllDonanimlar()
        {

            List<Donanimlar> products = new List<Donanimlar>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT Id, Name, Price FROM Products;";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = (int)reader["Id"],
                                Name = (string)reader["Name"],
                                Price = (decimal)reader["Price"]
                            };
                            products.Add(product);
                        }
                    }
                }
                throw new NotImplementedException();
        }
    }

}
