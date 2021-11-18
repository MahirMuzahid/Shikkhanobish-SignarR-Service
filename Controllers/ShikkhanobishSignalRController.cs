using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shikkhanobish_SignarR_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShikkhanobishSignalRController : ControllerBase
    {
        private readonly IHubContext<ShikkhanobishHub> _hubContext;
        public ShikkhanobishSignalRController(IHubContext<ShikkhanobishHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("CallSelectedTeacher")]
        public async Task<IActionResult> CallSelectedTeacher(int teacherID, string des, string cls, string sub, string chapter, int cost, string name, int studentID)
        {
            await _hubContext.Clients.All.SendAsync("CallSelectedTeacher", teacherID, des, cls, sub, chapter, cost, name, studentID);

            return Ok("ok");
        }

        [HttpPost("StudentPaymentStatus")]
        public async Task<IActionResult> StudentPaymentStatus(int studentID, bool successFullPayment, string amount, string response, string paymentID, string trxID, string cardID, string cardType)
        {
            await _hubContext.Clients.All.SendAsync("StudentPaymentStatus", studentID, successFullPayment, amount, response, paymentID, trxID, cardID, cardType);

            return Ok("ok");
        }
        [HttpPost("SelectedTeacherResponse")]
        public async Task<IActionResult> SelectedTeacherResponse(int teacherID, int  studentID, bool response, int apikey, string sessionID, string token)
        {
            await _hubContext.Clients.All.SendAsync("SelectedTeacherResponse", teacherID, studentID, response, apikey, sessionID, token);

            return Ok("ok");
        }
        [HttpPost("PassActiveStatus")]
        public async Task<IActionResult> PassActiveStatus(int teacherID, bool isActive)
        {
            await _hubContext.Clients.All.SendAsync("PassActiveStatus", teacherID, isActive);

            return Ok("ok");
        }
        [HttpPost("CutVideoCall")]
        public async Task<IActionResult> CutVideoCall(int teacherID, int studentID, bool isCut)
        {
            await _hubContext.Clients.All.SendAsync("CutVideoCall", teacherID, studentID, isCut);

            return Ok("ok");
        }
        [HttpPost("SendTimeAndCostInfo")]
        public async Task<IActionResult> SendTimeAndCostInfo(int teacherID, int studentID, int time, double earned)
        {
            await _hubContext.Clients.All.SendAsync("SendTimeAndCostInfo", teacherID, studentID, time, earned);

            return Ok("ok");
        }
        [HttpPost("LastMinAlert")]
        public async Task<IActionResult> LastMinAlert(int teacherID, int studentID, bool isLastMin)
        {
            await _hubContext.Clients.All.SendAsync("LastMinAlert", teacherID, studentID, isLastMin);

            return Ok("ok");
        }
        [HttpPost("studentTuitionResponse")]
        public async Task<IActionResult> studentTuitionResponse(int teacherID, int studentID, bool studentTuitionResponse, bool hidestVideo)
        {
            await _hubContext.Clients.All.SendAsync("studentTuitionResponse", teacherID, studentID, studentTuitionResponse, hidestVideo);

            return Ok("ok");
        }
        [HttpPost("sumbitQs")]
        public async Task<IActionResult> sumbitQs(int teacherID, int qsID, string errorTxt)
        {
            await _hubContext.Clients.All.SendAsync("sumbitQs", teacherID, qsID, errorTxt);

            return Ok("ok");
        }
        [HttpPost("realTimetuitionNotiofication")]
        public async Task<IActionResult> realTimetuitionNotiofication(string tuitionid)
        {
            await _hubContext.Clients.All.SendAsync("realTimetuitionNotiofication", tuitionid);

            return Ok("ok");
        }
    }
}
