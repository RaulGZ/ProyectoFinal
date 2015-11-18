namespace Proyecto_CitasMedicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Afiliacions",
                c => new
                    {
                        idAfiliacion = c.Int(nullable: false, identity: true),
                        numAfiliacion = c.Int(nullable: false),
                        tipoAf = c.String(),
                    })
                .PrimaryKey(t => t.idAfiliacion);
            
            CreateTable(
                "dbo.Hospitals",
                c => new
                    {
                        idHospital = c.Int(nullable: false, identity: true),
                        NomHospital = c.String(),
                        DirHospital = c.String(),
                    })
                .PrimaryKey(t => t.idHospital);
            
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        idCita = c.Int(nullable: false, identity: true),
                        hrCita = c.DateTime(nullable: false),
                        MotivoidMotivo = c.Int(nullable: false),
                        MedicoidMedico = c.Int(nullable: false),
                        PacienteidPaciente = c.Int(nullable: false),
                        HospitalidHospital = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCita)
                .ForeignKey("dbo.Hospitals", t => t.HospitalidHospital, cascadeDelete: true)
                .ForeignKey("dbo.Medicos", t => t.MedicoidMedico, cascadeDelete: true)
                .ForeignKey("dbo.Motivoes", t => t.MotivoidMotivo, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.PacienteidPaciente, cascadeDelete: true)
                .Index(t => t.MotivoidMotivo)
                .Index(t => t.MedicoidMedico)
                .Index(t => t.PacienteidPaciente)
                .Index(t => t.HospitalidHospital);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        idMedico = c.Int(nullable: false, identity: true),
                        nomMedico = c.String(),
                        tipoMedico = c.String(),
                        cedProfes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idMedico);
            
            CreateTable(
                "dbo.Motivoes",
                c => new
                    {
                        idMotivo = c.Int(nullable: false, identity: true),
                        nomMotivo = c.String(),
                    })
                .PrimaryKey(t => t.idMotivo);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        idPaciente = c.Int(nullable: false, identity: true),
                        numAfiliacion = c.Int(nullable: false),
                        nomPaciente = c.String(),
                        edad = c.Int(nullable: false),
                        telPac = c.Int(nullable: false),
                        dirPac = c.String(),
                        tipSangre = c.String(),
                        alergicoA = c.String(),
                    })
                .PrimaryKey(t => t.idPaciente);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "PacienteidPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.Citas", "MotivoidMotivo", "dbo.Motivoes");
            DropForeignKey("dbo.Citas", "MedicoidMedico", "dbo.Medicos");
            DropForeignKey("dbo.Citas", "HospitalidHospital", "dbo.Hospitals");
            DropIndex("dbo.Citas", new[] { "HospitalidHospital" });
            DropIndex("dbo.Citas", new[] { "PacienteidPaciente" });
            DropIndex("dbo.Citas", new[] { "MedicoidMedico" });
            DropIndex("dbo.Citas", new[] { "MotivoidMotivo" });
            DropTable("dbo.Pacientes");
            DropTable("dbo.Motivoes");
            DropTable("dbo.Medicos");
            DropTable("dbo.Citas");
            DropTable("dbo.Hospitals");
            DropTable("dbo.Afiliacions");
        }
    }
}
