using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PanelType
{
    None,
    Main,
    Option,
    Astuces,
    Parametres,
    Commandes,

}

public class MenuController : MonoBehaviour
{

    [Header("Panels")]
    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType,MenuPanel> panelsDict = new Dictionary<PanelType,MenuPanel>();
    private GameManager manager;

    [SerializeField] private EventSystem eventController;
    [SerializeField] private GameLoader gameLoader;

    private void Start()
    {
        
        manager = GameManager.instance;
        foreach (var _panel in panelsList)
        {
            if(_panel) 
            {
                panelsDict.Add(_panel.GetPanelType(),_panel);
                _panel.Init(this);
            }
        }
        OpenOnePanel(PanelType.Main);
    }

    public void OpenOnePanel(PanelType _type)
    {
        foreach (var _panel in panelsList) _panel.ChangeState(false);
        if(_type != PanelType.None) panelsDict[_type].ChangeState(true);
    }

    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type);
    }

    public void ChangeScene(string _sceneName){
        gameLoader.ChangeScene(_sceneName);
    }

    public void Quit()
    {
        manager.Quit();
    }

    public void SetSelectedGameObject(GameObject _element)
    {
        eventController.SetSelectedGameObject(_element);
    }
    public void SetSelectedGameObject()
    {
        eventController.SetSelectedGameObject(null);
    }
}
