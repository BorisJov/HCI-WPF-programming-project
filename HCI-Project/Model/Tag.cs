using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media;

namespace HCI_Project.Model
{
    [DataContract(IsReference = true)]
    public class Tag
    {
        [DataMember] private string _id;
        [NonSerialized] private Color _color;
        [DataMember] private string _description;
        [DataMember] private Colour _colour;

        public string Id { get => _id; set => _id = value; }
        public Color Color { get => _color; set => _color = value; }
        public string Description { get => _description; set => _description = value; }
        public Colour Colour { get => _colour; set => _colour = value; }

        public static void Serialize(ObservableCollection<Tag> tags)
        {
            foreach (Tag t in tags)
            {
                t._colour = t.Color;
            }
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("Tags.dat", FileMode.Create,
                                            FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, tags);
            stream.Close();
        }

        public static void Deserialize(ObservableCollection<Tag> tags)
        {
            ObservableCollection<Tag> des;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Tags.dat", FileMode.Open,
                                                FileAccess.Read, FileShare.Read);
                des = (ObservableCollection<Tag>)formatter.Deserialize(stream);
                foreach (Tag tag in des)
                {
                    tag.Color = tag._colour;
                    tags.Add(tag);
                }
                stream.Close();
            }
            catch
            {
                tags = new ObservableCollection<Tag>();
            }
        }

        public override string ToString()
        {
            return _id;
        }
    }
}
