using ShopDuongSon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopDuongSon.Controllers
{
    public class OrderController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Order
        public ActionResult Checkout()
        {
            // Lấy UserName của user đang đăng nhập
            var UserName = User.Identity.Name;
            // Lấy thông tin khách hàng đăng nhập từ CSDL
            var customer = db.Customers.Find(UserName);

            var model = new Order
            {
                CustomerId = customer.Id,
                OrderDate = DateTime.Now,
                Receiver = customer.Fullname,
                Amount = ShoppingCart.Cart.Total,
                Address = "105 Bà Huyện Thanh Quan, Q.3 Tp.HCM",
                RequireDate = DateTime.Now.AddDays(5)
            };
            return View(model);
           
        }

        public ActionResult Purchase(Order model)
        {
            try
            {
                db.Orders.Add(model); // Thêm order
                foreach (var p in ShoppingCart.Cart.Items)
                {
                    var detail = new OrderDetail
                    {
                        Order = model,
                        ProductId = p.Id,
                        UnitPrice = p.UnitPrice,
                        Quantity = p.Quantity,
                        Discount = p.Discount
                    };
                    db.OrderDetails.Add(detail); // thêm order details
                }
                db.SaveChanges();
                ShoppingCart.Cart.Clear();

                return RedirectToAction("MyOrders");
            }
            catch
            {
                ModelState.AddModelError("", "Lỗi, vui lòng kiểm tra lại thông tin đặt hàng !");
                return View("Checkout", model);
            }
        }
        public ActionResult MyOrders()
        {
            var customer = db.Customers.Find(User.Identity.Name);
            return View(customer.Orders);
        }
        public ActionResult Detail(int Id)
        {
            var order = db.Orders.Find(Id);
            return View(order);
        }
    }
}