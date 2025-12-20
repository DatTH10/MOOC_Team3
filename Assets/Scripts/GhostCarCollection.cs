using System.Collections.Generic;

[System.Serializable]
public class GhostCarCollection
{
    public List<GhostCarData> GhostCars;
}

[System.Serializable]
public class GhostCarData
{
    public string GhostCarName;
    public List<PositionData> Positions;
}

[System.Serializable]
public class PositionData
{
    public float x;
    public float y;
    public float z;
}