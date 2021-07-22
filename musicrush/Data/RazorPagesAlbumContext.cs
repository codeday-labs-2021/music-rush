using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using musicrush.Models;

    public class RazorPagesAlbumContext : DbContext
    {
        public RazorPagesAlbumContext (DbContextOptions<RazorPagesAlbumContext> options)
            : base(options)
        {
        }

        public DbSet<musicrush.Models.Album> Album { get; set; }
    }
