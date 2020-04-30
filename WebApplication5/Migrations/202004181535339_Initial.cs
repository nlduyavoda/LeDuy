namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Loaisanphams",
                c => new
                    {
                        Idloai = c.Int(nullable: false, identity: true),
                        Tenloai = c.String(),
                    })
                .PrimaryKey(t => t.Idloai);
            
            CreateTable(
                "dbo.Sanphams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tensanpham = c.String(),
                        Gia = c.Int(nullable: false),
                        Nsx = c.String(),
                        Loaisanpham_Idloai = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Loaisanphams", t => t.Loaisanpham_Idloai)
                .Index(t => t.Loaisanpham_Idloai);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sanphams", "Loaisanpham_Idloai", "dbo.Loaisanphams");
            DropIndex("dbo.Sanphams", new[] { "Loaisanpham_Idloai" });
            DropTable("dbo.Sanphams");
            DropTable("dbo.Loaisanphams");
        }
    }
}
