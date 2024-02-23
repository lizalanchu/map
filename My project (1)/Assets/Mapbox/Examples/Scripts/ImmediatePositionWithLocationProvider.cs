namespace Mapbox.Examples
{
    using Mapbox.Unity.Location;
    using Mapbox.Unity.Map;
    using UnityEngine;

    public class ImmediatePositionWithLocationProvider : MonoBehaviour
    {

        bool _isInitialized;

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

        Vector3 _targetPosition;

        void Start()
        {
            LocationProviderFactory.Instance.mapManager.OnInitialized += () => _isInitialized = true;
        }

        void LateUpdate()
        {
            if (_isInitialized)
            {
                var map = LocationProviderFactory.Instance.mapManager;
                var location = LocationProvider.CurrentLocation.LatitudeLongitude;
                var worldPosition = map.GeoToWorldPosition(location);
                // Игнорируем высоту, оставляем y равным нулю
                transform.position = new Vector3(worldPosition.x, 30, worldPosition.z);
            }
        }
    }
}
