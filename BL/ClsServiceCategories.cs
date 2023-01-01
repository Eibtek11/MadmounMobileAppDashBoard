using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ServiceCategoryService
    {
        List<TbServiceCategory> getAll();
        bool Add(TbServiceCategory client);
        bool Edit(TbServiceCategory client);
        bool Delete(TbServiceCategory client);


    }
    public class ClsServiceCategories : ServiceCategoryService
    {
        MadmounDbContext ctx;
        public ClsServiceCategories(MadmounDbContext context)
        {
            ctx = context;
        }

        public List<TbServiceCategory> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbServiceCategory> lstServiceCategories = ctx.TbServiceCategories.ToList();

            return lstServiceCategories;
        }

        public bool Add(TbServiceCategory item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServiceCategoryId = Guid.NewGuid();
                ctx.TbServiceCategories.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbServiceCategory item)
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

        public bool Delete(TbServiceCategory item)
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
