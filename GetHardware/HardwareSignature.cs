using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace GetHardware
{
    public class HardwareSignature
    {
        public string HDDSerial { get; set; }
        public string MACAddress { get; set; }

        public HardwareSignature()
        {
            string hdd = getHddSignature("Win32_DiskDrive", "Signature");
            string mac = getMacAddress();

            HDDSerial = hdd;
            MACAddress = mac;


        }

        private string getHddSignature(string wmiClass, string wmiProperty)
        {
            string sResult = string.Empty;

            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            sResult = result;

            return sResult;
        }

        private string getMacAddress()
        {
            const int MIN_MAC_ADDR_LENGTH = 12;
            string macAddress = string.Empty;
            long maxSpeed = -1;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                string tempMac = nic.GetPhysicalAddress().ToString();
                if (nic.Speed > maxSpeed &&
                    !string.IsNullOrEmpty(tempMac) &&
                    tempMac.Length >= MIN_MAC_ADDR_LENGTH)
                {
                    maxSpeed = nic.Speed;
                    macAddress = tempMac;
                }
            }

            return macAddress;
        }

    }
}
