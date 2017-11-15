using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Net
{
    [Serializable]
    class Message
    {
        enum Header { CONTROL, INFO, MESSAGE };

        Header head;
        List<String> data;
    }
}
