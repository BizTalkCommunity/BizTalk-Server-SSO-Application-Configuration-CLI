# BizTalk Server SSO Application Configuration CLI
BizTalk Server leverages the Enterprise Single Sign-On (SSO) capabilities for securely storing critical information such as secure configuration properties (for example, the proxy user ID, and proxy password) for the BizTalk adapters. Therefore, BizTalk Server requires SSO to work properly. BizTalk Server automatically installs SSO on every computer where you install the BizTalk Server runtime.

But it also can keep your own application configuration data in SSO database, let say the usual configurations that we normally keep in a configuration file (“app.config”)). If you’ve been in the BizTalk world long enough, you’ve probably faced this challenge or need and until 2009 there wasn’t an easy way to archive that and Richard Seroter’s BizTalk SSO Configuration Data Storage Tool was the go tool to store and manage Single Sign-On (SSO) applications - this is still a valid tool and if you rebuild the code in the last version of BizTalk Server it still works perfectly. 

Unfortunately, there is no command line tool to allow you to script the deployment SSO Application Configurations or perform CI/CD thru DevOps .

This tool is designed to address this gap allowing you to:
* You can securely import Application configurations by using this CLI application;

THIS TOOL IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND.

# About Us
**Sandro Pereira** | [DevScope](http://www.devscope.net/) | MVP & MCTS BizTalk Server 2010 | [https://blog.sandro-pereira.com/](https://blog.sandro-pereira.com/) | [@sandro_asp](https://twitter.com/sandro_asp)

**Pedro Almeida** | [DevScope](http://www.devscope.net/) | BizTalk Server Senior Consultant

**Diogo Formosinho** | [DevScope](http://www.devscope.net/) | BizTalk Server Developer
