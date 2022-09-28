using LearnEnglish.App.Views.Topics;
using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.Services
{
    public class TopicRepository : BaseRepository
    {
        public TopicRepository()
            : base()
        {

        }

        public Topic Create(string name)
        {
            var newTopic = new Topic();
            newTopic.Name = name;
            newTopic.CreatedAt = DateTime.Now;

            this.Context.Topics.Add(newTopic);

            this.SaveChanges();
            return newTopic;
        }

        public Topic? GetTopic(int id)
        {
            return this.Context.Topics.Where(u => u.DeletedAt == null).FirstOrDefault(u => u.Id == id);
        }

        public Topic? GetTopic(string name)
        {
            return this.Context.Topics.Where(u => u.DeletedAt == null).FirstOrDefault(u => u.Name == name);
        }

        public void DeleteTopic(int id)
        {
            var topic = this.Context.Topics.FirstOrDefault(u => u.Id == id);
            topic.DeletedAt = DateTime.Now;
            this.Context.SaveChanges();
        }

        public BindingList<TopicRowView> GetTopicDataGridView()
        {
            return new BindingList<TopicRowView>(this.Context
                .Topics.Where(u => u.DeletedAt == null).ToList()
                .Select((u, id) => new TopicRowView(u) { Order = id + 1 })
                .ToList()
            );
        }

        public TopicRowView GetTopicRowView(int id)
        {
            var refTopic = this.Context.Topics.Where(u => u.DeletedAt == null).FirstOrDefault(u => u.Id == id);
            return new TopicRowView(refTopic);
        }

        public IEnumerable<Topic> GetTopics()
        {
            return this.Context.Topics.Where(u => u.DeletedAt == null).ToList();
        }

        public Topic Update(int id, string name)
        {
            var refTopic = this.Context.Topics.FirstOrDefault(u => u.Id == id);
            refTopic.Name = name;
            this.Context.Topics.Update(refTopic);

            this.SaveChanges();
            return refTopic;
        }

        public void ImportTopics(string fileData)
        {
            List<Topic> root = new List<Topic>();
            using (BinaryReader br = new BinaryReader(new FileStream(fileData, FileMode.Open)))
            {
                int totalTopic = br.ReadInt32();
                for (int i = 0; i < totalTopic; ++i)
                {
                    Topic topic = new Topic();
                    topic.Name = br.ReadString();
                    int numCaps = br.ReadInt32();
                    for (int j = 0; j < numCaps; ++j)
                    {
                        Vocab vocab = new Vocab();

                        vocab.Eng = br.ReadString();
                        vocab.Vie = br.ReadString();
                        int lengthAudio = br.ReadInt32();
                        if (lengthAudio > 0)
                        {
                            vocab.Audio = br.ReadBytes(lengthAudio);
                        }

                        topic.Vocabs.Add(vocab);
                    }
                    for (int j = 1; 1 < 2; ++j)
                    {
                        string newName = topic.Name + " - Import-" + j;
                        if (this.Context.Topics.Where(u => u.Name.ToLower() == newName.ToLower()).ToList().Count() <= 0)
                        {
                            topic.Name = newName;
                            break;
                        }
                    }
                    root.Add(topic);
                }
                br.Close();
            }

            foreach (var topic in root)
            {
                this.Context.Topics.Add(topic);
                foreach (var vocab in topic.Vocabs)
                {
                    this.Context.Vocabs.Add(vocab);
                }
            }

            this.SaveChanges();
        }

        public void ExportTopics(List<Topic> topics, string fileOutput)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream(fileOutput, FileMode.Create)))
            {
                bw.Write(topics.Count);
                foreach (var topic in topics)
                {
                    var vocabs = new VocabRepository().ListVocabOfTopicWithAudio(topic.Id).Select(u => u.RefVocab);
                    bw.Write(topic.Name);
                    bw.Write(vocabs.Count());
                    foreach (var vocab in vocabs)
                    {
                        bw.Write(vocab.Eng);
                        bw.Write(vocab.Vie);
                        if (vocab.Audio == null)
                        {
                            bw.Write(0);
                        }
                        else
                        {
                            bw.Write(vocab.Audio.Length);
                            bw.Write(vocab.Audio);
                        }
                    }
                }
                bw.Close();
            }
        }
    }
}
