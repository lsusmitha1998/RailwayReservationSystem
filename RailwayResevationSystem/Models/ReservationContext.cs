using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RailwayResevationSystem.Models
{
    public class ReservationContext : DbContext
    {
        public ReservationContext() : base("SqlConn"){}
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<TrainSchedule> TrainSchedules { get; set; }
    }
}