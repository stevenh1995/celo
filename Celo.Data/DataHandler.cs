using Celo.Common;
using Celo.Data.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Celo.Data
{
    //Purpose of this class: DataLayer To Handle Data (Read / Write To a JSON file)
    //If we had entityframework, I would have created a project called Celo.DAL where I would be making a db calls. 
    public class DataHandler : IDataHandler
    {
        private const string _fileName = "Data.json";

        public List<User> GetData()
        {
            if (!File.Exists(_fileName))
            {
                var file = File.CreateText(_fileName);
                file.Dispose();
            }
            return ReadFile();
        }

        private List<User> ReadFile()
        {
            try
            {
                var data = File.ReadAllText(_fileName);
                if (string.IsNullOrEmpty(data))
                    return new List<User>();
                var userListData = JsonConvert.DeserializeObject<List<User>>(data);
                return userListData;
            }
            catch
            {
            }
            return null;
        }

        public void UpdateFile(List<User> userListData)
        {
            try
            {
                var stringData = JsonConvert.SerializeObject(userListData, Formatting.Indented);
                File.WriteAllText(_fileName, stringData);

            }
            catch
            { 
            }
        }

       

    }
}
