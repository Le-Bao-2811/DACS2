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
    public static class StatusSender
    {
        public static void SeedData(this EntityTypeBuilder<Status> builder)
        {         
            var now=DateTime.Now;
            builder.HasData(
                new Status
                {
                    Id = 1,
                    StatusName = "Đang chờ xử lý",
                    CreateAt = now,
                },
                new Status
                {
                    Id=2,
                    StatusName="Đang lấy hàng",
                    CreateAt=now,
                },
                new Status
                {
                    Id=3,
                    StatusName="Đang giao hàng",
                    CreateAt=now
                },
                new Status
                {
                    Id=4,
                    StatusName="Giao hàng thành công",
                    CreateAt=now
                }
            );
        }
    }
}
