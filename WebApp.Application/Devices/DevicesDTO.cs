using WebApp.Application.Modem;

namespace WebApp.Application.Devices
{
    public class DeviceDto
    {
        public ModemDTO Modem { get; set; }
        public SimCardDTO SimCard { get; set; }
    }

}
