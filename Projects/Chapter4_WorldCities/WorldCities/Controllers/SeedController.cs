using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldCities.Data;
using OfficeOpenXml;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WorldCities.Data.Models;
using System.Text.Json;

namespace WorldCities.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SeedController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult> Import()
        {
            var path = Path.Combine(
                _env.ContentRootPath,
                String.Format("Data/Source/worldCites.xlsx"));

            using (var stream = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read))
                {
                    using (var ep = new ExcelPackage(stream))
                    {
                        //get the first worksheet
                        var ws = ep.Workbook.Worksheets[0];

                        //initslize the record counters
                        var nCountries = 0;
                        var nCites = 0;

                        #region Import all countries
                        //create alist containing all the countries
                        // already existing into the database (it will be empty on the first run)
                        var lstCountries =_context.Countries.ToList();

                        //iterates throught all rows, skipping the first one
                        for (int nRow = 2; nRow <=ws.Dimension.End.Row; nRow++)
                        {
                            var row = ws.Cells[nRow, 1, nRow, ws.Dimension.End.Column];
                            var name = row[nRow, 5].GetValue<string>();

                            // Did we already created a country with the name?
                            if (lstCountries.Where(c => c.Name == name ).Count()==0)
                            {
                                //create the country entity and fill it with xlsx data
                                
                            }


                        }





                    }
                }
            
        }
    }
}