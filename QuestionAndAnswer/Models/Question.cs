using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace QuestionAndAnswer.Models
{
    public class Question
    {
        public virtual int QuestionId { get; set; }

        // 问题对应的创建人
        [Display(Name = "提问者")]
        public virtual string QuestionCreator { get; set; }

        // 问题内容
        [Display(Name = "问题内容")]
        [Required]
        public virtual string QuestionContent { get; set; }

        // 问题创建时间
        [Display(Name = "创建时间")]
        public virtual DateTime QuestionCreateTime { get; set; }

        // 相关回答
        public virtual List<Answer> Answers { get; set; }
    }
}