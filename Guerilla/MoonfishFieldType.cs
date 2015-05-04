using System;
using System.Runtime.InteropServices;

namespace Moonfish.Guerilla
{
    public static class MoonfishFieldTypeExtensions
    {
        public static int GetFieldSize(this MoonfishFieldType type)
        {
            switch (type)
            {
                    #region Standard Types

                case MoonfishFieldType.FieldCharInteger:
                case MoonfishFieldType.FieldCharEnum:
                case MoonfishFieldType.FieldByteFlags:
                case MoonfishFieldType.FieldByteBlockFlags:
                case MoonfishFieldType.FieldCharBlockIndex1:
                case MoonfishFieldType.FieldCharBlockIndex2:
                    return 1;
                case MoonfishFieldType.FieldShortInteger:
                case MoonfishFieldType.FieldEnum:
                case MoonfishFieldType.FieldWordFlags:
                case MoonfishFieldType.FieldWordBlockFlags:
                case MoonfishFieldType.FieldShortBlockIndex1:
                case MoonfishFieldType.FieldShortBlockIndex2:
                    return 2;
                case MoonfishFieldType.FieldLongInteger:
                case MoonfishFieldType.FieldLongEnum:
                case MoonfishFieldType.FieldLongFlags:
                case MoonfishFieldType.FieldLongBlockFlags:
                case MoonfishFieldType.FieldLongBlockIndex1:
                case MoonfishFieldType.FieldLongBlockIndex2:
                    return 4;

                    #endregion

                case MoonfishFieldType.FieldString:
                    return 32;
                case MoonfishFieldType.FieldLongString:
                    return 256;
                case MoonfishFieldType.FieldStringId:
                case MoonfishFieldType.FieldOldStringId: //?
                    return 4;

                case MoonfishFieldType.FieldPoint_2D:
                    return 4;

                case MoonfishFieldType.FieldRectangle_2D:
                    return 8;

                    #region Real, Vector, Point, Angle Types

                case MoonfishFieldType.FieldReal:
                case MoonfishFieldType.FieldAngle:
                case MoonfishFieldType.FieldRealFraction:
                    return 4;
                case MoonfishFieldType.FieldRealPoint_2D:
                case MoonfishFieldType.FieldRealVector_2D:
                case MoonfishFieldType.FieldRealEulerAngles_2D:
                    return 8;
                case MoonfishFieldType.FieldRealPoint_3D:
                case MoonfishFieldType.FieldRealVector_3D:
                case MoonfishFieldType.FieldRealEulerAngles_3D:
                    return 12;
                case MoonfishFieldType.FieldRealQuaternion:
                    return 16;
                case MoonfishFieldType.FieldRealPlane_2D:
                    return 12;
                case MoonfishFieldType.FieldRealPlane_3D:
                    return 16;

                    #endregion

                    #region Colour Types

                case MoonfishFieldType.FieldRgbColor:
                    return 3;
                case MoonfishFieldType.FieldArgbColor:
                    return 4;
                case MoonfishFieldType.FieldRealRgbColor:
                case MoonfishFieldType.FieldRealHsvColor:
                    return 12;
                case MoonfishFieldType.FieldRealArgbColor:
                case MoonfishFieldType.FieldRealAhsvColor:
                    return 16;

                    #endregion

                    #region Bounds

                case MoonfishFieldType.FieldShortBounds:
                    return 4;
                case MoonfishFieldType.FieldAngleBounds:
                case MoonfishFieldType.FieldRealBounds:
                case MoonfishFieldType.FieldRealFractionBounds:
                    return 8;

                    #endregion

                case MoonfishFieldType.FieldTag:
                    return 4;
                case MoonfishFieldType.FieldTagReference:
                case MoonfishFieldType.FieldBlock:
                case MoonfishFieldType.FieldData:
                    return 8;

                case MoonfishFieldType.FieldVertexBuffer:
                    return 32;

                case MoonfishFieldType.FieldMoonfishIdent:
                    return Marshal.SizeOf(typeof (Moonfish.Tags.TagIdent));

                case MoonfishFieldType.FieldUselessPad:
                case MoonfishFieldType.FieldArrayStart:
                case MoonfishFieldType.FieldArrayEnd:
                case MoonfishFieldType.FieldExplanation:
                case MoonfishFieldType.FieldTerminator:
                case MoonfishFieldType.FieldCustom:
                    return 0;
            }
            throw new Exception();
        }
    }

    public enum MoonfishFieldType : short
    {
        FieldString,
        FieldLongString,
        FieldStringId,
        FieldOldStringId,
        FieldCharInteger,
        FieldShortInteger,
        FieldLongInteger,
        FieldAngle,
        FieldTag,
        FieldCharEnum,
        FieldEnum,
        FieldLongEnum,
        FieldLongFlags,
        FieldWordFlags,
        FieldByteFlags,
        FieldPoint_2D,
        FieldRectangle_2D,
        FieldRgbColor,
        FieldArgbColor,
        FieldReal,
        FieldRealFraction,
        FieldRealPoint_2D,
        FieldRealPoint_3D,
        FieldRealVector_2D,
        FieldRealVector_3D,
        FieldRealQuaternion,
        FieldRealEulerAngles_2D,
        FieldRealEulerAngles_3D,
        FieldRealPlane_2D,
        FieldRealPlane_3D,
        FieldRealRgbColor,
        FieldRealArgbColor,
        FieldRealHsvColor,
        FieldRealAhsvColor,
        FieldShortBounds,
        FieldAngleBounds,
        FieldRealBounds,
        FieldRealFractionBounds,
        FieldTagReference,
        FieldBlock,
        FieldLongBlockFlags,
        FieldWordBlockFlags,
        FieldByteBlockFlags,
        FieldCharBlockIndex1,
        FieldCharBlockIndex2,
        FieldShortBlockIndex1,
        FieldShortBlockIndex2,
        FieldLongBlockIndex1,
        FieldLongBlockIndex2,
        FieldData,
        FieldVertexBuffer,
        FieldArrayStart,
        FieldArrayEnd,
        FieldPad,
        FieldUselessPad,
        FieldSkip,
        FieldExplanation,
        FieldCustom,
        FieldStruct,
        FieldTerminator,

        FieldMoonfishIdent,

        FieldTypeMax,
    }
}