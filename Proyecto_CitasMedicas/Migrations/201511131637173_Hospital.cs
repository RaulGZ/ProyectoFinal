namespace Proyecto_CitasMedicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hospital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomHospital = c.String(),
                        DirHospital = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hospitals");
        }
    }
}
