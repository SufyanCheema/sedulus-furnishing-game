using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureShowcase : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;
    [SerializeField] GameObject Inventory;
    private GameObject[] furnitureCells;
    private GameObject[] furnitures;

    private int furnitureCount;

    private int tempIndex;

    private int index;
    [SerializeField] private int cellCount;

    void Awake(){
        index = 0;
        furnitureCount = 0;
        tempIndex = -1;
        furnitureCells = new GameObject[cellCount];
        furnitures = new GameObject[cellCount];
        for(int i = 0; i < cellCount; i++){
            addFurnitureCell();
        }
    }

    public void setShowCaseActive(bool val){
        Inventory.GetComponent<InventoryHandler>().setShowCaseActive(val);
    }

    public void addFurnitureCell(){
        furnitureCells[index] = Instantiate(cellPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        furnitureCells[index].transform.SetParent(transform,false);
        furnitureCells[index].GetComponent<FurnitureCell>().Inventory = this.gameObject;
        furnitureCells[index].GetComponent<FurnitureCell>().setIndex(index);
        index++;
    }

    public GameObject addFurnituretoCell(GameObject furniture){
            if(furnitures[tempIndex] == null){
                furnitures[tempIndex] = furniture;
                furnitures[tempIndex].transform.SetParent(furnitureCells[tempIndex].transform,false);
                furnitureCount++;
                return null;
            }else{
                GameObject temp = furnitures[tempIndex];
                furnitures[tempIndex] = furniture;
                furnitures[tempIndex].transform.SetParent(furnitureCells[tempIndex].transform,false);
                return temp;
            }
    }

    public GameObject removeFurniturefromCell(){
        GameObject temp = furnitures[tempIndex];
        furnitures[tempIndex] = null;
        furnitureCount--;
        return temp;
    }

    public void removeFurniturefromCell(int fid){
        for(int i = 0; i < cellCount; i++){
            if(furnitures[i] != null && furnitures[i].GetComponent<Furniture>().FID == fid){
                Destroy(furnitures[i]);
                furnitures[i] = null;
                furnitureCount--;
                return;
            }
        }
        
    }

    public void initiateSwap(int n){
        tempIndex = n;
    }

    public int getFurnitureCount(){
        return this.furnitureCount;
    }

    public GameObject getFurniture(int n){
        int temp = -1;
        for(int i = 0; i < cellCount; i++){
            if (furnitures[i] != null ){
                temp++;
                if(temp == n){
                    return furnitures[i];
                }
            }
        }
        return null;
    }

   
}
