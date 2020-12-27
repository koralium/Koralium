/*
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
