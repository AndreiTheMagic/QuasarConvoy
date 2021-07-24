using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace QuasarConvoy.Managers
{
    public class SaveManager
    {
        public string saveName;
        public SaveManager(string name)
        {
            saveName = name;
        }
        public void Save(Save save)
        {
            using (var writer = new StreamWriter(new FileStream(saveName, FileMode.Create)))
            {
                var serializer = new XmlSerializer(typeof(Save));
                serializer.Serialize(writer, save);
            }
        }

        public Save Load()
        {
            if (!File.Exists(saveName))
            {
                //CreateNewGame();
                //Save();
            }
            Save save = new Save();
            using (var reader = new StreamReader(new FileStream(saveName, FileMode.Open)))
            {
                var serializer = new XmlSerializer(typeof(Save));
                save = (Save)serializer.Deserialize(reader);
            }
            return save;
        }
    }
}
