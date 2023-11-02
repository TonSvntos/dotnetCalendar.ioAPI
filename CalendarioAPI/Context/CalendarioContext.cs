using System;
using Microsoft.EntityFrameworkCore;

namespace CalendarioAPI.Context
{
    public class CalendarioContext : DbContext
    {
        
     public CalendarioContext(DbContextOptions<CalendarioContext> options) : base(options)
        {
        }
    
}
}
