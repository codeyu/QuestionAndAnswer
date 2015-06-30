using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionAndAnswer.Models
{
    public class Answer
    {
        // 主键答案Id
        public virtual int AnswerId { get; set; }

        // 外键，答案对应的问题的ID
        public virtual int QuestionId { get; set; }

        // 答案内容
        public virtual string AnswerContent { get; set; }

        // 问题回答时间
        public virtual DateTime AnswerTime { get; set; }

        // 导航属性，关联相关问题
        public virtual Question Question { get; set; }
    }
}