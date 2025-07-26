using System;
using System.Data.Entity;
using System.Linq;
using WebApplicationDocLab.Models;

namespace WebApplicationDocLab.Context
{
    public class DoctorLab : DbContext
    {
        // Your context has been configured to use a 'DoctorLab' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WebApplicationDocLab.Context.DoctorLab' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DoctorLab' 
        // connection string in the application configuration file.
        public DoctorLab()
            : base("name=DoctorLab")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User_Info> User_Infos { get; set; }
        public virtual DbSet<Doctor_Details> Doctor_Details { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Medicine_List> Medicine_Lists { get; set; }
        public virtual DbSet<BookingAppointment> BookingAppointments { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Test_List> Test_Lists { get; set; }
        public virtual DbSet<Doctor_Type> Doctor_Types{ get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Medical_History> Medical_Histories { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}