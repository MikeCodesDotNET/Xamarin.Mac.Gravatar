
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.CoreAnimation;
using System.Drawing;
using MonoMac.CoreGraphics;
using GravatarLib;

namespace Sample
{
    public partial class MainWindowController : MonoMac.AppKit.NSWindowController
    {
        #region Constructors

        // Called when created from unmanaged code
        public MainWindowController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
		
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
		
        // Call to load from the XIB/NIB file
        public MainWindowController() : base("MainWindow")
        {
            Initialize();
        }
		
        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed window accessor
        public new MainWindow Window
        {
            get
            {
                return (MainWindow)base.Window;
            }
        }

        GravatarFetcher fetcher = new GravatarFetcher();
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            imageAvatar.Image = NSImage.ImageNamed("769-male-selected@2x.png");

            tbxEmailAddress.EditingEnded += async delegate
            {
                imageAvatar.Image = await fetcher.GetGravatar(tbxEmailAddress.StringValue);
            };

            btnSignIn.Activated += SignIn;

        }

        void SignIn (object sender, EventArgs e)
        {
            var PasswordIsValid = false;
            if (PasswordIsValid == true)
            {
                //Sign In
            }
            else
            {
                Window.Animations = NSDictionary.FromObjectAndKey(ShakeAnimation(this.Window.Frame), new NSString(@"frameOrigin"));
                ((NSWindow)this.Window.Animator).SetFrameOrigin(Window.Frame.Location);
            }
        }

        CAKeyFrameAnimation ShakeAnimation(RectangleF frame)
        {
            var numberOfShakes = 3;
            var durationOfShakes = 0.5f;
            var vigourOfShake = 0.02f;
            CAKeyFrameAnimation shakeAnimation = new CAKeyFrameAnimation();

            var shakePath = new CGPath();
            shakePath.MoveToPoint(frame.GetMinX(), frame.GetMinY());
            int index;
            for (index = 0; index < numberOfShakes; index++)
            {
                shakePath.CGPathAddLineToPoint(frame.GetMinX() - frame.Size.Width * vigourOfShake, frame.GetMinY());
                shakePath.CGPathAddLineToPoint(frame.GetMinX() + frame.Size.Width * vigourOfShake, frame.GetMinY());
            }
            shakePath.CloseSubpath();
            shakeAnimation.Path = shakePath;
            shakeAnimation.Duration = durationOfShakes;
            return shakeAnimation;
        }
    }
}

