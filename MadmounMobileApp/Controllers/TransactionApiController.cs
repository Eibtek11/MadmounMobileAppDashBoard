using BL;
using Domains;
using MadmounMobileApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadmounMobileApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {

        TransactionService transactionService;
        ServiceService srRecords;
        ServicesApprovedService sr;
        ServicesRequiredService sq;
        ComplainService ComplainService;
        CityService cityService;
        AreaService areaService;
        MadmounDbContext ctx;
        UserManager<ApplicationUser> Usermanager;
        public TransactionApiController(TransactionService Transactionsservice, UserManager<ApplicationUser> usermanager, ServiceService SrRecords, ServicesApprovedService SR, ServicesRequiredService SQ, ComplainService complainService, CityService CityService, AreaService AreaService, MadmounDbContext context)
        {
            areaService = AreaService;
            ctx = context;
            cityService = CityService;
            ComplainService = complainService;
            sr = SR;
            sq = SQ;
            srRecords = SrRecords;
            Usermanager = usermanager;
            transactionService = Transactionsservice;
        }
        // GET: api/<TransactionApiController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransactionApiController>/5
        [HttpPost("transaction")]
        public TbTransaction transaction([FromForm] TransactionViewPageModel services)
        {
            TbServiceApprovedMilstone oTbServiceApprovedMilstone = ctx.TbServiceApprovedMilstones.Where(a => a.ServiceApprovedMilstoneId == services.ServiceApprovedMilstoneId).FirstOrDefault();
           
            TbServicesApproved oldItem = ctx.TbServicesApproveds.Where(a => a.ServiceApprovedId == oTbServiceApprovedMilstone.ServiceApprovedId).FirstOrDefault();

            TbTransaction oTbTransaction = new TbTransaction();
            oTbTransaction.SrOffId = oldItem.SrOffId;
            oTbTransaction.SrReqId = oldItem.SrReqId;
            oTbTransaction.SrRepId = oldItem.SrRepId;
            oTbTransaction.AreaId = oldItem.AreaId;
            oTbTransaction.CityId = oldItem.CityId;
            oTbTransaction.ServicesRequiredId = Guid.Parse(oldItem.CreatedBy);
            oTbTransaction.ServiceId = oldItem.ServiceId;
            oTbTransaction.ServiceApprovedMilstoneId = oTbServiceApprovedMilstone.ServiceApprovedMilstoneId;
            oTbTransaction.CreatedBy = services.CreatedBy;
            oTbTransaction.ServiceApprovedId = (Guid)oTbServiceApprovedMilstone.ServiceApprovedId;
            oTbTransaction.ServicesOffersId = Guid.Parse(oldItem.SrOffId);
            transactionService.Add(oTbTransaction);
            return oTbTransaction;
        }

        // POST api/<TransactionApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TransactionApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
