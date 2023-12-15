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

public class BillController : ApiBaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BillController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<BillDto>>> Get()
    {
        var results = await _unitOfWork.Bills.GetAllAsync();
        return _mapper.Map<List<BillDto>>(results);
    }
    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<BillDto>>> GetPagination([FromQuery] Params p)
    {
        if(!int.TryParse(p.Search, out int search))
        {
            search = 0;
        }
        var results = await _unitOfWork.Bills.GetAllAsync2(p.PageIndex, p.PageSize, search);
        var resultsDto = _mapper.Map<List<BillDto>>(results.registros);
        return  new Pager<BillDto>(resultsDto,results.totalRegistros, p.PageIndex, p.PageSize, p.Search);
    }

    [HttpPost()]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] BillManyProductsDto dto)
    {
        var bill = _mapper.Map<Bill>(dto);
        var listProducts = _mapper.Map<List<Sale>>(dto.ProductList);
        var result = await _unitOfWork.Bills.ConfirmSale(bill,listProducts);

        return Ok(result);
    }

    
}