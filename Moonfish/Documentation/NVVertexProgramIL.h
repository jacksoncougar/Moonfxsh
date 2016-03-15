#include "standard-types.hsl"

#pragma displayname("Dp4") ;
#pragma fileextensions(".xvu;") ;

typedef struct NVVertexProgramIL {
	//	Holds looping codes: 
	//	TODO: finish mapping this DWORD
	unsigned int DWORD0 : 32;

	// DWORD 1
	// SRC 0 : msbs
	unsigned enum _SRC0_REG_SWZ_W {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC0_REG_SWZ_W: 2;
	unsigned enum _SRC0_REG_SWZ_Z {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC0_REG_SWZ_Z: 2;
	unsigned enum _SRC0_REG_SWZ_Y {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC0_REG_SWZ_Y: 2;
	unsigned enum _SRC0_REG_SWZ_X {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC0_REG_SWZ_X: 2;
	unsigned int SRC0_NEGATE : 1;

	//	Attribute index for a shader input register
	unsigned int INST_INPUT_SRC : 4;
	//  Constant index for a shader constant register
	unsigned int INST_CONST_SRC : 8;
	//	Vector Opcodes
	unsigned enum INST_VEC_OPCODE {
		INST_OP_NOP = 0x00,
		INST_OP_MOV = 0x01,
		INST_OP_MUL = 0x02,
		INST_OP_ADD = 0x03,
		INST_OP_MAD = 0x04,
		INST_OP_DP3 = 0x05,
		INST_OP_DP4 = 0x07,
		INST_OP_DPH = 0x06,
		INST_OP_DST = 0x08,
		INST_OP_MIN = 0x09,
		INST_OP_MAX = 0x0A,
		INST_OP_SLT = 0x0B,
		INST_OP_SGE = 0x0C,
		INST_OP_ARL = 0x0D,
		INST_OP_FRC = 0x0E,
		INST_OP_FLR = 0x0F,
		INST_OP_SEQ = 0x10,
		INST_OP_SFL = 0x11,
		INST_OP_SGT = 0x12,
		INST_OP_SLE = 0x13,
		INST_OP_SNE = 0x14,
		INST_OP_STR = 0x15,
		INST_OP_SSG = 0x16,
		INST_OP_ARR = 0x17,
		INST_OP_ARA = 0x18,
		INST_OP_TXWHAT = 0x19
	} : 4;

	// Scaler Opcode
	unsigned enum _INST_SCA_OPCODE {
		INST_OP_NOP = 0x00,
		INST_OP_MOV = 0x01,
		INST_OP_RCP = 0x02,
		INST_OP_RCC = 0x03,
		INST_OP_RSQ = 0x04,
		INST_OP_EXP = 0x05,
		INST_OP_LOG = 0x06,
		INST_OP_LIT = 0x07,
	} INST_SCA_OPCODE : 7;


	// Source register mapping for OpCodes
	//
	// OP       Src0	Src1	Src2 
	// NOP		false	false	false 
	// MOV		false	false	true 
	// RCP		false	false	true 
	// RCC		false	false	true 
	// RSQ		false	false	true 
	// EXP		false	false	true 
	// LOG		false	false	true 
	// LIT		false	false	true 


	// OP		Src0	Src1	Src2 
	// NOP		false	false	false 
	// MOV		true	false	false 
	// MUL		true	true	false 
	// ADD		true	false	true  
	// MAD		true	true	true  
	// DP3		true	true	false 
	// DPH		true	true	false 
	// DP4		true	true	false 
	// DST		true	true	false 
	// MIN		true	true	false 
	// MAX		true	true	false 
	// SLT		true	true	false 
	// SGE		true	true	false 
	// ARL		true	false	false 

	// DWORD 2
	unsigned int SRC2_REG_TEMP_ID : 2;
	unsigned enum _SRC2_REG_SWZ_W {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC2_REG_SWZ_W: 2;
	unsigned enum _SRC2_REG_SWZ_Z {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC2_REG_SWZ_Z: 2;
	unsigned enum _SRC2_REG_SWZ_Y {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC2_REG_SWZ_Y: 2;
	unsigned enum _SRC2_REG_SWZ_X {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC2_REG_SWZ_X: 2;
	unsigned int SRC2_NEGATE : 1;

	unsigned int SRC1_REG_TYPE : 2;
	unsigned int SRC1_REG_TEMP_ID : 4;
	unsigned enum _SRC1_REG_SWZ_W {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC1_REG_SWZ_W: 2;
	unsigned enum _SRC1_REG_SWZ_Z {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC1_REG_SWZ_Z: 2;
	unsigned enum _SRC1_REG_SWZ_Y {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC1_REG_SWZ_Y: 2;
	unsigned enum _SRC1_REG_SWZ_X {
		X = 0, Y = 1, Z = 2, W = 3
	} SRC1_REG_SWZ_X: 2;
	unsigned int SRC1_NEGATE : 1;

	unsigned int SRC0_REG_TYPE : 2;
	unsigned int SRC0_REG_TEMP_ID : 4;

	// DWORD 3 
	unsigned int INST_LAST : 1;
	unsigned int INST_INDEX_CONST : 1;
	unsigned int INST_INDEX_CONST1 : 1;
	unsigned enum INST_VEC_DEST_MASK {
		INST_DEST_POS = 0,					//oPos

		INST_DEST_COL0 = 3,					//oD0
		INST_DEST_COL1 = 4,					//oD1?
		INST_DEST_FOGC = 5,					//oFog
		INST_DEST_PSZ = 6,					//oPts
		INST_DEST_BFC0 = 7,					//oB0
		INST_DEST_BFC1 = 8,					//oB1?
		INST_DEST_TC0 = 9,					//oT0
		INST_DEST_TC1 = 10,					//oT1
		INST_DEST_TC2 = 11,					//oT2
		INST_DEST_TC3 = 12,					//oT3

		INST_DEST_TEMP = 0xFF,				//r*
	} : 8;
	unsigned int INST_SCA_RESULT : 1; //?

	//	0x0C
	//	Used by Vector Opcodes or zero
	unsigned int INST_VEC_DEST_WRITEMASK_W : 1;
	unsigned int INST_VEC_DEST_WRITEMASK_Z : 1;
	unsigned int INST_VEC_DEST_WRITEMASK_Y : 1;
	unsigned int INST_VEC_DEST_WRITEMASK_X : 1;

	//	Used by Scalar Opcodes or zero
	unsigned int INST_SCA_DEST_WRITEMASK_W : 1;
	unsigned int INST_SCA_DEST_WRITEMASK_Z : 1;
	unsigned int INST_SCA_DEST_WRITEMASK_Y : 1;
	unsigned int INST_SCA_DEST_WRITEMASK_X : 1;
	//0x1F

	//	TODO : Why doesn't this make sense?
	unsigned int INST_REGISTER : 4;

	//	Write masks used when destination is a temp register
	unsigned int INST_REG_DEST_WRITEMASK_W : 1;
	unsigned int INST_REG_DEST_WRITEMASK_Z : 1;
	unsigned int INST_REG_DEST_WRITEMASK_Y : 1;
	unsigned int INST_REG_DEST_WRITEMASK_X : 1;

	//	Src2
	unsigned int SRC2_REG_TEMP_TYPE : 2;
	unsigned int SRC2_REG_TEMP_TYPE : 2;


} NVASM;
