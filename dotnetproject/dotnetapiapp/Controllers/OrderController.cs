using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapiapp.Models;
using Microsoft.AspNetCore.Authorization;
using dotnetapiapp.Common;
using dotnetapiapp.Domain;
using dotnetCommonUtils.CommonModels;

namespace dotnetapiapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProcessor _processor;
        public OrderController(IOrderProcessor processor)
        {
            _processor = processor;
        }

        [Route("GetOrderByid")]
        [HttpGet]
        public async Task<ActionResult> GetOrderByid(int id)
        {
            try
            {
                var result = await _processor.GetOrderByid(id);
                var response = new ResponseObject<Order>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("GetAllOrders")]
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            try
            {
                var result = await _processor.GetAllOrders();
                var response = new ResponseObject<List<Order>>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("CreateOrder")]
        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order order)
        {
            try
            {
                var result = await _processor.CreateOrder(order);
                var response = new ResponseObject<Order>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("UpdateOrder")]
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Order order)
        {
            try
            {
                var result = await _processor.UpdateOrder(order);
                var response = new ResponseObject<Order>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("DeleteOrder/{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            try
            {
                var result = await _processor.DeleteOrder(id);
                var response = new ResponseObject<bool>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("GetDeliveryByid")]
        [HttpGet]
        public async Task<ActionResult> GetDeliveryByid(int id)
        {
            try
            {
                var result = await _processor.GetDeliveryByid(id);
                var response = new ResponseObject<Delivery>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("GetDeliveryByUserId")]
        [HttpGet]
        public async Task<ActionResult> GetDeliveryByUserId(int userid)
        {
            try
            {
                var result = await _processor.GetDeliveryByUserId(userid);
                var response = new ResponseObject<List<Delivery>>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("GetAllDeliveries")]
        [HttpGet]
        public async Task<IActionResult> GetAllDeliveries()
        {
            try
            {
                List<Delivery> delivery = new List<Delivery>();
                delivery = await _processor.GetAllDeliveries();
                var response = new ResponseObject<List<Delivery>>{
                    IsSuccess = true,
                    data = delivery
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("CreateDelivery")]
        [HttpPost]
        public async Task<ActionResult> CreateDelivery(Delivery delivery)
        {
            try
            {
                var result = await _processor.CreateDelivery(delivery);
                var response = new ResponseObject<Delivery>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("UpdateDelivery")]
        [HttpPut]
        public async Task<ActionResult> UpdateDelivery(Delivery delivery)
        {
            try
            {
                var result = await _processor.UpdateDelivery(delivery);
                var response = new ResponseObject<Delivery>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("DeleteDelivery")]
        [HttpDelete]
        public async Task<ActionResult> DeleteDelivery(int Id)
        {
            try
            {
                var result = await _processor.DeleteDelivery(Id);
                var response = new ResponseObject<bool>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Route("GetDashBoardDetails")]
        [HttpGet]
        public async Task<IActionResult> GetDashBoardDetails(int userId)
        {
            try
            {
                List<DeliveryStatusCount> dashboard = new List<DeliveryStatusCount>();
                dashboard = await _processor.GetDashboardDetails(userId);
                var response = new ResponseObject<List<DeliveryStatusCount>>{
                    IsSuccess = true,
                    data = dashboard
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}