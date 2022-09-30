using DACS2.Share.Consts;
using DACS2.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACS2.Data.DataSender
{
    public static class MstPerMissionSender
    {
        public static void SeedData(this EntityTypeBuilder<MstPerMission> builder)
        {
            var now = new DateTime(year: 2021, month: 11, day: 10);
            var groupName = "";
            #region Data liên quan đến bảng Role
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý phân quyền";
            builder.HasData(
                new MstPerMission
                {
                    Id=AuthConst.Role.CREATE,
                    Code = "CREATE",
                    Table = NameTable.RoleTable,
                    GroupName = groupName,
                    Desc = "Thêm quyền",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Role.DELETE,
                    Code = "DELETE",
                    Table = NameTable.RoleTable,
                    GroupName = groupName,
                    Desc = "Xóa quyền",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Role.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.RoleTable,
                    GroupName = groupName,
                    Desc = "Sửa quyền",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Role.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = NameTable.RoleTable,
                    GroupName = groupName,
                    Desc = "Xem chi tiết quyền",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Role.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.RoleTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách quyền",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng CategoryNew
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý Thể loại tin tức";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.CategoryNews.CREATE,
                    Code = "CREATE",
                    Table = NameTable.CategoryNewsTable,
                    GroupName = groupName,
                    Desc = "Thêm thể loại tin thức",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.CategoryNews.DELETE,
                    Code = "DELETE",
                    Table = NameTable.CategoryNewsTable,
                    GroupName = groupName,
                    Desc = "Xóa thể loại tin thức",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.CategoryNews.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.CategoryNewsTable,
                    GroupName = groupName,
                    Desc = "Sửa thể loại tin thức",
                    CreatedDate = now
                },
               
                new MstPerMission
                {
                    Id = AuthConst.CategoryNews.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.CategoryNewsTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách thể loại tin thức",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng CategoryProduct
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý thể loại sản phẩm";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.CategoryProduct.CREATE,
                    Code = "CREATE",
                    Table = NameTable.CategoryProductTable,
                    GroupName = groupName,
                    Desc = "Thêm thể loại sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.CategoryProduct.DELETE,
                    Code = "DELETE",
                    Table = NameTable.CategoryProductTable,
                    GroupName = groupName,
                    Desc = "Xóa thể loại sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.CategoryProduct.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.CategoryProductTable,
                    GroupName = groupName,
                    Desc = "Sửa thể loại sản phẩm",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.CategoryProduct.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.CategoryProductTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách thể loại sản phẩm",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng Color
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý màu sản phẩm";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Color.CREATE,
                    Code = "CREATE",
                    Table = NameTable.ColorTable,
                    GroupName = groupName,
                    Desc = "Thêm màu sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Color.DELETE,
                    Code = "DELETE",
                    Table = NameTable.ColorTable,
                    GroupName = groupName,
                    Desc = "Xóa màu sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Color.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.ColorTable,
                    GroupName = groupName,
                    Desc = "Sửa màu sản phẩm",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Color.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.ColorTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách màu sản phẩm",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng Designs
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý kiểu dáng sản phẩm";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Designs.CREATE,
                    Code = "CREATE",
                    Table = NameTable.DesignsTable,
                    GroupName = groupName,
                    Desc = "Thêm  kiểu dáng sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Designs.DELETE,
                    Code = "DELETE",
                    Table = NameTable.DesignsTable,
                    GroupName = groupName,
                    Desc = "Xóa kiểu dáng sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Designs.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.DesignsTable,
                    GroupName = groupName,
                    Desc = "Sửa kiểu dáng sản phẩm",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Designs.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.DesignsTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách kiểu dáng sản phẩm",
                    CreatedDate = now
                }
                
            );
            #endregion
            #region Data liên quan đến bảng Image
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý hình sản phẩm";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Image.CREATE,
                    Code = "CREATE",
                    Table = NameTable.ImageTable,
                    GroupName = groupName,
                    Desc = "Thêm  hình ảnh sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Image.DELETE,
                    Code = "DELETE",
                    Table = NameTable.ImageTable,
                    GroupName = groupName,
                    Desc = "Xóa hình ảnh sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Image.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.ImageTable,
                    GroupName = groupName,
                    Desc = "Sửa hình ảnh sản phẩm",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Image.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.ImageTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách hình ảnh sản phẩm",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng Invoice
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý giỏ hàng";
            builder.HasData(

                new MstPerMission
                {
                    Id = AuthConst.Invoice.DELETE,
                    Code = "DELETE",
                    Table = NameTable.InvoiceTable,
                    GroupName = groupName,
                    Desc = "Xóa đơn hàng",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Invoice.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.InvoiceTable,
                    GroupName = groupName,
                    Desc = "Sửa đơn hàng",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Invoice.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.InvoiceTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách đơn hàng",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Invoice.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = NameTable.InvoiceTable,
                    GroupName = groupName,
                    Desc = "Xem  đơn hàng",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng InvoiceDetails
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý giỏ hàng";
            builder.HasData(

                new MstPerMission
                {
                    Id = AuthConst.InvoiceDetails.DELETE,
                    Code = "DELETE",
                    Table = NameTable.InvoiceDetailsTable,
                    GroupName = groupName,
                    Desc = "Xóa đơn hàng",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.InvoiceDetails.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.InvoiceDetailsTable,
                    GroupName = groupName,
                    Desc = "Xem chi tiết danh sách đơn hàng",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng News
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý tin tức";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.News.CREATE,
                    Code = "CREATE",
                    Table = NameTable.NewsTable,
                    GroupName = groupName,
                    Desc = "Thêm tin tức",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.News.DELETE,
                    Code = "DELETE",
                    Table = NameTable.NewsTable,
                    GroupName = groupName,
                    Desc = "Xóa tin tức",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.News.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.NewsTable,
                    GroupName = groupName,
                    Desc = "Sửa tin tức",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.News.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.NewsTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách tin tức",
                    CreatedDate = now
                },
                  new MstPerMission
                  {
                      Id = AuthConst.News.VIEW_DETAIL,
                      Code = "VIEW_DETAIL",
                      Table = NameTable.NewsTable,
                      GroupName = groupName,
                      Desc = "Xem tin tức",
                      CreatedDate = now
                  }
            );
            #endregion
            #region Data liên quan đến bảng Product
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý tin tức";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Product.CREATE,
                    Code = "CREATE",
                    Table = NameTable.productTable,
                    GroupName = groupName,
                    Desc = "Thêm sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Product.DELETE,
                    Code = "DELETE",
                    Table = NameTable.productTable,
                    GroupName = groupName,
                    Desc = "Xóa sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Product.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.productTable,
                    GroupName = groupName,
                    Desc = "Sửa sản phẩm",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Product.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.productTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách sản phẩm",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Product.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = NameTable.productTable,
                    GroupName = groupName,
                    Desc = "Xem sản phẩm",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng User
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý tài khoản";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.User.CREATE,
                    Code = "CREATE",
                    Table = NameTable.UserTable,
                    GroupName = groupName,
                    Desc = "Thêm tài khoản",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.User.DELETE,
                    Code = "DELETE",
                    Table = NameTable.UserTable,
                    GroupName = groupName,
                    Desc = "Xóa tài khoản",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.User.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.UserTable,
                    GroupName = groupName,
                    Desc = "Sửa tài khoản",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.User.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.UserTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách tài khoản",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.User.UNBLOCK,
                    Code = "UNBLOCK",
                    Table = NameTable.UserTable,
                    GroupName = groupName,
                    Desc = "Mở khóa tài khoản",
                    CreatedDate = now
                },
                 new MstPerMission
                 {
                     Id = AuthConst.User.BLOCK,
                     Code = "BLOCK",
                     Table = NameTable.UserTable,
                     GroupName = groupName,
                     Desc = "Khóa tài khoản",
                     CreatedDate = now
                 },
                 new MstPerMission
                 {
                     Id = AuthConst.User.UPDATE_PWD,
                     Code = "UPDATE_PWD",
                     Table = NameTable.UserTable,
                     GroupName = groupName,
                     Desc = "Đổi mật khẩu",
                     CreatedDate = now
                 },
                 new MstPerMission
                 {
                     Id = AuthConst.User.VIEW_DETAIL,
                     Code = "VIEW_DETAIL",
                     Table = NameTable.UserTable,
                     GroupName = groupName,
                     Desc = "Xem tài khoản",
                     CreatedDate = now
                 }
            );
            #endregion
            #region Data liên quan đến bảng Voucher
            // Permission liên quan đến bảng AppRole
            groupName = "Quản lý tin tức";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Voucher.CREATE,
                    Code = "CREATE",
                    Table = NameTable.VoucherTable,
                    GroupName = groupName,
                    Desc = "Thêm mã giảm giá",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Voucher.DELETE,
                    Code = "DELETE",
                    Table = NameTable.VoucherTable,
                    GroupName = groupName,
                    Desc = "Xóa mã giảm giá",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Voucher.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.VoucherTable,
                    GroupName = groupName,
                    Desc = "Sửa Mã giảm giá",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Voucher.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.VoucherTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách mã",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Voucher.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = NameTable.VoucherTable,
                    GroupName = groupName,
                    Desc = "Xem mã giảm giá",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng Policy
            // Permission liên quan đến bảng policy
            groupName = "Quản lý chính sách";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Policy.CREATE,
                    Code = "CREATE",
                    Table = NameTable.PolicyTable,
                    GroupName = groupName,
                    Desc = "Thêm chính sách",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Policy.DELETE,
                    Code = "DELETE",
                    Table = NameTable.PolicyTable,
                    GroupName = groupName,
                    Desc = "Xóa chính sách",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Policy.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.PolicyTable,
                    GroupName = groupName,
                    Desc = "Sửa chính sách",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Policy.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.PolicyTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách chính sách",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng Sytem
            // Permission liên quan đến bảng policy
            groupName = "Quản lý system";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.System.CREATE,
                    Code = "CREATE",
                    Table = NameTable.SystemTable,
                    GroupName = groupName,
                    Desc = "Thêm thông tin web",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.System.DELETE,
                    Code = "DELETE",
                    Table = NameTable.SystemTable,
                    GroupName = groupName,
                    Desc = "Xóa thông tin",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.System.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.SystemTable,
                    GroupName = groupName,
                    Desc = "Sửa thông tin",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.System.VIEW_DETAIL,
                    Code = "VIEW_DETAIL",
                    Table = NameTable.SystemTable,
                    GroupName = groupName,
                    Desc = "Xem thông tin",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng supplier
            // Permission liên quan đến bảng policy
            groupName = "Quản lý nhà cung cấp";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Supplier.CREATE,
                    Code = "CREATE",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Thêm nhà cung cấp",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Supplier.DELETE,
                    Code = "DELETE",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Xóa nhà cung cấp",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Supplier.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Sửa nhà cung cấp",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Supplier.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách nhà cung cấp",
                    CreatedDate = now
                }
            );
            #endregion
            #region Data liên quan đến bảng report
            // Permission liên quan đến bảng policy
            groupName = "Quản lý nhà cung cấp";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Report.CREATE,
                    Code = "CREATE",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Thêm phản hồi",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Report.DELETE,
                    Code = "DELETE",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Xóa nhà cung cấp",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Report.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Sửa phản hồi",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Report.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.SupplierTable,
                    GroupName = groupName,
                    Desc = "Xem danh sách phản hồi",
                    CreatedDate = now
                },
                 new MstPerMission
                 {
                     Id = AuthConst.Report.VIEW_DETAIL,
                     Code = "VIEW_DETAIL",
                     Table = NameTable.SupplierTable,
                     GroupName = groupName,
                     Desc = "Xem phản hồi",
                     CreatedDate = now
                 }
            );
            #endregion
            #region Data liên quan đến bảng size
            // Permission liên quan đến bảng policy
            groupName = "Quản lý Size";
            builder.HasData(
                new MstPerMission
                {
                    Id = AuthConst.Size.CREATE,
                    Code = "CREATE",
                    Table = NameTable.SizeTable,
                    GroupName = groupName,
                    Desc = "Thêm Size",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Size.DELETE,
                    Code = "DELETE",
                    Table = NameTable.SizeTable,
                    GroupName = groupName,
                    Desc = "Xóa Size",
                    CreatedDate = now
                },
                new MstPerMission
                {
                    Id = AuthConst.Size.UPDATE,
                    Code = "UPDATE",
                    Table = NameTable.SizeTable,
                    GroupName = groupName,
                    Desc = "Sửa Size",
                    CreatedDate = now
                },

                new MstPerMission
                {
                    Id = AuthConst.Size.VIEW_LIST,
                    Code = "VIEW_LIST",
                    Table = NameTable.SizeTable,
                    GroupName = groupName,
                    Desc = "Xem danh sáchSize",
                    CreatedDate = now
                },
                 new MstPerMission
                 {
                     Id = AuthConst.Size.VIEW_DETAIL,
                     Code = "VIEW_DETAIL",
                     Table = NameTable.SizeTable,
                     GroupName = groupName,
                     Desc = "Xem Size",
                     CreatedDate = now
                 }
            );
            #endregion
        }
    }
}
