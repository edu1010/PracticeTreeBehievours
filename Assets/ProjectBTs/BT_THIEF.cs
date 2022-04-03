using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_THIEF", menuName = "Behaviour Trees/BT_THIEF", order = 1)]
public class BT_THIEF : BehaviourTree
{
     // construtor
    public BT_THIEF()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_Arrive("storeEntrance", "4"),
            new ACTION_Utter("1", "2"),
            new RepeatUntilSuccessDecorator(
                new CONDITION_InstanceNear("9", "policeTag")
                ),
            new ACTION_WaitForSeconds("2"),
            new ACTION_Arrive("exitPoint"),
            new ACTION_DESTROY()
            );
    }
}
