using Homework67_Tasks.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework67_Tasks.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskItemsController : ControllerBase
    {
        private readonly IHubContext<TaskHub> _context;
        private string _connectionString;

        public TaskItemsController(IHubContext<TaskHub> context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("ConStr");
        }
    }
}
