using System;

namespace WookieBooks.Models
{
	public class Book
	{
		public Guid ICBN;
		public string Title;
		public string Description;
		public string Author;
		public string CoverImage;
		public decimal Price;
	}
}
