using AutoMapper;
using DACS2.Data.Entities;
using DACS2.Web.Areas.Admin.ViewModel.Account;
using DACS2.Web.Areas.Admin.ViewModel.News;
using DACS2.Web.Areas.Admin.ViewModel.NewsCategory;
using DACS2.Web.Areas.Admin.ViewModel.Role;
using DACS2.Web.Areas.Admin.ViewModel.Supplier;
using DACS2.Web.Areas.Admin.ViewModel.Voucher;

namespace DACS2.Web.WebConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig() { 
        
            CreateMap<User,SignUpVM>().ReverseMap(); 
            CreateMap<CategoryNews,AddorUpdateCategoryNewsVM>().ReverseMap();
            CreateMap<News,AddorUpdateNewsVM>().ReverseMap();
            CreateMap<Voucher,AddorUpdateVocher>().ReverseMap();
            
        }
        public static MapperConfiguration RoleIndexConf = new(mapper =>
        {
            // Map dữ liệu từ kiểu AppRole sang RoleListItemVM
            mapper.CreateMap<Role, ListRoleItemVM>();
        });
        public static MapperConfiguration UserIndexConf = new(mapper =>
        {
            // Map dữ liệu từ kiểu AppRole sang RoleListItemVM
            mapper.CreateMap<User, ListUserVM>()
            .ForMember(uItem=>uItem.role,opts=>opts.MapFrom(uE=>uE.role.RoleName));
        });
        public static MapperConfiguration LoginConf = new(mapper =>
        {
            // Map dữ liệu từ AppUser sang UserListItemVM, map thuộc tính RoleName
            mapper.CreateMap<User, UserDataForApp>()
                .ForMember(uItem => uItem.RoleName, opts => opts.MapFrom(uEntity => uEntity.role == null ? "" : uEntity.role.RoleName))
                .ForMember(uItem => uItem.Permission, opts => opts.MapFrom
                (
                    uEntity => string.Join(',', uEntity.role
                                                        .rolePermissions
                                                        .Select(p => p.MStPermissionId))
                )
            );
        });
        public static MapperConfiguration CategoryIndexConf = new(mapper =>
        {
            // Map dữ liệu từ kiểu AppRole sang RoleListItemVM
            mapper.CreateMap<CategoryNews, ListCategoryNewsVM>();
        });
        public static MapperConfiguration NewsIndexConf = new(mapper =>
        {
            // Map dữ liệu từ kiểu AppRole sang RoleListItemVM
            mapper.CreateMap<News, ListNewsVM>()
            .ForMember(uItem=>uItem.CategoryNew,otps=>otps.MapFrom(uE=>uE.categoryNews.NewsName));
        });
        public static MapperConfiguration VoucherIndexConf = new(mapper =>
        {
            // Map dữ liệu từ kiểu AppRole sang RoleListItemVM
            mapper.CreateMap<Voucher, ListVocherVM>();
        });
        public static MapperConfiguration SupplierIndexConf = new(mapper =>
        {
            // Map dữ liệu từ kiểu AppRole sang RoleListItemVM
            mapper.CreateMap<Supplier, ListSupplierVM>();
        });
    }
}
