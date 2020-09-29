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
    public class Scanner: ICloneable
    {
        public string Firm;

        public string ScannerType;

        public Resolution MaxResolution;

        public int[] ArrForSort;

        public int Number = 0;



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
            return $"Firm: {Firm} \nScanner Type: {ScannerType} \nMax Resolution: {MaxResolution}";
        }

        public object Clone()
        {
            Scanner s = new Scanner(this.Firm, this.ScannerType, (Resolution)this.MaxResolution.Clone());
            s.Number = this.Number;
            return s;
        }
    }
}
