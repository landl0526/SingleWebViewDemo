using Foundation;
using System;
using UIKit;

namespace SingleWebView
{
    public partial class ViewController : UIViewController, IUIWebViewDelegate
    {

        UIWebView MyWebView;


        public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
            // Perform any additional setup after loading the view, typically from a nib.

            MyWebView = new UIWebView();
            View.AddSubview(MyWebView);
            MyWebView.LoadRequest(new NSUrlRequest(new NSUrl("https://www.microsoft.com")));

            MyWebView.TranslatesAutoresizingMaskIntoConstraints = false;

            var leadConstraint = NSLayoutConstraint.Create(MyWebView, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, View, NSLayoutAttribute.Leading, 1.0f, 0);
            var topConstraint = NSLayoutConstraint.Create(MyWebView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, TopLayoutGuide, NSLayoutAttribute.Bottom, 1.0f, 0);
            var trailingConstraint = NSLayoutConstraint.Create(MyWebView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, View, NSLayoutAttribute.Trailing, 1.0f, 0);
            var bottomConstraint = NSLayoutConstraint.Create(MyWebView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, BottomLayoutGuide, NSLayoutAttribute.Top, 1.0f, 0);

            View.AddConstraints(new NSLayoutConstraint[] { leadConstraint, topConstraint, trailingConstraint, bottomConstraint });


            View.BackgroundColor = UIColor.Purple;

            MyWebView.Delegate = this;
        }

        [Export("webView:shouldStartLoadWithRequest:navigationType:")]
        public bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
        {
            return true;
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
    }

}