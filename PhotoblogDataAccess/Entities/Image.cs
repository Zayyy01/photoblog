using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoblogDataAccess.Entities
{
	public class Image
	{
		public Guid StreamId { get; set; }
		public byte[] FileStream { get; set; }
		public string Name { get; set; }
		public string PathLocator { get; set; }
		public string ParentPathLocator { get; set; }
		public string FileType { get; set; }
		public long CachedFileSize { get; set; }
		public DateTimeOffset CreationTime { get; set; }
		public DateTimeOffset LastWriteTime { get; set; }
		public DateTimeOffset LastAccessTime { get; set; }
		public bool IsDirectory { get; set; }
		public bool IsOffline { get; set; }
		public bool IsHidden { get; set; }
		public bool IsReadOnly { get; set; }
		public bool IsArchive { get; set; }
		public bool IsSystem { get; set; }
		public bool IsTemporary { get; set; }

	}
}
