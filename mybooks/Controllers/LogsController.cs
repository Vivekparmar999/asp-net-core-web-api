using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mybooks.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogsService _logsService;

        public LogsController(LogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpGet("get-all-logs-from-db")]
        public IActionResult GetAllLogsFromDB() 
        {
            try
            {
                var allLogs = _logsService.GetAllLogsFromDB();
                return Ok(allLogs);
            }
            catch (Exception e) {
                return BadRequest("could not load logs from the database");
            }
        }
    }
}
