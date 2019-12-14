using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace PhotoblogInfrastructure.Migrations
{
    public partial class Init : Migration
    {
	    protected override void Up(MigrationBuilder migrationBuilder)
	    {
		    // For new databases: enable prerequisites for filetable:
		    //https://docs.microsoft.com/en-us/sql/relational-databases/blob/enable-the-prerequisites-for-filetable?view=sql-server-ver15

		    string script = @"CREATE TABLE ImageStore AS FileTable  
    WITH (   
          FileTable_Directory = 'ImageTable',  
          FileTable_Collate_Filename = database_default  
         );";

		    var config = new ConfigurationBuilder()
			    .AddEnvironmentVariables()
			    .Build();

		    BlogDbContext ctx = new BlogDbContext(config.GetConnectionString("BlogDbConnectionString"));
		    ctx.Database.ExecuteSqlRaw(script);

		    migrationBuilder.CreateIndex(
			    name: "name_creation_time_idx",
			    table: "ImageStore",
			    columns: new[] {"name", "creation_time"});
	    }

	    protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageStore");
        }
    }
}
