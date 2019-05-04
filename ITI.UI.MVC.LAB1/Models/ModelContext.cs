namespace ITI.UI.MVC.LAB1.Models
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
       
        public ModelContext()
            : base("name=ModelContext")
        {

    }
                        public DbSet<Empolyee> Empolyees { get; set; }
                        public DbSet<Department> Departments { get; set; } //add new table



    }

}