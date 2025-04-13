﻿using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;

        public ProductsController(IValidator<Product> validator, ApiContext context)
        {
            _validator = validator;
            _context = context;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            //Product parametresinden göndermiş olduğumuz değerleri validasyondan(kontrolden) geçiriyoruz
            var validationResult = _validator.Validate(product); 
            if(!validationResult.IsValid)//validation geçerli değilse
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Ürün ekleme işlemi başarılı");
            }
            
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Ürün silme işlemi başarılı");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Ürün güncelleme işlemi başarılı");
            }
        }

    }
}
