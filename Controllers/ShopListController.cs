using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.Utils;
using ElPalacio.Domain.Filters;
using ElPalacio.Domain.Commons;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopListController : Controller
    {
        private readonly IShopListManager _manager;

        public ShopListController(IShopListManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] QueryParameter pagingParameter, [FromQuery] ShopListFilter entityFilter)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { Result = _manager.Get(pagingParameter, entityFilter) };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { BankAccount = await _manager.GetById(id) };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Posts the specified bankAccount.
        /// </summary>
        /// <param name="town">The town.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShopListRequestViewModel shopList)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { BankAccount = await _manager.Post(shopList) };
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Patches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="town">The town.</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, ShopListRequestViewModel shopList)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                await _manager.Patch(id, shopList);
                response.Success = 1;
                response.Failure = 0;
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }
        /// <summary>
        /// Patches the specified .
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                await _manager.Delete(id);
                response.Success = 1;
                response.Failure = 0;
            }
            catch (Exception ex)
            {
                response.Success = 0;
                response.Failure = 1;
                response.oData = new { Error = ex.Message };
            }

            return Ok(response);
        }

        /* protected override CheckoutViewModel ConverterOutput(CheckoutViewModel input)
         {
             return _mapper.Map<CheckoutViewModel>(input);
         }*/
    }
}