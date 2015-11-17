namespace Proyecto_CitasMedicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creartablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afiliacions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numAfiliacion = c.Int(nullable: false),
                        tipoAf = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nomMedico = c.String(),
                        tipoMedico = c.String(),
                        cedProfes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicos");
            DropTable("dbo.Afiliacions");
        }
    }
}
