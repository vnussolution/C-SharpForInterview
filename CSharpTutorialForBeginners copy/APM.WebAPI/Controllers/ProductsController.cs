using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace APM.WebAPI.Controllers
{


    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery(PageSize = 5, AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.OrderBy)]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
                var productRepository = new ProductRepository();
                return Ok(productRepository.Retrieve().AsQueryable());

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }


        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();
            var products = productRepository.Retrieve();
            return products.Where(p => p.ProductCode.Contains(search));

        }


        [Authorize]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {

            try
            {
                Product product;
                var productRepository = new ProductRepository();
                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);

                    if (product == null)
                        return NotFound();

                }
                else
                {
                    product = productRepository.Create();
                }
                return Ok(product);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {

                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var productRepository = new ProductRepository();
                var newProduct = productRepository.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }
                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(), newProduct);

            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var productRepository = new ProductRepository();
                var updateProduct = productRepository.Save(id, product);
                if (updateProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
