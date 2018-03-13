namespace Avosa.Innervoice.Core
{
    public class Confirmer
    {
        public Confirmer()
        {
            Success = true;
        }

        public bool Success { get; private set; }

        public string Error { get; private set; }

        public void SetError(string message)
        {
            Success = false;
            Error = message.Trim();
        }

        public override string ToString()
        {
            var template = "Succes: {0}. Error: {1}";
            return string.Format(template, Success, Error);
        }
    }
}
