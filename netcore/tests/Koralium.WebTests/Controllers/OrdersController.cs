using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koralium.WebTests.Entities.tpch;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Koralium.WebTests.Controllers
{

    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        public class JsonResponse<T>
        {
            public List<T> Values { get; set; }
        }

        private readonly TpchData _tpchData;
        public OrdersController(TpchData tpchData)
        {
            _tpchData = tpchData;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _tpchData.Orders;
        }
    }
}
