using System;

namespace Lab3
{
    public class FlatbedScanner: Scanner
    {
        public new string ScannerType { get; } = "Планшетный";

        public string ConnectionInterface;


        public override string GetInformation()
        {
            return $"Firm: {Firm} \nScanner Type: {ScannerType} \nMax Resolution: {MaxResolution} \nConnection interface: {ConnectionInterface}";
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
