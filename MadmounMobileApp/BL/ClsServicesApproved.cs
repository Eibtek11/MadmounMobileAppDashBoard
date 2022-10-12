using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ServicesApprovedService
    {
        List<TbServicesApproved> getAll();
        bool Add(TbServicesApproved client);
        bool Edit(TbServicesApproved client);
        bool Delete(TbServicesApproved client);


    }
    public class ClsServicesApproved : ServicesApprovedService
    {
        MadmounDbContext ctx;
        public ClsServicesApproved(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbServicesApproved> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbServicesApproved> lstServicesApproved = ctx.TbServicesApproveds.ToList();

            return lstServicesApproved;
        }

        public bool Add(TbServicesApproved item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServiceApprovedId = Guid.NewGuid();
                ctx.TbServicesApproveds.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbServicesApproved item)
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

        public bool Delete(TbServicesApproved item)
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
