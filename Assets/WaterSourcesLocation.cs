namespace Mapbox.Examples
{
    using Mapbox.Unity.Location;
    using UnityEngine;

    public class WaterSourcesLocation : MonoBehaviour
    {
        [SerializeField] private Vector2[] LatLon;
        [SerializeField] private GameObject[] POIs;

        bool _isInitialized;
        private float Zcorrection = 4.98445f;
        private float Xcorrection = 6.289173f;
        private Vector2 origin = new Vector2(-7.89f, 16.37f);

        private AbstractLocationProvider _locationProvider = null;


        void LateUpdate()
        {
            Unity.Map.AbstractMap map = LocationProviderFactory.Instance.mapManager;

            for (int i = 0; i < LatLon.Length; i++)
            {
                Utils.Vector2d currentPos = new Utils.Vector2d(LatLon[i].x, LatLon[i].y);
                Vector3 coord = new Vector3(map.GeoToWorldPositionXZ(currentPos).x - Xcorrection, -15.8f, map.GeoToWorldPositionXZ(currentPos).z + Zcorrection);
                POIs[i].transform.localPosition = coord;
            }
        }

    }
}

