using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplicationForServer.Models;

namespace WebApplicationForServer.Controllers
{
    public class ProductsController : ApiController
    {
        private u1590589_testdbEntities db = new u1590589_testdbEntities();

        [HttpGet]
        public List<Products> Get()
        {
            return db.Products.ToList();
        }

        // GET: api/Products/5
        [HttpGet]
        [ResponseType(typeof(Products))]
        public IHttpActionResult Get(int id)
        {
            Products products = db.Products.Find(id);
        
            if (products == null)
            {
                return NotFound();
            }

            return Ok(products);
        }

        // PUT: api/Products/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.Id)
            {
                return BadRequest();
            }

            db.Entry(products).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [HttpPost]
        [ResponseType(typeof(Products))]
        public IHttpActionResult Post(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(products);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete]
        [ResponseType(typeof(Products))]
        public IHttpActionResult Delete(int id)
        {
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            db.Products.Remove(products);
            db.SaveChanges();

            return Ok(products);
        }


        [HttpGet]
        private bool ProductsExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}