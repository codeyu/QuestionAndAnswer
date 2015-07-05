namespace QuestionAndAnswer.Migrations
{
    //Êý¾ÝÇ¨ÒÆ
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QustionValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "QuestionContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "QuestionContent", c => c.String());
        }
    }
}
