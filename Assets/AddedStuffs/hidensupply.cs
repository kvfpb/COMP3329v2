using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class hidensupply : MonoBehaviourPunCallbacks
{
    private float spawnDelay; // Delay between spawns
    private int spawnCount1; // Number of crates spawned
    private int spawnCount2;
    private int spawnLimit;
    private int[] prev;
    private GameObject[] spawnedSupplies1;
    private GameObject[] spawnedSupplies2;
    private float countdown1;
    private float countdown2;
    private int stage;

    // Array of spawn coordinates
    private Vector3[] spawnPoints =
    {
        new Vector3 // 1st
        {
            x = -118.1f,
            y = -7.371f,
            z = 72.21f
        },
        new Vector3 // 2nd
        {
            x = -165.17f,
            y = -8.25f,
            z = 93.3f
        },
        new Vector3 // 3rd
        {
            x = -181.069f,
            y = -5.626f,
            z = 91.765f
        },
        new Vector3 // 4th
        {
            x = -193.77f,
            y = -6.68f,
            z = 113.2f
        },
        new Vector3 // 5th
        {
            x = -183.16f,
            y = -5.8f,
            z = 138.39f
        },
        new Vector3 // 6th
        {
            x = -167.57f,
            y = -1.76f,
            z = 141.54f
        },
        new Vector3 // 7th
        {
            x = -120.189f,
            y = -2.844f,
            z = 170.815f
        },
        new Vector3 // 8th
        {
            x = -126.1f,
            y = -6.63f,
            z = 122f
        },
        new Vector3 // 9th
        {
            x = -98f,
            y = -0.8f,
            z = 110.37f
        },
        new Vector3 // 10th
        {
            x = -100.1f,
            y = 8f,
            z = 139.31f
        }
    };

    // Array of spawn rotations
    private Vector3[] spawnRotations =
    {
        new Vector3 // 1st
        {
            x = 0,
            y = 200,
            z = 0
        },
        new Vector3 // 2nd
        {
            x = 0,
            y = 200,
            z = 0
        },
        new Vector3 // 3rd
        {
            x = 0,
            y = 30,
            z = 0
        },
        new Vector3 // 4th
        {
            x = 0,
            y = 140,
            z = 0
        },
        new Vector3 // 5th
        {
            x = 0,
            y = 140,
            z = 0
        },
        new Vector3 // 6th
        {
            x = 0,
            y = 220,
            z = 0
        },
        new Vector3 // 7th
        {
            x = 0,
            y = 160,
            z = 0
        },
        new Vector3 // 8th
        {
            x = 0,
            y = 270,
            z = 0
        },
        new Vector3 // 9th
        {
            x = 0,
            y = 320,
            z = 0
        },
        new Vector3 // 10th
        {
            x = 0,
            y = 170,
            z = 0
        }
    };

    void Start()
    {
        spawnDelay = 0f;
        spawnCount1 = 0;
        spawnCount2 = 0;
        spawnLimit = 10;
        prev = new int[spawnLimit];
        spawnedSupplies1 = new GameObject[spawnLimit];
        spawnedSupplies2 = new GameObject[spawnLimit];
        countdown1 = 0f;
        countdown2 = 30f;
        stage = 1;
    }

    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        if (gos.Length != 2 || (!PhotonNetwork.IsMasterClient))
        {
            return;
        }

        GameObject[] gos2;
        gos2 = GameObject.FindGameObjectsWithTag("cutscene");
        if (gos2.Length == 2) // after cutscene, repeat the spawning by resetting spawnCounts and countdowns
        {
            spawnCount1 = 0;
            spawnCount2 = 0;
            countdown1 = 0f;
            countdown2 = 30f;
            stage = 1;
            for (int i = 0; i < 2; i++) // Destroy spawned supplies in this round, max = 4
            {
                PhotonNetwork.Destroy(spawnedSupplies1[i]);
                PhotonNetwork.Destroy(spawnedSupplies2[i]);
            }
            System.Array.Clear(prev, 0, prev.Length); // Clear prev (spawned) array
            return;
        }

        countdown1 -= Time.deltaTime;
        countdown2 -= Time.deltaTime;

        if (countdown1 < 0)
        {
            if (spawnCount1 == 0)
            {
                for (int i = 0; i < 2; i++) // Destroy spawned supplies two stages ago
                {
                    PhotonNetwork.Destroy(spawnedSupplies1[i]);
                    prev[i] = -1;
                }
            }
            if (spawnCount1 < 2) // yet to spawn 2 supplies
            {
                int spawnIndex = Random.Range(0, 10);
                int pos = System.Array.IndexOf(prev, spawnIndex);
                if (pos <= -1)
                {
                    if (stage == 1)
                    {
                        spawnedSupplies1[spawnCount1] = PhotonNetwork.Instantiate(
                            "supply1",
                            spawnPoints[spawnIndex],
                            Quaternion.Euler(spawnRotations[spawnIndex])
                        );
                    }
                    else if (stage == 3)
                    {
                        spawnedSupplies1[spawnCount1] = PhotonNetwork.Instantiate(
                            "supply3",
                            spawnPoints[spawnIndex],
                            Quaternion.Euler(spawnRotations[spawnIndex])
                        );
                    }
                    else
                    {
                        spawnedSupplies1[spawnCount1] = PhotonNetwork.Instantiate(
                            "supply4",
                            spawnPoints[spawnIndex],
                            Quaternion.Euler(spawnRotations[spawnIndex])
                        );
                    }

                    // Debug.Log(
                    //     "Spawned supply at " + spawnPoints[spawnIndex] + "count: " + spawnCount1
                    // );
                    prev[spawnCount1] = spawnIndex;
                    spawnCount1++;
                }
            }
            else
            {
                stage++;
                countdown1 = 60f;
                spawnCount1 = 0;
            }
        }
        else if (countdown2 < 0)
        {
            if (spawnCount2 == 0)
            {
                for (int i = 0; i < 2; i++) // Destroy spawned supplies two stages ago
                {
                    PhotonNetwork.Destroy(spawnedSupplies2[i]);
                    prev[i + 2] = -1;
                }
            }
            if (spawnCount2 < 2)
            {
                int spawnIndex = Random.Range(0, 10);
                int pos = System.Array.IndexOf(prev, spawnIndex);
                if (pos <= -1)
                {
                    if (stage == 2)
                    {
                        spawnedSupplies2[spawnCount2] = PhotonNetwork.Instantiate(
                            "supply2",
                            spawnPoints[spawnIndex],
                            Quaternion.Euler(spawnRotations[spawnIndex])
                        );
                    }
                    else
                    {
                        spawnedSupplies2[spawnCount2] = PhotonNetwork.Instantiate(
                            "supply4",
                            spawnPoints[spawnIndex],
                            Quaternion.Euler(spawnRotations[spawnIndex])
                        );
                    }
                    // Debug.Log(
                    //     "2nd array Spawned supply at "
                    //         + spawnPoints[spawnIndex]
                    //         + "count: "
                    //         + spawnCount2
                    // );
                    prev[spawnCount2 + 2] = spawnIndex;
                    spawnCount2++;
                }
            }
            else
            {
                stage++;
                countdown2 = 60f;
                spawnCount2 = 0;
            }
        }
    }
}
