WebPortOpener
=============

(c) 2014 Michael Schierl


Introduction
------------

WebPortOpener is a small ASP.NET web app (designed for ASP.NET 4.5 on a 
Windows 2012 R2 server) that provides a prompt where a (local or domain)
user can enter his username and password and solve a Google reCAPTCHA.

If both password and captcha are correct, the remote IP address is
dynamically added to a Windows Firewall rule (whose name can be configured
in Web.config), so that this person can now connect to another service on
this machine (for example RDP or OpenVPN) without opening that other service
to unrestricted bruteforce login attempts.

An included PowerShell script can be run periodically to remove all IP
addresses from the firewall rule again.

As it is not possible to have a firewall rule that has an empty
RemoteAddresses list, we keep a dummy loopback address 127.0.0.127 in the
list all time.

Requirements
------------

WebPortOpener requires a Windows 2012 R2 server with IIS and ASP.NET 4.5
installed. Edit Web.config (change the rule name) and deploy to your IIS
to get started. Make sure the application pool's user has enough permissions
to be able to edit the firewall rule.

To compile the source code yourself, you will need "Microsoft Visual Studio
2013 Express for Web".


License
-------

WebPortOpener is Free Software licensed under GNU General Public License
2 or later.
