using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //fileinfo module
using Crc16Module; //crc16 module
using System.IO.Ports;
using System.Threading;

namespace YmodemClass
{
    public delegate void functionTransmitingCb(int packet_index);

    public class Ymodem
    {
        private SerialPort _serialPort;
        private functionTransmitingCb transmitCb;

        public Ymodem(SerialPort port)
        {
            this._serialPort = port;
            this.transmitCb = null;
        }

        public void setTransmitingCb(functionTransmitingCb pfunc)
        {
            if (pfunc != null)
            {
                transmitCb = new functionTransmitingCb(pfunc);
            }
        }

        /*
        * Upload file via Ymodem protocol to the device
        * ret: is the transfer succeeded? true is if yes
        */
        public bool YmodemUploadFile(string path)
        {
            /* control signals */
            const byte STX = 2;  // Start of TeXt 
            const byte EOT = 4;  // End Of Transmission
            const byte ACK = 6;  // Positive ACknowledgement
            const byte C = 67;   // capital letter C
            const byte NACK = 21;   // NACK 

            /* sizes */
            const int dataSize = 1024;
            const int crcSize = 2;

            /* THE PACKET: 1029 bytes */
            /* header: 3 bytes */
            // STX
            int packetNumber = 0;
            int invertedPacketNumber = 255;
            /* data: 1024 bytes */
            byte[] data = new byte[dataSize];
            /* footer: 2 bytes */
            byte[] CRC = new byte[crcSize];

            /* get the file */
            FileStream fileStream = new FileStream(@path, FileMode.Open, FileAccess.Read);

            try
            {
                {
                    int read_byte;
                    int backup_byte = 9;
                    int count = _serialPort.BytesToRead;

                    Console.WriteLine("#####Read byte{0}:", count);
                    for (int i = 0; i < count; i++)
                    {
                        read_byte = _serialPort.ReadByte();
                        if (i == 0)
                        {
                            backup_byte = read_byte;
                        }
                        Console.WriteLine("[{0:X}]", read_byte);
                    }
                }

                /* send the initial packet with filename and filesize */
                if (67 != C)
                {
                    Console.WriteLine("Can't begin the transfer.");
                    return false;
                }

                {
                    byte[] data1 = new byte[128];
                    /* footer: 2 bytes */
                    byte[] CRC1 = new byte[crcSize];

                    sendYmodemInitialPacket(0x01, 0, invertedPacketNumber, data1, 128, path, fileStream, CRC1, crcSize);

                }

                //sendYmodemInitialPacket(STX, packetNumber, invertedPacketNumber, data, dataSize, path, fileStream, CRC, crcSize);

                Thread.Sleep(200);
                // int read_byte;
                // int backup_byte = 9;
                // int count = _serialPort.BytesToRead;
                //
                // Console.WriteLine("#####Read byte{0}:", count);
                // for (int i = 0; i < count; i++)
                // {
                //     read_byte = _serialPort.ReadByte();
                //     if (i == 0)
                //     {
                //         backup_byte = read_byte;
                //     }
                //     Console.WriteLine("[{0:X}]", read_byte);
                // }
                //
                //
                // //if (_serialPort.ReadByte() != ACK)

                if (_serialPort.ReadByte() != ACK)
                {
                    Console.WriteLine("Can't send the initial packet.");
                    return false;
                }   


                    if (_serialPort.ReadByte() != C)
                        return false;

                    /* send packets with a cycle until we send the last byte */
                    int fileReadCount;
                    do
                    {
                        /* if this is the last packet fill the remaining bytes with 0 */
                        fileReadCount = fileStream.Read(data, 0, dataSize);
                        if (fileReadCount == 0) break;
                        if (fileReadCount != dataSize)
                            for (int i = fileReadCount; i < dataSize; i++)
                                data[i] = 0;

                        /* calculate packetNumber */
                        packetNumber++;
                        if (packetNumber > 255)
                            packetNumber -= 256;
                        Console.WriteLine(packetNumber);

                        /* calculate invertedPacketNumber */
                        invertedPacketNumber = 255 - packetNumber;

                        /* calculate CRC */
                        Crc16Ccitt crc16Ccitt = new Crc16Ccitt(InitialCrcValue.Zeros);
                        CRC = crc16Ccitt.ComputeChecksumBytes(data);

                        /* send the packet */
                        sendYmodemPacket(STX, packetNumber, invertedPacketNumber, data, dataSize, CRC, crcSize);


                        /* wait for ACK */
                        if (_serialPort.ReadByte() != ACK)
                        {
                            Console.WriteLine("Couldn't send a packet.");
                            return false;
                        }

                        if (transmitCb != null)
                        {
                            transmitCb(packetNumber);
                        }
                    } while (dataSize == fileReadCount);

                    #region 重构部分
                    // /* send EOT (tell the downloader we are finished) */
                    // _serialPort.Write(new byte[] { EOT }, 0, 1);
                    // /* send closing packet */
                    // packetNumber = 0;
                    // invertedPacketNumber = 255;
                    // data = new byte[dataSize];
                    // CRC = new byte[crcSize];
                    // sendYmodemClosingPacket(STX, packetNumber, invertedPacketNumber, data, dataSize, CRC, crcSize);
                    // /* get ACK (downloader acknowledge the EOT) */
                    // if (_serialPort.ReadByte() != ACK)
                    // {
                    //     Console.WriteLine("Can't complete the transfer.");
                    //     return false;
                    // }
                    #endregion

                    /* send EOT (tell the downloader we are finished) */
                    _serialPort.Write(new byte[] { EOT }, 0, 1);

                    Thread.Sleep(20);
                    int back = _serialPort.ReadByte();
                    if (back != NACK)
                    {
                        Console.WriteLine("Can't get NACK. back ={0}",back);
                    }

                    _serialPort.Write(new byte[] { EOT }, 0, 1);

                    Thread.Sleep(20);
                    int back2 = _serialPort.ReadByte();
                    if (back2 != ACK)
                    {
                        Console.WriteLine("Can't get ACK. back2 ={0}", back2);
                    }
                    int back3 = _serialPort.ReadByte();

                    if (back3 != C)
                    {
                        Console.WriteLine("Can't get ACK. back3 ={0}", back3);
                    }

                /* send last packet frame */
                byte[] data3= new byte[128];
                byte[] CRC3= new byte[crcSize];
                sendYmodemClosingPacket(0x01, 0x00, 0xff, data3, 128, CRC3, crcSize);

                Thread.Sleep(20);
                int back4 = _serialPort.ReadByte();
                if (back4 != ACK)
                {
                    Console.WriteLine("Can't get ACK. back3 ={0}", back4);
                }

            }
            catch (TimeoutException)
            {
                throw new Exception("Eductor does not answering");
            }
            finally
            {
                fileStream.Close();
            }

            Console.WriteLine("File transfer is succesful");
            return true;
        }

