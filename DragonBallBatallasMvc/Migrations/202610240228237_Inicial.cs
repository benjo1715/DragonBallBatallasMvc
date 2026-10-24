namespace DragonBallBatallasMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batallas",
                c => new
                    {
                        BatallaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Enemigo = c.String(),
                        Resultado = c.String(),
                        GuerreroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BatallaId)
                .ForeignKey("dbo.Guerreroes", t => t.GuerreroId, cascadeDelete: true)
                .Index(t => t.GuerreroId);
            
            CreateTable(
                "dbo.Guerreroes",
                c => new
                    {
                        GuerreroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Raza = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.GuerreroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Batallas", "GuerreroId", "dbo.Guerreroes");
            DropIndex("dbo.Batallas", new[] { "GuerreroId" });
            DropTable("dbo.Guerreroes");
            DropTable("dbo.Batallas");
        }
    }
}
