using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MouseSyncProject.Shared
{
    internal class MouseEvent
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool LeftClick { get; set; }

        public bool RightClick { get; set; }
    }
}
