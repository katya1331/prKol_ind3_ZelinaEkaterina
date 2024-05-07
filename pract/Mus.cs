using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

using System.IO;

namespace pract
{
    internal class Mus
    {
        private string _song;
        private string _autor;
        private int _disknum;
        public string song
        {
            get { return _song; }
            set { _song = value; }
        }
        public string autor
        {
            get { return _autor; }
            set { _autor = value; }
        }
        public int disknum
        {
            get { return _disknum; }
            set { _disknum = value; }
        }
        public Hashtable disknames =new Hashtable();
        public bool AddDisk(int num,string data)
        {
            if (!disknames.Contains(num))
            {
                disknames.Add(num,data);
                File.AppendAllText("1.txt", num.ToString() + data+"\n");
                return true;
            }
            else 
            {
                return false;
            }

        }
    }
}
