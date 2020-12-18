using System.Collections.Generic;

using NUnit.Framework;

using WookieBooks.Controllers;
using WookieBooks.Models;

namespace WookieBooksTests
{
	public class Tests
	{
		BooksController controller;
		List<Book> defaultBooks = new List<Book>() {
			new Book() {
				ICBN = 1,
				Author = "Boba Fett",
				Title = "The Fight To Survive",
				Description = "Survival through fighting",
				Price = new decimal(13.99),
				CoverImage = "https://images-na.ssl-images-amazon.com/images/I/51d-Jq2f8XL._SX313_BO1,204,203,200_.jpg",
			},
			new Book() {
				ICBN = 2,
				Author = "Jar Jar Binks",
				Title = "Watch Out, Jar Jar!",
				Description = "Jar Jar watches out",
				Price = new decimal(10.01),
				CoverImage = "https://static.wikia.nocookie.net/starwars/images/2/26/WatchOutJarJar-cover.jpg/revision/latest?cb=20090222161230",
			}
		};

		[SetUp]
		public void Setup()
		{
			controller = new BooksController();
		}

		[Test]
		public void GetAllBooks()
		{
			Assert.AreEqual(defaultBooks, controller.Get().Value);
		}

		[Test]
		public void AddBook()
		{

		}

		[Test]
		public void DeleteBook()
		{

		}

		[Test]
		public void UpdateBook()
		{

		}

		[Test]
		public void GetNonExistantBook()
		{

		}

		[Test]
		public void DeleteNonExistantBook()
		{

		}
	}
}