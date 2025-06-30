using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public enum LogicTypes
{  
    Not,           
    And,          
    Or,            
    Implies,
    EqRelation,    
    ConstTrue,  
    ConstFalse,
    KlammerAuf,
    KlammerZu,
    A,
    E,
    NotEqual,
    Equal,
    Blank
}

public class LogicBlock : MonoBehaviour
{

    public bool Interactables;
    
    public LogicTypes type;

    public Material Not;
    public Material And;
    public Material Or;
    public Material Implies;
    public Material EqRelation;
    public Material ConstTrue;
    public Material ConstFalse;
    public Material KlammerAuf;
    public Material KlammerZu;
    public Material E; 
    public Material A;
    public Material Equal;
    public Material NotEqual;
    public Material Invisible;


    private LogicTypes lastType;
    private Renderer renderer;

    private Rigidbody rigidbody;
    private XRBaseInteractable grabinteractable;
    private CheckSelected cs;
    private SnapCubeHere snap;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
        rigidbody = GetComponent<Rigidbody>();
        grabinteractable = GetComponent<XRBaseInteractable>();
        cs = GetComponent<CheckSelected>();
        snap = GetComponent<SnapCubeHere>();
        rigidbody.isKinematic = true;

        if (Interactables){
            grabinteractable.enabled = true;
            cs.enabled = true;
        }

        lastType = type;
        UpdateMaterial();
    
    }

    /*private void Update()
    {
        if (type != lastType)
        {
            lastType = type;
            UpdateMaterial();
        }
    }*/

    private void UpdateMaterial()
    {
        switch (type)
        {
            case LogicTypes.Blank:
                snap.enabled = true;
                renderer.material = Invisible;
                break;
            case LogicTypes.Not:
                renderer.material = Not;
                break;
            case LogicTypes.And:
                renderer.material = And;
                break;
            case LogicTypes.Or:
                renderer.material = Or;
                break;
            case LogicTypes.Implies:
                renderer.material = Implies;
                break;
            case LogicTypes.EqRelation:
                renderer.material = EqRelation;
                break;
            case LogicTypes.ConstTrue:
                renderer.material = ConstTrue;
                break;
            case LogicTypes.ConstFalse:
                renderer.material = ConstFalse;
                break;
            case LogicTypes.Equal:
                renderer.material = Equal;
                break;        
            case LogicTypes.NotEqual:
                renderer.material = NotEqual;
                break;     
            case LogicTypes.KlammerAuf:
                renderer.material = KlammerAuf;
                break;            
            case LogicTypes.KlammerZu:
                renderer.material = KlammerZu;
                break;            
            case LogicTypes.E:
                renderer.material = E;
                break;            
            case LogicTypes.A:
                renderer.material = A;
                break;
        }
    }
}
