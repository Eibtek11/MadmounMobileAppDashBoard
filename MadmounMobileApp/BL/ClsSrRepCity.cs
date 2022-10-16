using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface SrrepCityService
    {
        List<TbSrRepCity> getAll();
        bool Add(TbSrRepCity client);
        bool Edit(TbSrRepCity client);
        bool Delete(TbSrRepCity client);


    }
    public class ClsSrRepCity : SrrepCityService
    {
        MadmounDbContext ctx;
        public ClsSrRepCity(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbSrRepCity> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbSrRepCity> lstSrRepServices = ctx.TbSrRepCities.ToList();

            return lstSrRepServices;
        }

        public bool Add(TbSrRepCity item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.SrRepCityId = Guid.NewGuid();
                ctx.TbSrRepCities.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbSrRepCity item)
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

        public bool Delete(TbSrRepCity item)
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
