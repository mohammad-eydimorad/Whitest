namespace ISC.Whitest.Web.Core.Hosting.IISExpressHosting
{
    public class IISExpressHostFactory
    {
        public static IISExpressHost CreateDefaultInstance(string targetProjectFolder, int port,
            string iisExePath = null)
        {
            return new IISExpressHost(targetProjectFolder, port,iisExePath);
        }
    }
}
