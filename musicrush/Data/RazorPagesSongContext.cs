using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using musicrush.Models;

public class RazorPagesSongContext : DbContext
{
    public RazorPagesSongContext (DbContextOptions<RazorPagesSongContext> options)
        : base(options)
    {
    }
    public DbSet<musicrush.Models.Song> Songs { get; set; }
    
    public DbSet<musicrush.Models.Album> Albums { get; set; }
}
