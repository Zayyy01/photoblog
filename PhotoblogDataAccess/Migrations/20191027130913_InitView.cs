using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace PhotoblogDataAccess.Migrations
{
    public partial class InitView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        string script = @"CREATE VIEW [dbo].[ImageStoreView]
AS
SELECT [stream_id]
      ,[file_stream]
      ,[name]
      ,CONVERT(VARCHAR(4000),[path_locator]) AS [path_locator]
      ,CONVERT(VARCHAR(4000),[parent_path_locator]) AS [parent_path_locator]
      ,[file_type]
      ,[cached_file_size]
      ,[creation_time]
      ,[last_write_time]
      ,[last_access_time]
      ,[is_directory]
      ,[is_offline]
      ,[is_hidden]
      ,[is_readonly]
      ,[is_archive]
      ,[is_system]
      ,[is_temporary]
  FROM [dbo].[ImageStore];";

	        var config = new ConfigurationBuilder()
		        .AddEnvironmentVariables()
		        .Build();

	        BlogDbContext ctx = new BlogDbContext(config.GetConnectionString("BlogDbConnectionString"));
	        ctx.Database.ExecuteSqlRaw(script);



            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ImageStore",
            //    table: "ImageStore");

            //migrationBuilder.RenameTable(
            //    name: "ImageStore",
            //    newName: "ImageStoreView");

            //migrationBuilder.AlterColumn<string>(
            //    name: "name",
            //    table: "ImageStoreView",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(255)",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "file_type",
            //    table: "ImageStoreView",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(255)",
            //    oldNullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ImageStoreView",
            //    table: "ImageStoreView",
            //    column: "stream_id");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        string script = @"DROP VIEW dbo.ImageStoreView";

	        var config = new ConfigurationBuilder()
		        .AddEnvironmentVariables()
		        .Build();

	        BlogDbContext ctx = new BlogDbContext(config.GetConnectionString("BlogDbConnectionString"));
	        ctx.Database.ExecuteSqlRaw(script);
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ImageStoreView",
            //    table: "ImageStoreView");

            //migrationBuilder.RenameTable(
            //    name: "ImageStoreView",
            //    newName: "ImageStore");

            //migrationBuilder.AlterColumn<string>(
            //    name: "name",
            //    table: "ImageStore",
            //    type: "nvarchar(255)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "file_type",
            //    table: "ImageStore",
            //    type: "nvarchar(255)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ImageStore",
            //    table: "ImageStore",
            //    column: "stream_id");
        }
    }
}
