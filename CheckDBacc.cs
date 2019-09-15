using System;
using System.IO;
namespace dotNet_ass1
{
    public class CheckDBacc
    {
        public bool checkExist(int accnum)
        {
            //store all acc into array
            string[] allAcc = File.ReadAllLines("accDB.txt");
            foreach (string line in allAcc)
            {
                //check if match then return true
                if (Convert.ToInt32(line) == accnum)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
