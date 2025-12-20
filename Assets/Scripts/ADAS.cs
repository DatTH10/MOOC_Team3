using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class ADAS : MonoBehaviour
{
    [SerializeField] private GhostCarMove m_GhostCar1 = null;
    [SerializeField] private GhostCarMove m_GhostCar2 = null;
    [SerializeField] private GhostCarMove m_GhostCar3 = null;

    private List<Vector3> ghostCar01Positions = new();
    private List<Vector3> ghostCar02Positions = new();
    private List<Vector3> ghostCar03Positions = new();

    private void Awake()
    {
        LoadGhostCarData();
    }

    private void Start()
    {
        m_GhostCar1.points = ghostCar01Positions;
        m_GhostCar2.points = ghostCar02Positions;
        m_GhostCar3.points = ghostCar03Positions;
    }
    void LoadGhostCarData()
    {
        string path = Path.Combine(Application.dataPath, "Data/positionCar.json");

        if (!File.Exists(path))
        {
            Debug.LogError("Don't find file ghostcars.json");
            return;
        }

        string json = File.ReadAllText(path);
        GhostCarCollection collection =
            JsonUtility.FromJson<GhostCarCollection>(json);

        foreach (GhostCarData ghost in collection.GhostCars)
        {
            List<Vector3> targetList = GetListByName(ghost.GhostCarName);
            if (targetList == null) continue;

            foreach (PositionData pos in ghost.Positions)
            {
                targetList.Add(new Vector3(pos.x, pos.y, pos.z));
            }
        }

        Debug.Log("Load ghost car data success");
    }

    List<Vector3> GetListByName(string ghostName)
    {
        return ghostName switch
        {
            "GhostCar_01" => ghostCar01Positions,
            "GhostCar_02" => ghostCar02Positions,
            "GhostCar_03" => ghostCar03Positions,
            _ => null
        };
    }
}
