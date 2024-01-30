using UnityEngine;

public class WitchController : AxeGhostMovement
{


    protected override void Update()
    {
        base.Update();

        if (CanSeePlayer())
        {
            transform.LookAt(playerPosition.position);
            ShotPlayer();
        }
    }


    private void ShotPlayer()
    {
        /**
        *TO DO
        *Make ghost stop moving while shooting
        **/
        Debug.Log("Piu piu");
    }
}
