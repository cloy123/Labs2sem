using System;

namespace Lab1
{
    public class Scanner
    {
        public static string Firm = "фирма";
        public static string ScannerType = "тип сканера";
        public static Resolution MaxResolution = new Resolution(100, 100);

        //public Scanner(string firm, string scannerType, Resolution maxResolution)
        //{
        //    ScannerType = scannerType;
        //    Firm = firm;
            
        //    if(maxResolution == null)
        //    {
        //        throw new ArgumentNullException("Разрешение не может быть пустым или null", nameof(maxResolution));
        //    }
        //    else
        //    {
        //        MaxResolution = maxResolution;
        //    }
        //}

        //public Scanner() 
        //{
        //    MaxResolution = new Resolution();
        //}
    }
}