        private void sendYmodemInitialPacket(byte STX, int packetNumber, int invertedPacketNumber, byte[] data, int dataSize, string path, FileStream fileStream, byte[] CRC, int crcSize)
        {
            string fileName = System.IO.Path.GetFileName(path);
            string fileSize = fileStream.Length.ToString();

            /* add filename to data */
            int i;
            for (i = 0; i < fileName.Length && (fileName.ToCharArray()[i] != 0); i++)
            {
                data[i] = (byte)fileName.ToCharArray()[i];
            }
            data[i] = 0;

            /* add filesize to data */
            int j;
            for (j = 0; j < fileSize.Length && (fileSize.ToCharArray()[j] != 0); j++)
            {
                data[(i + 1) + j] = (byte)fileSize.ToCharArray()[j];
            }
            data[(i + 1) + j] = 0;

            /* fill the remaining data bytes with 0 */
            for (int k = ((i + 1) + j) + 1; k < dataSize; k++)
            {
                data[k] = 0;
            }

            /* calculate CRC */
            Crc16Ccitt crc16Ccitt = new Crc16Ccitt(InitialCrcValue.Zeros);
            CRC = crc16Ccitt.ComputeChecksumBytes(data);

            /* send the packet */
            sendYmodemPacket(STX, packetNumber, invertedPacketNumber, data, dataSize, CRC, crcSize);
        }

        private void sendYmodemClosingPacket(byte STX, int packetNumber, int invertedPacketNumber, byte[] data, int dataSize, byte[] CRC, int crcSize)
        {
            /* calculate CRC */
            Crc16Ccitt crc16Ccitt = new Crc16Ccitt(InitialCrcValue.Zeros);
            CRC = crc16Ccitt.ComputeChecksumBytes(data);

            /* send the packet */
            sendYmodemPacket(STX, packetNumber, invertedPacketNumber, data, dataSize, CRC, crcSize);
        }

        private void sendYmodemPacket(byte STX, int packetNumber, int invertedPacketNumber, byte[] data, int dataSize, byte[] CRC, int crcSize)
        {
            _serialPort.Write(new byte[] { STX }, 0, 1);
            _serialPort.Write(new byte[] { (byte)packetNumber }, 0, 1);
            _serialPort.Write(new byte[] { (byte)invertedPacketNumber }, 0, 1);
            _serialPort.Write(data, 0, dataSize);
            _serialPort.Write(CRC, 0, crcSize);
        }

    }
}
