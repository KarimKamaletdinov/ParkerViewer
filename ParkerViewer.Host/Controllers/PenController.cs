﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ParkerViewer.Abstractions.Dtos;
using ParkerViewer.Handlers.Pen;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkerViewer.Host.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PenController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<PenDto> Get()
        {
            return new SqlGetModels().Execute(new GetPensQuery());
        }

        [HttpPost]
        public void Post([FromBody] PenDto pen)
        {
            new SqlInsertModel().Execute(new PenCommand(){PenDto = pen});
        }
        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PenDto pen)
        {
            pen.Id = id;
            new SqlInsertModel().Execute(new PenCommand() { PenDto = pen });
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new SqlDeletePen().Execute(new DeletePenCommand(){Id = id});
        }
    }
}