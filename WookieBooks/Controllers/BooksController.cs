using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using System.Linq;

using WookieBooks.Models;

namespace WookieBooks.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private static List<Book> books = new List<Book>() {
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

		[HttpGet]
		public ActionResult<List<Book>> Get()
		{
			return books;
		}

		[HttpGet("{id}")]
		public ActionResult<Book> Get(int id)
		{
			return books.FirstOrDefault(book => book.ICBN == id);
		}

		[HttpPost]
		public void Post([FromBody] Book book)
		{
			books.RemoveAll(_book => _book.ICBN == book.ICBN);
			books.Add(book);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			books.RemoveAll(book => book.ICBN == id);
		}
	}
}
