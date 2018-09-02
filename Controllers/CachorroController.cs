using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apiCachorro.Repository.Interfaces;
using apiCachorro.Models;

namespace apiCachorro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CachorroController : Controller
    {

        private readonly ICachorroRepository _repository;
        public CachorroController(ICachorroRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cachorro>> GetAll()
        {
            return new ObjectResult(_repository.GetAll());
        }

        [HttpGet("{id}", Name = "GetCachorro")]
        public IActionResult GetById(long id)
        {
            var cachorro = _repository.FindById(id);
            if (cachorro == null)
                return NotFound();

            return new ObjectResult(cachorro);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cachorro cachorro)
        {

            if (cachorro == null)
                return BadRequest();

            _repository.Add(cachorro);


            return new ObjectResult(cachorro);

        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Cachorro cachorro)
        {
            if (cachorro == null || id <= 0)
                return BadRequest();

            var newCachorro = _repository.FindById(id);

            if (newCachorro == null)
                return NotFound();

            newCachorro.Nome = cachorro.Nome;
            newCachorro.Raca = cachorro.Raca;
            newCachorro.Cor = cachorro.Cor;

            _repository.Update(newCachorro);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var del = _repository.FindById(id);

            if (del == null)
                return NotFound();

            _repository.RemoveById(del.CachorroId);

            return new NoContentResult();
        }
    }
}