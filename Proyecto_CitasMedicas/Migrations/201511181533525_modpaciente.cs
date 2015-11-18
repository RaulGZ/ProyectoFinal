namespace Proyecto_CitasMedicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modpaciente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numAfiliacion = c.Int(nullable: false),
                        nomPaciente = c.String(),
                        edad = c.Int(nullable: false),
                        telPac = c.Int(nullable: false),
                        dirPac = c.String(),
                        tipSangre = c.String(),
                        alergicoA = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pacientes");
        }
    }
}
