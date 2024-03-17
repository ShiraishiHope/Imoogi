using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;

namespace Imoogi
{
    class Input
    {
        //Class used to optimize the keys insert within
        private static Hashtable keyTable = new Hashtable();

        //returns a key back to the class
        public static bool KeyPress(Keys key)
        {
            //if the hastable is empty, we return false
            if (keyTable[key] == null)
            {
                return false;
            }
            //if hashtable not empty, we return true
            return (bool)keyTable[key];
        }

        //change the state of the keys and snake
        public static void changeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
