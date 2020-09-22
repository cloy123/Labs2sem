using System;

namespace Lab1
{
    public class Scanner
    {
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
    }
}
