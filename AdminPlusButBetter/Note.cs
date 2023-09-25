using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPlusButBetter
{
    internal class Note
    {
        public string title;
        public string description;
        public int id;


        public Note(string aTitle, string aDescription, int aId)
        {
            title = aTitle;
            description = aDescription;
            id = aId;
        }
    }
}
