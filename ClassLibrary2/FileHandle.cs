using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class FileHandle
    {
        private string path = @"data/";
        public void SaveData(object data)
        {
            string realpath;
            Type d = data.GetType();
            if (d == typeof(List<AEffect>))
            {
                realpath = path + "Effects.txt";
            }
            else if (d == typeof(List<Item>))
            {
                realpath = path + "Items.txt";
            }
            else
            {
                return;
            }
            
            string json = JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText(realpath, json);
        }
        public List<AEffect> LoadDataEfect()
        {
            string realpath;

            realpath = path + "Effects.txt";
            if (File.Exists(realpath))
            {
                string file = System.IO.File.ReadAllText(realpath);

                List<AEffect> m = JsonConvert.DeserializeObject<List<AEffect>>(file);
                return m;
            }
            else
            {
                return new List<AEffect>();
            }
            
            
            
                        
            

        }
        public List<Item> LoadDataItem()
        {
            string realpath;
            realpath = path + "Items.txt";
            if (File.Exists(realpath))
            {
                
                string file = System.IO.File.ReadAllText(realpath);

                List<Item> m = JsonConvert.DeserializeObject<List<Item>>(file);
                return m;
            }
            else
            {
                return new List<Item>();
            }

            
         }




    }
}
