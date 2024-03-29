﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VCommerce.ProductApi.DTOs;
using VCommerce.ProductApi.Roles;
using VCommerce.ProductApi.Services;

namespace VCommerce.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var produtosDto = await _productService.GetProducts();
        if (produtosDto is null)
        {
            return NotFound("Products not found");
        }
        return Ok(produtosDto);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var produtoDto = await _productService.GetProductById(id);
        if (produtoDto is null)
        {
            return NotFound("Product not found");
        }
        return Ok(produtoDto);
    }

    [HttpPost]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult> Post([FromBody] ProductDTO produtoDto)
    {
        if (produtoDto is null)
            return BadRequest("Data Invalid");

        await _productService.AddProduct(produtoDto);

        return new CreatedAtRouteResult("GetProduct",
            new { id = produtoDto.Id }, produtoDto);
    }

    [HttpPut]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult> Put([FromBody] ProductDTO produtoDto)
    {
        if (produtoDto is null)
            return BadRequest("Data invalid");

        await _productService.UpdateProduct(produtoDto);

        return Ok(produtoDto);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<ActionResult<ProductDTO>> Delete(int id)
    {
        var produtoDto = await _productService.GetProductById(id);

        if (produtoDto is null)
        {
            return NotFound("Product not found");
        }

        await _productService.RemoveProduct(id);

        return Ok(produtoDto);
    }
}
