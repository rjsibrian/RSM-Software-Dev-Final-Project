using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppApi.Models;

namespace CONTROLLER_BASED_API_with_ASP.NET_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesSummaryViewController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalesSummaryViewController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SalesSummaryView
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleSummaryView>>> GetSalesSummaryView()
        {
            return await _context.SalesSummaryView.ToListAsync();
        }

    }
}
