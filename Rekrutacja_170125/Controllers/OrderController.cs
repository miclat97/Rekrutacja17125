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
        //            o.Id AS OrderId,
        //            o.ShopId,
        //            SUM(op.Quantity * p.NetPrice) AS TotalNetValue
        //        FROM
        //            Orders o
        //        JOIN
        //            OrderProducts op ON o.Id = op.OrderId
        //        JOIN
        //            Products p ON op.ProductId = p.Id
        //        JOIN
        //            Clients c ON o.ClientId = c.Id
        //        WHERE
        //            o.ShopId % 2 = 0
        //            AND LOWER(c.City) LIKE '%w%'
        //        GROUP BY
        //            o.Id, o.ShopId
        //        ORDER BY
        //            o.Id;
        //    ";

        //    var formattableStringQuery = FormattableStringFactory.Create(sqlQuery);

        //    var result = await _context
        //        .Database
        //        .SqlQuery<OrderSummaryDTO>(formattableStringQuery)
        //        .ToListAsync();

        //    return Ok(result);
        //}


        [HttpGet("GetSumOfOrdersValuesInShopsWithEvenIdByEF")]
        public async Task<IActionResult> GetSumOfOrdersValuesInShopsWithEvenIdByEF()
        {
            var result = await _context.Orders
                .Where(o => o.ShopId % 2 == 0)
                .Where(o => o.Shop.City.ToLower().Contains("w"))
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Select(o => new
                {
                    o.Id,
                    o.ShopId,
                    TotalNetValue = o.OrderProducts
                        .Sum(op => op.Quantity * op.Product.NetPrice)
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("GetSummaryOfOrdersGroupedByPaymentMethodWithOrdersGrossThan150")]
        public async Task<IActionResult> GetSummaryOfOrdersGroupedByPaymentMethodWithOrdersGrossThan150()
        {
            var orderTotals = await _context.Orders
                .Select(o => new
                {
                    o.Id,
                    o.PaymentMethod,
                    TotalGrossValue = o.OrderProducts
                        .Sum(op => op.Quantity * op.Product.GrossPrice)
                })
                .Where(o => o.TotalGrossValue >= 150)
                .ToListAsync();

            var summary = orderTotals
                .GroupBy(o => o.PaymentMethod)
                .Select(g => new
                {
                    PaymentMethod = g.Key,
                    OrderCount = g.Count(),
                    TotalGrossValue = g.Sum(o => o.TotalGrossValue)
                })
                .ToList();

            return Ok(summary);
        }
    }
}
