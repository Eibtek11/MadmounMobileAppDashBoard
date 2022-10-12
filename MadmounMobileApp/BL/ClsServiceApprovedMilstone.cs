using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ServiceApprovedMilstoneService
    {
        List<TbServiceApprovedMilstone> getAll();
        bool Add(TbServiceApprovedMilstone client);
        bool Edit(TbServiceApprovedMilstone client);
        bool Delete(TbServiceApprovedMilstone client);


    }
    public class ClsServiceApprovedMilstone : ServiceApprovedMilstoneService
    {
        MadmounDbContext ctx;
        public ClsServiceApprovedMilstone(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbServiceApprovedMilstone> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbServiceApprovedMilstone> lstServiceApprovedMilstones = ctx.TbServiceApprovedMilstones.ToList();

            return lstServiceApprovedMilstones;
        }

        public bool Add(TbServiceApprovedMilstone item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServiceApprovedMilstoneId = Guid.NewGuid();
                ctx.TbServiceApprovedMilstones.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbServiceApprovedMilstone item)
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

        public bool Delete(TbServiceApprovedMilstone item)
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
