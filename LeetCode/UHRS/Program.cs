using Microsoft.Search.UHRS.Client;
/// using Microsoft.Search.UHRS.Services

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UHRS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UHRSServiceClientSetup.SetUserName("v-gavinwu");
                UHRSServiceClientSetup.SetPassword("Wgt#12345");
                UHRSServiceClientSetup.SetServerAddress("prod.uhrs.playmsn.com");
                UHRSServiceClientSetup.WinLoginAD(UHRSServiceClientSetup.GetServerAddress(), ADAuthType.Interactive);
                //UHRSServiceClientSetup client = new UHRSServiceClientSetup();
                //var auth = client.GetAuthClient(UHRSServiceClientSetup.GetServerAddress(), UHRSServiceClientSetup.GetUserName(), UHRSServiceClientSetup.GetPassWord());
                //var ss = auth.Login(UHRSServiceClientSetup.GetUserName(), UHRSServiceClientSetup.GetPassWord());
                //UHRSServiceClientSetup.WinLogin("prod.uhrs.playmsn.com");
                ///UHRSServiceClientSetup.GetAuth();
                ////UHRSServiceClientSetup.WinLoginAD(serverAddress);
            }
            catch (Exception ex)
            {
                //customer exception handling 
            }
        }
    }
}
