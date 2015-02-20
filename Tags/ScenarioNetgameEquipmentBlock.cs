using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioNetgameEquipmentBlock
    {
        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation( this.position );
                var rotationXMatrix = Matrix4.CreateRotationX( this.orientation.orientation.Z );
                var rotationYMatrix = Matrix4.CreateRotationY( -this.orientation.orientation.Y );
                var rotationZMatrix = Matrix4.CreateRotationZ( this.orientation.orientation.X );
                var rotationMatrix = rotationZMatrix * rotationYMatrix * rotationXMatrix;
                return Matrix4.CreateScale( 1 ) * rotationMatrix * translationMatrix;
            }
        }
    };
}
