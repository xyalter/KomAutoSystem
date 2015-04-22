using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SystemCenter
{
    public class PnPDevice
    {
        public static PnPEntityInfo[] AllPnPEntities
        {
            get
            {
                return PnPDevice.WhoPnPEntity(0, 0, Guid.Empty);
            }
        }

        public static PnPEntityInfo[] AllUsbDevices
        {
            get
            {
                return PnPDevice.WhoUsbDevice(0, 0, Guid.Empty);
            }
        }

        public static USBDiskInfo[] AllUsbDisk
        {
            get
            {
                return PnPDevice.WhoUsbDisk();
            }
        }

        public PnPDevice()
        {
        }

        private static object GetPropertiesValue(ManagementObject mo, string name)
        {
            object item;
            try
            {
                item = mo[name];
            }
            catch (Exception exception)
            {
                item = string.Empty;
            }
            return item;
        }

        private static string GetSerialNumber(string sPNPDeviceID)
        {
            string[] strArrays = sPNPDeviceID.Split(new char[] { '\\' });
            string str = strArrays[(int)strArrays.Length - 1];
            char[] chrArray = new char[] { '&' };
            return str.Split(chrArray)[0];
        }

        public static PnPEntityInfo[] WhoPnPEntity(ushort VendorID, ushort ProductID, Guid ClassGuid)
        {
            string str;
            string str1;
            PnPEntityInfo item = new PnPEntityInfo();
            List<PnPEntityInfo> pnPEntityInfos = new List<PnPEntityInfo>();
            if (VendorID == 0)
            {
                str = (ProductID != 0 ? string.Concat("'%VID[_]____&PID[_]", ProductID.ToString("X4"), "%'") : "'%VID[_]____&PID[_]____%'");
            }
            else if (ProductID != 0)
            {
                string[] strArrays = new string[] { "'%VID[_]", VendorID.ToString("X4"), "&PID[_]", ProductID.ToString("X4"), "%'" };
                str = string.Concat(strArrays);
            }
            else
            {
                str = string.Concat("'%VID[_]", VendorID.ToString("X4"), "&PID[_]____%'");
            }
            if (ClassGuid != Guid.Empty)
            {
                string[] strArrays1 = new string[] { "SELECT * FROM Win32_PnPEntity WHERE PNPDeviceID LIKE", str, " AND ClassGuid='", ClassGuid.ToString("B"), "'" };
                str1 = string.Concat(strArrays1);
            }
            else
            {
                str1 = string.Concat("SELECT * FROM Win32_PnPEntity WHERE PNPDeviceID LIKE", str);
            }
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher(str1)).Get();
            if (managementObjectCollections != null)
            {
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    string item1 = managementObject["PNPDeviceID"] as string;
                    Match match = Regex.Match(item1, "VID_[0-9|A-F]{4}&PID_[0-9|A-F]{4}");
                    if (!match.Success)
                    {
                        continue;
                    }
                    item.PNPDeviceID = item1;
                    item.Name = managementObject["Name"] as string;
                    item.Description = managementObject["Description"] as string;
                    item.Service = managementObject["Service"] as string;
                    item.Status = managementObject["Status"] as string;
                    item.VendorID = Convert.ToUInt16(match.Value.Substring(4, 4), 16);
                    item.ProductID = Convert.ToUInt16(match.Value.Substring(13, 4), 16);
                    item.ClassGuid = new Guid(managementObject["ClassGuid"] as string);
                    pnPEntityInfos.Add(item);
                }
            }
            if (pnPEntityInfos.Count == 0)
            {
                return null;
            }
            return pnPEntityInfos.ToArray();
        }

        public static PnPEntityInfo[] WhoPnPEntity(ushort VendorID, ushort ProductID)
        {
            return PnPDevice.WhoPnPEntity(VendorID, ProductID, Guid.Empty);
        }

        public static PnPEntityInfo[] WhoPnPEntity(Guid ClassGuid)
        {
            return PnPDevice.WhoPnPEntity(0, 0, ClassGuid);
        }

        public static PnPEntityInfo[] WhoPnPEntity(string PNPDeviceID)
        {
            string str;
            PnPEntityInfo item = new PnPEntityInfo();
            List<PnPEntityInfo> pnPEntityInfos = new List<PnPEntityInfo>();
            str = (!string.IsNullOrEmpty(PNPDeviceID) ? string.Concat("SELECT * FROM Win32_PnPEntity WHERE PNPDeviceID LIKE '%", PNPDeviceID.Replace('\\', '\u005F'), "%'") : "SELECT * FROM Win32_PnPEntity WHERE PNPDeviceID LIKE '%VID[_]____&PID[_]____%'");
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher(str)).Get();
            if (managementObjectCollections != null)
            {
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    string item1 = managementObject["PNPDeviceID"] as string;
                    Match match = Regex.Match(item1, "VID_[0-9|A-F]{4}&PID_[0-9|A-F]{4}");
                    if (!match.Success)
                    {
                        continue;
                    }
                    item.PNPDeviceID = item1;
                    item.Name = managementObject["Name"] as string;
                    item.Description = managementObject["Description"] as string;
                    item.Service = managementObject["Service"] as string;
                    item.Status = managementObject["Status"] as string;
                    item.VendorID = Convert.ToUInt16(match.Value.Substring(4, 4), 16);
                    item.ProductID = Convert.ToUInt16(match.Value.Substring(13, 4), 16);
                    item.ClassGuid = new Guid(managementObject["ClassGuid"] as string);
                    pnPEntityInfos.Add(item);
                }
            }
            if (pnPEntityInfos.Count == 0)
            {
                return null;
            }
            return pnPEntityInfos.ToArray();
        }

        public static PnPEntityInfo[] WhoPnPEntity(string[] ServiceCollection)
        {
            PnPEntityInfo item = new PnPEntityInfo();
            if (ServiceCollection == null || (int)ServiceCollection.Length == 0)
            {
                return PnPDevice.WhoPnPEntity(0, 0, Guid.Empty);
            }
            List<PnPEntityInfo> pnPEntityInfos = new List<PnPEntityInfo>();
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE PNPDeviceID LIKE '%VID[_]____&PID[_]____%'")).Get();
            if (managementObjectCollections != null)
            {
            Label0:
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    string str = managementObject["PNPDeviceID"] as string;
                    Match match = Regex.Match(str, "VID_[0-9|A-F]{4}&PID_[0-9|A-F]{4}");
                    if (!match.Success)
                    {
                        continue;
                    }
                    string item1 = managementObject["Service"] as string;
                    if (string.IsNullOrEmpty(item1))
                    {
                        continue;
                    }
                    string[] serviceCollection = ServiceCollection;
                    int num = 0;
                    while (num < (int)serviceCollection.Length)
                    {
                        if (string.Compare(item1, serviceCollection[num], true) != 0)
                        {
                            num++;
                        }
                        else
                        {
                            item.PNPDeviceID = str;
                            item.Name = managementObject["Name"] as string;
                            item.Description = managementObject["Description"] as string;
                            item.Service = item1;
                            item.Status = managementObject["Status"] as string;
                            item.VendorID = Convert.ToUInt16(match.Value.Substring(4, 4), 16);
                            item.ProductID = Convert.ToUInt16(match.Value.Substring(13, 4), 16);
                            item.ClassGuid = new Guid(managementObject["ClassGuid"] as string);
                            pnPEntityInfos.Add(item);
                            goto Label0;
                        }
                    }
                }
            }
            if (pnPEntityInfos.Count == 0)
            {
                return null;
            }
            return pnPEntityInfos.ToArray();
        }

        public static PnPEntityInfo[] WhoUsbDevice(ushort VendorID, ushort ProductID, Guid ClassGuid)
        {
            PnPEntityInfo item = new PnPEntityInfo();
            List<PnPEntityInfo> pnPEntityInfos = new List<PnPEntityInfo>();
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher("SELECT * FROM Win32_USBControllerDevice")).Get();
            if (managementObjectCollections != null)
            {
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    string str = managementObject["Dependent"] as string;
                    char[] chrArray = new char[] { '=' };
                    string str1 = str.Split(chrArray)[1];
                    Match match = Regex.Match(str1, "VID_[0-9|A-F]{4}&PID_[0-9|A-F]{4}");
                    if (!match.Success)
                    {
                        continue;
                    }
                    ushort num = Convert.ToUInt16(match.Value.Substring(4, 4), 16);
                    if (VendorID != 0 && VendorID != num)
                    {
                        continue;
                    }
                    ushort num1 = Convert.ToUInt16(match.Value.Substring(13, 4), 16);
                    if (ProductID != 0 && ProductID != num1)
                    {
                        continue;
                    }
                    ManagementObjectCollection managementObjectCollections1 = (new ManagementObjectSearcher(string.Concat("SELECT * FROM Win32_PnPEntity WHERE DeviceID=", str1))).Get();
                    if (managementObjectCollections1 == null)
                    {
                        continue;
                    }
                    foreach (ManagementObject managementObject1 in managementObjectCollections1)
                    {
                        Guid guid = new Guid(managementObject1["ClassGuid"] as string);
                        if (ClassGuid != Guid.Empty && ClassGuid != guid)
                        {
                            continue;
                        }
                        item.PNPDeviceID = managementObject1["PNPDeviceID"] as string;
                        item.Name = managementObject1["Name"] as string;
                        item.Description = managementObject1["Description"] as string;
                        item.Service = managementObject1["Service"] as string;
                        item.Status = managementObject1["Status"] as string;
                        item.VendorID = num;
                        item.ProductID = num1;
                        item.ClassGuid = guid;
                        pnPEntityInfos.Add(item);
                    }
                }
            }
            if (pnPEntityInfos.Count == 0)
            {
                return null;
            }
            return pnPEntityInfos.ToArray();
        }

        public static PnPEntityInfo[] WhoUsbDevice(ushort VendorID, ushort ProductID)
        {
            return PnPDevice.WhoUsbDevice(VendorID, ProductID, Guid.Empty);
        }

        public static PnPEntityInfo[] WhoUsbDevice(Guid ClassGuid)
        {
            return PnPDevice.WhoUsbDevice(0, 0, ClassGuid);
        }

        public static PnPEntityInfo[] WhoUsbDevice(string PNPDeviceID)
        {
            PnPEntityInfo item = new PnPEntityInfo();
            List<PnPEntityInfo> pnPEntityInfos = new List<PnPEntityInfo>();
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher("SELECT * FROM Win32_USBControllerDevice")).Get();
            if (managementObjectCollections != null)
            {
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    string str = managementObject["Dependent"] as string;
                    char[] chrArray = new char[] { '=' };
                    string str1 = str.Split(chrArray)[1];
                    if (!string.IsNullOrEmpty(PNPDeviceID) && str1.IndexOf(PNPDeviceID, 1, PNPDeviceID.Length - 2, StringComparison.OrdinalIgnoreCase) == -1)
                    {
                        continue;
                    }
                    Match match = Regex.Match(str1, "VID_[0-9|A-F]{4}&PID_[0-9|A-F]{4}");
                    if (!match.Success)
                    {
                        continue;
                    }
                    ManagementObjectCollection managementObjectCollections1 = (new ManagementObjectSearcher(string.Concat("SELECT * FROM Win32_PnPEntity WHERE DeviceID=", str1))).Get();
                    if (managementObjectCollections1 == null)
                    {
                        continue;
                    }
                    foreach (ManagementObject managementObject1 in managementObjectCollections1)
                    {
                        item.PNPDeviceID = managementObject1["PNPDeviceID"] as string;
                        item.Name = managementObject1["Name"] as string;
                        item.Description = managementObject1["Description"] as string;
                        item.Service = managementObject1["Service"] as string;
                        item.Status = managementObject1["Status"] as string;
                        item.VendorID = Convert.ToUInt16(match.Value.Substring(4, 4), 16);
                        item.ProductID = Convert.ToUInt16(match.Value.Substring(13, 4), 16);
                        item.ClassGuid = new Guid(managementObject1["ClassGuid"] as string);
                        pnPEntityInfos.Add(item);
                    }
                }
            }
            if (pnPEntityInfos.Count == 0)
            {
                return null;
            }
            return pnPEntityInfos.ToArray();
        }

        public static PnPEntityInfo[] WhoUsbDevice(string[] ServiceCollection)
        {
            PnPEntityInfo item = new PnPEntityInfo();
            if (ServiceCollection == null || (int)ServiceCollection.Length == 0)
            {
                return PnPDevice.WhoUsbDevice(0, 0, Guid.Empty);
            }
            List<PnPEntityInfo> pnPEntityInfos = new List<PnPEntityInfo>();
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher("SELECT * FROM Win32_USBControllerDevice")).Get();
            if (managementObjectCollections != null)
            {
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    string str = managementObject["Dependent"] as string;
                    char[] chrArray = new char[] { '=' };
                    string str1 = str.Split(chrArray)[1];
                    Match match = Regex.Match(str1, "VID_[0-9|A-F]{4}&PID_[0-9|A-F]{4}");
                    if (!match.Success)
                    {
                        continue;
                    }
                    ManagementObjectCollection managementObjectCollections1 = (new ManagementObjectSearcher(string.Concat("SELECT * FROM Win32_PnPEntity WHERE DeviceID=", str1))).Get();
                    if (managementObjectCollections1 == null)
                    {
                        continue;
                    }
                Label0:
                    foreach (ManagementObject managementObject1 in managementObjectCollections1)
                    {
                        string item1 = managementObject1["Service"] as string;
                        if (string.IsNullOrEmpty(item1))
                        {
                            continue;
                        }
                        string[] serviceCollection = ServiceCollection;
                        int num = 0;
                        while (num < (int)serviceCollection.Length)
                        {
                            if (string.Compare(item1, serviceCollection[num], true) != 0)
                            {
                                num++;
                            }
                            else
                            {
                                item.PNPDeviceID = managementObject1["PNPDeviceID"] as string;
                                item.Name = managementObject1["Name"] as string;
                                item.Description = managementObject1["Description"] as string;
                                item.Service = item1;
                                item.Status = managementObject1["Status"] as string;
                                item.VendorID = Convert.ToUInt16(match.Value.Substring(4, 4), 16);
                                item.ProductID = Convert.ToUInt16(match.Value.Substring(13, 4), 16);
                                item.ClassGuid = new Guid(managementObject1["ClassGuid"] as string);
                                pnPEntityInfos.Add(item);
                                goto Label0;
                            }
                        }
                    }
                }
            }
            if (pnPEntityInfos.Count == 0)
            {
                return null;
            }
            return pnPEntityInfos.ToArray();
        }

        public static USBDiskInfo[] WhoUsbDisk()
        {
            List<USBDiskInfo> uSBDiskInfos = new List<USBDiskInfo>();
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType = \"USB\"")).Get();
            if (managementObjectCollections != null)
            {
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    USBDiskInfo uSBDiskInfo = new USBDiskInfo()
                    {
                        Caption = (string)PnPDevice.GetPropertiesValue(managementObject, "Caption"),
                        Name = (string)PnPDevice.GetPropertiesValue(managementObject, "Name"),
                        PNPDeviceID = (string)PnPDevice.GetPropertiesValue(managementObject, "PNPDeviceID"),
                        Model = (string)PnPDevice.GetPropertiesValue(managementObject, "Model"),
                        FirmwareRevision = (string)PnPDevice.GetPropertiesValue(managementObject, "FirmwareRevision"),
                        DeviceID = (string)PnPDevice.GetPropertiesValue(managementObject, "DeviceID"),
                        Size = (ulong)PnPDevice.GetPropertiesValue(managementObject, "Size"),
                        Status = (string)PnPDevice.GetPropertiesValue(managementObject, "Status"),

                    };
                    uSBDiskInfo.SerialNumber = PnPDevice.GetSerialNumber(uSBDiskInfo.PNPDeviceID);
                    uSBDiskInfos.Add(uSBDiskInfo);
                }
            }
            if (uSBDiskInfos.Count == 0)
            {
                return null;
            }
            return uSBDiskInfos.ToArray();
        }

        public static USBDiskInfo[] WhoUsbDisk(string pSerialNumber)
        {
            List<USBDiskInfo> uSBDiskInfos = new List<USBDiskInfo>();
            ManagementObjectCollection managementObjectCollections = (new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType = \"USB\"")).Get();
            if (managementObjectCollections != null)
            {
                foreach (ManagementObject managementObject in managementObjectCollections)
                {
                    USBDiskInfo uSBDiskInfo = new USBDiskInfo()
                    {
                        Caption = (string)PnPDevice.GetPropertiesValue(managementObject, "Caption"),
                        Name = (string)PnPDevice.GetPropertiesValue(managementObject, "Name"),
                        PNPDeviceID = (string)PnPDevice.GetPropertiesValue(managementObject, "PNPDeviceID"),
                        Model = (string)PnPDevice.GetPropertiesValue(managementObject, "Model"),
                        FirmwareRevision = (string)PnPDevice.GetPropertiesValue(managementObject, "FirmwareRevision"),
                        DeviceID = (string)PnPDevice.GetPropertiesValue(managementObject, "DeviceID"),
                        Size = (ulong)PnPDevice.GetPropertiesValue(managementObject, "Size"),
                        Status = (string)PnPDevice.GetPropertiesValue(managementObject, "Status"),

                    };
                    uSBDiskInfo.SerialNumber = PnPDevice.GetSerialNumber(uSBDiskInfo.PNPDeviceID);
                    if (!uSBDiskInfo.SerialNumber.Equals(pSerialNumber))
                    {
                        continue;
                    }
                    uSBDiskInfos.Add(uSBDiskInfo);
                }
            }
            if (uSBDiskInfos.Count == 0)
            {
                return null;
            }
            return uSBDiskInfos.ToArray();
        }
    }
}
