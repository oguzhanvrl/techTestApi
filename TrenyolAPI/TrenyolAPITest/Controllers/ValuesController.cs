using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TrenyolAPITest.Models;

namespace TrenyolAPITest.Controllers
{
    public class ValuesController : ApiController
    {
        List<Book> books=new Book().BookList();
        
        // GET api/values
        public IEnumerable<Book> Get()
        {
            return books;
        }
        
        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
           var controlBook= books.FirstOrDefault(x => x.bookID == id);
            if (controlBook!=null)
            {
                /*return controlBook.bookID+Environment.NewLine+controlBook.bookAuthor+Environment.NewLine+controlBook.bookTitle;*/
                return Request.CreateResponse(HttpStatusCode.OK, controlBook);
            }
            else
            {
                var message = string.Format("Book with id = {0} not found", id);
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.NotFound, err);
            }
           
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
