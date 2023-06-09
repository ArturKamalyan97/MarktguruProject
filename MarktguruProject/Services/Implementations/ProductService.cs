﻿using MarktguruProject.DomainModels;
using MarktguruProject.Repositories.Interfaces;
using MarktguruProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarktguruProject.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            await this._productRepository.AddAsync(product.ToEntity());
            await Task.CompletedTask;
        }
        public async Task EditAsync(Product product)
        {
            await this._productRepository.EditAsync(product.ToEntity());
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Product?>> GetAllAsync()
        {
            var list = await this._productRepository.GetAllAsync();
            return list.Select(x => new Product(x)).ToList();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var product = await this._productRepository.GetByIdAsync(id);
            return product == null ? null : new Product(product);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await this._productRepository.DeleteAsync(id);
        }


    }
}
