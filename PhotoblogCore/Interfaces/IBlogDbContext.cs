using Microsoft.EntityFrameworkCore;
using PhotoblogCore.Entities;

namespace PhotoblogCore.Interfaces
{
	public interface IBlogDbContext
	{
		DbSet<Image> Images { get; set; }
	}
}
