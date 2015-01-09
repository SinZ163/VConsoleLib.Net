using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Types
{
    class Channel
    {
        public UInt32 ID;
        public UInt32 unknown1; //only seen to be 0, 1 or 2
        public UInt32 unknown2; //only seen to be 0, 1, 2, or 8
        public UInt32 verbosity_default;
        public UInt32 verbosity_current;
        public UInt32 RGBA_Override;
        public String name;

        public Channel(UInt32 ID, UInt32 unknown1, UInt32 unknown2, UInt32 verbosity_default, UInt32 verbosity_current, UInt32 RGBA_Override, String name)
        {
            this.ID = ID;
            this.unknown1 = unknown1;
            this.unknown2 = unknown2;
            this.verbosity_default = verbosity_default;
            this.verbosity_current = verbosity_current;
            this.RGBA_Override = RGBA_Override;
            this.name = name;
        }
    }
}
