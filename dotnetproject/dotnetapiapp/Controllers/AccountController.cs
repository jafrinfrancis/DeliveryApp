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
    public class AccountController : ControllerBase
    {
        private readonly IAccountProcessor _processor; 
        public AccountController(IAccountProcessor processor){
            _processor = processor;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(Login model){
            try{
                var result = await _processor.Login(model);
                var response = new ResponseObject<AuthResponse>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch(CustomException ex){
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch(Exception ex){           
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(Register model){
            try{
                var result = await _processor.Register(model);
                var response = new ResponseObject<AuthResponse>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch(CustomException ex){
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult> Update(UserDetails model)
        {
            try
            {
                var result = await _processor.Update(model);
                var response = new ResponseObject<UserDetails>
                {
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>
                {
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

        [HttpGet]
        [Route("GetUserDetailsByEmail/{email}")]
        public async Task<ActionResult> GetUserDetailsByEmail(string email){
            try{
                var result = await _processor.GetUserByEmail(email);
                var response = new ResponseObject<UserDetails>{
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch(CustomException ex){
                var response = new ResponseObject<string>{
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return BadRequest(response);
            }
            catch(Exception ex){
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetUserDetailsById/{id}")]
        public async Task<ActionResult> GetUserDetailsById(int id)
        {
            try
            {
                var result = await _processor.GetUserById(id);
                var response = new ResponseObject<UserDetails>
                {
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>
                {
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

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            try
            {
                var result = await _processor.GetAllUsers();
                var response = new ResponseObject<List<UserDetails>>
                {
                    IsSuccess = true,
                    data = result
                };
                return Ok(response);
            }
            catch (CustomException ex)
            {
                var response = new ResponseObject<string>
                {
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

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public async Task<ActionResult> Admin(){
            return Ok("success auth");
        }

        [HttpGet]
        [Authorize(Roles = "DeliveryBoy")]
        [Route("DeliveryBoy")]
        public async Task<ActionResult> DevilveryBoy(){
            return Ok("success auth");
        }

        [HttpGet]
        [Route("Test")]
        public async Task<ActionResult> Test(){
            return Ok("success auth");
        }

        // [HttpGet]
        // [Authorize( OrderType= "Online")]
        // [Route("Online")]
        // public async Task<ActionResult> Online(){
        //     return Ok("success auth");
        // }
        // [HttpGet]
        // [Authorize(OrderType = "Direct")]
        // [Route("Direct")]
        // public async Task<ActionResult> Direct(){
        //     return Ok("success auth");
        // }
        // [HttpGet]
        // [Authorize(OrderType = "ThirdParty")]
        // [Route("ThirdParty")]
        // public async Task<ActionResult> ThirdParty(){
        //     return Ok("success auth");
        // }
        // [HttpGet]
        // [Authorize(OrderType = "Pending")]
        // [Route("Pending")]
        // public async Task<ActionResult> Pending(){
        //     return Ok("success auth");
        // }
        // [HttpGet]
        // [Authorize(OrderType = "LongTimeOrder")]
        // [Route("LongTimeOrder")]
        // public async Task<ActionResult> LongTimeOrder(){
        //     return Ok("success auth");
        // }
    }
}