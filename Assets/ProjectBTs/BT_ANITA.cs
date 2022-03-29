using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_ANITA", menuName = "Behaviour Trees/BT_ANITA", order = 1)]
public class BT_ANITA : BehaviourTree
{
    /* If necessary declare BT parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 
     */

     // construtor
    public BT_ANITA()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        /* Write here (method OnConstruction) the code that constructs the Behaviour Tree 
           Remember to set the root attribute to a proper node
           e.g.
            ...
            root = new SEQUENCE();
            ...

          A behaviour tree can use other behaviour trees.  
      */
        root = new DynamicSelector();
        root.AddChild(
            new CONDITION_CustomerInStore(),
            new Sequence(
                new ACTION_Deactivate("theBroom"),
                new ACTION_Deactivate("theNotes"),
                new ACTION_TellEngaged("10","2"),
                new ACTION_Arrive("theFrontOfDesk"),
                new BT_SeeToCustomer()
                )
            ) ;
        root.AddChild(
            new CONDITION_AlwaysTrue(),
            new BT_SweepAndSing()

            );
    }
}
public class BT_SeeToCustomer : BehaviourTree
{
    public BT_SeeToCustomer()
    {

    }
    public override void OnConstruction()
    { 
    }

}
public class BT_SweepAndSing: BehaviourTree
{
    public BT_SweepAndSing()
    {

    }
    public override void OnConstruction()
    { 
    }

}