﻿using System.Linq;
using Normal.Realtime;
using UnityEngine;
using UnityEditor;

public static class TestSpawnLotsOShit
{
    private static float _outerBounds = 10f;
    [MenuItem("Debug/TEST SPAWN LOTS OF BRICKS AND SEND TO DATASTORE")]
    public static void Spawn()
    {
        Realtime realtime = Realtime.instances.First();

        for (int i = 0; i < 200; i++)
        {
            NormcoreRPC.Brick serializedBrickObject = new NormcoreRPC.Brick()
            {
                matId = 3,
                type = "4x2",
                uuid = BrickId.FetchNewBrickID(),
                pos = RandomBrickPos(),
                rot = Quaternion.identity
            };

            BrickServerInterface.GetInstance().SendBrick(serializedBrickObject, realtime);
            GameObject newBrick = PlacedBrickCreator.CreateFromBrickObject(serializedBrickObject);
        }
    }

    static Vector3 RandomBrickPos()
    {
        float x = Random.Range(0f, _outerBounds);
        if (Random.Range(0f, 1f) > 0.5f)
            x *= -1;

        float z = Random.Range(0f, _outerBounds);
        if (Random.Range(0f, 1f) > 0.5f)
            z *= -1;

        float y = Random.Range(1f, 4f);

        return new Vector3(x, y, z);;
    }
}