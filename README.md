# PhotoBrowser.Forms

Full screen image viewer(Xamarin.Forms) that includes "pinch to zoom" and "swipe to dismiss" gestures.

[![NuGet](https://img.shields.io/nuget/v/PhotoBrowser.Forms.svg)](https://www.nuget.org/packages/PhotoBrowser.Forms/)

Supports Android and iOS.
* Android library from : https://github.com/angels2it/FrescoImageViewer
* iOS library from : https://github.com/mwaterfall/MWPhotoBrowser

## Features

* Pinch to zoom.
* Swipe to dismiss.
* Custom Title.
* Custom Action Button.

## Screen-Shots

<img src="ScreenShots/screenshot_android.gif" alt="PhotoBrowser for Android"/> <img src="ScreenShots/screenshot_ios.gif" alt="PhotoBrowser for iOS"/>

## Setup

* Install the [nuget package](https://www.nuget.org/packages/PhotoBrowser.Forms) in portable and all platform specific projects.

### Android

In MainActivity.cs file

```cs
    Stormlion.PhotoBrowser.Droid.Platform.Init(this);
```

### iOS

In AppDelegate.cs file

```cs
    Stormlion.PhotoBrowser.iOS.Platform.Init();
```
## Usage

```cs
    new PhotoBrowser
    {
        Photos = new List<Photo>
        {
            new Photo
            {
                URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Vincent.jpg",
                Title = "Vincent"
            },
            new Photo
            {
                URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Jules.jpg",
                Title = "Jules"
            },
            new Photo
            {
                URL = "https://raw.githubusercontent.com/stfalcon-studio/FrescoImageViewer/v.0.5.0/images/posters/Korben.jpg",
                Title = "Korben"
            },
			new Photo
            {
                URL = "https://upload.wikimedia.org/wikipedia/commons/f/f7/Bananas.svg",
                Title = "Banana"
            }
        },
        ActionButtonPressed = (index) =>
        {
            Debug.WriteLine($"Clicked {index}");
        }
    }.Show();
```

### More Properties
* ActionButtonPressed
* StartIndex

## Contributions
Contributions are welcome!
