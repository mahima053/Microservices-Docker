using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentMigrator;

namespace WebApplication1
{
    [Migration(260520221000)]
    public class Migration_260520221000 : Migration
    {
        public override void Down()
        {
            Delete.Table("Customers");
        }

        public override void Up()
        {
            Create.Table("Customers")
                    .WithColumn("Id").AsGuid().NotNullable()
                    .WithColumn("FirstName").AsString()
                    .WithColumn("LastName").AsString()
                    .WithColumn("EmailAddress").AsString();

        }
    }
}
