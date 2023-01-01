using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ServiceApprovedImagesService
    {
        List<TbServiceApprovedImage> getAll();
        bool Add(TbServiceApprovedImage client);
        bool Add(TbServiceApprovedImage client , IFormFile imagePath);
        bool Edit(TbServiceApprovedImage client);
        bool Delete(TbServiceApprovedImage client);


    }
    public class ClsServiceApprovedImages : ServiceApprovedImagesService
    {
        MadmounDbContext ctx;
        public ClsServiceApprovedImages(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbServiceApprovedImage> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbServiceApprovedImage> lstServiceApprovedImage = ctx.TbServiceApprovedImages.ToList();

            return lstServiceApprovedImage;
        }

        public bool Add(TbServiceApprovedImage item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServiceApprovedImageId = Guid.NewGuid();
                ctx.TbServiceApprovedImages.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }




        public bool Add(TbServiceApprovedImage item , IFormFile imagePath)
        {
            try
            {
                string ImageName = Guid.NewGuid().ToString() + ".jpg";
                var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                using (var stream = System.IO.File.Create(filePaths))
                {
                    imagePath.CopyToAsync(stream);
                }
                item.ImagePath = ImageName;
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServiceApprovedImageId = Guid.NewGuid();
                ctx.TbServiceApprovedImages.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbServiceApprovedImage item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbServiceApprovedImage item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
