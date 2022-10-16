using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface SrrepService
    {
        List<TbSrRepService> getAll();
        bool Add(TbSrRepService client);
        bool Edit(TbSrRepService client);
        bool Delete(TbSrRepService client);


    }
    public class ClsSrRepService : SrrepService
    {
        MadmounDbContext ctx;
        public ClsSrRepService(MadmounDbContext context)
        {
            ctx = context;
        }

        public List<TbSrRepService> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbSrRepService> lstSrRepServices = ctx.TbSrRepServices.ToList();

            return lstSrRepServices;
        }

        public bool Add(TbSrRepService item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.SrRepServiceId = Guid.NewGuid();
                ctx.TbSrRepServices.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbSrRepService item)
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

        public bool Delete(TbSrRepService item)
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
