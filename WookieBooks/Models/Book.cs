using System;

namespace WookieBooks.Models
{
	public class Book
	{
		public int ICBN;
		public string Title;
		public string Description;
		public string Author;
		public string CoverImage;
		public decimal Price;

		public override bool Equals(object obj)
		{
			Book bookObject = obj as Book;
			return (
				ICBN == bookObject.ICBN &&
				Title == bookObject.Title &&
				Description == bookObject.Description &&
				Price == bookObject.Price &&
				Author == bookObject.Author &&
				CoverImage == bookObject.CoverImage
			);
		}
	}
}
