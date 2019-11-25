namespace Mvc3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Giris : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrencilers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(),
                        Soyadi = c.String(),
                        OgrenciNo = c.String(),
                        Tc = c.String(),
                        Email = c.String(),
                        Telefon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ogrencilers");
        }
    }
}
