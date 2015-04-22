using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemCenter
{
    public class USBDiskInfo
    {
        public string Caption;

        public string Name;

        public string PNPDeviceID;

        public string Model;

        public string FirmwareRevision;

        public string DeviceID;

        public ulong Size;

        public string Status;

        public string SerialNumber;

        public USBDiskInfo()
        {
        }

        private string GetDiskSize(ulong iSize)
        {
            if ((double)((float)iSize) > Math.Pow(1024, 4))
            {
                double num = Math.Round((double)((float)iSize) / Math.Pow(1024, 4), 2);
                return string.Concat(num.ToString(), " TB");
            }
            if ((double)((float)iSize) > Math.Pow(1024, 3))
            {
                double num1 = Math.Round((double)((float)iSize) / Math.Pow(1024, 3), 2);
                return string.Concat(num1.ToString(), " GB");
            }
            if ((double)((float)iSize) > Math.Pow(1024, 2))
            {
                double num2 = Math.Round((double)((float)iSize) / Math.Pow(1024, 2), 2);
                return string.Concat(num2.ToString(), " MB");
            }
            if ((double)((float)iSize) <= Math.Pow(1024, 1))
            {
                return string.Concat(iSize.ToString(), " B");
            }
            double num3 = Math.Round((double)((float)iSize) / Math.Pow(1024, 1), 2);
            return string.Concat(num3.ToString(), " KB");
        }

        public override string ToString()
        {
            return string.Concat(this.Caption, "(", this.GetDiskSize(this.Size), ")");
        }
    }
}
