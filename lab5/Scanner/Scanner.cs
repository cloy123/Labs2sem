using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab5
{
    [Serializable]
    public class Scanner
    {

        public int[] ArrForSort;

        #region lab1 и lab2
        public string Firm;

        public string ScannerType;

        public Resolution MaxResolution;



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
        #endregion

        #region lab3
        public virtual string GetInformation()
        {
            return $"Firm: {Firm} \nScanner Type: {ScannerType} \nMax Resolution: {MaxResolution.ToString()}";
        }
        #endregion

        #region lab4

        public string[] Formats;

        public Scanner(string firm, string scannerType, Resolution maxResolution, string[] formats):this(firm, scannerType, maxResolution)
        {
            Formats = formats;
        }

        #endregion



    }
}
