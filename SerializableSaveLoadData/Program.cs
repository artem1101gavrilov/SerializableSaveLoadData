using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApplication1
{
    class Program
    {
        [System.Serializable]
        public class ClassSave //Класс для сохранения данных персонажа
        {
            public int id;
            public bool bool1;
            public string stroka;
            public List<int> ListInt;
        }

        static void SaveData()
        {
            ClassSave Save1 = new ClassSave();
            Save1.ListInt = new List<int>();
            Save1.ListInt.Add(4);
            Save1.ListInt.Add(2);
            Save1.ListInt.Add(5);
            Save1.ListInt.Add(6);
            Save1.id = 0;
            Save1.bool1 = true;
            Save1.stroka = "Привет. Как дела?";
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "/saves")) Directory.CreateDirectory(Directory.GetCurrentDirectory() + "/saves");
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/saves/save1.art", FileMode.Create);
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(fs, Save1);
            fs.Close();
        }

        static void LoadData()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "/saves/save1.art"))
            {
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/saves/save1.art", FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                try
                {
                    ClassSave Load1 = (ClassSave)bformatter.Deserialize(fs);
                    Console.Write(Load1.stroka + Load1.ListInt[3]);
                }
                catch (System.Exception e)
                {
                    Console.Write("Error=(");
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        static void Main(string[] args)
        {
            SaveData();
            LoadData();
            Console.ReadKey(); 
        }
    }
}
