#Constant Contact with Nexmo SMS

 <img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image1.png" width=200>

##Introduction 

**Constant Contact with Nexmo SMS** app allows users to send SMS to all the subscribers available in the Constant Contact email campaign contact list. It helps users to send SMS not only to campaigns in draft status but also to campaigns in sent and scheduled status.

##Use Case

Send SMS to all the contacts available in the Constant Contact campaign having draft, sent and scheduled status.

##Prerequisites

-   Nexmo subscription and corresponding Nexmo API keys (Key and Secret). To access the API keys, see appendix (Nexmo API Keys)

-   Constant Contact subscription and corresponding Constant Contact API key. To access the API key, see appendix (Constant Contact API Keys)

-   In Constant Contact list, *Phone number* should be in the international format.

##Features

-   Send SMS to all the subscribers available in the Constant Contact email campaigns.

-   Customize SMS message with a replaceable parameter of Constant Contact list.

-   Enable and disable SMS functionality for sent, draft, scheduled campaigns.

##Steps to install Constant Contact with Nexmo SMS app

1.  Visit the target Git repository using the [URL](https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Package/Constant%20Contact%20with%20Nexmo%20SMS.exe)

2.  Click on **Raw** as shown in the below image; app’s exe file will get downloaded: 
	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image3.png" width=400>

3.  Install **Constant Contact with Nexmo SMS**.exe on your local device.

4.  **Constant Contact with Nexmo SMS** Wizard opens up. In this window, click on the **Next** button

    <img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image4.png" width=400>

5.  Change the destination folder for installation and click **Next.**

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image5.png" width=400>

6.  See the current settings and click **Install.**

    <img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image6.png" width=400>

7.  Click on **Finish**. The shortcut for **Constant Contact with Nexmo SMS** app will be created on your desktop.

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image7.png" width=400>

##Steps to use Constant Contact with Nexmo SMS app 

1.  Double click on the app icon on your desktop or go to the **Start** menu, type **Constant Contact with Nexmo SMS.exe** and select **Constant Contact with Nexmo SMS**.

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image8.png" width=400>

2.  The settings form will open up. Provide details for **Nexmo Key**, **Nexmo Secret, Constant Contact API Key,** and **Constant Contact Access Token. S**ee appendix (Constant Contact API Keys)

3.  Click on **Save**.

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image9.png" width=400>

4.  These settings will be saved for later use, which can be updated from the menu later on.

5.  Select campaign from the campaign list.

6.  By default, the campaigns with draft status are listed. If required, click the **Sent** and **Schedule** campaigns under **Filter Campaign**.

    <img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image10.png" width=400>

7.  After clicking on **Next** Button, the app will display another **Send SMS** detailed form.

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image11.png" width=400>

8.  The form has the following fields:

	-   **Select recipient field**: Displays all **Phone** type field like Home Phone, Work Phone, Mobile, Cell Phone Number. User needs to specify one phone field on which he wants to send the SMS.

	-   **Message**: User can type a customized message with replaceable parameters. For example - if the user wants to send a message Hello &lt;&lt;name&gt;&gt;, then the user can type “Hello” and select **CompanyName** from the Select tag list box. It will replace **CompanyName** with the company name of the contact from the **Constant Contact** list.

	-   **Select tag**: This list box displays all fields available in **Constant Contact** list.

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image12.png" width=400>

9.  After clicking on **Send SMS** button, it will ask for confirmation – **Yes** or **No**

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image13.png" width=400>

10. After confirmation, the campaign will start sending SMS to all the contacts listed in that campaign.

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image14.png" width=400>

11. If there is some issue in sending the SMS, the following message will be shown by the app:

    <img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image15.png" width=400>

##Appendix

Nexmo API Keys
--------------

-   To access the Nexmo keys, go to <https://www.nexmo.com/> and sign-in.

-   On the top right corner, click on the **Api Settings**.

-   Key and Secret will display in the top bar as shown in the below image:

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image16.png" width=400>

Constant Contact API Keys and Access Token keys
-----------------------------------------------

-   [**Log in**](https://constantcontact.mashery.com/login) for a Mashery account or [**Sign up**](https://constantcontact.mashery.com/member/register)** .**

-   For new users, a confirmation email is sent to the registered email ID. An API key will be assigned to your application.

-   After the constant contact application is registered, access token can be received from [here](https://constantcontact.mashery.com/io-docs).

	<img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image17.png" width=400>

-   Enter the API key received and for the access token, click on **Get Access Token** button.

-   When you click **Get Access Token**, you are taken to a Constant Contact account sign up page.

-   Create a new account, or if you have an existing **Constant Contact** account (NOT your Mashery developer account), sign in.

    <img src= "https://raw.githubusercontent.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/master/Docs/image18.png" width=400>

-   Click **Allow** to generate an access token. Copy it and keep it handy.