using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace MissionPlanner
{
    public static class AircraftSerializer
    {
        public static void Serialize(string savePath, IDictionary dictionary)
        {
            using (var writer = File.CreateText(savePath))
            {
                List<Entry> entries = new List<Entry>(dictionary.Count);
                foreach (object key in dictionary.Keys)
                {
                    entries.Add(new Entry(key, dictionary[key]));
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
                serializer.Serialize(writer, entries);
            }
        }

        public static void Deserialize(string path, IDictionary dictionary)
        {
            using (var reader = File.OpenText(path))
            {
                dictionary.Clear();
                XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>));
                List<Entry> list = (List<Entry>) serializer.Deserialize(reader);
                foreach (Entry entry in list)
                {
                    dictionary[entry.Key] = entry.Value;
                }
            }
        }

        [XmlInclude(typeof(AircraftConnectionInfo))]
        public class Entry
        {
            public object Key;
            public object Value;

            public Entry()
            {
            }

            public Entry(object key, object value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}