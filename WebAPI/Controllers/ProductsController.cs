using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        //IoC Container -- Iversion of Control //değişimin kontrolü //bellekteki bir liste düşün //biliyorum product service e ihtiyacın var bellekte onu yükledim
         

        IProductService _productService;

        public ProductsController(IProductService productService)  //controller diyor ki sen IProductService bagımlısısın gevşek bir bagımlılık
        {
            _productService = productService;
        }


        [HttpGet ("getall")]
        public IActionResult GetAll()
        {
            //Swagger
            //Dependency chain
          
            var result = _productService.GetAll();    //result bize işlem sonucunu verir varsa mesaj ve data ise datayı verir data result ise data vardır
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
             
         //Çözümlemek demek ona bağlı bir sınıfı new lemek demek 
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
                
            }
            return BadRequest(result);

            //genellikle silme ve güncelleme için de post kullanılır güncelleme için put silme için delete kullanabilirsin
        }
       
    }
}
