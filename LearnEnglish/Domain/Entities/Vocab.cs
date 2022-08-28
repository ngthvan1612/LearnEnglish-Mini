
namespace LearnEnglish.Domain.Entities
{
    public partial class Vocab
    {
        public int Id { get; set; }

        public string? Eng { get; set; }
        public string? Vie { get; set; }
        public byte[]? Audio { get; set; }

        //FK
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }

        public DateTime Created { get; set; }

        public Vocab()
        {

        }
    }
}
