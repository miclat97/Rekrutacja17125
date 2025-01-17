using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rekrutacja_170125.DatabaseContext;
using Rekrutacja_170125.Entities;
using Rekrutacja_170125.Models;
using System.Runtime.CompilerServices;

namespace Rekrutacja_170125.Controllers
{
    [Route("order")]
    public class OrderController : Controller
    {
        private readonly ShopContext _context;

        public OrderController(ShopContext context)
        {
            _context = context;
        }

        //[HttpGet("sql")]
        //public async Task<IActionResult> GetSumOfOrdersValuesInShopsWithEvenIdSQL()
        //{
        //    var sqlQuery = @"
        //        SELECT 
        //            o.ShopId,
        //            SUM(p.NetPrice * op.Quantity) AS TotalNetValue
        //        FROM Orders o
        //        INNER JOIN OrderProducts op ON o.Id = op.OrderId
        //        INNER JOIN Products p ON op.ProductId = p.Id
        //        WHERE o.ShopId % 2 = 0
        //        AND o.ClientId IN (
        //            SELECT c.Id FROM Clients c WHERE LOWER(c.City) LIKE '%w%'
        //        )
        //        GROUP BY o.ShopId
        //    ";

        //    var formattableStringQuery = FormattableStringFactory.Create(sqlQuery);

        //    var result = await _context
        //        .Database
        //        .SqlQuery<OrderSummaryDTO>(formattableStringQuery)
        //        .ToListAsync();

        //    return Ok(result);
        //}


        //[HttpGet("entityframework")]
        //public async Task<IActionResult> GetSumOfOrdersValuesInShopsWithEvenIdByEF()
        //{
        //    var result = await _context.Orders
        //        .Where(o => o.ShopId % 2 == 0)
        //        .Where(o => o.Client.City.ToLower().Contains("w"))
        //        .Join(_context.OrderProducts,
        //            o => o.Id,
        //            op => op.OrderId,
        //            (o, op) => new { o, op })
        //        .Join(_context.Products,
        //            combined => combined.op.ProductId,
        //            p => p.Id,
        //            (combined, p) => new { combined.o, combined.op, p })
        //        .GroupBy(g => g.o.ShopId)
        //        .Select(g => new OrderSummaryDTO
        //        {
        //            ShopId = g.Key,
        //            TotalNetValue = g.Sum(x => x.op.Quantity * x.p.NetPrice)
        //        })
        //        .ToListAsync();

        //    return Ok(result);
        //}
    }
}
