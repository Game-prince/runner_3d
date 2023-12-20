using UnityEngine;

[System.Serializable]
public class Powerup
{
  public string name;
  public int duration;
  public int maxPowerups;
  public GameObject prefab;

  public Powerup(string name, int duration, int maxPowerups, GameObject prefab)
  {
    this.name = name;
    this.duration = duration;
    this.maxPowerups = maxPowerups;
    this.prefab = prefab;
  }

  public void instantiate(Vector3 position)
  {
    GameObject powerup = GameObject.Instantiate(prefab, position, Quaternion.identity);
  }

  public void powerupEffect() { }

}