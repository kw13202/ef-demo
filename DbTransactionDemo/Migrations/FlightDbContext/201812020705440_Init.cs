namespace DbTransactionDemo.Migrations.FlightDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FlighBookings",
                c => new
                    {
                        FlightId = c.Int(nullable: false, identity: true),
                        FlightName = c.String(nullable: false, maxLength: 50),
                        Number = c.String(),
                        TravellingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FlightId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FlighBookings");
        }
    }
}
