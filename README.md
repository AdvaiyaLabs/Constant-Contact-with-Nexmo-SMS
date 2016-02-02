# Constant Contact with Nexmo SMS

<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage1.png">

*“An app to send SMS to Constant Contact Campaign contact list”*

<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage2.png">

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

Steps to install Constant Contact with Nexmo SMS 
=================================================

1.  Visit the target Git repository using the [URL ]()

2.  Click on **Raw** as shown in the below image; app’s .zip file will get downloaded:<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage3.png">

3.  Extract ZIP file and install **Constant Contact with Nexmo SMS**.exe on your local device.

4.  **Constant Contact with Nexmo SMS** Wizard opens up. In this window, click on the **Next** button

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage4.png">

5.  Change the destination folder for installation and click **Next.**

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage5.png">

1.  See the current settings and click **Install.**

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage6.png">

2.  Click on **Finish**. The shortcut for **Constant Contact with Nexmo SMS** app will be created on your desktop.

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage7.png">

Steps to use Constant Contact with Nexmo SMS 
=============================================

1.  Double click on the app icon on your desktop or go to the **Start** menu, type **Constant Contact with Nexmo SMS.exe** and select **Constant Contact with Nexmo SMS**.

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage8.png">

1.  The settings form will open up. Provide details for **Nexmo Key**, **Nexmo Secret, Constant Contact API Key,** and **Constant Contact Access Token.** Click on **Save**.

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage9.png">

1.  These settings will be saved for later use, which can be updated from the menu later on.

2.  Select campaign from the campaign list. By default, the campaigns with draft status are listed. User can also include sent and scheduled campaigns by checking on filter campaign checkboxes.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage10.png">

3.  After clicking on **Next** Button, the app will display another **Send SMS** detailed form.

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage11.png">

1.  The form has the following fields:

-   **Select recipient Field**: Displays all **Phone** type field like Home Phone, Work Phone, Mobile, Cell Phone Number.

-   **Message**: User can type a customized message with replaceable parameters. For example - if the user wants to send a message Hello &lt;&lt;name&gt;&gt;, then the user can type “Hello” and select **CompanyName** from the list box. It will replace **CompanyName** with the company name of the contact from the **Constant Contact** list.

-   **Select tag**: This list box displays all fields available in **Constant Contact** list.

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage12.png">

1.  After clicking on **Send SMS** button, it will ask for confirmation – **Yes** or **No**

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage13.png">

1.  After confirmation, the campaign will start sending SMS to all the contacts listed in that campaign.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage14.png">

2.  If there is some issue in sending the SMS, the following message will be shown by the app:

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage15.png">

Appendix
========

Nexmo API Keys
--------------

-   To access the Nexmo keys, go to <https://www.nexmo.com/> and sign-in.

-   On the top right corner, click on the **Api Settings**.

-   Key and Secret will display in the top bar as shown in the below image:

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage16.png">

Constant Contact API Keys and Access Token keys
-----------------------------------------------

-   [**Sign up**](https://constantcontact.mashery.com/member/register)** **for a Mashery account or [**log in**](https://constantcontact.mashery.com/login)**.**

-   Confirm your account, if it's new.

-   Check your inbox for a confirmation email from Mashery.

    A confirmation email is sent to the registered email ID. After clicking on the confirmation link, it will redirect to a page where you can generate your API key.

<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage17.png">

-   Register an Application. An API Key will be assigned to your application.

-   Write the application name, check the **Terms of Service** checkbox and click on **Register Application**.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage18.png">

-   After the constant contact application is registered, access token can be received from [here](https://constantcontact.mashery.com/io-docs).

> <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage19.png">

-   Enter the API key received and for the access token, click on **Get Access Token** button.

-   When you click **Get Access Token**, you are taken to a Constant Contact account sign up page.

<img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage20.png">

-   Create a new account, or if you have an existing **Constant Contact** account (NOT your Mashery developer account), sign in.

    <img src="https://github.com/AdvaiyaLabs/Constant-Contact-with-Nexmo-SMS/blob/master/Docs/image1.pngimage21.png">

-   Click **Allow** to generate an access token. Copy it and keep it handy.
