using System.Windows.Controls;
using Task3SqlServer.Model;

namespace Task3SqlServer.Core
{
    public static class CoreConnection
    {
        public static Frame CoreFrame { get; set; }

        public static Task3DBEntities DB { get; set; }
    }
}
