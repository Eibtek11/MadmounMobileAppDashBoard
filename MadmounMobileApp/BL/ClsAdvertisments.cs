using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface AdvertismentService
    {
        List<TbAdvertisements> getAll();
        bool Add(TbAdvertisements client);
        bool Edit(TbAdvertisements client);
        bool Delete(TbAdvertisements client);


    }
    public class ClsAdvertisments : AdvertismentService
    {
        MadmounDbContext ctx;
        
        public ClsAdvertisments(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbAdvertisements> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbAdvertisements> lstAdvertisements = ctx.Advertisementss.ToList();

            return lstAdvertisements;
        }

        public bool Add(TbAdvertisements item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.AdvertisementId = Guid.NewGuid();
                ctx.Advertisementss.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbAdvertisements item)
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

        public bool Delete(TbAdvertisements item)
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
