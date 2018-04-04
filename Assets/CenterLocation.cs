namespace Mapbox.Examples
{
    using Mapbox.Unity.Location;
    using UnityEngine;
    using UnityEngine.UI;
    using Mapbox.Unity.Utilities;

    public class CenterLocation : MonoBehaviour
    {

        [SerializeField]
        Text _statusText;

        double lat, lon;
        float scale;
        Utils.Vector2d refPoint;
        Utils.Vector2d offSet;

        ILocationProvider _locationProvider;
        ILocationProvider LocationProvider
        {
            get
            {
                if (_locationProvider == null)
                {
                    _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
                }

                return _locationProvider;
            }
        }

        void Update()
        {
            var map = LocationProviderFactory.Instance.mapManager;
            Utils.Vector2d refPoint_XY = Conversions.LatLonToMeters(map.CenterMercator);
                      
            Utils.Vector2d coords = Conversions.GeoToWorldPosition(33.585076, -101.874668, map.CenterMercator, scale = 100F);
            _statusText.text = string.Format("{0}", map.CenterMercator);
        }
    }
}
