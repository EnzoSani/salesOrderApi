using AutoMapper;
using Microsoft.EntityFrameworkCore;
using salesOrderApi.DataAccess;
using salesOrderApi.Entity;
using salesOrderApi.Models;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            var customerData = await _dbContext.TblProducts.ToListAsync();
            if(customerData != null && customerData.Count > 0)
            {
                return _mapper.Map<List<ProductEntity>>(customerData);
            }
            return new List<ProductEntity>();
        }

        public async Task<ProductEntity> GetByCode(string code)
        {
            var customerData = await _dbContext.TblProducts.FirstOrDefaultAsync(item => item.Code == code);
            if(customerData != null)
            {
                var _prodData = _mapper.Map<ProductEntity>(customerData);
                if(_prodData !=null)
                {
                    _prodData.Variants = GetVariantByProduct(code).Result;
                }
                return _prodData;
            }
            return new ProductEntity();
        }

        public async Task<List<ProductVariantEntity>> GetVariantByProduct(string productCode)
        {
            var customerData = await _dbContext.TblProductvarinats.Where(item=>item.ProductCode == productCode).ToListAsync();
            if(customerData != null && customerData.Count > 0)
            {
                return _mapper.Map<List<ProductVariantEntity>>(customerData);
            }
            return new List<ProductVariantEntity>(); 
        }

        public async Task<List<ProductEntity>> GetByCategory(int category)
        {
            var customerData = await _dbContext.TblProducts.Where(item=>item.CategoryId == category).ToListAsync();   
            if(customerData != null && customerData.Count > 0)
            {
                return _mapper.Map<List<ProductEntity>>(customerData);
            }
            return new List<ProductEntity>();
        }

        public async Task<ResponseType> SaveProduct(ProductEntity product)
        {
            try
            {
                string Result = string.Empty;
                int processcount = 0;

                if(product != null)
                {
                    using(var dbtransaction = await _dbContext.Database.BeginTransactionAsync())
                    {
                        //check exist product
                        var _product = await _dbContext.TblProducts.FirstOrDefaultAsync(item=>item.Code == product.Code);
                        if(_product != null)
                        {
                            //update here
                            _product.Name = product.Name;
                            _product.CategoryId = product.Category;
                            _product.Price = product.Price;
                            _product.Remarks = product.Remarks;
                        }
                        else
                        {
                            //create new record
                            var _newProduct = new TblProduct()
                            {
                                Code = product.Code,
                                Name = product.Name,
                                Price = product.Price,
                                CategoryId = product.Category,
                                Remarks = product.Remarks
                            };
                            await _dbContext.TblProducts.AddAsync(_newProduct);

                        }
                        if(product.Variants != null && product.Variants.Count > 0)
                        {
                            product.Variants.ForEach(item =>
                            {
                                var _resp = SaveProductVariant(item, product.Code);
                                if (_resp.Result)
                                {
                                    processcount++;
                                }
                            });
                            if(processcount == product.Variants.Count)
                            {
                                await _dbContext.SaveChangesAsync();
                                await dbtransaction.CommitAsync();
                                return new ResponseType() { KyValue = product.Code, Result = "Pass" };
                            }
                            else
                            {
                                await dbtransaction.RollbackAsync();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return new ResponseType() { KyValue = string.Empty, Result = "Fail" };
        }

        public async Task<bool> SaveProductVariant(ProductVariantEntity _variant, string productCode)
        {
            bool Result = false;

            try
            {
                var _existData = await _dbContext.TblProductvarinats.FirstOrDefaultAsync(item => item.Id == _variant.Id);
                if (_existData != null)
                {
                    _existData.ColorId = _variant.ColorId;
                    _existData.SizeId = _variant.SizeId;
                    _existData.ProductCode = _variant.ProductCode;
                    _existData.Price = _variant.Price;
                    _existData.Remarks = _variant.Remarks;
                }
                else
                {
                    var _newRecord = new TblProductvariant()
                    {
                        ColorId = _variant.ColorId,
                        SizeId = _variant.SizeId,
                        ProductCode = _variant.ProductCode,
                        Price = _variant.Price,
                        Remarks = _variant.Remarks,
                        Isactive = true
                    };
                    await _dbContext.TblProductvarinats.AddAsync(_newRecord);
                }
                Result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Result;
        }
    }
}
