// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace Sample
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton btnSignIn { get; set; }

		[Outlet]
		MonoMac.AppKit.NSImageView imageAvatar { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField tbxEmailAddress { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSecureTextField tbxPassword { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageAvatar != null) {
				imageAvatar.Dispose ();
				imageAvatar = null;
			}

			if (tbxEmailAddress != null) {
				tbxEmailAddress.Dispose ();
				tbxEmailAddress = null;
			}

			if (tbxPassword != null) {
				tbxPassword.Dispose ();
				tbxPassword = null;
			}

			if (btnSignIn != null) {
				btnSignIn.Dispose ();
				btnSignIn = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
