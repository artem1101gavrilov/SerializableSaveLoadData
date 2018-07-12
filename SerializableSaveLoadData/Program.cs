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
        public class ItemData2
        {
            public int id;
            public string name;
            public bool isStackable;
        }

        [System.Serializable]
        public class ItemData
        {
            public int id;
            public string name;
            public bool isStackable;
        }
        [System.Serializable]
        public class Quest
        {
            public int id; //Номер квеста
            public string name; //Текстовое поле для кнопки
        }
        [System.Serializable]
        public class ClassSave //Класс для сохранения данных персонажа
        {
            public int id;
            public bool bool1;
            public string stroka;
            public List<int> ListInt;
            public List<ItemData> ListItem;
            public List<Quest> ListQuest;
        }

        static void SaveData()
        {
            ItemData2 item = new ItemData2();
            item.id = 4;
            item.name = "dfg";
            item.isStackable = true;

            ItemData item0 = new ItemData();
            item0.id = item.id;
            item0.isStackable = item.isStackable;
            item0.name = item.name;

            Quest quest = new Quest();
            quest.id = 0;
            quest.name = "45fgh";

            ClassSave Save1 = new ClassSave();
            Save1.ListItem = new List<ItemData>();
            Save1.ListItem.Add(item0);
            Save1.ListQuest = new List<Quest>();
            Save1.ListQuest.Add(quest);
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
                    Console.Write(Load1.ListItem[0].id + Load1.ListItem[0].name + Load1.ListItem[0].isStackable);
                    Console.Write(Load1.ListQuest[0].id + Load1.ListQuest[0].name);
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
