
using DACS2.Data.Reponsitory;
using DACS2.Share.Consts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DACS2.Web.Areas.Admin.Components.MainNavBar
{
    public class MainNavBarViewComponent : ViewComponent
    {
        readonly BaseReponsitory repository;
        public MainNavBarViewComponent(BaseReponsitory _repository)
        {
            repository = _repository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navBar = new NavBarViewModel();
            navBar.Items.AddRange(new MenuItem[]
            {
                 new MenuItem
                        {
                            Action = "Index",
                            Controller = "Home",
                            DisplayText = "Trang chủ",
                            Icon = "fa-home",
                            Permission = AuthConst.CategoryNews.VIEW_LIST
                        },

                new MenuItem
                {
                    DisplayText = "Quản lý trang web",
                    Icon = "fa-tasks",
                    ChildrenItems = new MenuItem[]
                    {
                        new MenuItem
                        {
                            Action = "Index",
                            Controller = "Account",
                            DisplayText = "Danh sách tài khoản",
                            Icon = "fa-user",
                            Permission = AuthConst.User.VIEW_LIST
                        },
                        new MenuItem
                        {
                            Action = "Index",
                            Controller = "Role",
                            DisplayText = "Quyền trên trang",
                            Icon = "fa-user-tag",
                            Permission = AuthConst.Role.VIEW_LIST
                        },

                    }
                },
                new MenuItem
                {
                    DisplayText = "Quản lý tin tức",
                    Icon = "fa-tasks",
                    ChildrenItems = new MenuItem[]
                    {
                        new MenuItem
                        {
                            Action = "Index",
                            Controller = "CategoryNews",
                            DisplayText = "Thể loại tin  tức",
                            Icon = "fa-newspaper",
                            Permission = AuthConst.CategoryNews.VIEW_LIST
                        },
                         new MenuItem
                        {
                            Action = "Index",
                            Controller = "News",
                            DisplayText = "tin  tức",
                            Icon = "fa-newspaper",
                            Permission = AuthConst.News.VIEW_LIST
                        },

                    }
                },
                new MenuItem
                {
                    DisplayText = "Quản lý Sản phẩm",
                    Icon = "fa-tasks",
                    ChildrenItems = new MenuItem[]
                    {
                       new MenuItem
                        {
                            Action = "Index",
                            Controller = "Supplier",
                            DisplayText = "Nhà cung cấp",
                            Icon = "fa-parachute-box",
                            Permission = AuthConst.Supplier.VIEW_LIST
                        },
                         new MenuItem
                        {
                            Action = "Index",
                            Controller = "CategoryProduct",
                            DisplayText = "Thể loại sản phẩm",
                            Icon = "fa-product-hunt",
                            Permission = AuthConst.CategoryProduct.VIEW_LIST
                        },
                          new MenuItem
                        {
                            Action = "Index",
                            Controller = "Product",
                            DisplayText = "Sản phẩm",
                            Icon = "fa-tshirt",
                            Permission = AuthConst.Product.VIEW_LIST
                        },

                    }
                },
                new MenuItem
                {
                            Action = "Index",
                            Controller = "Voucher",
                            DisplayText = "Mã giảm giá",
                            Icon = "fa-receipt",
                            Permission = AuthConst.Voucher.VIEW_LIST
                },
                new MenuItem
                        {
                            Action = "Index",
                            Controller = "Policy",
                            DisplayText = "Chính sách",
                            Icon = "fa-barcode",
                            Permission = AuthConst.Policy.VIEW_LIST
                        },
                new MenuItem
                {
                            DisplayText = "Khách hàng",
                            Icon = "fa-tasks",
                            ChildrenItems = new MenuItem[]
                            {
                                new MenuItem
                                {
                                    Action = "Index",
                                    Controller = "Report",
                                    DisplayText = "Phản hồi",
                                    Icon = "fa-flag-checkered",
                                    Permission = AuthConst.Report.VIEW_LIST
                                },
                                new MenuItem
                                {
                                    Action = "Index",
                                    Controller = "Cart",
                                    DisplayText = "Giỏ hàng",
                                    Icon = "fa-shopping-cart",
                                    Permission = AuthConst.Invoice.VIEW_LIST
                                },
                            }
                 },
                 
				//new MenuItem
				//{
				//	DisplayText = "Menu 2 cấp",
				//	Icon = "fa-folder-open",
				//	ChildrenItems = new MenuItem[]
				//	{
				//		new MenuItem
				//		{
				//			Action = "Index",
				//			Controller = "User",
				//			DisplayText = "Quản lý tài khoản",
				//			Icon = "fa-user-cog"
				//		}
				//	}
				//},
			});
            return View(navBar);
        }
    }
}
