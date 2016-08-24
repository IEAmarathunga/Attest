using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web;

namespace Attest.Web.Controllers.Services
{
    public class SMS : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                if (serialPort.IsOpen)
                    serialPort.Close();
            }

            // Free any unmanaged objects here.
            if (serialPort.IsOpen)
                serialPort.Close();
            disposed = true;
        }
        SerialPort serialPort;

        public SMS(string comport)
        {
            this.serialPort = new SerialPort();
            this.serialPort.PortName = comport;
            this.serialPort.BaudRate = 9600;
            this.serialPort.Parity = Parity.None;
            this.serialPort.DataBits = 8;
            this.serialPort.StopBits = StopBits.One;
            this.serialPort.Handshake = Handshake.RequestToSend;
            this.serialPort.DtrEnable = true;
            this.serialPort.RtsEnable = true;
            this.serialPort.NewLine = System.Environment.NewLine;
        }

        public bool sendSMS(string cellNo, string sms)
        {
            string messages = null;
            messages = sms;
            if (this.serialPort.IsOpen == true)
            {
                try
                {                   
                    this.serialPort.WriteLine("AT" + (char)(13));
                    Thread.Sleep(4);
                    this.serialPort.WriteLine("AT+CMGF=1" + (char)(13));
                    Thread.Sleep(5);
                    this.serialPort.WriteLine("AT+CMGS=\"" + cellNo + "\"");
                    Thread.Sleep(10);
                    this.serialPort.WriteLine("" + messages + (char)(26));
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
                return true;
            }
            else return false;
        }

        public void Opens()
        {
            try
            {
                if (this.serialPort.IsOpen == false)
                {
                    this.serialPort.Open();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Close()
        {
            try
            {
                if (this.serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

    }
}