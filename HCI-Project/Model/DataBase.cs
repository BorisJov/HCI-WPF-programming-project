using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI_Project.Model
{
    [Serializable]
    public class DataBase
    {
        private ObservableCollection<Festival> _festivals;
        private ObservableCollection<FestivalType> _festivalTypes;
        private ObservableCollection<Tag> _tags;

        public DataBase(ObservableCollection<Festival> festivals, ObservableCollection<FestivalType> festivalTypes, ObservableCollection<Tag> tags)
        {
            Festivals = festivals;
            FestivalTypes = festivalTypes;
            Tags = tags;
        }

        public ObservableCollection<Festival> Festivals { get => _festivals; set => _festivals = value; }
        public ObservableCollection<FestivalType> FestivalTypes { get => _festivalTypes; set => _festivalTypes = value; }
        public ObservableCollection<Tag> Tags { get => _tags; set => _tags = value; }

        public static DataBase Deserialize()
        {
            //String path = 
            FileStream fs = new FileStream("DataBase.xml", FileMode.OpenOrCreate);
            try
            {

                DataContractSerializer dcs = new DataContractSerializer(typeof(DataBase), null,
                                                                0x7FFF /*maxItemsInObjectGraph*/,
                                                                false /*ignoreExtensionDataObject*/,
                                                                true /*preserveObjectReferences : this is where the magic happens */,
                                                                null /*dataContractSurrogate*/);
                
                if (fs.Length > 0)
                {
                    DataBase db = (DataBase)dcs.ReadObject(fs);
                    foreach (Tag t in db.Tags)
                    {
                        t.Color = t.Colour;
                    }
                    return db;
                }
                else
                    return null;


            }
            catch (SerializationException e)
            {
                //Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                MessageBox.Show("Failed to deserialize. File will be deleted. Reason: " + e.Message);
                //brisem fajl koji sam pokusao otvoriti
                File.Delete("Save.bin");
                throw;
            }
            finally
            {
                fs.Close();
            }

        }



        public static void Serialize(DataBase db)
        {
            foreach (Tag t in db.Tags)
            {
                t.Colour = t.Color;
            }

            FileStream fs = new FileStream("DataBase.xml", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            DataContractSerializer dcs = new DataContractSerializer(typeof(DataBase), null,
                                                        0x7FFF /*maxItemsInObjectGraph*/,
                                                        false /*ignoreExtensionDataObject*/,
                                                        true /*preserveObjectReferences : this is where the magic happens */,
                                                        null /*dataContractSurrogate*/);
            try
            {
                dcs.WriteObject(fs, db);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

        }
    }
}
