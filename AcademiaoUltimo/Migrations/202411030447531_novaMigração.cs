namespace AcademiaoUltimo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novaMigração : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "idUsuario", c => c.String());
            AddColumn("dbo.Pagamentoes", "StringId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagamentoes", "StringId");
            DropColumn("dbo.Usuarios", "idUsuario");
        }
    }
}
