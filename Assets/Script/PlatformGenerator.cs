using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public List<GameObject> ListPrefab;
    public List<Vector3> ListTaille;
    public GameObject Fin;
    public GameObject Debut;
    public List<GameObject> Niveau;
    public List<Vector2> ListTailleNiveau;

    public List<GameObject> ListEnemy;
    public int nbEnemyGeneration;

    public GameObject J1;
    public GameObject J2;

    private Vector3 positionCursor;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 addList;
        //reset cursor
        positionCursor.x = 0;
        positionCursor.y = 0;
        positionCursor.z = 0.0448242f;
        //POsitionnement du Debut
        Debut.GetComponentInChildren<Transform>().localPosition = positionCursor;
        GameObject InstantNiveau = Instantiate(Debut);
        Niveau.Add(InstantNiveau);
        addList.x = 10;
        addList.y = 0;
        ListTailleNiveau.Add(addList);
        /* ------------------------------------------------------------------------------*/
        positionCursor.x = 10;
        //BOUCLE DE CREATION
        for (int i = 0; i < 100; i++){
        //choix Platform
          float choix = Random.value * ListPrefab.Count;
          int newChoix = (int)choix;
          if (newChoix == ListPrefab.Count){
            newChoix = newChoix -1;
          }
          ListPrefab[newChoix].GetComponentInChildren<Transform>().localPosition = positionCursor;
          //positionnement Platform
          GameObject InstantPrefab = Instantiate(ListPrefab[newChoix]);
          Niveau.Add(InstantPrefab);
          //ajustement cursor
          for (int j = 0; j < ListPrefab.Count;j++){
            Vector3 newPosPrefab = ListPrefab[newChoix].GetComponentInChildren<Transform>().localPosition;
            //Nouvelle position de tout les prefab
            newPosPrefab.x += ListTaille[newChoix].x;
            newPosPrefab.y += ListTaille[newChoix].y;
            newPosPrefab.z += ListTaille[newChoix].z;
            ListPrefab[newChoix].GetComponentInChildren<Transform>().localPosition = newPosPrefab;
          }
          //ajustement du curseur de positionnement
          positionCursor.x +=ListTaille[newChoix].x;
          positionCursor.y +=ListTaille[newChoix].y;
          positionCursor.z +=ListTaille[newChoix].z;
          addList.x = ListTaille[newChoix].x;
          addList.y = ListTaille[newChoix].y;
          ListTailleNiveau.Add(addList);
        }
        /* ----------------------------------------------------------------------------*/
        Fin.GetComponentInChildren<Transform>().localPosition = positionCursor;
        GameObject InstantFin = Instantiate(Fin);
        Niveau.Add(InstantFin);
        addList.x = 0;
        addList.y = 0;
        ListTailleNiveau.Add(addList);
         /* ----------------------------------------------------------------------------*/
        //Tp des joueurs dans la map
        positionCursor.x = 3f;
        positionCursor.y = 2f;
        positionCursor.z = -0.5f;
        J1.GetComponentInChildren<Transform>().localPosition = positionCursor;
        positionCursor.x = 5f;
        positionCursor.y = 2f;
        J2.GetComponentInChildren<Transform>().localPosition = positionCursor;
        /* ----------------------------------------------------------------------------*/
        
        //Generation des ennemis
        for(int i = 0; i < nbEnemyGeneration; i++){
          //choix random de l'ennemis aleatoire
          float choixEnemyFloat = Random.value * ListEnemy.Count;
          int choixEnemy = (int)choixEnemyFloat;
          if (choixEnemy == ListEnemy.Count){
            choixEnemy = choixEnemy -1;
          }
        //choix du prefab dans lequel on va possitionner le mechant (dans la liste Niveau)
        bool trou = true;
        int intChoixPrefab = 0;
        while (trou == true){
            float floatchoixprefab = Random.value * Niveau.Count;
            intChoixPrefab = (int) floatchoixprefab;
            if (intChoixPrefab == 0){
                intChoixPrefab += 1;
            } 
            else{
               if (intChoixPrefab == Niveau.Count){
                    intChoixPrefab -= 1;
                }
            }
            if (Niveau[intChoixPrefab].name == "Trou(Clone)"){
                trou = true;
            }
            else{
                trou = false;
            }
        }
        /*Recuperation de quelques données */
        GameObject PrefabChoisis = Niveau[intChoixPrefab];
        print(PrefabChoisis.name + intChoixPrefab);
        //pos prefab choisis
        Vector3 posPrefabChoisis = PrefabChoisis.GetComponentInChildren<Transform>().localPosition;
        //taille prefab choisis
        Vector2 taillePrefab = ListTailleNiveau[intChoixPrefab];
        float posMinX,posMaxX;
        posMinX = posPrefabChoisis.x;
        posMaxX = posMinX + taillePrefab.x/*taille du prefab*/;
        //generation aleatoire de la place du personnage dansson prefab
        float floatRandomX = posMinX + (Random.value * taillePrefab.x);
        int RandomX = (int)floatRandomX;
        print(posMinX +" "+posMaxX+" "+ RandomX);
        //positionnement du curseur
        positionCursor.x = (float)RandomX;
        positionCursor.y = posPrefabChoisis.y + 2f;
        positionCursor.z = -0.5f;
        //print("Enemy n°" + i +"  :" + choixPlace );

        //PLacement de l'ennemis
        GameObject Enemy = ListEnemy[choixEnemy];
        Enemy.GetComponentInChildren<Enemy>().transformPlayer = J1.GetComponentInChildren<Transform>();
        Enemy.GetComponentInChildren<Enemy>().J2 = J2;
        Enemy.GetComponentInChildren<Enemy>().J1 = J1;
        Enemy.GetComponentInChildren<Transform>().localPosition = positionCursor;
        Instantiate(Enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

