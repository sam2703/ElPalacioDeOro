using ElPalacio.Domain.Commons;
using ElPalacio.Domain.Entities;
using ElPalacio.Domain.Filters;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.Manager;
using ElPalacio.Domain.Utils;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElPalacio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _manager;

        public CategoryController(ICategoryManager manager)
        {
            _manager = manager;
        }
        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get([FromQuery] QueryParameter pagingParameter, [FromQuery] CategoryFilter entityFilter)
        {
            pagingParameter.AllowPaging = false;
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
                response.oData = new { BalanceProvider = await _manager.GetById(id) };
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
        public async Task<IActionResult> Post([FromBody] CategoryRequestViewModel viewModel)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                response.Success = 1;
                response.Failure = 0;
                response.oData = new { Category = await _manager.Post(viewModel) };
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
        public async Task<IActionResult> Patch(int id, CategoryRequestViewModel category)
        {
            JsonResponse response = new JsonResponse();

            try
            {
                await _manager.Patch(id, category);
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

        /*  protected override CategoryViewModel ConverterOutput(CategoryRequestViewModel input)
          {
              return _mapper.Map<CategoryViewModel>(input);
          }*/
    }
}