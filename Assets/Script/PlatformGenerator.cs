using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject troupourcheck;
    public List<GameObject> ListPrefab;
    public GameObject Fin;
    public GameObject Debut;

    public List<GameObject> ListEnemy;
    public int nbEnemyGeneration;

    public GameObject J1;
    public GameObject J2;

    public List<Vector3> ListTaille;
    private Vector3 positionCursor;
    public List<GameObject> Niveau = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
         //reset cursor
        positionCursor.x = 0;
        positionCursor.y = 0;
        positionCursor.z = 0.0448242f;
        
        Debut.GetComponentInChildren<Transform>().localPosition = positionCursor;
        Niveau.Add(Debut);
        Instantiate(Debut);
        positionCursor.x = 10;
        Vector3 positionDebut = positionCursor;
        //BOUCLE DE CREATION
        for (int i = 0; i < 10; i++){
        //choix Platform
          float choix = Random.value * ListPrefab.Count;
          int newChoix = (int)choix;
          if (newChoix == ListPrefab.Count){
            newChoix = newChoix -1;
          }
          ListPrefab[newChoix].GetComponentInChildren<Transform>().localPosition = positionCursor;
          //positionnement Platform
          GameObject prefabToGo = ListPrefab[newChoix];
          Instantiate(ListPrefab[newChoix]);
          Niveau.Add(prefabToGo);
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
        }
        Vector3 positionFin = positionCursor;
        Fin.GetComponentInChildren<Transform>().localPosition = positionCursor;
        Niveau.Add(Fin);
        Instantiate(Fin);
        /*
        //ceci c'est des test pour la solution numero 2
        print(Niveau[3].ToString());
        print(ListPrefab.IndexOf(Niveau[3])); //index elem choisit dans la list prefab
        print(ListTaille[ListPrefab.IndexOf(Niveau[3])].x); //taille de l'element choisit dans la liste d'apres la liste taille
        */
        //Tp des joueurs dans la map
        positionCursor.x = 3f;
        positionCursor.y = 2f;
		positionCursor.z = -0.5f;
        J1.GetComponentInChildren<Transform>().localPosition = positionCursor;
        positionCursor.x = 5f;
        positionCursor.y = 2f;
        J2.GetComponentInChildren<Transform>().localPosition = positionCursor;

        //Generation des ennemis
        for(int i = 0; i < nbEnemyGeneration; i++){
          //choix random de l'ennemis aleatoire
          float choixEnemyFloat = Random.value * ListEnemy.Count;
          int choixEnemy = (int)choixEnemyFloat;
          if (choixEnemy == ListEnemy.Count){
            choixEnemy = choixEnemy -1;
          }
          /*
          //print("Enemy n°" + i +"  :" + choixEnemy );
          //randomisation de la place de l'ennemis entre positionDebut et positionFin
          //choix du X
          float choixPlaceFloat = positionDebut.x + (Random.value * positionFin.x);
          int choixPlace = (int)choixPlaceFloat;
          if (choixPlace == positionFin.x){
            choixPlace = choixPlace -1;
          }
          //choix du Y
          //Check si HOLE
          bool checkY = false;

          Vector3 testPosition;
          int y = 0;
          testPosition.x = choixPlace;
          testPosition.y = y;
          testPosition.z = 0.0448242f;
          for (y = 5; y >= -5; y--){
              testPosition.x = choixPlace;
              testPosition.y = y;
              //Checking si un collider tagé ground est au meme endoit que le testPosition
              if (checkingGround(testPosition)){
                checkY = true;
              }
              else{
                checkY = false;
              }
          }
          */
          //Choix du prefab pour mettre l'ennemis
          int IntChoixElem = 0;
          bool trou = true;
          GameObject[] ListeScene = this.gameObject.scene.GetRootGameObjects();
          while(trou)
          {
            float choixElem = Random.value * ListeScene.Length;
            if (choixElem == ListeScene.Length)
            {
                choixElem = choixElem - 1;
            }
            IntChoixElem = (int)choixElem;
            if (ListeScene.GetValue((int)choixElem).ToString() == troupourcheck.ToString() || choixElem < 5)
            {
               print("On relance");
            }
            else 
            {
                trou = false;
            }
          }
          print("Element choisis aleatoirement : " + Niveau[IntChoixElem].name);

          //Choix du x dans le prefab
          //POsition du prefab
          Vector3 PositionPrefabChoisit = Niveau[IntChoixElem].GetComponentInChildren<Transform>().position;
          print("Position du prefab choisis " + IntChoixElem + " x : " + PositionPrefabChoisit.x + " y : " +PositionPrefabChoisit.y);

          /*
          //positionnement du curseur
          positionCursor.x = choixPlace;
          positionCursor.y = 10f;
          positionCursor.z = -0.5f;
          //print("Enemy n°" + i +"  :" + choixPlace );

          //PLacement de l'ennemis
          GameObject Enemy = ListEnemy[choixEnemy];
          Enemy.GetComponentInChildren<Enemy>().transformPlayer = J1.GetComponentInChildren<Transform>();
          Enemy.GetComponentInChildren<Enemy>().J2 = J2;
          Enemy.GetComponentInChildren<Enemy>().J1 = J1;
          Enemy.GetComponentInChildren<Transform>().localPosition = positionCursor;
          Instantiate(Enemy);
          */
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    bool checkingGround(Vector3 testPosition){
      GameObject cursor;
      cursor = new GameObject("cursor");
      cursor.AddComponent<Transform>();
      cursor.GetComponentInChildren<Transform>().localPosition = testPosition;
      cursor.AddComponent<BoxCollider2D>();
      Vector2 newSize;
      newSize.x = 0.90f;
      newSize.y = 0.90f;
      cursor.GetComponentInChildren<BoxCollider2D>().size = newSize;
      cursor.AddComponent<Rigidbody2D>();
      cursor.GetComponentInChildren<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      cursor.GetComponentInChildren<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
      cursor.tag = "Cursor";
      //print("je met le script");
      string scriptName = "ScriptCursor";
      System.Type LeTypeScript = System.Type.GetType (scriptName + ",Assembly-CSharp");
      cursor.AddComponent(LeTypeScript);
      //test de collision
      print(cursor.GetComponentInChildren<ScriptCursor>().col);
      if (cursor.GetComponentInChildren<ScriptCursor>().col){
        //Destroy(cursor);
        return true;
      }
      else {
        //Destroy(cursor);
        return true;
      }
      //Destroy(cursor);
      return true;
    }
}
