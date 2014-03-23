Tinamous Api Console Example
----------------------------

Visual Studio (2012) Console host application showing how to use the basics of the Tinamous Api.

Includes posting measurements, status posts, and raising alerts as well as getting data back from Tinamous.

Uses HTTP BASIC authentication.

You will need to create a appSettings.config file with credentials in it, this should be set as copy always in Visual Studio.


Example appSettings.config file
------------------------------------

<appSettings>
  <add key="Tinamous.AccountName" value="[Account Name].Tinamous.com"/>
  <add key="Tinamous.UseHttps" value="true" />
  <add key="Tinamous.UserName" value="[Device Username]"/>
  <add key="Tinamous.Password" value="[Device Password]"/>
</appSettings>

------------------------------------

You can signup for a free Tinamous account at https://Tinamous.com

When signed up the account name will the subdomain to access Tinamous, you should use this as the url.

You will need to create a Device in order to access Tinamous using HTTP BASIC or ApiKey authentication, this can be done once you log into Tinamous from the main timeline page.