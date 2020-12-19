using System.Collections.Generic;

using NUnit.Framework;

using WookieBooks.Controllers;
using WookieBooks.Models;

namespace WookieBooksTests
{
	public class Tests
	{
		BooksController controller;
		List<Book> defaultBooks;

		[SetUp]
		public void Setup()
		{
			controller = new BooksController();
			defaultBooks = new List<Book>() {
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
		}

		[Test]
		public void GetAllBooks()
		{
			Assert.AreEqual(defaultBooks, controller.Get().Value);
		}

		[Test]
		public void GetBookByICBN()
		{
			Assert.AreEqual(defaultBooks[0], controller.Get(1).Value);
		}

		[Test]
		public void AddBook()
		{
			Book newBook = new Book()
			{
				ICBN = 3,
				Title = "Dark Lord: The Rise of Darth Vader",
				Author = "Darth Vader",
				CoverImage = "https://images-na.ssl-images-amazon.com/images/I/91d8jnMjHrL.jpg",
				Price = new decimal(14.99),
				Description = "The rise of a dark lord, Darth Vader"
			};

			controller.Post(newBook);
			Assert.IsTrue(controller.Get().Value.Contains(newBook));
		}

		[Test]
		public void DeleteBook()
		{
			defaultBooks.RemoveAt(0);

			controller.Delete(1);
			Assert.AreEqual(defaultBooks, controller.Get().Value);
		}

		[Test]
		public void UpdateBook()
		{
			Book updateBook = new Book()
			{
				ICBN = 2,
				Title = "Watch Out, Jim Jam!",
				Author = "Jim Jam Bonks",
				CoverImage = "https://static.wikia.nocookie.net/simpsons/images/5/51/800px-Jim_Jam.png/revision/latest/top-crop/width/360/height/360?cb=20170101190859",
				Price = new decimal(20),
				Description = "Jim Jam Bonks watches out"
			};

			controller.Post(updateBook);
			Assert.IsTrue(controller.Get().Value.Contains(updateBook));
			Assert.IsFalse(controller.Get().Value.Contains(defaultBooks[1]));
		}

		[Test]
		public void GetNonExistantBook()
		{
			Assert.AreEqual(null, controller.Get(100).Value);
		}

		[Test]
		public void DeleteNonExistantBook()
		{
			controller.Delete(100);
			Assert.AreEqual(defaultBooks, controller.Get().Value);
		}
	}
}