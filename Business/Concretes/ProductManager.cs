using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        private IMapper _mapper;

        public ProductManager(IProductDal productDal , IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public async Task<CreatedProductResponse> Add(CreateProductRequests createProductRequests)
        {
            Product product = _mapper.Map<Product>(createProductRequests);

            Product createdProduct = await _productDal.AddAsync(product);

            CreatedProductResponse createdProductResponse = _mapper.Map<CreatedProductResponse>(createdProduct);

            return createdProductResponse;

            // Product product = new Product();    
            //product.Id = Guid.NewGuid();
            //product.CategoryId = createProductRequests.CategoryId;
            //product.ProductName = createProductRequests.ProductName;
            //product.QuantityPerUnit = createProductRequests.QuantityPerUnit;
            //product.UnitPrice = createProductRequests.UnitPrice;
            //product.UnitsInStock = createProductRequests.UnitsInStock;



            //CreatedProductResponse createdProductResponse = new CreatedProductResponse();
            //createdProductResponse.Id = createdProduct.Id;
            //createdProductResponse.ProductName = createProductRequests.ProductName;
            //createdProductResponse.QuantityPerUnit= createProductRequests.QuantityPerUnit;
            //createdProductResponse.UnitPrice = createProductRequests.UnitPrice;
            //createdProductResponse.UnitsInStock = createProductRequests.UnitsInStock;
        }


        //GetlistProductResponse
        public async Task<IPaginate<GetListProductResponse>> GetListAsync()
        {
            //paginate içinde product listesi
            var data = await _productDal.GetListAsync(
                include: p => p.Include(p=> p.Category)
                );
            
            var result = _mapper.Map<Paginate<GetListProductResponse>>(data);
            return result;


            //getListedProductResponse 
            //List<GetListProductResponse> getList = new List<GetListProductResponse>();

            //product list mapping
            //foreach (var item in result.Items)
            //{
            //    GetListProductResponse getListedProductResponse = new GetListProductResponse();
            //    getListedProductResponse.Id = item.Id;
            //    getListedProductResponse.ProductName = item.ProductName;
            //    getListedProductResponse.UnitPrice = item.UnitPrice;
            //    getListedProductResponse.QuantityPerUnit = item.QuantityPerUnit;
            //    getListedProductResponse.UnitsInStock = item.UnitsInStock;
            //    getList.Add(getListedProductResponse);
            //}

            ////paginate mapping
            //Paginate<GetListProductResponse> _paginate = new Paginate<GetListProductResponse>();
            //_paginate.Pages = result.Pages;
            //_paginate.Items = getList;
            //_paginate.Index = result.Index;
            //_paginate.Size = result.Size;
            //_paginate.Count = result.Count;
            ////_paginate.HasNext=result.Result.HasNext; //auto value
            ////_paginate.HasPrevious = result.Result.HasPrevious; //auto value
            //    return _paginate;
        }
    }
}

// Getlist operasyonuna response ekle.
// tobetodaki tüm nesneleri response request patternine göre ekle.
// sistemi automappera çek.
