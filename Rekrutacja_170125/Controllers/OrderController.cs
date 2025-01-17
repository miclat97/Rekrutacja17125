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

        [HttpGet("GetSumOfOrdersValuesInShopsWithEvenIdBySQL")]
        public async Task<IActionResult> GetSumOfOrdersValuesInShopsWithEvenIdSQL()
        {
            var query = @"
                SELECT
                    o.OrderId AS OrderId,
                    o.ShopId,
                    SUM(op.Quantity * p.NetPrice) AS TotalNetValue
                FROM Orders o
                INNER JOIN Shops s ON o.ShopId = s.Id
                INNER JOIN OrderProducts op ON o.Id = op.OrderId
                INNER JOIN Products p ON op.ProductId = p.Id
                WHERE
                    o.ShopId % 2 = 0
                    AND LOWER(s.City) LIKE '%w%'
                GROUP BY
                    o.Id,
                    o.ShopId;
            ";

            var result = await _context.Orders
                .FromSqlRaw(query)
                .Select(o => new OrderSummaryDTO
                {
                    OrderId = o.Id,
                    ShopId = o.ShopId,
                    TotalNetValue = o.OrderProducts.Sum(op => op.Quantity * op.Product.NetPrice)
                })
                .ToListAsync();


            return Ok(result);
        }


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
