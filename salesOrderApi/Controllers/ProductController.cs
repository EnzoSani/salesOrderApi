using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salesOrderApi.Entity;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductRepository productRepository, IWebHostEnvironment environment)
        {
            _productRepository = productRepository;
            _environment = environment;
        }

        [HttpGet ("GetAll")]
        public async Task<List<ProductEntity>> GetAll()
        {
            var productList = await _productRepository.GetAll();

            if(productList != null && productList.Count > 0)
            {
                productList.ForEach(item =>
                {
                    item.ProductImage = GetImageProduct(item.Code);
                });
            }
            return productList;
        }

        [HttpPost ("UploadImage")]
        public async Task<ActionResult> UploadImage()
        {
            bool Results = false;
            try
            {
                var _uploadFiles = Request.Form.Files;
                foreach (IFormFile source in _uploadFiles)
                {
                    string Filename = source.Name;
                    string FilePath = GetFilePath(Filename);

                    if(!System.IO.File.Exists(FilePath))
                    {
                        System.IO.File.Create(FilePath);
                    }

                    string imagePath = FilePath + "\\image.png";

                    if(System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using(FileStream stream = System.IO.File.Create(imagePath)) 
                    {
                        await source.CopyToAsync(stream);
                        Results = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Ok(Results);
        }

        [HttpGet ("RemoveImage/{code}")]
        public ResponseType RemoveImage(string code)
        {
            string FilePath = GetFilePath(code);
            string ImagePath = FilePath + "\\image.png";

            try
            {
                if (System.IO.File.Exists(ImagePath))
                {
                    System.IO.File.Delete(ImagePath);
                }

                return new ResponseType { Result = "Pass", KyValue = code };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet ("GetByCode")]
        public async Task<ProductEntity> GetByCode(string code)
        {
            return await _productRepository.GetByCode(code);
        }

        [HttpGet ("GetByCategory")]
        public async Task<List<ProductEntity>> GetByCategory(int code)
        {
            return await _productRepository.GetByCategory(code);
        }

        [HttpPost ("SaveProduct")]
        public async Task<ResponseType> SaveProduct([FromBody]ProductEntity product)
        {
            return await _productRepository.SaveProduct(product);
        }

        [NonAction]
        private string GetFilePath(string productCode)
        {
            return _environment.WebRootPath + "\\Uploads\\Product\\" + productCode;
        }

        [NonAction]
        private string GetImageProduct(string productCode)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "https://localhost:44342/";
            string FilePath = GetFilePath(productCode);
            string ImagePath = FilePath + "\\image.png";
            if(!System.IO.File.Exists(ImagePath))
            {
                ImageUrl = HostUrl + "/uploads/common/noimage.png";
            }
            else
            {
                ImageUrl = HostUrl + "/uploads/Product/" + productCode + "/image.png";
            }
            return ImageUrl;
        }


    }
}
