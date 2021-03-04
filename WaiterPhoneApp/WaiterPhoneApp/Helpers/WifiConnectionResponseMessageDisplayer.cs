﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WaiterPhoneApp.Helpers
{
    public class WifiConnectionResponseMessageDisplayer
    {
        internal static string GenerateResponse()
        {
            var response = WifiConnectionChecker.CheckConnection();

            switch(response)
            {
                case WifiConnectionResponse.NO_INTERNET:
                    return "No internet connection!";
                case WifiConnectionResponse.WIFI_DATA_INTERNET:
                    return string.Empty;
                case WifiConnectionResponse.OTHER_CONNECTION:
                    return "You are not connected to the wifi network!";
                default:
                    return "Could not determine the connection state!";
            }
        }
    }
}
