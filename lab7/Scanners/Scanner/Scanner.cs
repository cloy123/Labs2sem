using System;

namespace lab7
{
    public class Scanner: ICloneable
    {
        public string Firm { get; set; }
        public string ScannerType { get; set; }
        public Resolution MaxResolution { get; set; }
        public int Number { get; set; } = 0;
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
        { MaxResolution = new Resolution(); }
        public virtual string GetInformation()
        { return $"Firm: {Firm} \nScanner Type: {ScannerType} \nMax Resolution: {MaxResolution}"; }
        public object Clone()
        {
            Scanner s = new Scanner(this.Firm, this.ScannerType, (Resolution)this.MaxResolution.Clone());
            s.Number = this.Number;
            return s;
        }
    }
}
