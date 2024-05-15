using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace PlatformerTutorial {

    public class MapEntity : MonoBehaviour {

        public int stageID;

        MapGridElement grid;

        public void Ctor() {

        }

        public void Inject(MapGridElement grid) {
            this.grid = grid;
        }

    }

}