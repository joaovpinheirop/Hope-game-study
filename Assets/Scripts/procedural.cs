using UnityEngine;

public class procefural : MonoBehaviour
{
    public int largura = 256;
    public int altura = 256;
    public float escala = 20f;

    void Start()
    {
        GerarTerreno();
    }

    void GerarTerreno()
    {
        Terrain terreno = GetComponent<Terrain>();
        terreno.terrainData = GerarTerreno(terreno.terrainData);
    }

    TerrainData GerarTerreno(TerrainData terrenoData)
    {
        terrenoData.heightmapResolution = largura + 1;
        terrenoData.size = new Vector3(largura, 20, altura);
        terrenoData.SetHeights(0, 0, GerarAlturas());
        return terrenoData;
    }

    float[,] GerarAlturas()
    {
        float[,] alturas = new float[largura, altura];
        Vector2 offset = new Vector2(Random.Range(0f, 9999f), Random.Range(0f, 9999f));

        for (int x = 0; x < largura; x++)
        {
            for (int y = 0; y < altura; y++)
            {
                alturas[x, y] = Mathf.PerlinNoise((float)x / escala + offset.x, (float)y / escala + offset.y);
            }
        }

        return alturas;
    }
}
