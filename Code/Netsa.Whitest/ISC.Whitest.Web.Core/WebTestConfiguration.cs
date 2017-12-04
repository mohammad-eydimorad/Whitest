namespace ISC.Whitest.Web.Core
{
    public class WebTestConfiguration
    {
        public bool UseIISExpress { get; private set; }
        public string IISExpressPath { get; private set; }

        internal WebTestConfiguration(bool useIISExpress, string IISExpressPath)
        {
            this.UseIISExpress = useIISExpress;
            this.IISExpressPath = IISExpressPath;
        }
    }
}