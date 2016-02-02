using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Threading;
using CTCT;
using CTCT.Components;
using CTCT.Components.EmailCampaigns;
using CTCT.Services;
using CTCT.Components.Contacts;
using CTCT.Components.Tracking;
using System.Web;



namespace ConstantContact
{
    public partial class ConstantContactCampaign : Form
    {
        SmsSender SmsSender = new SmsSender();
        
        static string  NexmoAPI = string.Empty, NexmoSecretKey = string.Empty, NexmoFromNumber = string.Empty, ConstantContactAPI = string.Empty, ConstantContactToken = string.Empty;
        private static string ApiKey = ConstantContactAPI;
        private static string AccessToken = ConstantContactToken;
        
       
        public ConstantContactCampaign()
        {
            InitializeComponent();
            try
            {

                ReadSettings();
                LoadCampaign();
                this.MaximizeBox = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// Read settings.xml file. If settings.xml is blank open Settings form.
        /// </summary>
        public void ReadSettings()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("settings.xml");

                XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("/settings/nexmo");
                foreach (XmlNode node in nodeList)
                {
                    NexmoAPI = node.SelectSingleNode("api") != null ? node.SelectSingleNode("api").InnerText : "";
                    NexmoSecretKey = node.SelectSingleNode("secret-key") != null ? node.SelectSingleNode("secret-key").InnerText : "";
                    NexmoFromNumber = node.SelectSingleNode("from-number") != null ? node.SelectSingleNode("from-number").InnerText : "";
                }

                XmlNodeList mailchimpList = xmlDoc.DocumentElement.SelectNodes("/settings/constantcontact");
                foreach (XmlNode node in mailchimpList)
                {
                    ConstantContactAPI = node.SelectSingleNode("api") != null ? node.SelectSingleNode("api").InnerText : "";
                    ConstantContactToken = node.SelectSingleNode("access-token") != null ? node.SelectSingleNode("access-token").InnerText : "";
                   
                }

                if (string.IsNullOrEmpty(NexmoAPI)
                      || string.IsNullOrEmpty(NexmoSecretKey)
                      || string.IsNullOrEmpty(NexmoFromNumber)
                      || string.IsNullOrEmpty(ConstantContactAPI)
                      || string.IsNullOrEmpty(ConstantContactToken))
                {
                    OpenSettingsFrom();
                }
                else
                {
                    // Manager = new MailChimpManager(MailchimpAPI);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OpenSettingsFrom();
            }

        }
        /// <summary>
        /// Open Settings form
        /// </summary>
        public void OpenSettingsFrom()
        {
            this.Hide();
            Settings settings = new Settings();
            settings.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Bind Campaign in dropdown
        /// </summary>
        public void LoadCampaign()
        {
            try
            {
                ApiKey = ConstantContactAPI;
                AccessToken = ConstantContactToken;
                IUserServiceContext userServiceContext = new UserServiceContext(AccessToken, ApiKey);
                var cc = new ConstantContactFactory(userServiceContext);
                var emailCampignService = cc.CreateEmailCampaignService();
                ResultSet<EmailCampaign> listsAll = emailCampignService.GetCampaigns(null, null, null);
                ResultSet<EmailCampaign> filteredList = new ResultSet<EmailCampaign>() ;
                List<ConstantContactList> mailChimpList = new List<ConstantContactList>();

                if (listsAll != null && listsAll.Results.Count > 0)
                {
                    
                    filteredList.Results = listsAll.Results.Where(p => p.Status.Equals(CampaignStatus.DRAFT)).ToList();

                    if (!chkDraft.Checked)
                    {
                        var newList = filteredList.Results.ToList();
                        newList.RemoveAll(p => p.Status == CampaignStatus.DRAFT);
                        filteredList.Results = newList;
                    }
                    else
                    {
                        filteredList.Results = listsAll.Results.Where(p => p.Status == CampaignStatus.DRAFT).ToList();
                    }

                    if (!chkSchedule.Checked)
                    {
                        filteredList.Results.ToList().RemoveAll(p => p.Status == CampaignStatus.SCHEDULED);
                    }
                    else
                    {
                        var newList = filteredList.Results.ToList();
                        newList.RemoveAll(p => p.Status == CampaignStatus.SCHEDULED);
                        filteredList.Results = newList;
                        filteredList.Results = filteredList.Results.Concat(listsAll.Results.Where(p => p.Status == CampaignStatus.SCHEDULED)).ToList();
                        
                    }

                    if (!chkSent.Checked)
                    {
                        var newList = filteredList.Results.ToList();
                        newList.RemoveAll(p => p.Status == CampaignStatus.SENT);
                        filteredList.Results = newList;
                    }
                    else
                    {
                        if (filteredList.Results != null)
                        {
                            var newList = filteredList.Results.ToList();
                            newList.RemoveAll(p => p.Status == CampaignStatus.SENT);
                            filteredList.Results = newList;
                            filteredList.Results = filteredList.Results.Concat(listsAll.Results.Where(p => p.Status == CampaignStatus.SENT)).ToList();
                            
                        }
                    }
                    
                    cmbCampaign.DataSource = null;
                    cmbCampaign.Items.Clear();
                    mailChimpList.Add(new ConstantContactList("0", CommonConstants.MandatoryFields.SelectCampaign));
                    foreach (var list in filteredList.Results.OrderBy(p=>p.Name))
                    {
                        mailChimpList.Add(new ConstantContactList(list.Id.ToString(), list.Name+" "+'(' + list.Status + ')'));
                    }

                    cmbCampaign.DisplayMember = "Name";
                    cmbCampaign.ValueMember = "Id";
                    cmbCampaign.DataSource = mailChimpList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// Display campaign panel if user enable nexmo sms and hide Campaign panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextCampaign_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (ValidateFields())
                {
                    string campaignId = cmbCampaign.SelectedValue.ToString();
                    
                        BindFields();
                        pnlNexmoMessage.Visible = true;
                        pnlCampaign.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        public void SendCampaign()
        {
            if (ValidateFields())
            {
                var confirmResult = MessageBox.Show(CommonConstants.MandatoryFields.Alert,
                                                CommonConstants.MandatoryFields.SendCampaign,
                                                MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    
                    string campaignId = cmbCampaign.SelectedValue.ToString();
                    // Loading panel
                    Cursor.Current = Cursors.WaitCursor;

                    try
                    {
                        ApiKey = ConstantContactAPI;
                        AccessToken = ConstantContactToken;
                        IUserServiceContext userServiceContext = new UserServiceContext(AccessToken, ApiKey);
                        var cc = new ConstantContactFactory(userServiceContext);
                        List<SentContactList> SentContactListObj = new List<SentContactList>();
                        Contact contact = new Contact();
                        List<Contact> contactList = new List<Contact>();
                        var emailCampignService = cc.CreateEmailCampaignService();
                        var result = emailCampignService.GetCampaign(campaignId);
                        int count = 0;
                        foreach (var item in result.Lists)
                                     {
                                         SentContactList contactObj = new SentContactList();
                                         contactObj.Id = item.Id;
                                         SentContactListObj.Add(contactObj);
                                     }
                                     foreach (var item in SentContactListObj)
                                     {
                                         try
                                         {
                                         var getContactDetails = cc.CreateListService();
                                         var contactDetails = getContactDetails.GetContactsFromList(item.Id,null);

                                         foreach (var j in contactDetails.Results)
                                         {
                                            
                                             string message = getMessageDetails(txtMessage.Text.Trim(), j);
                                             string phone = getPhoneDetails(cmbFieldPhone.Text.Trim(), j);

                                             if (!string.IsNullOrEmpty(phone))
                                             {
                                                // Send SMS
                                                 string smsResult = SmsSender.SendSMS(phone, NexmoFromNumber, NexmoAPI, NexmoSecretKey, HttpUtility.UrlEncode(message));
                                                 count++;
                                             }
                                         }
                                         }
                                         catch (Exception ex)
                                         {
                                            // Logger.Write(ex);
                                             continue;
                                         }
                                     }
                                    if(count>0)
                                    {
                                             MessageBox.Show(CommonConstants.MandatoryFields.Success);
                                    }
                                    else
                                    {
                                            MessageBox.Show(CommonConstants.MandatoryFields.MSGNOTSEND);
                                    }
                           
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }
        /// <summary>
        ///Get phone details
        /// </summary>
        /// <returns></returns>
        private string getPhoneDetails(string p, Contact item)
        {
            string phone = string.Empty;
            try
            {
            if (cmbFieldPhone.SelectedIndex > 0 && cmbFieldPhone.SelectedItem != null)
            {
                if (cmbFieldPhone.Text.Trim() == CommonConstants.ConstantContactConstants.CellPhone)
                {
                    if (item.CellPhone != null || !string.IsNullOrWhiteSpace(item.CellPhone))
                    {
                        phone = item.CellPhone;
                    }
                }
                if (cmbFieldPhone.Text.Trim() == CommonConstants.ConstantContactConstants.HomePhone)
                {
                    if (item.HomePhone != null || !string.IsNullOrWhiteSpace(item.HomePhone))
                    {
                        phone = item.HomePhone;
                    }
                }
                if (cmbFieldPhone.Text.Trim() == CommonConstants.ConstantContactConstants.WorkPhone)
                {
                    if (item.WorkPhone != null || !string.IsNullOrWhiteSpace(item.WorkPhone))
                    {
                        phone = item.WorkPhone;
                    }
                }

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CommonConstants.MandatoryFields.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return phone;
        }

        /// <summary>
        ///Get message details
        /// </summary>
        /// <returns></returns>
        private string getMessageDetails(string message, Contact item)
        {
            try
            {

                var workaddress = item.Addresses.Where(p => p.AddressType == CommonConstants.MandatoryFields.BusinessAddress).FirstOrDefault();
                var homeAddress = item.Addresses.Where(p => p.AddressType == CommonConstants.MandatoryFields.BusinessPersonal).FirstOrDefault();

                //For Business Address 
                if (message.IndexOf(CommonConstants.ConstantContactConstants.BusinessStreetAddress) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.BusinessStreetAddress + "|*", workaddress != null ? workaddress.Line1 + " " + workaddress.Line2 + " " + workaddress.Line3 : "");
                }

                if (message.IndexOf(CommonConstants.ConstantContactConstants.BusinessAddressCountry) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.BusinessAddressCountry + "|*", workaddress != null ? workaddress.CountryCode : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.BusinessAddressCity) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.BusinessAddressCity + "|*", workaddress != null ? workaddress.City : "");
                }

                if (message.IndexOf(CommonConstants.ConstantContactConstants.BusinessAddressState) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.BusinessAddressState + "|*", workaddress != null ? workaddress.StateName : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.BusinessAddressStateCode) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.BusinessAddressStateCode + "|*", workaddress != null ? workaddress.StateCode : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.BusinessAddressZipCode) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.BusinessAddressZipCode + "|*", workaddress != null ? workaddress.PostalCode + "" + workaddress.SubPostalCode : "");
                }

                //Personal 

                if (message.IndexOf(CommonConstants.ConstantContactConstants.HomeStreetAddress) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.HomeStreetAddress + "|*", homeAddress != null ? homeAddress.Line1 + " " + homeAddress.Line2 + " " + homeAddress.Line3 : "");
                }

                if (message.IndexOf(CommonConstants.ConstantContactConstants.HomeAddressCountry) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.HomeAddressCountry + "|*", homeAddress != null ? homeAddress.CountryCode : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.HomeAddressState) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.HomeAddressState + "|*", homeAddress != null ? homeAddress.StateName : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.HomeAddressZipCode) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.HomeAddressZipCode + "|*", homeAddress != null ? homeAddress.PostalCode + "" + homeAddress.SubPostalCode : "");
                }

                if (message.IndexOf(CommonConstants.ConstantContactConstants.HomeAddressStateCode) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.HomeAddressStateCode + "|*", homeAddress != null ? homeAddress.StateCode : "");
                }

                if (message.IndexOf(CommonConstants.ConstantContactConstants.HomeAddressCity) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.HomeAddressCity + "|*", homeAddress != null ? homeAddress.City : "");
                }

                // Other fields
                if (message.IndexOf(CommonConstants.ConstantContactConstants.CellPhone) != -1)
                {

                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.CellPhone + "|*", item.CellPhone != null ? item.CellPhone : "");
                }

