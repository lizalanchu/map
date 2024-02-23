using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Utils;

public class MapLoader : MonoBehaviour
{
    public AbstractMap map; // Ссылка на компонент карты в Unity
    public Vector2d mapCenter = new Vector2d(40.6892, -74.0445); // Координаты центра карты (Нью-Йорк, например)
    public int zoom = 15; // Уровень масштабирования карты

    void Start()
    {
        // Загружаем карту при запуске сцены
        LoadMap();
    }

    void LoadMap()
    {
        // Устанавливаем координаты центра и уровень масштабирования
        map.Initialize(mapCenter, zoom);

        // Печатаем сообщение об успешной загрузке карты в консоль
        Debug.Log("Map loaded at coordinates: " + mapCenter.x + ", " + mapCenter.y);
    }
}
