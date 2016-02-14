using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Weathering.Services
{
    class LoggingService
    {
        private static StorageFolder storageFolder = null;
        private static StorageFile sampleFile = null;

        public async static void LogMessage(String message)
        {
            
            try
            {
                if (storageFolder == null)
                {
                    storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
                }
                if (sampleFile == null)
                {
                    sampleFile = await storageFolder.CreateFileAsync("weathering.log.txt", CreationCollisionOption.OpenIfExists);
                }
                await FileIO.AppendTextAsync(sampleFile, message + "\r\n");
            }
            catch (Exception)
            {

            }
        }
    }
}
