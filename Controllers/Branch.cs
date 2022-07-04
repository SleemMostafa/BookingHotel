using BookingHotel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Branch : ControllerBase
    {
        private readonly IRepositoryBranch repositoryBranch;

        public Branch(IRepositoryBranch repositoryBranch)
        {
            this.repositoryBranch = repositoryBranch;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(repositoryBranch.GetAll());
        }
    }
}
