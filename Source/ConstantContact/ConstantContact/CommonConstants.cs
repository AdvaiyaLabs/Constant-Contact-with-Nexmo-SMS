using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantContact
{
  public class CommonConstants
    {
      public class ConstantContactConstants
      {
          public const string CellPhone = "CellPhone";
          public const string HomePhone = "HomePhone";
          public const string WorkPhone = "WorkPhone";
          public const string BusinessStreetAddress = "Work.StreetAddress";
          public const string BusinessAddressCountry = "Work.CountryCode";
          public const string BusinessAddressCity = "Work.City";
          public const string BusinessAddressState = "Work.State";
          public const string BusinessAddressStateCode = "Work.StateCode";
          public const string BusinessAddressZipCode = "Work.ZipCode";
          public const string HomeStreetAddress = "Home.StreetAddress";
          public const string HomeAddressCountry = "Home.CountryCode";
          public const string HomeAddressCity = "Home.City";
          public const string HomeAddressState = "Home.State";
          public const string HomeAddressStateCode = "Home.StateCode";
          public const string HomeAddressZipCode = "Home.ZipCode";
          public const string CompanyName="CompanyName";
          public const string Fax="Fax";
          public const string FirstName="FirstName";
          public const string JobTitle="JobTitle";
          public const string LastName="LastName";
          public const string MiddleName="MiddleName";
          public const string PrefixName="PrefixName";
          public const string EmailAddress = "EmailAddress"; 
          
      }

      public class MandatoryFields
      {
          public const string Campaign = "Campaign";
          public const string CampaignNotFound = "Please select Campaign.";
          public const string Recipient = "Recipient field";
          public const string RecipientNotFound = "Please select recipient field.";
          public const string MessageNotFound = "Please enter Message.";
          public const string Message = "Please enter Message.";
          public const string SelectCampaign = "Select Campaign";
          public const string Success = "SMS sent successfully";
          public const string Alert="Do you want to send SMS ?";
          public const string SendCampaign = "Send SMS";
          public const string Next = "Next";
          public const string BusinessAddress = "BUSINESS";
          public const string BusinessPersonal = "PERSONAL";
          public const string Failure = "Campaign sending failed";
          public const string MSGNOTSEND = "SMS sending failed. Please enter a valid phone number.";
            public const string RecNotFound = "Select recipient field";
      }

    }
}
