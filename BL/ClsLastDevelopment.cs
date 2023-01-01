using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface LastDevelopmentService
    {
        List<TbLastDevelopments> getAll();
        bool Add(TbLastDevelopments client);
        bool Edit(TbLastDevelopments client);
        bool Delete(TbLastDevelopments client);


    }
    public class ClsLastDevelopment : LastDevelopmentService
    {
        MadmounDbContext ctx;

        public ClsLastDevelopment(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbLastDevelopments> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbLastDevelopments> lstLastDevelopments = ctx.TbLastDevelopmentss.ToList();

            return lstLastDevelopments;
        }

        public bool Add(TbLastDevelopments item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.LastDevelopmentId = Guid.NewGuid();
                ctx.TbLastDevelopmentss.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbLastDevelopments item)
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

        public bool Delete(TbLastDevelopments item)
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
