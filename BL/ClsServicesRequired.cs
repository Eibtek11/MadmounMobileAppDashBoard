using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ServicesRequiredService
    {
        List<TbServicesRequired> getAll();
        bool Add(TbServicesRequired client);
        bool Edit(TbServicesRequired client);
        bool Delete(TbServicesRequired client);


    }
    public class ClsServicesRequired : ServicesRequiredService
    {
        MadmounDbContext ctx;
        public ClsServicesRequired(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbServicesRequired> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbServicesRequired> lstServicesRequired = ctx.TbServicesRequireds.ToList();

            return lstServicesRequired;
        }

        public bool Add(TbServicesRequired item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServicesRequiredId = Guid.NewGuid();
                item.CreatedDate = DateTime.Now;
                ctx.TbServicesRequireds.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbServicesRequired item)
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

        public bool Delete(TbServicesRequired item)
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
