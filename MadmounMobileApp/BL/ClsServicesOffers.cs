using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ServicesOfferService
    {
        List<TbServicesOffers> getAll();
        bool Add(TbServicesOffers client);
        bool Edit(TbServicesOffers client);
        bool Delete(TbServicesOffers client);


    }
    public class ClsServicesOffers : ServicesOfferService
    {
        MadmounDbContext ctx;

        public ClsServicesOffers(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbServicesOffers> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbServicesOffers> lstServicesOffers = ctx.TbServicesOfferss.ToList();

            return lstServicesOffers;
        }

        public bool Add(TbServicesOffers item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServicesOffersId = Guid.NewGuid();
                ctx.TbServicesOfferss.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbServicesOffers item)
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

        public bool Delete(TbServicesOffers item)
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
