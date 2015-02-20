using Moonfish.Guerilla;
using Moonfish.Tags;
using OpenTK;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Moonfish.Guerilla.Tags
{
    public interface IH2ObjectPalette
    {
        TagReference ObjectReference { get; }
    }
    public interface IH2ObjectInstance
    {
        /// <summary>
        /// index of ScenarioObjectNamesBlock element containing the scriptable name for this object instance
        /// </summary>
        ShortBlockIndex1 NameIndex { get; }
        /// <summary>
        /// index of Scenario*PalleteBlock element which contains the object of this instance
        /// </summary>
        ShortBlockIndex1 PaletteIndex { get; }
        /// <summary>
        /// contains instance data (orientation, spawning flags, uniqueID, etc...)
        /// </summary>
        ScenarioObjectDatumStructBlock ObjectDatum { get; }


        Matrix4 WorldMatrix { get; }
    }
    public partial class ScenarioSceneryPaletteBlock : IH2ObjectPalette
    {
        TagReference IH2ObjectPalette.ObjectReference
        {
            get { return this.name; }
        }
    }
    public partial class ScenarioWeaponPaletteBlock : IH2ObjectPalette
    {
        TagReference IH2ObjectPalette.ObjectReference
        {
            get { return this.name; }
        }
    }
    public partial class ScenarioVehiclePaletteBlock : IH2ObjectPalette
    {
        TagReference IH2ObjectPalette.ObjectReference
        {
            get { return this.name; }
        }
    }
    public partial class ScenarioEquipmentPaletteBlock : IH2ObjectPalette
    {
        TagReference IH2ObjectPalette.ObjectReference
        {
            get { return this.name; }
        }
    }
    public partial class ScenarioCratePaletteBlock : IH2ObjectPalette
    {
        TagReference IH2ObjectPalette.ObjectReference
        {
            get { return this.name; }
        }
    }

    public partial class ScenarioSceneryBlock : IH2ObjectInstance
    {
        #region Guerilla Preprocess Functions
        [GuerillaPreProcessMethod( BlockName = "scenario_scenery_block" )]
        [GuerillaPreProcessMethod( BlockName = "scenario_biped_block" )]
        [GuerillaPreProcessMethod( BlockName = "scenario_vehicle_block" )]
        [GuerillaPreProcessMethod( BlockName = "scenario_weapon_block" )]
        [GuerillaPreProcessMethod( BlockName = "scenario_crate_block" )]
        protected static void GuerillaPreProcessMethod( BinaryReader binaryReader, IList<tag_field> fields )
        {
            var index = ( from field in fields
                          where field.Name == "Object Data"
                          select fields.IndexOf( field ) ).Single( );
            fields.Insert( ++index, new tag_field( ) { type = field_type._field_pad, Name = "indexer", definition = 4 } );
        }
        #endregion


        ShortBlockIndex1 IH2ObjectInstance.NameIndex
        {
            get { return this.name; }
        }

        ShortBlockIndex1 IH2ObjectInstance.PaletteIndex
        {
            get { return this.type; }
        }

        ScenarioObjectDatumStructBlock IH2ObjectInstance.ObjectDatum
        {
            get { return this.objectData; }
        }

        Matrix4 IH2ObjectInstance.WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translationMatrix = Matrix4.CreateTranslation( objectData.position );
                var rotationXMatrix = Matrix4.CreateRotationX( this.objectData.rotation.Z );
                var rotationYMatrix = Matrix4.CreateRotationY( -this.objectData.rotation.Y );
                var rotationZMatrix = Matrix4.CreateRotationZ( this.objectData.rotation.X );
                var scaleMatrix = Matrix4.CreateScale( this.objectData.scale == 0 ? 1 : this.objectData.scale );
                return worldMatrix *= rotationZMatrix * rotationYMatrix * rotationXMatrix * translationMatrix * scaleMatrix;
            }
        }
    }
    public partial class ScenarioWeaponBlock : IH2ObjectInstance
    {
        ShortBlockIndex1 IH2ObjectInstance.NameIndex
        {
            get { return this.name; }
        }

        ShortBlockIndex1 IH2ObjectInstance.PaletteIndex
        {
            get { return this.type; }
        }

        ScenarioObjectDatumStructBlock IH2ObjectInstance.ObjectDatum
        {
            get { return this.objectData; }
        }

        Matrix4 IH2ObjectInstance.WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translationMatrix = Matrix4.CreateTranslation( objectData.position );
                var rotationXMatrix = Matrix4.CreateRotationX( this.objectData.rotation.Z );
                var rotationYMatrix = Matrix4.CreateRotationY( -this.objectData.rotation.Y );
                var rotationZMatrix = Matrix4.CreateRotationZ( this.objectData.rotation.X );
                var scaleMatrix = Matrix4.CreateScale( this.objectData.scale == 0 ? 1 : this.objectData.scale );
                return worldMatrix *= rotationZMatrix * rotationYMatrix * rotationXMatrix * translationMatrix * scaleMatrix;
            }
        }
    }
    public partial class ScenarioVehicleBlock : IH2ObjectInstance
    {
        ShortBlockIndex1 IH2ObjectInstance.NameIndex
        {
            get { return this.name; }
        }

        ShortBlockIndex1 IH2ObjectInstance.PaletteIndex
        {
            get { return this.type; }
        }

        ScenarioObjectDatumStructBlock IH2ObjectInstance.ObjectDatum
        {
            get { return this.objectData; }
        }

        Matrix4 IH2ObjectInstance.WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translationMatrix = Matrix4.CreateTranslation( objectData.position );
                var rotationXMatrix = Matrix4.CreateRotationX( this.objectData.rotation.Z );
                var rotationYMatrix = Matrix4.CreateRotationY( -this.objectData.rotation.Y );
                var rotationZMatrix = Matrix4.CreateRotationZ( this.objectData.rotation.X );
                var scaleMatrix = Matrix4.CreateScale( this.objectData.scale == 0 ? 1 : this.objectData.scale );
                return worldMatrix *= rotationZMatrix * rotationYMatrix * rotationXMatrix * translationMatrix * scaleMatrix;
            }
        }
    }
    public partial class ScenarioEquipmentBlock : IH2ObjectInstance
    {
        ShortBlockIndex1 IH2ObjectInstance.NameIndex
        {
            get { return this.name; }
        }

        ShortBlockIndex1 IH2ObjectInstance.PaletteIndex
        {
            get { return this.type; }
        }

        ScenarioObjectDatumStructBlock IH2ObjectInstance.ObjectDatum
        {
            get { return this.objectData; }
        }

        Matrix4 IH2ObjectInstance.WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translationMatrix = Matrix4.CreateTranslation( objectData.position );
                var rotationXMatrix = Matrix4.CreateRotationX( this.objectData.rotation.Z );
                var rotationYMatrix = Matrix4.CreateRotationY( -this.objectData.rotation.Y );
                var rotationZMatrix = Matrix4.CreateRotationZ( this.objectData.rotation.X );
                var scaleMatrix = Matrix4.CreateScale( this.objectData.scale == 0 ? 1 : this.objectData.scale );
                return worldMatrix *= rotationZMatrix * rotationYMatrix * rotationXMatrix * translationMatrix * scaleMatrix;
            }
        }
    }
    public partial class ScenarioCrateBlock : IH2ObjectInstance
    {
        ShortBlockIndex1 IH2ObjectInstance.NameIndex
        {
            get { return base.name; }
        }

        ShortBlockIndex1 IH2ObjectInstance.PaletteIndex
        {
            get { return this.type; }
        }

        ScenarioObjectDatumStructBlock IH2ObjectInstance.ObjectDatum
        {
            get { return this.objectData; }
        }

        Matrix4 IH2ObjectInstance.WorldMatrix
        {
            get
            {
                var worldMatrix = Matrix4.Identity;
                var translationMatrix = Matrix4.CreateTranslation( objectData.position );
                var rotationXMatrix = Matrix4.CreateRotationX( this.objectData.rotation.Z );
                var rotationYMatrix = Matrix4.CreateRotationY( -this.objectData.rotation.Y );
                var rotationZMatrix = Matrix4.CreateRotationZ( this.objectData.rotation.X );
                var scaleMatrix = Matrix4.CreateScale( this.objectData.scale == 0 ? 1 : this.objectData.scale );
                return worldMatrix *= rotationZMatrix * rotationYMatrix * rotationXMatrix * translationMatrix * scaleMatrix;
            }
        }
    };
}
