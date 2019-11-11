using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace HCI_Project.Model
{
    [DataContract(IsReference = true)]
    public class FestivalType
    {
        [DataMember] private string _id;
        [DataMember] private string _name;
        [DataMember] private string _iconPath;
        [DataMember] private string _description;

        public FestivalType() { }

        public FestivalType(String id, String name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string IconPath { get => _iconPath; set => _iconPath = value; }

        public static void Serialize(ObservableCollection<FestivalType> festivals)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("FestivalTypes.dat", FileMode.Create,
                                            FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, festivals);
            stream.Close();
        }

        public static void Deserialize(ObservableCollection<FestivalType> festivals)
        {
            ObservableCollection<FestivalType> des;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("FestivalTypes.dat", FileMode.Open,
                                                FileAccess.Read, FileShare.Read);
                des = (ObservableCollection<FestivalType>)formatter.Deserialize(stream);
                foreach (FestivalType ft in des)
                {
                    festivals.Add(ft);
                }
                stream.Close();
            }
            catch
            {
                festivals = new ObservableCollection<FestivalType>();
            }
        }

        public override string ToString()
        {
            return _name + "|" + _id;
        }
    }
}