                if (message.IndexOf(CommonConstants.ConstantContactConstants.CompanyName) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.CompanyName + "|*", item.CompanyName != null ? item.CompanyName : "");
                }

                if (message.IndexOf(CommonConstants.ConstantContactConstants.Fax) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.Fax + "|*", item.Fax != null ? item.Fax : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.FirstName) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.FirstName + "|*", item.FirstName != null ? item.FirstName : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.HomePhone) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.HomePhone + "|*", item.HomePhone != null ? item.HomePhone : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.JobTitle) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.JobTitle + "|*", item.JobTitle != null ? item.JobTitle : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.LastName) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.LastName + "|*", item.LastName != null ? item.LastName : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.MiddleName) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.MiddleName + "|*", item.MiddleName != null ? item.MiddleName : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.PrefixName) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.PrefixName + "|*", item.PrefixName != null ? item.PrefixName : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.WorkPhone) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.WorkPhone + "|*", item.WorkPhone != null ? item.WorkPhone : "");
                }
                if (message.IndexOf(CommonConstants.ConstantContactConstants.EmailAddress) != -1)
                {
                    message = message.Replace("*|" + CommonConstants.ConstantContactConstants.EmailAddress + "|*", item.EmailAddresses != null ? item.EmailAddresses.FirstOrDefault().EmailAddr : "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, CommonConstants.MandatoryFields.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return message;
        }
      
        
        /// <summary>
        /// Validate nexmo fields 
        /// </summary>
        /// <returns></returns>
        public bool ValidateFields()
        {
            if (cmbCampaign.SelectedIndex <= 0 || cmbCampaign.SelectedItem == null)
            {
                MessageBox.Show(CommonConstants.MandatoryFields.CampaignNotFound, CommonConstants.MandatoryFields.Campaign, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbCampaign.Focus();
                return false;
            }

            if (chkDraft.Checked && pnlNexmoMessage.Visible)
            {
                if (cmbFieldPhone.SelectedIndex <= 0 || cmbFieldPhone.SelectedItem == null)
                {
                    MessageBox.Show(CommonConstants.MandatoryFields.RecipientNotFound, CommonConstants.MandatoryFields.Recipient, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbFieldPhone.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
                {
                    MessageBox.Show(CommonConstants.MandatoryFields.MessageNotFound, CommonConstants.MandatoryFields.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMessage.Focus();
                    return false;
                }
            }
            return true;
        }

        private void chkDraft_CheckedChanged(object sender, EventArgs e)
        {
            LoadCampaign();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings settings = new Settings();
            settings.ShowDialog();
            this.Close();
        }



        /// <summary>
        /// Bind phone type field
        /// </summary>
        public void BindFields() 
        {
            
            List<ConstantContactList> ccPhoneField = new List<ConstantContactList>();
            ccPhoneField.Add(new ConstantContactList("0", CommonConstants.MandatoryFields.RecNotFound));
            ccPhoneField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.CellPhone, CommonConstants.ConstantContactConstants.CellPhone));
            ccPhoneField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.HomePhone, CommonConstants.ConstantContactConstants.HomePhone));
            ccPhoneField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.WorkPhone, CommonConstants.ConstantContactConstants.WorkPhone));

            List<ConstantContactList> ccField = new List<ConstantContactList>();
            //BUSINESS
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.BusinessStreetAddress, CommonConstants.ConstantContactConstants.BusinessStreetAddress));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.BusinessAddressCountry, CommonConstants.ConstantContactConstants.BusinessAddressCountry));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.BusinessAddressCity, CommonConstants.ConstantContactConstants.BusinessAddressCity));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.BusinessAddressState, CommonConstants.ConstantContactConstants.BusinessAddressState));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.BusinessAddressStateCode, CommonConstants.ConstantContactConstants.BusinessAddressStateCode));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.BusinessAddressZipCode, CommonConstants.ConstantContactConstants.BusinessAddressZipCode));
            //PERSONAL
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.HomeStreetAddress, CommonConstants.ConstantContactConstants.HomeStreetAddress));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.HomeAddressCountry, CommonConstants.ConstantContactConstants.HomeAddressCountry));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.HomeAddressCity,CommonConstants.ConstantContactConstants.HomeAddressCity));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.HomeAddressState, CommonConstants.ConstantContactConstants.HomeAddressState));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.HomeAddressStateCode, CommonConstants.ConstantContactConstants.HomeAddressStateCode));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.HomeAddressZipCode, CommonConstants.ConstantContactConstants.HomeAddressZipCode));
            

            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.CompanyName, CommonConstants.ConstantContactConstants.CompanyName));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.Fax, CommonConstants.ConstantContactConstants.Fax));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.FirstName, CommonConstants.ConstantContactConstants.FirstName));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.JobTitle, CommonConstants.ConstantContactConstants.JobTitle));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.LastName, CommonConstants.ConstantContactConstants.LastName));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.MiddleName, CommonConstants.ConstantContactConstants.MiddleName));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.PrefixName, CommonConstants.ConstantContactConstants.PrefixName));
            ccField.Add(new ConstantContactList(CommonConstants.ConstantContactConstants.EmailAddress, CommonConstants.ConstantContactConstants.EmailAddress));

            if (ccField != null && ccField.Count > 0)
            {

                lstboxFields.Items.Clear();
                lstboxFields.Items.AddRange(ccField.OrderBy(p=>p.Name).ToArray());
                lstboxFields.DisplayMember = "Name";

                cmbFieldPhone.DisplayMember = "Name";
                cmbFieldPhone.ValueMember = "Id";
                cmbFieldPhone.DataSource = ccPhoneField;
            }

        }

        private void lstboxFields_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var insertText = "*|" + lstboxFields.Text + "|*";
            var selectionIndex = txtMessage.SelectionStart;
            txtMessage.Text = txtMessage.Text.Insert(selectionIndex, insertText);
            txtMessage.SelectionStart = selectionIndex + insertText.Length;
        }

        private void btnSendCampain_Click(object sender, EventArgs e)
        {
            SendCampaign();
        }

        
        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlNexmoMessage.Visible = false;
            pnlCampaign.Visible = true;
        }


        private void ConstantContact_Shown(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool isOpen = false;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Settings")
                {
                    frm.Hide();
                }
            }
        }
        
        public string HTMLEncodeSpecialChars(string text)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in text)
            {
                if (c > 127) // special chars
                    sb.Append(String.Format("&#{0};", (int)c));
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
