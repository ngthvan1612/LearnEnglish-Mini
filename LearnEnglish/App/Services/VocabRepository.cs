using LearnEnglish.App.Views.Vocabs;
using LearnEnglish.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEnglish.App.Services
{
    public class VocabRepository : BaseRepository
    {
        public VocabRepository()
        {

        }

        public Vocab Create(int topicId, string eng, string vie, byte[] audio)
        {
            var newVocab = new Vocab()
            {
                TopicId = topicId,
                Eng = eng,
                Vie = vie,
                Audio = audio
            };
            this.Context.Vocabs.Add(newVocab);

            this.SaveChanges();
            return newVocab;
        }

        public Vocab Get(string eng, string vie)
        {
            eng = eng.Trim().ToLower();
            vie = vie.Trim().ToLower();
            var vocab = this.Context.Vocabs.Where(u => u.DeletedAt == null).FirstOrDefault(u => u.Eng.ToLower().Trim() == eng && u.Vie.ToLower().Trim() == vie);
            return vocab;
        }

        public Vocab GetInTopic(int topicId, string eng, string vie)
        {
            eng = eng.Trim().ToLower();
            vie = vie.Trim().ToLower();
            var vocab = this.Context.Vocabs.Where(u => u.DeletedAt == null).Where(u => u.TopicId == topicId).FirstOrDefault(u => u.Eng.ToLower().Trim() == eng && u.Vie.ToLower().Trim() == vie);
            return vocab;
        }

        public void DeleteVocab(int id)
        {
            var vocab = this.Context.Vocabs.FirstOrDefault(u => u.Id == id);
            vocab.DeletedAt = DateTime.Now;
            this.Context.SaveChanges();
        }

        public VocabRowView GetWithAudio(int vocabId)
        {
            var refVocab = this.Context.Vocabs.Where(u => u.DeletedAt == null).FirstOrDefault(u => u.Id == vocabId);
            return new VocabRowView(refVocab);
        }

        public VocabRowView GetWithoutAudio(int vocabId)
        {
            var query = from vocab in this.Context.Vocabs
                        where vocab.Id == vocabId && vocab.DeletedAt == null
                        select new
                        {
                            HasAudio = vocab.Audio != null,
                            Ref = new Vocab()
                            {
                                Id = vocab.Id,
                                Eng = vocab.Eng,
                                Vie = vocab.Vie,
                                Audio = null,
                                CreatedAt = vocab.CreatedAt,
                                TopicId = vocab.TopicId
                            }
                        };
            var resultExecute = query.ToList();
            if (resultExecute.Count <= 0)
            {
                return null;
            }
            return new VocabRowView(resultExecute[0].Ref)
            {
                HasAudio = resultExecute[0].HasAudio
            };
        }

        public IEnumerable<VocabRowView> ListVocabOfTopicWithAudio(int topicId)
        {
            var listVocabs = this.Context.Vocabs.Where(u => u.DeletedAt == null).Where(u => u.TopicId == topicId).ToList();
            return listVocabs.Select((u, id) => new VocabRowView(u) { HasAudio = u.Audio != null, Order = id + 1 });
        }

        public IEnumerable<VocabRowView> ListVocabOfTopicWithoutAudio(int topicId)
        {
            var query = from vocab in this.Context.Vocabs
                        where vocab.TopicId == topicId && vocab.DeletedAt == null
                        select new
                        {
                            HasAudio = vocab.Audio != null,
                            Ref = new Vocab()
                            {
                                Id = vocab.Id,
                                Eng = vocab.Eng,
                                Vie = vocab.Vie,
                                Audio = null,
                                CreatedAt = vocab.CreatedAt,
                                TopicId = vocab.TopicId
                            }
                        };
            var resultExecute = query.ToList();
            return resultExecute.Select((u, id) => new VocabRowView(u.Ref)
            {
                HasAudio = u.HasAudio,
                Order = id + 1
            });
        }

        public Vocab UpdateAudio(int vocabId, byte[] audio)
        {
            var refVocab = this.Context.Vocabs.FirstOrDefault(u => u.Id == vocabId);
            refVocab.Audio = audio;
            this.Context.Vocabs.Update(refVocab);

            this.SaveChanges();
            return refVocab;
        }

        public Vocab UpdateText(int vocabId, string eng, string vie)
        {
            var refVocab = this.Context.Vocabs.FirstOrDefault(u => u.Id == vocabId);
            refVocab.Eng = eng;
            refVocab.Vie = vie;
            this.Context.Vocabs.Update(refVocab);

            this.SaveChanges();
            return refVocab;
        }
    }
}
