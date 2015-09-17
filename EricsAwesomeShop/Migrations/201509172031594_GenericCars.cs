namespace EricsAwesomeShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenericCars : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RollsRoyces", newName: "InternalCombustionCars");
            RenameTable(name: "dbo.Teslas", newName: "ElectricCars");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ElectricCars", newName: "Teslas");
            RenameTable(name: "dbo.InternalCombustionCars", newName: "RollsRoyces");
        }
    }
}
