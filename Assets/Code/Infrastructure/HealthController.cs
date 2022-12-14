using UnityEngine;
using Zenject;

public class HealthController : MonoBehaviour
{
    // Fields --------------------------------------------
    public float healPointsMax = 5f;
    public float healPointsMin = 0f;
    float healPointsCur;
    // ---------------------------------------------------



    // Properties ----------------------------------------

    // ---------------------------------------------------



    // Events --------------------------------------------

    // ---------------------------------------------------



    // Injection -----------------------------------------
    [Inject]
    private void Constructor()
    {

    }
    // ---------------------------------------------------



    // Unity Methods -------------------------------------
    protected void Start()
    {

    }

    protected void Update()
    {

    }
    // ---------------------------------------------------



    // Other Methods -------------------------------------
    public void IncreaseHealPoints(float value)
    {

        healPointsCur = Mathf.Clamp(healPointsCur + value, 0, healPointsMax);
        //healIndicator.SetValue(healPointsCur);

    }
    public void DecreaseHealPoints()
    {
        --healPointsCur;
        //healIndicator.SetValue(healPointsCur);
        if (healPointsCur <= 0)
        {
            Destroy(gameObject);
        }
    }
    // ---------------------------------------------------
}
