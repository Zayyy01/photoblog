using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PhotoblogDataAccess.Entities;

namespace PhotoblogDataAccess
{
	public class BlogDbContext : DbContext
	{
		private string _connectionString;
		public DbSet<Image> Images { get; set; }

		public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
		{

		}

		public BlogDbContext(string connectionString)
		{
			this._connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (_connectionString != null)
				optionsBuilder.UseSqlServer(_connectionString);
			else
				base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Image>(eb =>
			{
				//eb.HasNoKey();
				eb.HasKey("StreamId");
				//eb.ToView("ImageStoreView");
				eb.ToTable("ImageStoreView");
				eb.Property(v => v.StreamId).HasColumnName("stream_id");
				eb.Property(v => v.FileStream).HasColumnName("file_stream");
				eb.Property(v => v.Name).HasColumnName("name").HasColumnType("nvarchar(255)");
				eb.Property(v => v.PathLocator).HasColumnName("path_locator");
				eb.Property(v => v.ParentPathLocator).HasColumnName("parent_path_locator");
				eb.Property(v => v.FileType).HasColumnName("file_type").HasColumnType("nvarchar(255)");
				eb.Property(v => v.CachedFileSize).HasColumnName("cached_file_size");
				eb.Property(v => v.CreationTime).HasColumnName("creation_time");
				eb.Property(v => v.LastWriteTime).HasColumnName("last_write_time");
				eb.Property(v => v.LastAccessTime).HasColumnName("last_access_time");
				eb.Property(v => v.IsDirectory).HasColumnName("is_directory");
				eb.Property(v => v.IsOffline).HasColumnName("is_offline");
				eb.Property(v => v.IsHidden).HasColumnName("is_hidden");
				eb.Property(v => v.IsReadOnly).HasColumnName("is_readonly");
				eb.Property(v => v.IsArchive).HasColumnName("is_archive");
				eb.Property(v => v.IsSystem).HasColumnName("is_system");
				eb.Property(v => v.IsTemporary).HasColumnName("is_temporary");
			});
		}
	}
}
