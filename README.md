# Constant Contact with Nexmo SMS

<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.png" width=200>

##Introduction 

**Constant Contact with Nexmo SMS** allows users to send SMS to all the subscribers available in the Constant Contact email campaign contact list. It helps users to send SMS not only to campaigns in draft status but also to campaigns in sent and scheduled status.

##Use Case

Send SMS to all the contacts available in the Constant Contact campaign having draft, sent and scheduled status.

##Prerequisites

-   Nexmo subscription and corresponding Nexmo API keys (Key and Secret). To access the API keys, see appendix (Nexmo API Keys)

-   Constant Contact subscription and corresponding Constant Contact API key. To access the API key, see appendix (Constant Contact API Keys)

-   In Constant Contact list, *Phone number* should be in the international format.

##Features

-   Send SMS to all the subscribers available in the Constant Contact email campaigns.

-   Customize SMS message with a replaceable parameter of Constant Contact list.

-   Enable and disable sent, draft, scheduled campaigns.

##Steps to install Constant Contact with Nexmo SMS 

1.  Visit the target Git repository using the [URL ](https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Package/Constant%20Contact%20with%20Nexmo%20SMS.exe)

2.  Click on **Raw** as shown in the below image; app’s exe file will get downloaded:<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image3.png" width=600>

3.  Install **Constant Contact with Nexmo SMS**.exe on your local device.

4.  **Constant Contact with Nexmo SMS** Wizard opens up. In this window, click on the **Next** button

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image4.png" width=600>

5.  Change the destination folder for installation and click **Next.**

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image5.png" width=600>

6.  See the current settings and click **Install.**

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image6.png" width=600>

7.  Click on **Finish**. The shortcut for **Constant Contact with Nexmo SMS** app will be created on your desktop.

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image7.png" width=600>

##Steps to use Constant Contact with Nexmo SMS 

1.  Double click on the app icon on your desktop or go to the **Start** menu, type **Constant Contact with Nexmo SMS.exe** and select **Constant Contact with Nexmo SMS**.

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image8.png" width=600>

2.  The settings form will open up. Provide details for **Nexmo Key**, **Nexmo Secret, Constant Contact API Key,** and **Constant Contact Access Token.** Click on **Save**.

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image9.png" width=600>

3.  These settings will be saved for later use, which can be updated from the menu later on.

4.  Select campaign from the campaign list. By default, the campaigns with draft status are listed. User can also include sent and scheduled campaigns by checking on filter campaign checkboxes.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image10.png" width=600>

5.  After clicking on **Next** Button, the app will display another **Send SMS** detailed form.

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image11.png" width=600>

6.  The form has the following fields:

	-   **Select recipient Field**: Displays all **Phone** type field like Home Phone, Work Phone, Mobile, Cell Phone Number.

	-   **Message**: User can type a customized message with replaceable parameters. For example - if the user wants to send a message Hello &lt;&lt;name&gt;&gt;, then the user can type “Hello” and select **CompanyName** from the list box. It will replace **CompanyName** with the company name of the contact from the **Constant Contact** list.

	-   **Select tag**: This list box displays all fields available in **Constant Contact** list.

		<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image12.png" width=600>

7.  After clicking on **Send SMS** button, it will ask for confirmation – **Yes** or **No**

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image13.png" width=600>

8.  After confirmation, the campaign will start sending SMS to all the contacts listed in that campaign.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image14.png" width=600>

9.  If there is some issue in sending the SMS, the following message will be shown by the app:

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image15.png" width=600>

##Appendix

Nexmo API Keys
--------------

-   To access the Nexmo keys, go to <https://www.nexmo.com/> and sign-in.

-   On the top right corner, click on the **Api Settings**.

-   Key and Secret will display in the top bar as shown in the below image:

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image16.png" width=600>

Constant Contact API Keys and Access Token keys
-----------------------------------------------

-   [**Sign up**](https://constantcontact.mashery.com/member/register)** **for a Mashery account or [**log in**](https://constantcontact.mashery.com/login)**.**

-   Confirm your account, if it's new.

-   Check your inbox for a confirmation email from Mashery.

    A confirmation email is sent to the registered email ID. After clicking on the confirmation link, it will redirect to a page where you can generate your API key.

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image17.png" width=600>

-   Register an Application. An API Key will be assigned to your application.

-   Write the application name, check the **Terms of Service** checkbox and click on **Register Application**.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image18.png" width=600>

-   After the constant contact application is registered, access token can be received from [here](https://constantcontact.mashery.com/io-docs).

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image19.png" width=600>

-   Enter the API key received and for the access token, click on **Get Access Token** button.

-   When you click **Get Access Token**, you are taken to a Constant Contact account sign up page.

	<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image20.png" width=600>

-   Create a new account, or if you have an existing **Constant Contact** account (NOT your Mashery developer account), sign in.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image21.png" width=600>

-   Click **Allow** to generate an access token. Copy it and keep it handy.
