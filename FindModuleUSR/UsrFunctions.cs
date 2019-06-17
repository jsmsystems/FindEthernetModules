using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindModuleUSR
{

  




    public static class UsrFunctions
    {

        public static byte[] searchCommand = { 0xFF, 0x01, 0x01, 0x02 };

        public static byte[] SearchCommand
        {
            get { return searchCommand; }
        }

        public static byte[] resetCommand = { 0xFF, 0x02, 0x01, 0x02 };

        public static byte[] ResetCommand
        {
            get { return resetCommand; }
        }

        public static byte[] readCommand = { 0xFF, 0x01, 0x01, 0x02 };

        public static byte[] ReadCommand
        {
            get { return readCommand; }
        }

        public static byte[] storeCommand = { 0xFF, 0x01, 0x01, 0x02 };

        public static byte[] StoreCommand
        {
            get { return storeCommand; }
        }




    }
}
