namespace Learn.AngularJS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateComplexDataModel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "Name", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Department", "Name", c => c.String(maxLength: 50));
        }
    }
}
