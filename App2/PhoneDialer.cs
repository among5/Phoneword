using System;
using Xamarin.Essentials;

namespace Core
{
  public static class PhoneDialerTest
  {
    public static void PlacePhoneCall(string number)
    {
      try
      {
        PhoneDialer.Open(number);
      }
      catch (ArgumentNullException anEx)
      {
        // Number was null or white space
      }
      catch (FeatureNotSupportedException ex)
      {
        // Phone Dialer is not supported on this device.
      }
      catch (Exception ex)
      {
        // Other error has occurred.
      }
    }
  }
}
