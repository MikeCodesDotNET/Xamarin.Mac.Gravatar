Xamarin.Mac.Gravatar
====================

A Xamarin.Mac library for fetching Gravatar images

## Getting Started

```cs
var fetcher = new GravatarFetcher();
var imageAvatar = new NSImageView(bigFrame);

imageAvatar.Image = await fetcher.GetGravatar(tbxEmailAddress.StringValue);
```

Sample project contains an example of how best to use this library.