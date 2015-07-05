namespace QuestionAndAnswer.Migrations
{
    // Êý¾ÝÇ¨ÒÆ
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnswerValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Answers", "AnswerContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Answers", "AnswerContent", c => c.String());
        }
    }
}
