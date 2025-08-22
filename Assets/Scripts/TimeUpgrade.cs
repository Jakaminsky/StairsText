using UnityEngine;

public class TimeUpgrade : MonoBehaviour
{
    public static int upgradeNumStep = 0;
    public static int upgradeNumJump = 0;
    public static int upgradeNumLeap = 0;
    public static int upgradeNumBound = 0;
    public static int upgradeNumLaunch = 0;

    private void Start()
    {
        Mathf.Clamp(upgradeNumStep, 0, 100);
        Mathf.Clamp(upgradeNumJump, 0, 200);
        Mathf.Clamp(upgradeNumLeap, 0, 300);
        Mathf.Clamp(upgradeNumBound, 0, 400);
        Mathf.Clamp(upgradeNumLaunch, 0, 500);
    }

    public void onClick()
    {
        upgradeNumStep++;
        upgradeNumJump++;
        upgradeNumLeap++;
        upgradeNumBound++;
        upgradeNumLaunch++;
    }
}
