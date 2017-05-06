using System;

namespace Dorado.Components.Alerts
{
    public class Alert
    {
        public String Message { get; set; }
        public AlertType Type { get; set; }
        public Int32 Timeout { get; set; }
    }
}