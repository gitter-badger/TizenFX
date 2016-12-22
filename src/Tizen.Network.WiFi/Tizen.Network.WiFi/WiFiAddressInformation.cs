/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using Tizen.Network.Connection;

namespace Tizen.Network.WiFi
{
    internal class WiFiAddressInformation : IAddressInformation
    {
        private IntPtr _handle;
        private AddressFamily _family;
        private bool _disposed = false;

        internal WiFiAddressInformation(IntPtr handle, AddressFamily family)
        {
            _handle = handle;
            _family = family;
        }

        ~WiFiAddressInformation()
        {
            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            _handle = IntPtr.Zero;
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public System.Net.IPAddress Dns1
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.Ap.GetDnsAddress(_handle, 1, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get first dns address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                if (addrStr == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetDnsAddress(_handle, 1, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set first dns address, Error - " + (WiFiError)ret);
                }
            }
        }
        public System.Net.IPAddress Dns2
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.Ap.GetDnsAddress(_handle, 2, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get second dns address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                if (addrStr == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetDnsAddress(_handle, 2, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set second dns address, Error - " + (WiFiError)ret);
                }
            }
        }
        public System.Net.IPAddress Gateway
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.Ap.GetGatewayAddress(_handle, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get gateway address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                if (addrStr == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetGatewayAddress(_handle, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set gateway address, Error - " + (WiFiError)ret);
                }
            }
        }
        public System.Net.IPAddress SubnetMask
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.Ap.GetSubnetMask(_handle, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get subnet mask, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                if (addrStr == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetSubnetMask(_handle, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set subnet mask, Error - " + (WiFiError)ret);
                }
            }
        }
        public System.Net.IPAddress Ip
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.Ap.GetIpAddress(_handle, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ip address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                if (addrStr == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetIpAddress(_handle, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set ip address, Error - " + (WiFiError)ret);
                }
            }
        }
        public IpConfigType IpConfigType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.Ap.GetIpConfigType(_handle, (int)_family, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ip config type, Error - " + (WiFiError)ret);
                }
                return (IpConfigType)type;
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetIpConfigType(_handle, (int)_family, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set ip config type, Error - " + (WiFiError)ret);
                }
            }
        }
    }
}
