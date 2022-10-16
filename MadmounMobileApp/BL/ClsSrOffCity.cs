using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface SroffCityService
    {
        List<TbSrOffCity> getAll();
        bool Add(TbSrOffCity client);
        bool Edit(TbSrOffCity client);
        bool Delete(TbSrOffCity client);


    }
    public class ClsSrOffCity : SroffCityService
    {
        MadmounDbContext ctx;
        public ClsSrOffCity(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbSrOffCity> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbSrOffCity> lstSrOffCitys = ctx.TbSrOffCities.ToList();

            return lstSrOffCitys;
        }

        public bool Add(TbSrOffCity item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.SrOffCityId = Guid.NewGuid();
                ctx.TbSrOffCities.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbSrOffCity item)
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

        public bool Delete(TbSrOffCity item)
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
