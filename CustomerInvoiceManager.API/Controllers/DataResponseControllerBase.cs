using CustomerInvoiceManager.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerInvoiceManager.API.Controllers
{
    public class DataResponseControllerBase : ControllerBase
    {
        protected DataResponse<T> CreateDataResponse<T>(Func<T> setDataResponseValue)
        {
            DataResponse<T> dataResponse = new DataResponse<T>();
            try
            {
                dataResponse.Value = setDataResponseValue();
            }
            catch (Exception ex)
            {
                dataResponse.Exception = ex;
            }
            return dataResponse;
        }
    }
}
