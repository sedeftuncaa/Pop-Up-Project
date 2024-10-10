// using System;
// using System.Collections.Generic;
// using System.Linq;
// using DI.Managers;
// using Enums;
// using Models;
// using Structs;
// using UnityEngine;
// using Zenject;
//
// namespace Utilies
// {
//     public  class Utilities: IDisposable
//     {
//
//         #region ZenjectSetup
//         private GridManager _gridManager;
//         private GridProperties _gridProperties;
//         private NodeProperties _nodeProperties;
//
//         [Inject]
//         private void Setup(GridManager gridManager, GridProperties gridProperties, NodeProperties nodeProperties)
//         {
//             _gridManager = gridManager;
//             _gridProperties = gridProperties;
//             _nodeProperties = nodeProperties;
//         }
//         
//
//         #endregion
//         
//         public GridTile CheckForGridSnap(Vector2 pos)
//         {
//             GridTile[] gridItems = _gridManager.GetTilesList().Values.ToArray();
//
//             float closestDistance = float.MaxValue;
//             GridTile closestGridNode = null;
//             foreach (GridTile gridItem in gridItems)
//             {
//                 float distance = Vector2.Distance(pos, gridItem.transform.position);
//                 if (distance < closestDistance)
//                 {
//                
//                     closestDistance = distance;
//                     closestGridNode = gridItem;
//                 }
//             }
//         
//             return closestGridNode;
//         }
//         
//         public List<Vector2Int> GetNeighbors(Vector2Int gridPosition)
//         {
//             List<Vector2Int> neighbors = new List<Vector2Int>();
//
//             for (var i = _gridProperties.height ; i >= 0; i--)
//             {
//                 var pos = new Vector2Int(gridPosition.x, gridPosition.y - i);
//                 if (!neighbors.Contains(pos))
//                 {
//                     if (_gridManager.TilesList.TryGetValue(pos, out var newTile))
//                     {
//                         if (newTile.GetNodeType!=NodeTypes.Empty && newTile.GetGridPosition != gridPosition)
//                         {
//                             neighbors.Add(pos);
//                         }
//                     }
//                 }
//             }
//
//             return neighbors;
//         }
//         
//         // public bool IsAllNodeHaveOwnGridTile()
//         // {
//         //     var allNodes = _nodeProperties.allNodesObjectsInScene;
//         //     var allGridTiles = _gridManager.GetTilesList().Values;
//         //     foreach (var node in allNodes)
//         //     {
//         //         if (allGridTiles.All(x => x.GetGridPosition != node.GetGridTile.GetGridPosition))
//         //         {
//         //             return false;
//         //         }
//         //     }
//         //
//         //     return true;
//         // }
//
//         public void Dispose()
//         {
//             _gridManager?.Dispose();
//         }
//     }
// }