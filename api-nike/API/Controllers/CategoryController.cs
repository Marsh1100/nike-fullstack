using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using API.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class CategoryController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }



    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
    {
        var results = await _unitOfWork.Categories.GetAllAsync();
        return _mapper.Map<List<CategoryDto>>(results);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CategoryDto>>> GetPagination([FromQuery] Params p)
    {
        var results = await _unitOfWork.Categories.GetAllAsync(p.PageIndex, p.PageSize, p.Search);
        var resultsDto = _mapper.Map<List<CategoryDto>>(results.registros);
        return  new Pager<CategoryDto>(resultsDto,results.totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }

    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto dto)
    {
        var result = _mapper.Map<Category>(dto);
        this._unitOfWork.Categories.Add(result);
        await _unitOfWork.SaveAsync();


        if(result == null)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(Post), new{id=result.Id}, result);
    }


    [HttpPut()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CategoryDto>> put(CategoryDto dto)
    {
        if(dto == null){ return NotFound(); }
        var result = this._mapper.Map<Category>(dto);
        this._unitOfWork.Categories.Update(result);
        Console.WriteLine(await this._unitOfWork.SaveAsync());
        return Ok(result);
    }


    [HttpDelete("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitOfWork.Categories.GetByIdAsync(id);
        if(result == null)
        {
            return NotFound();
        }
        this._unitOfWork.Categories.Remove(result);
        await this._unitOfWork.SaveAsync();
        return NoContent();
    }

   
    
}