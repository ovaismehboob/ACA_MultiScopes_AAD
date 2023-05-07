# Implementing Authorization for Container Apps using AAD Scopes

This repository contains code for a sample application to implement the following scenario:

- The frond-end application named as **WebUI** that authenticate user from Azure Active Directory using OAuth 2.0 Authorization Code Grant flow. 
- Two backend services namely **WebAPI1** and **WebAPI2** that authorize request for scopes part of the Access token passed by WebUI. 

## Architecture 

Here is the overall architecture of the solution. The applications are deployed on Azure Container Apps and using Azure Active Directory for authentication and authorization using OAuth 2.0 Authorization Code Grant flow. 

![](images/Architecture.png)

## Configure Project

Run the following steps to configure this on to your AAD tenant: 

- Register one application as **WebUI** in Azure AD
- Register one application as **WebAPI** in Azure AD and define two scopes as **API1** and **API2**
- Update **Client Id**, **Client Secret** and **Tenant Id** in the **appsettings.json** of **WebUI** project. Also update the **BaseUrl** and **Scopes** for API1 and API2. 
- Update **Client Id**, **Tenant Id**, **Audience** as the Scope set for WebAPI in AAD for both **WebAPI1** and **WebAPI2** projects.
- Update scopes as **API1** for **WebAPI1** project and **API2** for **WebAPI2** project. 

Hope this helps!