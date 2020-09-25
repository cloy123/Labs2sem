using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab6
{
    [Serializable]
    public class Scanner
    {
        public string Firm;

        public string ScannerType;

        public Resolution MaxResolution;

        public int[] ArrForSort;

        public int Number = 0;// = new Random().Next(1, 100);



        public Scanner(string firm, string scannerType, Resolution maxResolution)
        {
            ScannerType = scannerType;
            Firm = firm;
            
            if(maxResolution == null)
            {
                throw new ArgumentNullException("Разрешение не может быть пустым или null", nameof(maxResolution));
            }
            else
            {
                MaxResolution = maxResolution;
            }
        }

        public Scanner() 
        {
            MaxResolution = new Resolution();
        }
        public virtual string GetInformation()
        {
            return $"Firm: {Firm} \nScanner Type: {ScannerType} \nMax Resolution: {MaxResolution.ToString()}";
        }

        public string[] Formats;

        public Scanner(string firm, string scannerType, Resolution maxResolution, string[] formats):this(firm, scannerType, maxResolution)
        {
            Formats = formats;
        }
    }
}
