using FluentMigrator;


namespace cars_api.Data.Migrations
{
    [Migration(30012025)]

    public class CreateSchema : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("car")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("brand").AsString(120).NotNullable()
                .WithColumn("model_type").AsString(120).NotNullable()
                .WithColumn("horse_power").AsInt32().NotNullable()
                .WithColumn("range").AsInt32().NotNullable()
                .WithColumn("max_speed").AsInt32().NotNullable();
        }
    }
}
