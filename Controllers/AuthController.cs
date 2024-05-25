using AutoMapper;
using IceCreamRecipe.Repositories.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Users;
using Models.VnPay;
using Repositories.Plans;
using Repositories.Users;
using Services.VnpayService;

namespace Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {

        private readonly IUserRepo userRepo;
        
        private readonly IVnPayService vnPayService;
        

        public AuthController(IUserRepo userRepo,IVnPayService vnPayService) {
            this.userRepo = userRepo;
            this.vnPayService = vnPayService;

        }

        /// <summary>
        /// register user
        /// </summary>
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto dto) {
            var user = await userRepo.Register(dto);
            var model = new VnPaymentSubscriptionRequestModel();
            
            // var plan = await planRepo.FindById(dto.planId);
            model.TotalAmount = (dto.PlanId == 1 ? 15 : 150) * 25000; 
            model.PlanId = dto.PlanId;
            model.UserId = user.Id;
            
            
            return Ok(vnPayService.CreatePaymentUrlForSubscription(model));
                
        }

        /// <summary>
        /// login
        /// </summary>
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto dto) {
            TokenDto token = await userRepo.Login(dto);
            return Ok(token);
        }

        //[Authorize(Roles = "User,Admin")]
        [HttpGet("Test")]
        public IActionResult Test() {
            return Ok(User.Identity.IsAuthenticated);
        }

    }
}
