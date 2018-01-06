using System;
using System.Threading;

namespace Training3.Model
{
    public class CargoGenerator
    {
        Thread generatingThread;
        Action generate;

        public CargoGenerator(Action generate)
        {
            this.generate = generate;
        }

        public void StartGenerating()
        {
            generatingThread = new Thread(Generate);
            generatingThread.IsBackground = true;
            generatingThread.Start();
        }

        private void Generate()
        {
            while (generatingThread.IsAlive)
            {
                generate();
                Thread.Sleep(5000);
            }
        }

        public void StopGenerating()
        {
            generatingThread.Abort();
        }

    }
}
