using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//public class speedCalculator : MonoBehaviour
//{

//    [SerializeField]
//    Text _statusText;

//    float lonA, latA;

//    // Use this for initialization
//    void Start()
//    {
//        lonA = Input.location.lastData.longitude;
//        latA = Input.location.lastData.latitude;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector2d posA = Conversions.LatLonToMeters(latA, lonA);
//        Vector2d posB = Conversions.LatLonToMeters(Input.location.lastData.latitude, Input.location.lastData.longitude);
//        float dist = Mathf.Sqrt(Mathf.Pow((float)(posB.x - posA.x), 2) + Mathf.Pow((float)(posB.y - posA.y), 2))/1000;
//        float time = Time.deltaTime;
//        float speed = dist / time;
//        _statusText.text = string.Format("{0}  Km/s", speed);

//        lonA = Input.location.lastData.longitude;
//        latA = Input.location.lastData.latitude;
//    }
//}

namespace Mapbox.Examples
{
    using Mapbox.Unity.Location;
    using Mapbox.Utils;
    using UnityEngine;
    using UnityEngine.UI;
    using Mapbox.Unity.Utilities;

    public class speedCalculator : MonoBehaviour
    {

        [SerializeField]
        Text _statusText;

        Location previousLoc;

        private AbstractLocationProvider _locationProvider = null;
        void Start()
        {
            if (null == _locationProvider)
            {
                _locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
            }
            previousLoc = _locationProvider.CurrentLocation;

        }

        void Update()
        {
            StartCoroutine(CalcSpeed());
        }

        IEnumerator CalcSpeed()
        {
            yield return new WaitForSeconds(1);
            Location currLoc = _locationProvider.CurrentLocation;
            Vector2d posA = Conversions.LatLonToMeters(previousLoc.LatitudeLongitude.x, previousLoc.LatitudeLongitude.y);
            Vector2d posB = Conversions.LatLonToMeters(currLoc.LatitudeLongitude.x, currLoc.LatitudeLongitude.y);
            float dist = Mathf.Sqrt(Mathf.Pow((float)(posB.x - posA.x), 2) + Mathf.Pow((float)(posB.y - posA.y), 2)) / 1000;
            float time = Time.deltaTime;
            float speed = dist / time;
            _statusText.text = string.Format("{0}  Km/s", speed);
            previousLoc = _locationProvider.CurrentLocation;
        }
    }
}

