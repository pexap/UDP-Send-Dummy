using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Tes_Kirim_Data_Dummy
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient UDP = new UdpClient();
            IPAddress IP = IPAddress.Parse("127.0.0.1");
            IPEndPoint Tujuan = new IPEndPoint(IP, Int32.Parse("6301"));
            IPEndPoint Tujuan2 = new IPEndPoint(IP, Int32.Parse("6302"));
            IPEndPoint Tujuan3 = new IPEndPoint(IP, Int32.Parse("6303"));
            IPEndPoint Tujuan4 = new IPEndPoint(IP, Int32.Parse("6304"));

            Random r = new Random();

            int dataX = 0, dataY = 0, dataW = 0;
            string data1, data2, data3;

            int dataX1 = 0, dataX2 = 0, dataX3 = 0,
                dataY1 = 0, dataY2 = 0, dataY3 = 0,
                dataW1 = 0, dataW2 = 0, dataW3 = 0;
            double batPC1 = 24, batPC2 = 24, batPC3 = 24,
                   batMot1 = 24, batMot2 = 24, batMot3 = 24;

            Console.SetWindowSize(50, 5);

            while (true)
            {
                dataX1 += 7;
                if (dataX1 >= 500) dataX1 = 0;

                dataY2 += 7;
                if (dataY2 >= 500) dataY2 = 0;

                dataX3 += 7;
                dataY3 += 7;
                if (dataX3 >= 500) dataX3 = 0;
                if (dataY3 >= 500) dataY3 = 0;

                dataW3 += 15;
                if (dataW3 >= 360) dataW3 = 0;

                //data1 = dataX + "/" + dataY + "/" + dataW;
                //data2 = dataW + "/" + dataX + "/" + dataY;
                //data3 = dataY + "/" + dataW + "/" + dataX;

                data1 = dataX1 + "/" + dataY1 + "/" + "0" + "/-1/0/" + dataX1 + "/" + dataY1 + "/" + "22" + "/" + batMot1;
                data2 = dataX2 + "/" + dataY2 + "/" + "90" + "/-1/ 0/" + dataX2 + "/" + dataY2 + "/" + batPC2 + "/" + "22";
                data3 = dataX3 + "/" + dataY3 + "/" + dataW3 + "/-1/0/" + dataX3 + "/" + dataY3 + "/" + "22" + "/" + "22";

                //data1 = "400" + "/" + "600" + "/" + "0" + "/-1/0/" + "0" + "/" + "0" + "/" + "22" + "/" + "24";
                //data2 = "200" + "/" + "200" + "/" + "90" + "/-1/0/" + "0" + "/" + "0" + "/" + "24" + "/" + "22";
                //data3 = "300" + "/" + "300" + "/" + "180" + "/-1/0/" + "0" + "/" + "0" + "/" + "22" + "/" + "22";
                //data1 = "400/600/0/10/0/0";
                //data2 = "400/800/0/10/0/0";
                //data3 = "0/0/0/10/0/0";

                byte[] dataByte1 = Encoding.ASCII.GetBytes(data1);
                byte[] dataByte2 = Encoding.ASCII.GetBytes(data2);
                byte[] dataByte3 = Encoding.ASCII.GetBytes(data3);

                UDP.Send(dataByte1, dataByte1.Length, Tujuan);
                UDP.Send(dataByte2, dataByte2.Length, Tujuan2);
                UDP.Send(dataByte3, dataByte3.Length, Tujuan3);
                UDP.Send(dataByte1, dataByte1.Length, Tujuan4);

                Console.Clear();
                Console.WriteLine("Robot 1 : " + data1);
                Console.WriteLine("Robot 2 : " + data2);
                Console.WriteLine("Robot 3 : " + data3);

                Thread.Sleep(20);
            }
        }
    }
}
