using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.Views.Topics
{
    public class TopicRowView
    {
        [DisplayName("STT")]
        public int Order { get; set; }

        [DisplayName("Tên")]
        public string? Name { get; set; }

        [Browsable(false)]
        public Topic? RefTopic { get; set; }

        public TopicRowView() { }
        public TopicRowView(Topic topic)
        {
            Name = topic.Name;
            RefTopic = topic;
        }
    }
}
