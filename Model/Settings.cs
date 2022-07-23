using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZipTools.Model
{
    public class Settings
    {
        public AES AES { get; set; }
    }

    public class AES
    {
        public List<Key> Keys { get; set; }
        public Key SelectedKey { get; set; }
    }

    public class Key
    { 
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
