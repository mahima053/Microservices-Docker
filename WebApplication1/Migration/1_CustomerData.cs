

namespace WebApplication1.Migration
{
    using FluentMigrator;
    [Migration(1, "AddingCustomerData")]
    public class CustomerData : Migration
{
    public override void Down()
    {
            Delete.Table("Customers");
    }

    public override void Up()
    {
            Create.Table("Customers")
                        .WithColumn("Id").AsGuid().PrimaryKey("_Customer").NotNullable()
                        .WithColumn("FirstName").AsString()
                        .WithColumn("LastName").AsString()
                        .WithColumn("EmailAddress").AsString(); 
        }
}
}
