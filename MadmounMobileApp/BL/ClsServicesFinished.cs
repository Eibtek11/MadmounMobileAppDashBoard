using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ServicesFinishedService
    {
        List<TbServicesFinished> getAll();
        bool Add(TbServicesFinished client);
        bool Edit(TbServicesFinished client);
        bool Delete(TbServicesFinished client);


    }
    public class ClsServicesFinished : ServicesFinishedService
    {
        MadmounDbContext ctx;
        public ClsServicesFinished(MadmounDbContext context)
        {
            ctx = context;
        }
        public List<TbServicesFinished> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbServicesFinished> lstServicesFinished = ctx.TbServicesFinisheds.ToList();

            return lstServicesFinished;
        }

        public bool Add(TbServicesFinished item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.ServiceFinishedId = Guid.NewGuid();
                ctx.TbServicesFinisheds.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbServicesFinished item)
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

        public bool Delete(TbServicesFinished item)
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
