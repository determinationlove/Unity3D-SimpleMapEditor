using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

namespace JsonFile
{
    public class pathFile
    {
        private string path, col;
        private bool ExistFile;


        public pathFile(string _path)
        {
            path = _path;
            if (File.Exists(path))
                ExistFile = true;
        }

        public string ExiFile()
        {
            if (ExistFile == false) return "NotFile";
            else return "FileOK";
        }

        public JsonDatas Load()
        {
            // 如果檔案存在
            if (ExistFile == false)
                return null;

            string d = File.ReadAllText(path);
            JsonDatas jsdatas = JsonUtility.FromJson<JsonDatas>(d);

            return jsdatas;
        }

        public void Save(JsonDatas jsd)
        {
            string save =  JsonUtility.ToJson(jsd);

            File.WriteAllText(path, save, Encoding.UTF8);
        }

        public void Edit(JsonDatas jsd, int _id, string _name, string _skill)
        {
            jsd.Id = _id;
            jsd.Name = _name;
            jsd.Skill = _skill;
            
            string save =  JsonUtility.ToJson(jsd);
            File.WriteAllText(path, save, Encoding.UTF8);
        }

        public void Edit(JsonDatas jsd, int _id)
        {
            jsd.Id = _id;
            
            string save =  JsonUtility.ToJson(jsd);
            File.WriteAllText(path, save, Encoding.UTF8);
        }

        public void Edit(JsonDatas jsd, int _id, string _name)
        {
            jsd.Id = _id;
            jsd.Name = _name;

            string save =  JsonUtility.ToJson(jsd);
            File.WriteAllText(path, save, Encoding.UTF8);
        }

    }
}