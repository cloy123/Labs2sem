using System;
using System.Collections.Generic;
using System.Text;
using ScannerBL;

namespace Lab3
{
    public class FlatbedScanner: Scanner
    {
        public new const string ScannerType = "Планшетный";

        public string ConnectionInterface;


        public override string GetInformation()
        {
            return base.GetInformation() + $", Connection interface: {ConnectionInterface}";
        }

        public FlatbedScanner() : base() { }

        public FlatbedScanner(string firm, Resolution maxResolution, string connectionInterface)
        {
            Firm = firm;

            if (maxResolution == null)
            {
                throw new ArgumentNullException("Разрешение не может быть пустым или null", nameof(maxResolution));
            }
            else
            {
                MaxResolution = maxResolution;
            }

            ConnectionInterface = connectionInterface;
        }
    }
}
