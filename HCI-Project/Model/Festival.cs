using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace HCI_Project.Model
{
    [DataContract]
    public class Festival
    {
        public enum AlcoholServingEnum { NO_ALCOHOL, CAN_BRING, CAN_BUY }
        public enum PriceCategoryEnum { FREE, LOW_PRICE, MID_PRICE, HIGH_PRICE }

        [DataMember] private string _name;
        [DataMember] private string _id;
        [DataMember] private string _description;
        [DataMember] private FestivalType _type;
        [DataMember] private String _iconPath;
        [DataMember] private bool _iconFromType;
        [DataMember] private bool _handicapAccessible;
        [DataMember] private bool _smokingAllowed;
        [DataMember] private bool _indoors;
        [DataMember] private PriceCategoryEnum _priceCategory;
        [DataMember] private AlcoholServingEnum _alcoholServing;
        [DataMember] private DateTime _date;
        [DataMember] private int _expectedCrowdSize;
        [DataMember] private List<Tag> _tags;
        [DataMember] private Point _position;

        public string Name { get => _name; set => _name = value; }
        public string Id { get => _id; set => _id = value; }
        public string Description { get => _description; set => _description = value; }
        public bool HandicapAccessible { get => _handicapAccessible; set => _handicapAccessible = value; }
        public bool SmokingAllowed { get => _smokingAllowed; set => _smokingAllowed = value; }
        public bool Indoors { get => _indoors; set => _indoors = value; }
        public AlcoholServingEnum AlcoholServing { get => _alcoholServing; set => _alcoholServing = value; }
        public PriceCategoryEnum PriceCategory { get => _priceCategory; set => _priceCategory = value; }
        public FestivalType Type { get => _type; set => _type = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public int ExpectedCrowdSize { get => _expectedCrowdSize; set => _expectedCrowdSize = value; }
        public String IconPath { get => _iconPath; set => _iconPath = value; }
        public List<Tag> Tags { get => _tags; set => _tags = value; }
        public bool IconFromType { get => _iconFromType; set => _iconFromType = value; }
        public Point Position { get => _position; set => _position = value; }

        public Festival()
        {
            _tags = new List<Tag>();
        }

        public Festival(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public static void Serialize(ObservableCollection<Festival> festivals)
        {
            IFormatter formatter = new BinaryFormatter( );
            Stream stream = new FileStream("Festivals.dat", FileMode.Create,
                                            FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, festivals);
            stream.Close( );
        }

        public static void Deserialize(ObservableCollection<Festival> festivals)
        {
            ObservableCollection<Festival> des;
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Festivals.dat", FileMode.Open, 
                                                FileAccess.Read, FileShare.Read);
                des = (ObservableCollection<Festival>)formatter.Deserialize(stream);
                foreach (Festival fest in des)
                {
                    festivals.Add(fest);
                }
                stream.Close();
            }
            catch
            {
                festivals = new ObservableCollection<Festival>();
            }
        }

        public override string ToString()
        {
            return _name + "|" + _id;
        }
    }
}
