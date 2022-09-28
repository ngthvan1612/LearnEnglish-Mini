using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.Views.Topics
{
    public class TopicStudySelectionItem
    {
        [DisplayName("STT")]
        public int Order { get; set; }

        [DisplayName("Tên chủ đề")]
        public string Name { get; set; }

        [DisplayName("Chọn")]
        public bool Selected { get; set; }

        [Browsable(false)]
        public Topic Ref { get; set; }

        public TopicStudySelectionItem()
        { }
    }
}
