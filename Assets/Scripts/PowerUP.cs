using UnityEngine;

public class PowerUP : MonoBehaviour
{
    // Start is called before the first frame update
   public enum PowerUpType
    {
        IncreaseHealth,
        reduceSpeed,
    }
     public PowerUpType powerUpType;
}
