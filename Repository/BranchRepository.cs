using BookingHotel.Models;

namespace BookingHotel.Repository
{
    public class BranchRepository : IRepositoryBranch
    {
        private readonly ApplicationContext db;

        public BranchRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public Branch Add(Branch entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Branch> GetAll()
        {
            return (db.Branches.ToList());
        }

        public Branch GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
