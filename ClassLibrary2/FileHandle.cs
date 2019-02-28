using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class FileHandle
    {
        private string path = @"T:\uff/";
        public void SaveData(object data)
        {
            string realpath;
            Type d = data.GetType();
            if (d == typeof(List<AEfect>))
            {
                realpath = path + "Efets.txt";
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
        public List<AEfect> LoadDataEfect()
        {
            string realpath;

                realpath = path + "Efets.txt";
                string file = System.IO.File.ReadAllText(realpath);

                List<AEfect> m = JsonConvert.DeserializeObject <List<AEfect>> (file);
                return m;
            
                        
            

        }
        public List<Item> LoadDataItem()
        {
            string realpath;

            
                realpath = path + "Items.txt";
                string file = System.IO.File.ReadAllText(realpath);

                  List<Item> m = JsonConvert.DeserializeObject<List<Item>>(file);
                return m;
         }




    }
}
