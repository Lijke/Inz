using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour{
  public List<GameObject> canvases;
  public List<ItemSO> itemSo;
  public static CanvasManager Instance;
  public ShopPanelDetails shopPanelDetails;

  private void Awake(){
    Instance = this;
  }

  public void ChangeVisibleCanvas(int id){
    foreach (var canvas in canvases){
      canvas.SetActive(false);
    }
    canvases[id].SetActive(true);
    if (canvases[id].name == "Details"){
      canvases[id]?.GetComponent<ShopPanelDetails>()?.SetupView(itemSo[0]);
    }
  }

  public void ExitDetailsCanvas(){
    foreach (var canvas in canvases){
      canvas.SetActive(false);
    }
    canvases[0].SetActive(true);
    shopPanelDetails.SetCurrenItem(0);
  }

  public void AddItem(ItemSO item){
    shopPanelDetails.AddItem(item);
  }
}
