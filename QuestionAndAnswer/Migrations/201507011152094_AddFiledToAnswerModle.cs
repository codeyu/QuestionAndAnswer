namespace QuestionAndAnswer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFiledToAnswerModle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "AnswerCreator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "AnswerCreator");
        }
    }
}
