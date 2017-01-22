using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TransformExtensions
{
    public static class Extensions
    {
        public static void SetLocalX(this Transform self, float x) {
            self.localPosition = new Vector3( x, self.localPosition.y, self.localPosition.z );
        }
        public static void SetLocalY (this Transform self, float y) {
            self.localPosition = new Vector3( self.localPosition.x, y, self.localPosition.z );
        }
        public static void SetLocalZ (this Transform self, float z) {
            self.localPosition = new Vector3( self.localPosition.x, self.localPosition.y, z );
        }

    }
}
