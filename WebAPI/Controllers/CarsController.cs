using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            var result= _carService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.IsSuccess) 
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(Car car) 
        {
            //carmanager da getbyid metodu da olmalıydı aslında
            
            var result =_carService.Delete(car);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.IsSuccess == true)
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result=_carService.GetCarDetails();
            if (result.IsSuccess) 
            {
                return Ok(result);
            }
            else
                return BadRequest();
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            return BadRequest(result);
        }
    }
}
