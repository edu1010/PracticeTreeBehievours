using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_ANITA", menuName = "Behaviour Trees/BT_ANITA", order = 1)]
public class BT_ANITA : BehaviourTree
{
    // construtor
    public BT_ANITA()
    {
        /* Receive BT parameters and set them. Remember all are of type string */
    }

    public override void OnConstruction()
    {
        root = new RepeatForeverDecorator();
        
        DynamicSelector dynamicSelector = new DynamicSelector();
        root.AddChild(dynamicSelector);

        //Extra for police and thief behaviour
        dynamicSelector.AddChild(
            new CONDITION_ThiefInStore("theThief"),
            new Sequence(
                new ACTION_Deactivate("theNotes"),
                new ACTION_Utter("0", "2"),
                new ACTION_INVOKE_POLICE()
                )
            );
        dynamicSelector.AddChild(
            new CONDITION_CustomerInStore("theCustomer"),
            new Sequence(
                new ACTION_Deactivate("theBroom"),
                new ACTION_Deactivate("theNotes"),
                new ACTION_Utter("10"),
                new ACTION_Arrive("theFrontOfDesk"),
                new BT_SeeToCustomer()
                )
            );
        dynamicSelector.AddChild(
         new CONDITION_NoMoreFruit(),
         new Sequence(
             new ACTION_ClearUtterance(),
             new ACTION_Arrive("theRestockPoint", "20"),
             new ACTION_ReStock()
             )
         );
        dynamicSelector.AddChild(
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
        root = new Sequence(
            new ACTION_EngageInDialog("theCustomer"),
            new ACTION_AskEngaged("11", "2", "theAnswer"),
            new Selector(
                new Sequence(
                    new ACTION_ParseAnswer("theAnswer", "theProduct"),
                    new ACTION_TellEngaged("13", "2"),
                    new BT_SELL_PRODUCT()
                    ),
                new ACTION_TellEngaged("12", "2")
                ),
            new ACTION_DisengageFromDialog(), 
            new ACTION_ClearUtterance()
            );

    }

}
public class BT_SweepAndSing : BehaviourTree
{
    public BT_SweepAndSing()
    {

    }
    public override void OnConstruction()
    {
        root = new Sequence(
            new ACTION_ClearUtterance(),
            new ACTION_Activate("theBroom"),
            new ACTION_Activate("theNotes"),
            new ACTION_WanderAround("theSweepingPoint", "0.5")
            );
    }

}

public class BT_SELL_PRODUCT : BehaviourTree
{
    public BT_SELL_PRODUCT() { }
    public override void OnConstruction()
    {
        root = new Selector(
            new Sequence(
                new CONDITION_CheckExistences("theProduct"),
                new ACTION_Sell("theProduct"),
                new ACTION_TellEngaged("14", "2")             
                ),
             new ACTION_TellEngaged("12", "2")         

            );
    }
}