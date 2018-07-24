using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CTileMap
{
	//Objeto que contiene todos los tiles
	private GameObject mMapObject;

    //Cantidad de columnas
    public const int MAP_WIDTH = 17;
    //Cantidad de filas
    public const int MAP_HEIGHT = 13;

    //48x48 pixeles mide cada tile, aumenta la distancia
    public const int TILE_WIDTH = 48*2;
    public const int TILE_HEIGHT = 48*2;

    // Ancho y alto del nivel en pixeles.
    public const int WORLD_WIDTH = MAP_WIDTH * TILE_WIDTH;
    public const int WORLD_HEIGHT = MAP_HEIGHT * TILE_HEIGHT;
    //Es una lista de listas de tiles (clase nuestra). Una referencia de una clase nuestra de CTile
    private List<List<CTile>> mMap;

    // Cantidad de tiles que hay.
    // TODO ver la cantidad de tiles diferentes
    private const int NUM_TILES = 2;

    // Array con los sprites de los tiles.
    private Sprite[] mTiles;

    // La pantalla tiene 17 columnas x 13 filas de tiles.
    // En el caso de hacer otro nivel copiamos el level estatico en otro.
    //Es el mapa con el indice de los tipos de tiles, despues hay que hacer el mapa
    //TODO Ver la cantidad optima para el overworld.
    public static int[] LEVEL_001 = {
        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,1,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,1,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,1,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,
        1, 0, 0, 0, 0,  0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,1,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,1,
        1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,1,
        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,1,1,1,1,1

    };

    private int mCurrentLevel;

    // Tile auxiliar, caminable, que se retorna cuando accedemos afuera del mapa.
    private CTile mEmptyTile;
    //Se cargan los sprites de los tiles
    //TODO hacer manager de assets
    public CTileMap()
    {
        mMapObject =    new GameObject();
        mMapObject.name = "Mapa";
        mTiles = new Sprite[NUM_TILES];
        mTiles[0] = Resources.Load<Sprite>("Sprites/tiles/tile000");
        mTiles[1] = Resources.Load<Sprite>("Sprites/tiles/tile001");
        //mTiles[2] = Resources.Load<Sprite>("Sprites/tiles/wall002");
        /*mTiles[3] = Resources.Load<Sprite>("Sprites/tiles/tile003");
        mTiles[4] = Resources.Load<Sprite>("Sprites/tiles/tile004");
        mTiles[5] = Resources.Load<Sprite>("Sprites/tiles/tile005");*/

        //TODO: Cargar todo junto con LOADALL
        buildLevel(1);

        mEmptyTile = new CTile(0, 0, 0, mTiles[0]);
        mEmptyTile.setVisible(false);
        mEmptyTile.setWalkable(true);
    }

    //Construye el mapa
    // Construye el mapa. Crear el array y carga el mapa aLevel.
    public void buildLevel(int aLevel)
    {
        mCurrentLevel = aLevel;

        int[] m;
        m = LEVEL_001;


        mMap = new List<List<CTile>>();

        // Para cada fila..
        for (int y = 0; y < MAP_HEIGHT; y++)
        {
            // Crea un array para la fila vacio.
            mMap.Add(new List<CTile>());

            // Llenar la fila.
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                // Obtener que indice de tile es: 0, 1, ....
                int index = m[y * MAP_WIDTH + x];
                // Crear el tile.
                CTile tile = new CTile(x * TILE_WIDTH, y * TILE_HEIGHT, index, mTiles[index]);
                // Agregar el tile a la fila.
                mMap[y].Add(tile);
            }
        }

    }
    //mMap es una lista de listas de elementos de CTiles    
    public void loadLevel(int aLevel)
    {
        mCurrentLevel = aLevel;

        int[] m;
        m = LEVEL_001;

        //Mientras que y sea menor que el maximo de altura del mapa se agregan tiles.
        //Aca se crean las filas vacias.
        for (int y = 0; y < MAP_HEIGHT; y++)
        {
            //Se le agrega una fila, para eso es el add, se le agrega vacia.
            //Se van agregando de a 1 los tiles con arrays vacios.
            //mMap.Add(new List<CTile>());

            //Mientras que la columna sea menor que el maximo se repite la iteracion.
            //Aca se llenan los arrays vacios de columnas con los tipos de tiles
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                //Nos trae el indice de tiles (0, 1, 2...etc)
                int index = m[y * MAP_WIDTH + x];
                //CTile tile = new CTile(x * TILE_WIDTH, y * TILE_HEIGHT, index, mTiles[index]);
                CTile tile = getTile(x, y);
                tile.setName("Tile - " + y + ","+ x);
                //tile.setParentObject(mMapObject.transform);
                //Agrega el tile creado al array
                //mMap[y].Add(tile);
                tile.setTileIndex(index);
                tile.setImage(mTiles[index]);
            }
        }
    }


    //Es como un manager de tiles
    public void update()
    {
        //Si la iteracion no pasa el maximo se repite
        for (int y = 0; y < MAP_HEIGHT; y++)
        {
            //Si la iteracion no pasa el maximo se repite
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                //se update los tiles a medida que cambie
                mMap[y][x].update();
            }
        }
    }

    public void render()
    {
        for (int y = 0; y < MAP_HEIGHT; y++)
        {
            for (int x = 0; x < MAP_WIDTH; x++)
            {
                mMap[y][x].render();
            }
        }
    }

    public void destroy()
    {
        for (int y = MAP_HEIGHT - 1; y >= 0; y--)
        {
            for (int x = MAP_WIDTH - 1; x >= 0; x--)
            {
                mMap[y][x].destroy();
                mMap[y][x] = null;
            }
            mMap.RemoveAt(y);
        }

        mMap = null;
    }

    //Parametros: aX es la columna, aY es la fila.
    public int getTileIndex(int aX, int aY)
    {
        if (aX < 0 || aX >= MAP_WIDTH || aY < 0 || aY >= MAP_HEIGHT)
        {
            return 0;
        }
        else
        {
            return mMap[aY][aX].getTileIndex();
        }
    }

    public CTile getTile(int aX, int aY)
    {
        if (aX < 0 || aX >= MAP_WIDTH || aY < 0 || aY >= MAP_HEIGHT)
        {
            // Si accedo fuera del mapa retorna el empty tile que es caminable.
            return mEmptyTile;
        }
        else
        {
            return mMap[aY][aX];
        }
    }
}
