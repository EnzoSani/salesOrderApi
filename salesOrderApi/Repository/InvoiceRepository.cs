using AutoMapper;
using Microsoft.EntityFrameworkCore;
using salesOrderApi.DataAccess;
using salesOrderApi.Entity;
using salesOrderApi.Models;
using salesOrderApi.Repository.IRepository;

namespace salesOrderApi.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IMapper _mapper;

        public InvoiceRepository(ApplicationDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<InvoiceHeader>> GetAllInvoiceHeader()
        {
            var _data = await _dbContext.TblSalesHeaders.ToListAsync();
            if (_data != null && _data.Count > 0)
            {
                var _dataItem = _mapper.Map<List<InvoiceHeader>>(_data);
                return _dataItem;
            }
            return new List<InvoiceHeader>();
        }

        public async Task<InvoiceHeader> GetInvoiceHeaderByCode(string invoiceNo)
        {
            var _data = await _dbContext.TblSalesHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceNo);
            if(_data != null)
            {
                var _dataItem = _mapper.Map<InvoiceHeader>(_data);
                return _dataItem;
            }
            return new InvoiceHeader();
        }

        public async Task<List<InvoiceDetail>> GetAllInvoiceDetailByCode(string invoiceNo)
        {
            var _data = await _dbContext.TblSalesProductInfos.Where(item=>item.InvoiceNo == invoiceNo).ToListAsync();
            if(_data != null)
            {
                var _dataItem = _mapper.Map<List<InvoiceDetail>>(_data);
                return _dataItem;
            }
            return new List<InvoiceDetail>();
        }

        public async Task<ResponseType> Save(InvoiceInput invoiceEntity)
        {
            string Result = string.Empty;
            int processcount = 0;
            var response = new ResponseType();
            if (invoiceEntity != null)
            {
                using (var dbtransaction = await _dbContext.Database.BeginTransactionAsync())
                {

                    if (invoiceEntity != null)
                        Result = await SaveHeader(invoiceEntity);

                    if (!string.IsNullOrEmpty(Result) && (invoiceEntity.Details != null && invoiceEntity.Details.Count > 0))
                    {
                        invoiceEntity.Details.ForEach(item =>
                        {
                            bool saveresult = this.SaveDetail(item, invoiceEntity.CreateUser, invoiceEntity.InvoiceNo).Result;
                            if (saveresult)
                            {
                                processcount++;
                            }
                        });

                        if (invoiceEntity.Details.Count == processcount)
                        {
                            await _dbContext.SaveChangesAsync();
                            await dbtransaction.CommitAsync();
                            response.Result = "pass";
                            response.KyValue = Result;
                        }
                        else
                        {
                            await dbtransaction.RollbackAsync();
                            response.Result = "faill";
                            response.Result = string.Empty;
                        }
                    }
                    else
                    {
                        response.Result = "faill";
                        response.Result = string.Empty;
                    }

                    // await this._DBContext.SaveChangesAsync();
                    //         await dbtransaction.CommitAsync();
                    //         response.Result = "pass";
                    //         response.KyValue = Result;

                };
            }
            else
            {
                return new ResponseType();
            }
            return response;

        }

        private async Task<string> SaveHeader(InvoiceInput invoiceHeader)
        {
            string Result = string.Empty;
            try
            {
                TblSalesHeader _header = _mapper.Map<InvoiceInput, TblSalesHeader>(invoiceHeader);
                _header.InvoiceDate= DateTime.Now;
                var header = await _dbContext.TblSalesHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceHeader.InvoiceNo);
                
                if(header != null)
                {
                    header.CustomerId = invoiceHeader.CustomerId;
                    header.CustomerName = invoiceHeader.CustomerName;
                    header.DeliveryAddress = invoiceHeader.DeliveryAddress;
                    header.Total = invoiceHeader.Total;
                    header.Remarks = invoiceHeader.Remarks;
                    header.Tax = invoiceHeader.Tax;
                    header.NetTotal = invoiceHeader.NetTotal;
                    header.ModifyUser = invoiceHeader.CreateUser;
                    header.ModifyDate = DateTime.Now;

                    var _detdata = await _dbContext.TblSalesProductInfos.Where(item => item.InvoiceNo == invoiceHeader.InvoiceNo).ToListAsync();
                    if (_detdata != null && _detdata.Count > 0)
                    {
                        _dbContext.TblSalesProductInfos.RemoveRange(_detdata);
                    }
                }
                else
                {
                    await _dbContext.TblSalesHeaders.AddAsync(_header);
                }
                Result = invoiceHeader.InvoiceNo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return Result;
        }

        private async Task<bool> SaveDetail(InvoiceDetail invoiceDetail, string User, string InvoiceNo)
        {
            try
            {
                TblSalesProductInfo _detail = _mapper.Map<InvoiceDetail, TblSalesProductInfo>(invoiceDetail);
                _detail.CreateDate = DateTime.Now;
                _detail.CreateUser = User;
                _detail.InvoiceNo = InvoiceNo;
                await _dbContext.TblSalesProductInfos.AddAsync(_detail);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<ResponseType> Remove(string invoiceNo)
        {
            try
            {
                using(var dbTransaction = await _dbContext.Database.BeginTransactionAsync())
                {
                    var _data = await _dbContext.TblSalesHeaders.FirstOrDefaultAsync(item=> item.InvoiceNo == invoiceNo);
                    if (_data != null)
                    {
                        _dbContext.TblSalesHeaders.Remove(_data);
                    }

                    var _detdata = await _dbContext.TblSalesProductInfos.Where(item=> item.InvoiceNo == invoiceNo).ToListAsync();
                    if(_detdata != null && _detdata.Count >0)
                    {
                        _dbContext.TblSalesProductInfos.RemoveRange(_detdata);
                    }

                    await _dbContext.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                }
                return new ResponseType() {  Result="pass", KyValue=invoiceNo};
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
