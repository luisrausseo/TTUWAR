using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using UnityEngine;

public class positionCalc : MonoBehaviour {

    [SerializeField] private float lat1;
    [SerializeField] private float lon1;

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

    void Start () {
            AbstractMap map = LocationProviderFactory.Instance.mapManager;
            Mapbox.Utils.Vector2d currentPos = new Mapbox.Utils.Vector2d(lat1, lon1);
            Vector3 coord = new Vector3(map.GeoToWorldPosition(currentPos).x, -15.8f, map.GeoToWorldPosition(currentPos).z);
            transform.localPosition = coord;
    }
}
