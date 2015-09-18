using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using emergencyApp.Resources;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using System.IO;
using System.Collections.ObjectModel;
using System.Text;
using System.Runtime.Serialization.Json;




namespace emergencyApp
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            startGeoNamesAPICall();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

       
        
        private void startGeoNamesAPICall()
        {
            try
            {
                HttpWebRequest httpReq = (HttpWebRequest)HttpWebRequest.Create(new Uri("http://demo.places.nlp.nokia.com/places/v1/discover/search?at=22.3435%2C88.1933&q=hospital&pretty=&app_code=GlM8fu62wKr7eGd91GEsRg&app_id=nZBm6nSjffZMMzo7wYxx"));
                httpReq.BeginGetResponse(HTTPWebRequestCallBack, httpReq);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void HTTPWebRequestCallBack(IAsyncResult result)
        {
            string strResponse = "";

            try
            {
                Dispatcher.BeginInvoke(() =>
                {
                    try
                    {
                        HttpWebRequest httpRequest = (HttpWebRequest)result.AsyncState;
                        WebResponse response = httpRequest.EndGetResponse(result);
                        Stream stream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(stream);
                        strResponse = reader.ReadToEnd();

                        parseResponseData(strResponse);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void parseResponseData(String aResponse)
        {
            results placesListObj = new results();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(aResponse));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(placesListObj.GetType());
            placesListObj = ser.ReadObject(ms) as results;
            ms.Close();

            if (placesListObj != null)
            {
                parseContent(placesListObj);             
            }
        
        }

        private void parseContent(results placesListObj)
        {
            MessageBox.Show(placesListObj.response.PlaceList.ElementAt(0).Distance);
        }
         
        GeoCoordinateWatcher watcher;

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "4d859d2c-fd11-4df0-86d7-63487e1102d6";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "xJcZzAZVErj5ihcRAKBfsw";
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                        
              /*
            if (watcher == null)
            {
                watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                watcher.MovementThreshold = 20;
                watcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
                watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                watcher.Start();
            }*/
        }
        /*
        void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // The Location Service is disabled or unsupported.
                    // Check to see whether the user has disabled the Location Service.
                    if (watcher.Permission == GeoPositionPermission.Denied)
                    {
                        // The user has disabled the Location Service on their device.
                        statusTextBlock.Text = "you have this application access to location.";
                    }
                    else
                    {
                        statusTextBlock.Text = "location is not functioning on this device";
                    }
                    break;

                case GeoPositionStatus.Initializing:
                    // The Location Service is initializing.
                    // Disable the Start Location button.
                    button1.IsEnabled = false;
                    break;

                case GeoPositionStatus.NoData:
                    // The Location Service is working, but it cannot get location data.
                    // Alert the user and enable the Stop Location button.
                    statusTextBlock.Text = "location data is not available.";
                    button1.IsEnabled = true;
                    break;

                case GeoPositionStatus.Ready:
                    // The Location Service is working and is receiving location data.
                    // Show the current position and enable the Stop Location button.
                    statusTextBlock.Text = "location data is available.";
                    button1.IsEnabled = true;
                    break;
            }
        }
        */
        /*
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            latitudeTextBlock.Text = e.Position.Location.Latitude.ToString("0.000");
            longitudeTextBlock.Text = e.Position.Location.Longitude.ToString("0.000");
        }
        */
    }
}