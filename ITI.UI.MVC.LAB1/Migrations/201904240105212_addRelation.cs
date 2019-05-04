namespace ITI.UI.MVC.LAB1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Department");
            AddColumn("dbo.Empolyee", "FK_DepartmentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Department", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Empolyee", "FK_DepartmentId");
            AddForeignKey("dbo.Empolyee", "FK_DepartmentId", "dbo.Department", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empolyee", "FK_DepartmentId", "dbo.Department");
            DropIndex("dbo.Empolyee", new[] { "FK_DepartmentId" });
            AlterColumn("dbo.Department", "Name", c => c.String());
            DropColumn("dbo.Empolyee", "FK_DepartmentId");
            RenameTable(name: "dbo.Department", newName: "Departments");
        }
    }
}
