﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMControllerApp_TK.Utilities
{
    class jsonObj
    {
        public int x;
        public int y;
        public double time;
        public int thickness;
        public string color;

        public jsonObj(int x, int y, double time, int thickness, string color)
        {
            this.x = x;
            this.y = y;
            this.time = time;
            this.thickness = thickness;
            this.color = color;
        }
    }

    class FileHandling
    {
        private static FileHandling instance;
        public List<jsonObj> objList;
        public string fullPath;
        public static FileHandling getInstance(string fullPath)
        {
            if (instance == null) instance = new FileHandling(fullPath);
            return instance;
        }
        public FileHandling(string fullPath)
        {
            objList = new List<jsonObj>();
            this.fullPath = fullPath;
        }
        public bool loadFromFile()
        {
            if (!File.Exists(fullPath)) return false;

            string json;
            using (StreamReader r = new StreamReader(fullPath))
            {
                json = r.ReadToEnd();
                objList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<jsonObj>>(json);
            }

            return true;
        }
        public bool saveToFile()
        {
            if (!File.Exists(fullPath)) return false;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(objList.ToArray());
            System.IO.File.WriteAllText(fullPath, json);

            return true;
        }
    }
}