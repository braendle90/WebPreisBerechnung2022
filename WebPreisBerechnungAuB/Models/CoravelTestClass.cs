using Coravel.Invocable;
using Microsoft.CodeAnalysis.Text;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Data;

namespace WebPreisBerechnungAuB.Models
{
    public class CoravelTestClass : IInvocable
    {

        private ApplicationDbContext _context;

        public CoravelTestClass(ApplicationDbContext context)
        {
            _context = context;
        }
        public  Task Invoke()
        {

    

            return Task.CompletedTask;

        }
    }
}
