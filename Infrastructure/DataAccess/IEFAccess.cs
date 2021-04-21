using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public interface IEFAccess
    {
        DbSet<Picture> Cam1KeepTable { get; set; }
    }
}