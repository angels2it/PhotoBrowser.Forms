using FFImageLoading;
using FFImageLoading.Svg.Platform;
using Ricardo.LibMWPhotoBrowser.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Stormlion.PhotoBrowser.iOS
{
    public class MyMWPhotoBrower : MWPhotoBrowserDelegate
    {
        protected PhotoBrowser _photoBrowser;

        protected List<MWPhoto> _photos = new List<MWPhoto>();

        public MyMWPhotoBrower(PhotoBrowser photoBrowser)
        {
            _photoBrowser = photoBrowser;
        }

        public async void Show()
        {
            _photos = new List<MWPhoto>();

            foreach (Photo p in _photoBrowser.Photos)
            {
                MWPhoto mp;
                if (p.URL.EndsWith(".svg", StringComparison.InvariantCulture))
                {
                    mp = MWPhoto.FromImage(
                       await ImageService.Instance
                           .LoadFileFromApplicationBundle(p.URL)
                           .WithCustomDataResolver(new SvgDataResolver(0, 0, true))
                           .WithCustomLoadingPlaceholderDataResolver(new SvgDataResolver(0, 0, true))
                           .AsUIImageAsync());
                }
                else
                {
                    mp = MWPhoto.FromUrl(new Foundation.NSUrl(p.URL));
                }

                if (!string.IsNullOrWhiteSpace(p.Title))
                {
                    mp.Caption = p.Title;
                }

                _photos.Add(mp);
            }

            MWPhotoBrowser browser = new MWPhotoBrowser(this);

            browser.DisplayActionButton = _photoBrowser.ActionButtonPressed != null;
            browser.SetCurrentPhoto((nuint)_photoBrowser.StartIndex);
            browser.EnableGrid = _photoBrowser.EnableGrid;

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(new UINavigationController(browser), true, null);
        }

        public override MWPhoto GetPhoto(MWPhotoBrowser photoBrowser, nuint index) => _photos[(int)index];

        public override nuint NumberOfPhotosInPhotoBrowser(MWPhotoBrowser photoBrowser) => (nuint)_photos.Count;

        public override void OnActionButtonPressed(MWPhotoBrowser photoBrowser, nuint index)
        {
            _photoBrowser.ActionButtonPressed?.Invoke((int)index);
        }

        public void Close()
        {
            UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);
        }
    }
}
