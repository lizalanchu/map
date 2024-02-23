using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class PlaceObjectOnMap : MonoBehaviour
{
    public AbstractMap map;
    public GameObject objectPrefab; // Префаб вашего объекта

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем экранные координаты нажатия на экран
            Vector3 mousePosition = Input.mousePosition;

            // Преобразуем экранные координаты в мировые координаты
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

            // Преобразуем мировые координаты в географические координаты
            Vector2d latLong = map.WorldToGeoPosition(worldPosition);

            // Устанавливаем объект на карту в полученных географических координатах
            InstantiateObjectAtCoordinates(latLong);
        }
    }

    // Метод для установки объекта на карту по географическим координатам
    void InstantiateObjectAtCoordinates(Vector2d latLong)
    {
        // Создаем новый объект на указанных координатах
        GameObject newObject = Instantiate(objectPrefab, new Vector3((float)latLong.x, 0, (float)latLong.y), Quaternion.identity);

        // Если объект создан успешно, вы можете добавить дополнительную логику здесь
    }
}

