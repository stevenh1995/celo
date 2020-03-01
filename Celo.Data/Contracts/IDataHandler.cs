using Celo.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Celo.Data.Contracts
{
    public interface IDataHandler
    {
        public List<User> GetData();

        public void UpdateFile(List<User> userListData);
    }
}
