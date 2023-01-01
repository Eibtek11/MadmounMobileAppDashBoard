using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface SrOffService
    {
        List<TbSrOffService> getAll();
        bool Add(TbSrOffService client);
        bool Edit(TbSrOffService client);
        bool Delete(TbSrOffService client);


    }
    public class ClsSrOffService : SrOffService
    {
        MadmounDbContext ctx;
        public ClsSrOffService(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbSrOffService> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbSrOffService> lstSrOffServices = ctx.TbSrOffServices.ToList();

            return lstSrOffServices;
        }

        public bool Add(TbSrOffService item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.SrOffServiceId = Guid.NewGuid();
                ctx.TbSrOffServices.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbSrOffService item)
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

        public bool Delete(TbSrOffService item)
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
