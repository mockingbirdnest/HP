
using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using Mockingbird.HP.Class_Library;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace Mockingbird.HP.Parser
{

   public enum SymbolConstants : int
    {
        SYMBOL_EOF                    = 0  , // (EOF)
        SYMBOL_ERROR                  = 1  , // (Error)
        SYMBOL_WHITESPACE             = 2  , // (Whitespace)
        SYMBOL_A67                    = 3  , // 'A67'
        SYMBOL_A97                    = 4  , // 'A97'
        SYMBOL_ADDITION35             = 5  , // 'Addition35'
        SYMBOL_ADDITION67             = 6  , // 'Addition67'
        SYMBOL_ADDITION97             = 7  , // 'Addition97'
        SYMBOL_ARC35                  = 8  , // 'Arc35'
        SYMBOL_B67                    = 9  , // 'B67'
        SYMBOL_B97                    = 10 , // 'B97'
        SYMBOL_BST97                  = 11 , // 'Bst97'
        SYMBOL_C67                    = 12 , // 'C67'
        SYMBOL_C97                    = 13 , // 'C97'
        SYMBOL_CHS35                  = 14 , // 'Chs35'
        SYMBOL_CHS67                  = 15 , // 'Chs67'
        SYMBOL_CHS97                  = 16 , // 'Chs97'
        SYMBOL_CLR35                  = 17 , // 'Clr35'
        SYMBOL_CLX35                  = 18 , // 'Clx35'
        SYMBOL_CLX67                  = 19 , // 'Clx67'
        SYMBOL_CLX97                  = 20 , // 'Clx97'
        SYMBOL_COS35                  = 21 , // 'Cos35'
        SYMBOL_COS97                  = 22 , // 'Cos97'
        SYMBOL_D67                    = 23 , // 'D67'
        SYMBOL_D97                    = 24 , // 'D97'
        SYMBOL_DISPLAY_X97            = 25 , // 'Display_X97'
        SYMBOL_DIVISION35             = 26 , // 'Division35'
        SYMBOL_DIVISION67             = 27 , // 'Division67'
        SYMBOL_DIVISION97             = 28 , // 'Division97'
        SYMBOL_DSP67                  = 29 , // 'Dsp67'
        SYMBOL_DSP97                  = 30 , // 'Dsp97'
        SYMBOL_E67                    = 31 , // 'E67'
        SYMBOL_E97                    = 32 , // 'E97'
        SYMBOL_EEX35                  = 33 , // 'Eex35'
        SYMBOL_EEX67                  = 34 , // 'Eex67'
        SYMBOL_EEX97                  = 35 , // 'Eex97'
        SYMBOL_EIGHT35                = 36 , // 'Eight35'
        SYMBOL_EIGHT67                = 37 , // 'Eight67'
        SYMBOL_EIGHT97                = 38 , // 'Eight97'
        SYMBOL_ENG97                  = 39 , // 'Eng97'
        SYMBOL_ENTER35                = 40 , // 'Enter35'
        SYMBOL_ENTER67                = 41 , // 'Enter67'
        SYMBOL_ENTER97                = 42 , // 'Enter97'
        SYMBOL_EXP35                  = 43 , // 'Exp35'
        SYMBOL_EXP97                  = 44 , // 'Exp97'
        SYMBOL_F67                    = 45 , // 'f67'
        SYMBOL_F97                    = 46 , // 'f97'
        SYMBOL_FIVE35                 = 47 , // 'Five35'
        SYMBOL_FIVE67                 = 48 , // 'Five67'
        SYMBOL_FIVE97                 = 49 , // 'Five97'
        SYMBOL_FIX97                  = 50 , // 'Fix97'
        SYMBOL_FOUR35                 = 51 , // 'Four35'
        SYMBOL_FOUR67                 = 52 , // 'Four67'
        SYMBOL_FOUR97                 = 53 , // 'Four97'
        SYMBOL_G67                    = 54 , // 'g67'
        SYMBOL_GSB97                  = 55 , // 'Gsb97'
        SYMBOL_GTO67                  = 56 , // 'Gto67'
        SYMBOL_GTO97                  = 57 , // 'Gto97'
        SYMBOL_H67                    = 58 , // 'h67'
        SYMBOL_I97                    = 59 , // 'I97'
        SYMBOL_LBL97                  = 60 , // 'Lbl97'
        SYMBOL_LN35                   = 61 , // 'Ln35'
        SYMBOL_LN97                   = 62 , // 'Ln97'
        SYMBOL_LOG35                  = 63 , // 'Log35'
        SYMBOL_MULTIPLICATION35       = 64 , // 'Multiplication35'
        SYMBOL_MULTIPLICATION67       = 65 , // 'Multiplication67'
        SYMBOL_MULTIPLICATION97       = 66 , // 'Multiplication97'
        SYMBOL_NINE35                 = 67 , // 'Nine35'
        SYMBOL_NINE67                 = 68 , // 'Nine67'
        SYMBOL_NINE97                 = 69 , // 'Nine97'
        SYMBOL_ONE35                  = 70 , // 'One35'
        SYMBOL_ONE67                  = 71 , // 'One67'
        SYMBOL_ONE97                  = 72 , // 'One97'
        SYMBOL_PERCENT97              = 73 , // 'Percent97'
        SYMBOL_PERIOD35               = 74 , // 'Period35'
        SYMBOL_PERIOD67               = 75 , // 'Period67'
        SYMBOL_PERIOD97               = 76 , // 'Period97'
        SYMBOL_PI35                   = 77 , // 'Pi35'
        SYMBOL_R_DOWN35               = 78 , // 'R_Down35'
        SYMBOL_R_DOWN97               = 79 , // 'R_Down97'
        SYMBOL_R_S67                  = 80 , // 'R_S67'
        SYMBOL_R_S97                  = 81 , // 'R_S97'
        SYMBOL_RCL35                  = 82 , // 'Rcl35'
        SYMBOL_RCL67                  = 83 , // 'Rcl67'
        SYMBOL_RCL97                  = 84 , // 'Rcl97'
        SYMBOL_RECIPROCAL35           = 85 , // 'Reciprocal35'
        SYMBOL_RECIPROCAL97           = 86 , // 'Reciprocal97'
        SYMBOL_RTN97                  = 87 , // 'Rtn97'
        SYMBOL_SCI97                  = 88 , // 'Sci97'
        SYMBOL_SEVEN35                = 89 , // 'Seven35'
        SYMBOL_SEVEN67                = 90 , // 'Seven67'
        SYMBOL_SEVEN97                = 91 , // 'Seven97'
        SYMBOL_SIGMA_PLUS67           = 92 , // 'Sigma_Plus67'
        SYMBOL_SIGMA_PLUS97           = 93 , // 'Sigma_Plus97'
        SYMBOL_SIN35                  = 94 , // 'Sin35'
        SYMBOL_SIN97                  = 95 , // 'Sin97'
        SYMBOL_SIX35                  = 96 , // 'Six35'
        SYMBOL_SIX67                  = 97 , // 'Six67'
        SYMBOL_SIX97                  = 98 , // 'Six97'
        SYMBOL_SQRT35                 = 99 , // 'Sqrt35'
        SYMBOL_SQRT97                 = 100, // 'Sqrt97'
        SYMBOL_SQUARE97               = 101, // 'Square97'
        SYMBOL_SST67                  = 102, // 'Sst67'
        SYMBOL_SST97                  = 103, // 'Sst97'
        SYMBOL_STO35                  = 104, // 'Sto35'
        SYMBOL_STO67                  = 105, // 'Sto67'
        SYMBOL_STO97                  = 106, // 'Sto97'
        SYMBOL_SUB_I67                = 107, // 'Sub_I67'
        SYMBOL_SUB_I97                = 108, // 'Sub_I97'
        SYMBOL_SUBTRACTION35          = 109, // 'Subtraction35'
        SYMBOL_SUBTRACTION67          = 110, // 'Subtraction67'
        SYMBOL_SUBTRACTION97          = 111, // 'Subtraction97'
        SYMBOL_TAN35                  = 112, // 'Tan35'
        SYMBOL_TAN97                  = 113, // 'Tan97'
        SYMBOL_THREE35                = 114, // 'Three35'
        SYMBOL_THREE67                = 115, // 'Three67'
        SYMBOL_THREE97                = 116, // 'Three97'
        SYMBOL_TO_POLAR97             = 117, // 'To_Polar97'
        SYMBOL_TO_RECTANGULAR97       = 118, // 'To_Rectangular97'
        SYMBOL_TWO35                  = 119, // 'Two35'
        SYMBOL_TWO67                  = 120, // 'Two67'
        SYMBOL_TWO97                  = 121, // 'Two97'
        SYMBOL_X_EXCHANGE_Y35         = 122, // 'X_Exchange_Y35'
        SYMBOL_X_EXCHANGE_Y97         = 123, // 'X_Exchange_Y97'
        SYMBOL_X_TO_THE_YTH35         = 124, // 'X_To_The_Yth35'
        SYMBOL_Y_TO_THE_XTH97         = 125, // 'Y_To_The_Xth97'
        SYMBOL_ZERO35                 = 126, // 'Zero35'
        SYMBOL_ZERO67                 = 127, // 'Zero67'
        SYMBOL_ZERO97                 = 128, // 'Zero97'
        SYMBOL_A                      = 129, // <A>
        SYMBOL_ABS                    = 130, // <Abs>
        SYMBOL_ADDITION               = 131, // <Addition>
        SYMBOL_ARCCOS                 = 132, // <Arccos>
        SYMBOL_ARCSIN                 = 133, // <Arcsin>
        SYMBOL_ARCTAN                 = 134, // <Arctan>
        SYMBOL_B                      = 135, // <B>
        SYMBOL_BINARY_INSTRUCTION     = 136, // <Binary_Instruction>
        SYMBOL_BST                    = 137, // <Bst>
        SYMBOL_C                      = 138, // <C>
        SYMBOL_CF                     = 139, // <CF>
        SYMBOL_CHS                    = 140, // <Chs>
        SYMBOL_CL_PRGM                = 141, // <Cl_Prgm>
        SYMBOL_CL_REG                 = 142, // <Cl_Reg>
        SYMBOL_CLR                    = 143, // <Clr>
        SYMBOL_CLX                    = 144, // <Clx>
        SYMBOL_COS                    = 145, // <Cos>
        SYMBOL_D                      = 146, // <D>
        SYMBOL_DEG                    = 147, // <Deg>
        SYMBOL_DEL                    = 148, // <Del>
        SYMBOL_DIGIT                  = 149, // <Digit>
        SYMBOL_DIGIT_COUNT            = 150, // <Digit_Count>
        SYMBOL_DIGIT_LABEL            = 151, // <Digit_Label>
        SYMBOL_DISPLAY_X              = 152, // <Display_X>
        SYMBOL_DIVISION               = 153, // <Division>
        SYMBOL_DSP                    = 154, // <Dsp>
        SYMBOL_DSZ                    = 155, // <Dsz>
        SYMBOL_DSZ_SUB_I              = 156, // <Dsz_Sub_I>
        SYMBOL_E                      = 157, // <E>
        SYMBOL_EEX                    = 158, // <Eex>
        SYMBOL_EIGHT                  = 159, // <Eight>
        SYMBOL_ENG                    = 160, // <Eng>
        SYMBOL_ENTER                  = 161, // <Enter>
        SYMBOL_EXP                    = 162, // <Exp>
        SYMBOL_F                      = 163, // <f>
        SYMBOL_F_TEST                 = 164, // <F_Test>
        SYMBOL_FACTORIAL              = 165, // <Factorial>
        SYMBOL_FIVE                   = 166, // <Five>
        SYMBOL_FIX                    = 167, // <Fix>
        SYMBOL_FLAG                   = 168, // <Flag>
        SYMBOL_FOUR                   = 169, // <Four>
        SYMBOL_FRAC                   = 170, // <Frac>
        SYMBOL_GRD                    = 171, // <Grd>
        SYMBOL_GSB                    = 172, // <Gsb>
        SYMBOL_GSB_LC_67              = 173, // <Gsb_LC_67>
        SYMBOL_GSB_LC_SHORTCUT        = 174, // <Gsb_LC_Shortcut>
        SYMBOL_GSB_UC_SHORTCUT        = 175, // <Gsb_UC_Shortcut>
        SYMBOL_GTO                    = 176, // <Gto>
        SYMBOL_GTO_PERIOD             = 177, // <Gto_Period>
        SYMBOL_HMS_PLUS               = 178, // <HMS_Plus>
        SYMBOL_I                      = 179, // <I>
        SYMBOL_INSTRUCTION            = 180, // <Instruction>
        SYMBOL_INT                    = 181, // <Int>
        SYMBOL_ISZ                    = 182, // <Isz>
        SYMBOL_ISZ_SUB_I              = 183, // <Isz_Sub_I>
        SYMBOL_LABEL                  = 184, // <Label>
        SYMBOL_LBL                    = 185, // <Lbl>
        SYMBOL_LBL_LC_67              = 186, // <Lbl_LC_67>
        SYMBOL_LC_A                   = 187, // <LC_a>
        SYMBOL_LC_B                   = 188, // <LC_b>
        SYMBOL_LC_C                   = 189, // <LC_c>
        SYMBOL_LC_D                   = 190, // <LC_d>
        SYMBOL_LC_E                   = 191, // <LC_e>
        SYMBOL_LETTER_LABEL           = 192, // <Letter_Label>
        SYMBOL_LN                     = 193, // <Ln>
        SYMBOL_LOG                    = 194, // <Log>
        SYMBOL_LOWERCASE_LETTER_LABEL = 195, // <Lowercase_Letter_Label>
        SYMBOL_LST_X                  = 196, // <Lst_X>
        SYMBOL_MEMORY                 = 197, // <Memory>
        SYMBOL_MERGE                  = 198, // <Merge>
        SYMBOL_MULTIPLICATION         = 199, // <Multiplication>
        SYMBOL_NINE                   = 200, // <Nine>
        SYMBOL_NULLARY_INSTRUCTION    = 201, // <Nullary_Instruction>
        SYMBOL_ONE                    = 202, // <One>
        SYMBOL_OPERABLE_MEMORY        = 203, // <Operable_Memory>
        SYMBOL_OPERATOR               = 204, // <Operator>
        SYMBOL_P_EXCHANGE_S           = 205, // <P_Exchange_S>
        SYMBOL_PAUSE                  = 206, // <Pause>
        SYMBOL_PERCENT                = 207, // <Percent>
        SYMBOL_PERCENT_CHANGE         = 208, // <Percent_Change>
        SYMBOL_PERIOD                 = 209, // <Period>
        SYMBOL_PI                     = 210, // <Pi>
        SYMBOL_PRINT_PRGM             = 211, // <Print_Prgm>
        SYMBOL_R_DOWN                 = 212, // <R_Down>
        SYMBOL_R_S                    = 213, // <R_S>
        SYMBOL_R_UP                   = 214, // <R_Up>
        SYMBOL_RAD                    = 215, // <Rad>
        SYMBOL_RC_I_67                = 216, // <Rc_I_67>
        SYMBOL_RCL                    = 217, // <Rcl>
        SYMBOL_RCL_I_SHORTCUT         = 218, // <Rcl_I_Shortcut>
        SYMBOL_RCL_NULLARY            = 219, // <Rcl_Nullary>
        SYMBOL_RCL_SIGMA_PLUS         = 220, // <Rcl_Sigma_Plus>
        SYMBOL_RCL_SUB_I_SHORTCUT     = 221, // <Rcl_Sub_I_Shortcut>
        SYMBOL_RECIPROCAL             = 222, // <Reciprocal>
        SYMBOL_REG                    = 223, // <Reg>
        SYMBOL_RND                    = 224, // <Rnd>
        SYMBOL_RTN                    = 225, // <Rtn>
        SYMBOL_S                      = 226, // <S>
        SYMBOL_SCI                    = 227, // <Sci>
        SYMBOL_SEVEN                  = 228, // <Seven>
        SYMBOL_SF                     = 229, // <SF>
        SYMBOL_SIGMA_MINUS            = 230, // <Sigma_Minus>
        SYMBOL_SIGMA_PLUS             = 231, // <Sigma_Plus>
        SYMBOL_SIN                    = 232, // <Sin>
        SYMBOL_SIX                    = 233, // <Six>
        SYMBOL_SPACE                  = 234, // <Space>
        SYMBOL_SQRT                   = 235, // <Sqrt>
        SYMBOL_SQUARE                 = 236, // <Square>
        SYMBOL_SST                    = 237, // <Sst>
        SYMBOL_ST_I_67                = 238, // <St_I_67>
        SYMBOL_STK                    = 239, // <Stk>
        SYMBOL_STO                    = 240, // <Sto>
        SYMBOL_STO_NULLARY            = 241, // <Sto_Nullary>
        SYMBOL_SUB_I                  = 242, // <Sub_I>
        SYMBOL_SUBTRACTION            = 243, // <Subtraction>
        SYMBOL_TAN                    = 244, // <Tan>
        SYMBOL_TEN_TO_THE_XTH         = 245, // <Ten_To_The_Xth>
        SYMBOL_TERNARY_INSTRUCTION    = 246, // <Ternary_Instruction>
        SYMBOL_THREE                  = 247, // <Three>
        SYMBOL_TO_DEGREES             = 248, // <To_Degrees>
        SYMBOL_TO_HMS                 = 249, // <To_HMS>
        SYMBOL_TO_HOURS               = 250, // <To_Hours>
        SYMBOL_TO_POLAR               = 251, // <To_Polar>
        SYMBOL_TO_RADIANS             = 252, // <To_Radians>
        SYMBOL_TO_RECTANGULAR         = 253, // <To_Rectangular>
        SYMBOL_TWO                    = 254, // <Two>
        SYMBOL_UNARY_INSTRUCTION      = 255, // <Unary_Instruction>
        SYMBOL_UPPERCASE_LETTER       = 256, // <Uppercase_Letter>
        SYMBOL_UPPERCASE_LETTER_LABEL = 257, // <Uppercase_Letter_Label>
        SYMBOL_W_DATA                 = 258, // <W_Data>
        SYMBOL_X_AVERAGE              = 259, // <X_Average>
        SYMBOL_X_EQ_0                 = 260, // <X_EQ_0>
        SYMBOL_X_EQ_Y                 = 261, // <X_EQ_Y>
        SYMBOL_X_EXCHANGE_I           = 262, // <X_Exchange_I>
        SYMBOL_X_EXCHANGE_Y           = 263, // <X_Exchange_Y>
        SYMBOL_X_GT_0                 = 264, // <X_GT_0>
        SYMBOL_X_GT_Y                 = 265, // <X_GT_Y>
        SYMBOL_X_LE_Y                 = 266, // <X_LE_Y>
        SYMBOL_X_LT_0                 = 267, // <X_LT_0>
        SYMBOL_X_NE_0                 = 268, // <X_NE_0>
        SYMBOL_X_NE_Y                 = 269, // <X_NE_Y>
        SYMBOL_X_TO_THE_YTH           = 270, // <X_To_The_Yth>
        SYMBOL_Y_TO_THE_XTH           = 271, // <Y_To_The_Xth>
        SYMBOL_ZERO                   = 272  // <Zero>
    };

    enum RuleConstants : int
    {
        RULE_A_A67                           = 0  , // <A> ::= 'A67'
        RULE_A_A97                           = 1  , // <A> ::= 'A97'
        RULE_ABS_H67_SIX67                   = 2  , // <Abs> ::= 'h67' 'Six67'
        RULE_ABS_F97_Y_TO_THE_XTH97          = 3  , // <Abs> ::= 'f97' 'Y_To_The_Xth97'
        RULE_ADDITION_ADDITION35             = 4  , // <Addition> ::= 'Addition35'
        RULE_ADDITION_ADDITION67             = 5  , // <Addition> ::= 'Addition67'
        RULE_ADDITION_ADDITION97             = 6  , // <Addition> ::= 'Addition97'
        RULE_ARCCOS_ARC35_COS35              = 7  , // <Arccos> ::= 'Arc35' 'Cos35'
        RULE_ARCCOS_G67_FIVE67               = 8  , // <Arccos> ::= 'g67' 'Five67'
        RULE_ARCCOS_F97_COS97                = 9  , // <Arccos> ::= 'f97' 'Cos97'
        RULE_ARCSIN_ARC35_SIN35              = 10 , // <Arcsin> ::= 'Arc35' 'Sin35'
        RULE_ARCSIN_G67_FOUR67               = 11 , // <Arcsin> ::= 'g67' 'Four67'
        RULE_ARCSIN_F97_SIN97                = 12 , // <Arcsin> ::= 'f97' 'Sin97'
        RULE_ARCTAN_ARC35_TAN35              = 13 , // <Arctan> ::= 'Arc35' 'Tan35'
        RULE_ARCTAN_G67_SIX67                = 14 , // <Arctan> ::= 'g67' 'Six67'
        RULE_ARCTAN_F97_TAN97                = 15 , // <Arctan> ::= 'f97' 'Tan97'
        RULE_B_B67                           = 16 , // <B> ::= 'B67'
        RULE_B_B97                           = 17 , // <B> ::= 'B97'
        RULE_BST_H67_SST67                   = 18 , // <Bst> ::= 'h67' 'Sst67'
        RULE_BST_BST97                       = 19 , // <Bst> ::= 'Bst97'
        RULE_C_C67                           = 20 , // <C> ::= 'C67'
        RULE_C_C97                           = 21 , // <C> ::= 'C97'
        RULE_CF_H67_ADDITION67               = 22 , // <CF> ::= 'h67' 'Addition67'
        RULE_CF_F97_GTO97                    = 23 , // <CF> ::= 'f97' 'Gto97'
        RULE_CHS_CHS35                       = 24 , // <Chs> ::= 'Chs35'
        RULE_CHS_CHS67                       = 25 , // <Chs> ::= 'Chs67'
        RULE_CHS_CHS97                       = 26 , // <Chs> ::= 'Chs97'
        RULE_CL_PRGM_F67_CLX67               = 27 , // <Cl_Prgm> ::= 'f67' 'Clx67'
        RULE_CL_PRGM_F97_THREE97             = 28 , // <Cl_Prgm> ::= 'f97' 'Three97'
        RULE_CL_REG_F67_EEX67                = 29 , // <Cl_Reg> ::= 'f67' 'Eex67'
        RULE_CL_REG_F97_TWO97                = 30 , // <Cl_Reg> ::= 'f97' 'Two97'
        RULE_CLR_CLR35                       = 31 , // <Clr> ::= 'Clr35'
        RULE_CLX_CLX35                       = 32 , // <Clx> ::= 'Clx35'
        RULE_CLX_CLX67                       = 33 , // <Clx> ::= 'Clx67'
        RULE_CLX_CLX97                       = 34 , // <Clx> ::= 'Clx97'
        RULE_COS_COS35                       = 35 , // <Cos> ::= 'Cos35'
        RULE_COS_F67_FIVE67                  = 36 , // <Cos> ::= 'f67' 'Five67'
        RULE_COS_COS97                       = 37 , // <Cos> ::= 'Cos97'
        RULE_D_D67                           = 38 , // <D> ::= 'D67'
        RULE_D_D97                           = 39 , // <D> ::= 'D97'
        RULE_DEG_H67_ENTER67                 = 40 , // <Deg> ::= 'h67' 'Enter67'
        RULE_DEG_F97_ENTER97                 = 41 , // <Deg> ::= 'f97' 'Enter97'
        RULE_DEL_H67_CLX67                   = 42 , // <Del> ::= 'h67' 'Clx67'
        RULE_DEL_F97_ONE97                   = 43 , // <Del> ::= 'f97' 'One97'
        RULE_DISPLAY_X_F67_R_S67             = 44 , // <Display_X> ::= 'f67' 'R_S67'
        RULE_DISPLAY_X_DISPLAY_X97           = 45 , // <Display_X> ::= 'Display_X97'
        RULE_DIVISION_DIVISION35             = 46 , // <Division> ::= 'Division35'
        RULE_DIVISION_DIVISION67             = 47 , // <Division> ::= 'Division67'
        RULE_DIVISION_DIVISION97             = 48 , // <Division> ::= 'Division97'
        RULE_DSP_DSP67                       = 49 , // <Dsp> ::= 'Dsp67'
        RULE_DSP_DSP97                       = 50 , // <Dsp> ::= 'Dsp97'
        RULE_DSZ_SUB_I_G67_STO67             = 51 , // <Dsz_Sub_I> ::= 'g67' 'Sto67'
        RULE_DSZ_SUB_I_F97_BST97_SUB_I97     = 52 , // <Dsz_Sub_I> ::= 'f97' 'Bst97' 'Sub_I97'
        RULE_DSZ_F67_STO67                   = 53 , // <Dsz> ::= 'f67' 'Sto67'
        RULE_DSZ_F97_BST97_I97               = 54 , // <Dsz> ::= 'f97' 'Bst97' 'I97'
        RULE_E_E67                           = 55 , // <E> ::= 'E67'
        RULE_E_E97                           = 56 , // <E> ::= 'E97'
        RULE_EEX_EEX35                       = 57 , // <Eex> ::= 'Eex35'
        RULE_EEX_EEX67                       = 58 , // <Eex> ::= 'Eex67'
        RULE_EEX_EEX97                       = 59 , // <Eex> ::= 'Eex97'
        RULE_EIGHT_EIGHT35                   = 60 , // <Eight> ::= 'Eight35'
        RULE_EIGHT_EIGHT67                   = 61 , // <Eight> ::= 'Eight67'
        RULE_EIGHT_EIGHT97                   = 62 , // <Eight> ::= 'Eight97'
        RULE_ENG_H67_DSP67                   = 63 , // <Eng> ::= 'h67' 'Dsp67'
        RULE_ENG_ENG97                       = 64 , // <Eng> ::= 'Eng97'
        RULE_ENTER_ENTER35                   = 65 , // <Enter> ::= 'Enter35'
        RULE_ENTER_ENTER67                   = 66 , // <Enter> ::= 'Enter67'
        RULE_ENTER_ENTER97                   = 67 , // <Enter> ::= 'Enter97'
        RULE_EXP_EXP35                       = 68 , // <Exp> ::= 'Exp35'
        RULE_EXP_G67_SEVEN67                 = 69 , // <Exp> ::= 'g67' 'Seven67'
        RULE_EXP_EXP97                       = 70 , // <Exp> ::= 'Exp97'
        RULE_F_F67                           = 71 , // <f> ::= 'f67'
        RULE_F_F97                           = 72 , // <f> ::= 'f97'
        RULE_F_TEST_H67_MULTIPLICATION67     = 73 , // <F_Test> ::= 'h67' 'Multiplication67'
        RULE_F_TEST_F97_GSB97                = 74 , // <F_Test> ::= 'f97' 'Gsb97'
        RULE_FACTORIAL_H67_DIVISION67        = 75 , // <Factorial> ::= 'h67' 'Division67'
        RULE_FACTORIAL_F97_RECIPROCAL97      = 76 , // <Factorial> ::= 'f97' 'Reciprocal97'
        RULE_FIVE_FIVE35                     = 77 , // <Five> ::= 'Five35'
        RULE_FIVE_FIVE67                     = 78 , // <Five> ::= 'Five67'
        RULE_FIVE_FIVE97                     = 79 , // <Five> ::= 'Five97'
        RULE_FIX_F67_DSP67                   = 80 , // <Fix> ::= 'f67' 'Dsp67'
        RULE_FIX_FIX97                       = 81 , // <Fix> ::= 'Fix97'
        RULE_FOUR_FOUR35                     = 82 , // <Four> ::= 'Four35'
        RULE_FOUR_FOUR67                     = 83 , // <Four> ::= 'Four67'
        RULE_FOUR_FOUR97                     = 84 , // <Four> ::= 'Four97'
        RULE_FRAC_G67_PERIOD67               = 85 , // <Frac> ::= 'g67' 'Period67'
        RULE_FRAC_F97_TO_RECTANGULAR97       = 86 , // <Frac> ::= 'f97' 'To_Rectangular97'
        RULE_GRD_H67_EEX67                   = 87 , // <Grd> ::= 'h67' 'Eex67'
        RULE_GRD_F97_EEX97                   = 88 , // <Grd> ::= 'f97' 'Eex97'
        RULE_GSB_LC_67_G67_GTO67             = 89 , // <Gsb_LC_67> ::= 'g67' 'Gto67'
        RULE_GSB_F67_GTO67                   = 90 , // <Gsb> ::= 'f67' 'Gto67'
        RULE_GSB_GSB97                       = 91 , // <Gsb> ::= 'Gsb97'
        RULE_GTO_GTO67                       = 92 , // <Gto> ::= 'Gto67'
        RULE_GTO_GTO97                       = 93 , // <Gto> ::= 'Gto97'
        RULE_HMS_PLUS_H67_PERIOD67           = 94 , // <HMS_Plus> ::= 'h67' 'Period67'
        RULE_HMS_PLUS_F97_ADDITION97         = 95 , // <HMS_Plus> ::= 'f97' 'Addition97'
        RULE_I_I97                           = 96 , // <I> ::= 'I97'
        RULE_INT_F67_PERIOD67                = 97 , // <Int> ::= 'f67' 'Period67'
        RULE_INT_F97_TO_POLAR97              = 98 , // <Int> ::= 'f97' 'To_Polar97'
        RULE_ISZ_SUB_I_G67_RCL67             = 99 , // <Isz_Sub_I> ::= 'g67' 'Rcl67'
        RULE_ISZ_SUB_I_F97_SST97_SUB_I97     = 100, // <Isz_Sub_I> ::= 'f97' 'Sst97' 'Sub_I97'
        RULE_ISZ_F67_RCL67                   = 101, // <Isz> ::= 'f67' 'Rcl67'
        RULE_ISZ_F97_SST97_I97               = 102, // <Isz> ::= 'f97' 'Sst97' 'I97'
        RULE_LBL_LC_67_G67_SST67             = 103, // <Lbl_LC_67> ::= 'g67' 'Sst67'
        RULE_LBL_F67_SST67                   = 104, // <Lbl> ::= 'f67' 'Sst67'
        RULE_LBL_LBL97                       = 105, // <Lbl> ::= 'Lbl97'
        RULE_LN_LN35                         = 106, // <Ln> ::= 'Ln35'
        RULE_LN_F67_SEVEN67                  = 107, // <Ln> ::= 'f67' 'Seven67'
        RULE_LN_LN97                         = 108, // <Ln> ::= 'Ln97'
        RULE_LOG_LOG35                       = 109, // <Log> ::= 'Log35'
        RULE_LOG_F67_EIGHT67                 = 110, // <Log> ::= 'f67' 'Eight67'
        RULE_LOG_F97_LN97                    = 111, // <Log> ::= 'f97' 'Ln97'
        RULE_LST_X_H67_ZERO67                = 112, // <Lst_X> ::= 'h67' 'Zero67'
        RULE_LST_X_F97_DSP97                 = 113, // <Lst_X> ::= 'f97' 'Dsp97'
        RULE_MERGE_G67_ENTER67               = 114, // <Merge> ::= 'g67' 'Enter67'
        RULE_MERGE_F97_PERIOD97              = 115, // <Merge> ::= 'f97' 'Period97'
        RULE_MULTIPLICATION_MULTIPLICATION35 = 116, // <Multiplication> ::= 'Multiplication35'
        RULE_MULTIPLICATION_MULTIPLICATION67 = 117, // <Multiplication> ::= 'Multiplication67'
        RULE_MULTIPLICATION_MULTIPLICATION97 = 118, // <Multiplication> ::= 'Multiplication97'
        RULE_NINE_NINE35                     = 119, // <Nine> ::= 'Nine35'
        RULE_NINE_NINE67                     = 120, // <Nine> ::= 'Nine67'
        RULE_NINE_NINE97                     = 121, // <Nine> ::= 'Nine97'
        RULE_ONE_ONE35                       = 122, // <One> ::= 'One35'
        RULE_ONE_ONE67                       = 123, // <One> ::= 'One67'
        RULE_ONE_ONE97                       = 124, // <One> ::= 'One97'
        RULE_P_EXCHANGE_S_F67_CHS67          = 125, // <P_Exchange_S> ::= 'f67' 'Chs67'
        RULE_P_EXCHANGE_S_F97_CLX97          = 126, // <P_Exchange_S> ::= 'f97' 'Clx97'
        RULE_PAUSE_H67_ONE67                 = 127, // <Pause> ::= 'h67' 'One67'
        RULE_PAUSE_F97_R_S97                 = 128, // <Pause> ::= 'f97' 'R_S97'
        RULE_PERCENT_CHANGE_G67_ZERO67       = 129, // <Percent_Change> ::= 'g67' 'Zero67'
        RULE_PERCENT_CHANGE_F97_PERCENT97    = 130, // <Percent_Change> ::= 'f97' 'Percent97'
        RULE_PERCENT_F67_ZERO67              = 131, // <Percent> ::= 'f67' 'Zero67'
        RULE_PERCENT_PERCENT97               = 132, // <Percent> ::= 'Percent97'
        RULE_PERIOD_PERIOD35                 = 133, // <Period> ::= 'Period35'
        RULE_PERIOD_PERIOD67                 = 134, // <Period> ::= 'Period67'
        RULE_PERIOD_PERIOD97                 = 135, // <Period> ::= 'Period97'
        RULE_PI_PI35                         = 136, // <Pi> ::= 'Pi35'
        RULE_PI_H67_TWO67                    = 137, // <Pi> ::= 'h67' 'Two67'
        RULE_PI_F97_DIVISION97               = 138, // <Pi> ::= 'f97' 'Division97'
        RULE_PRINT_PRGM_F97_SCI97            = 139, // <Print_Prgm> ::= 'f97' 'Sci97'
        RULE_R_DOWN_R_DOWN35                 = 140, // <R_Down> ::= 'R_Down35'
        RULE_R_DOWN_H67_EIGHT67              = 141, // <R_Down> ::= 'h67' 'Eight67'
        RULE_R_DOWN_R_DOWN97                 = 142, // <R_Down> ::= 'R_Down97'
        RULE_R_S_R_S67                       = 143, // <R_S> ::= 'R_S67'
        RULE_R_S_R_S97                       = 144, // <R_S> ::= 'R_S97'
        RULE_R_UP_H67_NINE67                 = 145, // <R_Up> ::= 'h67' 'Nine67'
        RULE_R_UP_F97_R_DOWN97               = 146, // <R_Up> ::= 'f97' 'R_Down97'
        RULE_RAD_H67_CHS67                   = 147, // <Rad> ::= 'h67' 'Chs67'
        RULE_RAD_F97_CHS97                   = 148, // <Rad> ::= 'f97' 'Chs97'
        RULE_RC_I_67_H67_RCL67               = 149, // <Rc_I_67> ::= 'h67' 'Rcl67'
        RULE_RCL_NULLARY_RCL35               = 150, // <Rcl_Nullary> ::= 'Rcl35'
        RULE_RCL_RCL67                       = 151, // <Rcl> ::= 'Rcl67'
        RULE_RCL_RCL97                       = 152, // <Rcl> ::= 'Rcl97'
        RULE_RECIPROCAL_RECIPROCAL35         = 153, // <Reciprocal> ::= 'Reciprocal35'
        RULE_RECIPROCAL_H67_FOUR67           = 154, // <Reciprocal> ::= 'h67' 'Four67'
        RULE_RECIPROCAL_RECIPROCAL97         = 155, // <Reciprocal> ::= 'Reciprocal97'
        RULE_REG_H67_THREE67                 = 156, // <Reg> ::= 'h67' 'Three67'
        RULE_REG_F97_ENG97                   = 157, // <Reg> ::= 'f97' 'Eng97'
        RULE_RND_F67_SUB_I67                 = 158, // <Rnd> ::= 'f67' 'Sub_I67'
        RULE_RND_F97_RTN97                   = 159, // <Rnd> ::= 'f97' 'Rtn97'
        RULE_RTN_H67_GTO67                   = 160, // <Rtn> ::= 'h67' 'Gto67'
        RULE_RTN_RTN97                       = 161, // <Rtn> ::= 'Rtn97'
        RULE_S_G67_SIGMA_PLUS67              = 162, // <S> ::= 'g67' 'Sigma_Plus67'
        RULE_S_F97_SQRT97                    = 163, // <S> ::= 'f97' 'Sqrt97'
        RULE_SCI_G67_DSP67                   = 164, // <Sci> ::= 'g67' 'Dsp67'
        RULE_SCI_SCI97                       = 165, // <Sci> ::= 'Sci97'
        RULE_SEVEN_SEVEN35                   = 166, // <Seven> ::= 'Seven35'
        RULE_SEVEN_SEVEN67                   = 167, // <Seven> ::= 'Seven67'
        RULE_SEVEN_SEVEN97                   = 168, // <Seven> ::= 'Seven97'
        RULE_SF_H67_SUBTRACTION67            = 169, // <SF> ::= 'h67' 'Subtraction67'
        RULE_SF_F97_LBL97                    = 170, // <SF> ::= 'f97' 'Lbl97'
        RULE_SIGMA_MINUS_H67_SIGMA_PLUS67    = 171, // <Sigma_Minus> ::= 'h67' 'Sigma_Plus67'
        RULE_SIGMA_MINUS_F97_SIGMA_PLUS97    = 172, // <Sigma_Minus> ::= 'f97' 'Sigma_Plus97'
        RULE_SIGMA_PLUS_SIGMA_PLUS67         = 173, // <Sigma_Plus> ::= 'Sigma_Plus67'
        RULE_SIGMA_PLUS_SIGMA_PLUS97         = 174, // <Sigma_Plus> ::= 'Sigma_Plus97'
        RULE_SIN_SIN35                       = 175, // <Sin> ::= 'Sin35'
        RULE_SIN_F67_FOUR67                  = 176, // <Sin> ::= 'f67' 'Four67'
        RULE_SIN_SIN97                       = 177, // <Sin> ::= 'Sin97'
        RULE_SIX_SIX35                       = 178, // <Six> ::= 'Six35'
        RULE_SIX_SIX67                       = 179, // <Six> ::= 'Six67'
        RULE_SIX_SIX97                       = 180, // <Six> ::= 'Six97'
        RULE_SPACE_H67_R_S67                 = 181, // <Space> ::= 'h67' 'R_S67'
        RULE_SPACE_F97_FIX97                 = 182, // <Space> ::= 'f97' 'Fix97'
        RULE_SQRT_SQRT35                     = 183, // <Sqrt> ::= 'Sqrt35'
        RULE_SQRT_F67_NINE67                 = 184, // <Sqrt> ::= 'f67' 'Nine67'
        RULE_SQRT_SQRT97                     = 185, // <Sqrt> ::= 'Sqrt97'
        RULE_SQUARE_G67_NINE67               = 186, // <Square> ::= 'g67' 'Nine67'
        RULE_SQUARE_SQUARE97                 = 187, // <Square> ::= 'Square97'
        RULE_SST_SST67                       = 188, // <Sst> ::= 'Sst67'
        RULE_SST_SST97                       = 189, // <Sst> ::= 'Sst97'
        RULE_STK_G67_R_S67                   = 190, // <Stk> ::= 'g67' 'R_S67'
        RULE_STK_F97_DISPLAY_X97             = 191, // <Stk> ::= 'f97' 'Display_X97'
        RULE_ST_I_67_H67_STO67               = 192, // <St_I_67> ::= 'h67' 'Sto67'
        RULE_STO_NULLARY_STO35               = 193, // <Sto_Nullary> ::= 'Sto35'
        RULE_STO_STO67                       = 194, // <Sto> ::= 'Sto67'
        RULE_STO_STO97                       = 195, // <Sto> ::= 'Sto97'
        RULE_SUB_I_SUB_I67                   = 196, // <Sub_I> ::= 'Sub_I67'
        RULE_SUB_I_SUB_I97                   = 197, // <Sub_I> ::= 'Sub_I97'
        RULE_SUBTRACTION_SUBTRACTION35       = 198, // <Subtraction> ::= 'Subtraction35'
        RULE_SUBTRACTION_SUBTRACTION67       = 199, // <Subtraction> ::= 'Subtraction67'
        RULE_SUBTRACTION_SUBTRACTION97       = 200, // <Subtraction> ::= 'Subtraction97'
        RULE_TAN_TAN35                       = 201, // <Tan> ::= 'Tan35'
        RULE_TAN_F67_SIX67                   = 202, // <Tan> ::= 'f67' 'Six67'
        RULE_TAN_TAN97                       = 203, // <Tan> ::= 'Tan97'
        RULE_TEN_TO_THE_XTH_G67_EIGHT67      = 204, // <Ten_To_The_Xth> ::= 'g67' 'Eight67'
        RULE_TEN_TO_THE_XTH_F97_EXP97        = 205, // <Ten_To_The_Xth> ::= 'f97' 'Exp97'
        RULE_THREE_THREE35                   = 206, // <Three> ::= 'Three35'
        RULE_THREE_THREE67                   = 207, // <Three> ::= 'Three67'
        RULE_THREE_THREE97                   = 208, // <Three> ::= 'Three97'
        RULE_TO_DEGREES_F67_TWO67            = 209, // <To_Degrees> ::= 'f67' 'Two67'
        RULE_TO_DEGREES_F97_I97              = 210, // <To_Degrees> ::= 'f97' 'I97'
        RULE_TO_HMS_G67_THREE67              = 211, // <To_HMS> ::= 'g67' 'Three67'
        RULE_TO_HMS_F97_STO97                = 212, // <To_HMS> ::= 'f97' 'Sto97'
        RULE_TO_HOURS_F67_THREE67            = 213, // <To_Hours> ::= 'f67' 'Three67'
        RULE_TO_HOURS_F97_RCL97              = 214, // <To_Hours> ::= 'f97' 'Rcl97'
        RULE_TO_POLAR_G67_ONE67              = 215, // <To_Polar> ::= 'g67' 'One67'
        RULE_TO_POLAR_TO_POLAR97             = 216, // <To_Polar> ::= 'To_Polar97'
        RULE_TO_RADIANS_G67_TWO67            = 217, // <To_Radians> ::= 'g67' 'Two67'
        RULE_TO_RADIANS_F97_SUB_I97          = 218, // <To_Radians> ::= 'f97' 'Sub_I97'
        RULE_TO_RECTANGULAR_F67_ONE67        = 219, // <To_Rectangular> ::= 'f67' 'One67'
        RULE_TO_RECTANGULAR_TO_RECTANGULAR97 = 220, // <To_Rectangular> ::= 'To_Rectangular97'
        RULE_TWO_TWO35                       = 221, // <Two> ::= 'Two35'
        RULE_TWO_TWO67                       = 222, // <Two> ::= 'Two67'
        RULE_TWO_TWO97                       = 223, // <Two> ::= 'Two97'
        RULE_W_DATA_F67_ENTER67              = 224, // <W_Data> ::= 'f67' 'Enter67'
        RULE_W_DATA_F97_ZERO97               = 225, // <W_Data> ::= 'f97' 'Zero97'
        RULE_X_AVERAGE_F67_SIGMA_PLUS67      = 226, // <X_Average> ::= 'f67' 'Sigma_Plus67'
        RULE_X_AVERAGE_F97_SQUARE97          = 227, // <X_Average> ::= 'f97' 'Square97'
        RULE_X_EQ_0_F67_SUBTRACTION67        = 228, // <X_EQ_0> ::= 'f67' 'Subtraction67'
        RULE_X_EQ_0_F97_FIVE97               = 229, // <X_EQ_0> ::= 'f97' 'Five97'
        RULE_X_EQ_Y_G67_SUBTRACTION67        = 230, // <X_EQ_Y> ::= 'g67' 'Subtraction67'
        RULE_X_EQ_Y_F97_EIGHT97              = 231, // <X_EQ_Y> ::= 'f97' 'Eight97'
        RULE_X_EXCHANGE_I_H67_SUB_I67        = 232, // <X_Exchange_I> ::= 'h67' 'Sub_I67'
        RULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 = 233, // <X_Exchange_I> ::= 'f97' 'X_Exchange_Y97'
        RULE_X_EXCHANGE_Y_X_EXCHANGE_Y35     = 234, // <X_Exchange_Y> ::= 'X_Exchange_Y35'
        RULE_X_EXCHANGE_Y_H67_SEVEN67        = 235, // <X_Exchange_Y> ::= 'h67' 'Seven67'
        RULE_X_EXCHANGE_Y_X_EXCHANGE_Y97     = 236, // <X_Exchange_Y> ::= 'X_Exchange_Y97'
        RULE_X_GT_0_F67_DIVISION67           = 237, // <X_GT_0> ::= 'f67' 'Division67'
        RULE_X_GT_0_F97_SIX97                = 238, // <X_GT_0> ::= 'f97' 'Six97'
        RULE_X_GT_Y_G67_DIVISION67           = 239, // <X_GT_Y> ::= 'g67' 'Division67'
        RULE_X_GT_Y_F97_NINE97               = 240, // <X_GT_Y> ::= 'f97' 'Nine97'
        RULE_X_LE_Y_G67_MULTIPLICATION67     = 241, // <X_LE_Y> ::= 'g67' 'Multiplication67'
        RULE_X_LE_Y_F97_MULTIPLICATION97     = 242, // <X_LE_Y> ::= 'f97' 'Multiplication97'
        RULE_X_LT_0_F67_MULTIPLICATION67     = 243, // <X_LT_0> ::= 'f67' 'Multiplication67'
        RULE_X_LT_0_F97_SUBTRACTION97        = 244, // <X_LT_0> ::= 'f97' 'Subtraction97'
        RULE_X_NE_0_F67_ADDITION67           = 245, // <X_NE_0> ::= 'f67' 'Addition67'
        RULE_X_NE_0_F97_FOUR97               = 246, // <X_NE_0> ::= 'f97' 'Four97'
        RULE_X_NE_Y_G67_ADDITION67           = 247, // <X_NE_Y> ::= 'g67' 'Addition67'
        RULE_X_NE_Y_F97_SEVEN97              = 248, // <X_NE_Y> ::= 'f97' 'Seven97'
        RULE_X_TO_THE_YTH_X_TO_THE_YTH35     = 249, // <X_To_The_Yth> ::= 'X_To_The_Yth35'
        RULE_Y_TO_THE_XTH_H67_FIVE67         = 250, // <Y_To_The_Xth> ::= 'h67' 'Five67'
        RULE_Y_TO_THE_XTH_Y_TO_THE_XTH97     = 251, // <Y_To_The_Xth> ::= 'Y_To_The_Xth97'
        RULE_ZERO_ZERO35                     = 252, // <Zero> ::= 'Zero35'
        RULE_ZERO_ZERO67                     = 253, // <Zero> ::= 'Zero67'
        RULE_ZERO_ZERO97                     = 254, // <Zero> ::= 'Zero97'
        RULE_INSTRUCTION                     = 255, // <Instruction> ::= <Nullary_Instruction>
        RULE_INSTRUCTION2                    = 256, // <Instruction> ::= <Unary_Instruction>
        RULE_INSTRUCTION3                    = 257, // <Instruction> ::= <Binary_Instruction>
        RULE_INSTRUCTION4                    = 258, // <Instruction> ::= <Ternary_Instruction>
        RULE_GSB_LC_SHORTCUT                 = 259, // <Gsb_LC_Shortcut> ::= <Lowercase_Letter_Label>
        RULE_GSB_UC_SHORTCUT                 = 260, // <Gsb_UC_Shortcut> ::= <Uppercase_Letter_Label>
        RULE_RCL_I_SHORTCUT                  = 261, // <Rcl_I_Shortcut> ::= <I>
        RULE_RCL_SUB_I_SHORTCUT              = 262, // <Rcl_Sub_I_Shortcut> ::= <Sub_I>
        RULE_NULLARY_INSTRUCTION             = 263, // <Nullary_Instruction> ::= <Abs>
        RULE_NULLARY_INSTRUCTION2            = 264, // <Nullary_Instruction> ::= <Addition>
        RULE_NULLARY_INSTRUCTION3            = 265, // <Nullary_Instruction> ::= <Arccos>
        RULE_NULLARY_INSTRUCTION4            = 266, // <Nullary_Instruction> ::= <Arcsin>
        RULE_NULLARY_INSTRUCTION5            = 267, // <Nullary_Instruction> ::= <Arctan>
        RULE_NULLARY_INSTRUCTION6            = 268, // <Nullary_Instruction> ::= <Bst>
        RULE_NULLARY_INSTRUCTION7            = 269, // <Nullary_Instruction> ::= <Chs>
        RULE_NULLARY_INSTRUCTION8            = 270, // <Nullary_Instruction> ::= <Cl_Prgm>
        RULE_NULLARY_INSTRUCTION9            = 271, // <Nullary_Instruction> ::= <Cl_Reg>
        RULE_NULLARY_INSTRUCTION10           = 272, // <Nullary_Instruction> ::= <Clr>
        RULE_NULLARY_INSTRUCTION11           = 273, // <Nullary_Instruction> ::= <Clx>
        RULE_NULLARY_INSTRUCTION12           = 274, // <Nullary_Instruction> ::= <Cos>
        RULE_NULLARY_INSTRUCTION13           = 275, // <Nullary_Instruction> ::= <Deg>
        RULE_NULLARY_INSTRUCTION14           = 276, // <Nullary_Instruction> ::= <Del>
        RULE_NULLARY_INSTRUCTION15           = 277, // <Nullary_Instruction> ::= <Digit>
        RULE_NULLARY_INSTRUCTION16           = 278, // <Nullary_Instruction> ::= <Display_X>
        RULE_NULLARY_INSTRUCTION17           = 279, // <Nullary_Instruction> ::= <Division>
        RULE_NULLARY_INSTRUCTION18           = 280, // <Nullary_Instruction> ::= <Dsz_Sub_I>
        RULE_NULLARY_INSTRUCTION19           = 281, // <Nullary_Instruction> ::= <Dsz>
        RULE_NULLARY_INSTRUCTION20           = 282, // <Nullary_Instruction> ::= <Eex>
        RULE_NULLARY_INSTRUCTION21           = 283, // <Nullary_Instruction> ::= <Eng>
        RULE_NULLARY_INSTRUCTION22           = 284, // <Nullary_Instruction> ::= <Enter>
        RULE_NULLARY_INSTRUCTION23           = 285, // <Nullary_Instruction> ::= <Exp>
        RULE_NULLARY_INSTRUCTION24           = 286, // <Nullary_Instruction> ::= <Factorial>
        RULE_NULLARY_INSTRUCTION25           = 287, // <Nullary_Instruction> ::= <Fix>
        RULE_NULLARY_INSTRUCTION26           = 288, // <Nullary_Instruction> ::= <Frac>
        RULE_NULLARY_INSTRUCTION27           = 289, // <Nullary_Instruction> ::= <Grd>
        RULE_NULLARY_INSTRUCTION28           = 290, // <Nullary_Instruction> ::= <HMS_Plus>
        RULE_NULLARY_INSTRUCTION29           = 291, // <Nullary_Instruction> ::= <Int>
        RULE_NULLARY_INSTRUCTION30           = 292, // <Nullary_Instruction> ::= <Isz_Sub_I>
        RULE_NULLARY_INSTRUCTION31           = 293, // <Nullary_Instruction> ::= <Isz>
        RULE_NULLARY_INSTRUCTION32           = 294, // <Nullary_Instruction> ::= <Ln>
        RULE_NULLARY_INSTRUCTION33           = 295, // <Nullary_Instruction> ::= <Log>
        RULE_NULLARY_INSTRUCTION34           = 296, // <Nullary_Instruction> ::= <Lst_X>
        RULE_NULLARY_INSTRUCTION35           = 297, // <Nullary_Instruction> ::= <Merge>
        RULE_NULLARY_INSTRUCTION36           = 298, // <Nullary_Instruction> ::= <Multiplication>
        RULE_NULLARY_INSTRUCTION37           = 299, // <Nullary_Instruction> ::= <P_Exchange_S>
        RULE_NULLARY_INSTRUCTION38           = 300, // <Nullary_Instruction> ::= <Pause>
        RULE_NULLARY_INSTRUCTION39           = 301, // <Nullary_Instruction> ::= <Percent_Change>
        RULE_NULLARY_INSTRUCTION40           = 302, // <Nullary_Instruction> ::= <Percent>
        RULE_NULLARY_INSTRUCTION41           = 303, // <Nullary_Instruction> ::= <Period>
        RULE_NULLARY_INSTRUCTION42           = 304, // <Nullary_Instruction> ::= <Pi>
        RULE_NULLARY_INSTRUCTION43           = 305, // <Nullary_Instruction> ::= <Print_Prgm>
        RULE_NULLARY_INSTRUCTION44           = 306, // <Nullary_Instruction> ::= <R_Down>
        RULE_NULLARY_INSTRUCTION45           = 307, // <Nullary_Instruction> ::= <R_S>
        RULE_NULLARY_INSTRUCTION46           = 308, // <Nullary_Instruction> ::= <R_Up>
        RULE_NULLARY_INSTRUCTION47           = 309, // <Nullary_Instruction> ::= <Rad>
        RULE_NULLARY_INSTRUCTION48           = 310, // <Nullary_Instruction> ::= <Rc_I_67>
        RULE_NULLARY_INSTRUCTION49           = 311, // <Nullary_Instruction> ::= <Rcl_I_Shortcut>
        RULE_NULLARY_INSTRUCTION50           = 312, // <Nullary_Instruction> ::= <Rcl_Nullary>
        RULE_NULLARY_INSTRUCTION51           = 313, // <Nullary_Instruction> ::= <Rcl_Sigma_Plus>
        RULE_NULLARY_INSTRUCTION52           = 314, // <Nullary_Instruction> ::= <Rcl_Sub_I_Shortcut>
        RULE_NULLARY_INSTRUCTION53           = 315, // <Nullary_Instruction> ::= <Reciprocal>
        RULE_NULLARY_INSTRUCTION54           = 316, // <Nullary_Instruction> ::= <Reg>
        RULE_NULLARY_INSTRUCTION55           = 317, // <Nullary_Instruction> ::= <Rnd>
        RULE_NULLARY_INSTRUCTION56           = 318, // <Nullary_Instruction> ::= <Rtn>
        RULE_NULLARY_INSTRUCTION57           = 319, // <Nullary_Instruction> ::= <S>
        RULE_NULLARY_INSTRUCTION58           = 320, // <Nullary_Instruction> ::= <Sci>
        RULE_NULLARY_INSTRUCTION59           = 321, // <Nullary_Instruction> ::= <Sigma_Minus>
        RULE_NULLARY_INSTRUCTION60           = 322, // <Nullary_Instruction> ::= <Sigma_Plus>
        RULE_NULLARY_INSTRUCTION61           = 323, // <Nullary_Instruction> ::= <Sin>
        RULE_NULLARY_INSTRUCTION62           = 324, // <Nullary_Instruction> ::= <Space>
        RULE_NULLARY_INSTRUCTION63           = 325, // <Nullary_Instruction> ::= <Sqrt>
        RULE_NULLARY_INSTRUCTION64           = 326, // <Nullary_Instruction> ::= <Square>
        RULE_NULLARY_INSTRUCTION65           = 327, // <Nullary_Instruction> ::= <Sst>
        RULE_NULLARY_INSTRUCTION66           = 328, // <Nullary_Instruction> ::= <St_I_67>
        RULE_NULLARY_INSTRUCTION67           = 329, // <Nullary_Instruction> ::= <Sto_Nullary>
        RULE_NULLARY_INSTRUCTION68           = 330, // <Nullary_Instruction> ::= <Stk>
        RULE_NULLARY_INSTRUCTION69           = 331, // <Nullary_Instruction> ::= <Subtraction>
        RULE_NULLARY_INSTRUCTION70           = 332, // <Nullary_Instruction> ::= <Tan>
        RULE_NULLARY_INSTRUCTION71           = 333, // <Nullary_Instruction> ::= <Ten_To_The_Xth>
        RULE_NULLARY_INSTRUCTION72           = 334, // <Nullary_Instruction> ::= <To_Degrees>
        RULE_NULLARY_INSTRUCTION73           = 335, // <Nullary_Instruction> ::= <To_HMS>
        RULE_NULLARY_INSTRUCTION74           = 336, // <Nullary_Instruction> ::= <To_Hours>
        RULE_NULLARY_INSTRUCTION75           = 337, // <Nullary_Instruction> ::= <To_Polar>
        RULE_NULLARY_INSTRUCTION76           = 338, // <Nullary_Instruction> ::= <To_Radians>
        RULE_NULLARY_INSTRUCTION77           = 339, // <Nullary_Instruction> ::= <To_Rectangular>
        RULE_NULLARY_INSTRUCTION78           = 340, // <Nullary_Instruction> ::= <W_Data>
        RULE_NULLARY_INSTRUCTION79           = 341, // <Nullary_Instruction> ::= <X_Average>
        RULE_NULLARY_INSTRUCTION80           = 342, // <Nullary_Instruction> ::= <X_EQ_0>
        RULE_NULLARY_INSTRUCTION81           = 343, // <Nullary_Instruction> ::= <X_EQ_Y>
        RULE_NULLARY_INSTRUCTION82           = 344, // <Nullary_Instruction> ::= <X_Exchange_I>
        RULE_NULLARY_INSTRUCTION83           = 345, // <Nullary_Instruction> ::= <X_Exchange_Y>
        RULE_NULLARY_INSTRUCTION84           = 346, // <Nullary_Instruction> ::= <X_GT_0>
        RULE_NULLARY_INSTRUCTION85           = 347, // <Nullary_Instruction> ::= <X_GT_Y>
        RULE_NULLARY_INSTRUCTION86           = 348, // <Nullary_Instruction> ::= <X_LE_Y>
        RULE_NULLARY_INSTRUCTION87           = 349, // <Nullary_Instruction> ::= <X_LT_0>
        RULE_NULLARY_INSTRUCTION88           = 350, // <Nullary_Instruction> ::= <X_NE_0>
        RULE_NULLARY_INSTRUCTION89           = 351, // <Nullary_Instruction> ::= <X_NE_Y>
        RULE_NULLARY_INSTRUCTION90           = 352, // <Nullary_Instruction> ::= <X_To_The_Yth>
        RULE_NULLARY_INSTRUCTION91           = 353, // <Nullary_Instruction> ::= <Y_To_The_Xth>
        RULE_UNARY_INSTRUCTION               = 354, // <Unary_Instruction> ::= <CF> <Flag>
        RULE_UNARY_INSTRUCTION2              = 355, // <Unary_Instruction> ::= <Dsp> <Digit_Count>
        RULE_UNARY_INSTRUCTION3              = 356, // <Unary_Instruction> ::= <F_Test> <Flag>
        RULE_UNARY_INSTRUCTION4              = 357, // <Unary_Instruction> ::= <Gsb> <Label>
        RULE_UNARY_INSTRUCTION5              = 358, // <Unary_Instruction> ::= <Gsb_LC_67> <Uppercase_Letter_Label>
        RULE_UNARY_INSTRUCTION6              = 359, // <Unary_Instruction> ::= <Gsb_LC_Shortcut>
        RULE_UNARY_INSTRUCTION7              = 360, // <Unary_Instruction> ::= <Gsb_UC_Shortcut>
        RULE_UNARY_INSTRUCTION8              = 361, // <Unary_Instruction> ::= <Gto> <Label>
        RULE_UNARY_INSTRUCTION9              = 362, // <Unary_Instruction> ::= <Lbl> <Label>
        RULE_UNARY_INSTRUCTION10             = 363, // <Unary_Instruction> ::= <Lbl_LC_67> <Uppercase_Letter_Label>
        RULE_UNARY_INSTRUCTION11             = 364, // <Unary_Instruction> ::= <Rcl> <Memory>
        RULE_UNARY_INSTRUCTION12             = 365, // <Unary_Instruction> ::= <SF> <Flag>
        RULE_UNARY_INSTRUCTION13             = 366, // <Unary_Instruction> ::= <Sto> <Memory>
        RULE_BINARY_INSTRUCTION              = 367, // <Binary_Instruction> ::= <Sto> <Operator> <Operable_Memory>
        RULE_TERNARY_INSTRUCTION             = 368, // <Ternary_Instruction> ::= <Gto_Period> <Digit> <Digit> <Digit>
        RULE_RCL_SIGMA_PLUS                  = 369, // <Rcl_Sigma_Plus> ::= <Rcl> <Sigma_Plus>
        RULE_GTO_PERIOD                      = 370, // <Gto_Period> ::= <Gto> <Period>
        RULE_OPERATOR                        = 371, // <Operator> ::= <Subtraction>
        RULE_OPERATOR2                       = 372, // <Operator> ::= <Addition>
        RULE_OPERATOR3                       = 373, // <Operator> ::= <Multiplication>
        RULE_OPERATOR4                       = 374, // <Operator> ::= <Division>
        RULE_DIGIT                           = 375, // <Digit> ::= <Zero>
        RULE_DIGIT2                          = 376, // <Digit> ::= <One>
        RULE_DIGIT3                          = 377, // <Digit> ::= <Two>
        RULE_DIGIT4                          = 378, // <Digit> ::= <Three>
        RULE_DIGIT5                          = 379, // <Digit> ::= <Four>
        RULE_DIGIT6                          = 380, // <Digit> ::= <Five>
        RULE_DIGIT7                          = 381, // <Digit> ::= <Six>
        RULE_DIGIT8                          = 382, // <Digit> ::= <Seven>
        RULE_DIGIT9                          = 383, // <Digit> ::= <Eight>
        RULE_DIGIT10                         = 384, // <Digit> ::= <Nine>
        RULE_DIGIT_COUNT                     = 385, // <Digit_Count> ::= <Digit>
        RULE_DIGIT_COUNT2                    = 386, // <Digit_Count> ::= <Sub_I>
        RULE_FLAG                            = 387, // <Flag> ::= <Zero>
        RULE_FLAG2                           = 388, // <Flag> ::= <One>
        RULE_FLAG3                           = 389, // <Flag> ::= <Two>
        RULE_FLAG4                           = 390, // <Flag> ::= <Three>
        RULE_UPPERCASE_LETTER                = 391, // <Uppercase_Letter> ::= <A>
        RULE_UPPERCASE_LETTER2               = 392, // <Uppercase_Letter> ::= <B>
        RULE_UPPERCASE_LETTER3               = 393, // <Uppercase_Letter> ::= <C>
        RULE_UPPERCASE_LETTER4               = 394, // <Uppercase_Letter> ::= <D>
        RULE_UPPERCASE_LETTER5               = 395, // <Uppercase_Letter> ::= <E>
        RULE_LC_A                            = 396, // <LC_a> ::= <f> <A>
        RULE_LC_B                            = 397, // <LC_b> ::= <f> <B>
        RULE_LC_C                            = 398, // <LC_c> ::= <f> <C>
        RULE_LC_D                            = 399, // <LC_d> ::= <f> <D>
        RULE_LC_E                            = 400, // <LC_e> ::= <f> <E>
        RULE_UPPERCASE_LETTER_LABEL          = 401, // <Uppercase_Letter_Label> ::= <Uppercase_Letter>
        RULE_LOWERCASE_LETTER_LABEL          = 402, // <Lowercase_Letter_Label> ::= <LC_a>
        RULE_LOWERCASE_LETTER_LABEL2         = 403, // <Lowercase_Letter_Label> ::= <LC_b>
        RULE_LOWERCASE_LETTER_LABEL3         = 404, // <Lowercase_Letter_Label> ::= <LC_c>
        RULE_LOWERCASE_LETTER_LABEL4         = 405, // <Lowercase_Letter_Label> ::= <LC_d>
        RULE_LOWERCASE_LETTER_LABEL5         = 406, // <Lowercase_Letter_Label> ::= <LC_e>
        RULE_LETTER_LABEL                    = 407, // <Letter_Label> ::= <Lowercase_Letter_Label>
        RULE_LETTER_LABEL2                   = 408, // <Letter_Label> ::= <Uppercase_Letter_Label>
        RULE_DIGIT_LABEL                     = 409, // <Digit_Label> ::= <Digit>
        RULE_LABEL                           = 410, // <Label> ::= <Digit_Label>
        RULE_LABEL2                          = 411, // <Label> ::= <Letter_Label>
        RULE_LABEL3                          = 412, // <Label> ::= <Sub_I>
        RULE_OPERABLE_MEMORY                 = 413, // <Operable_Memory> ::= <Digit>
        RULE_OPERABLE_MEMORY2                = 414, // <Operable_Memory> ::= <Sub_I>
        RULE_MEMORY                          = 415, // <Memory> ::= <Operable_Memory>
        RULE_MEMORY2                         = 416, // <Memory> ::= <Uppercase_Letter>
        RULE_MEMORY3                         = 417  // <Memory> ::= <I>
    };

    public interface IActions
    {
		void ParserAccept ();
        void ParserError (string input, TerminalToken token);
        string RemainingText
        {
			get;
        }
        bool Retry
        {
			get;
        }
        
        void ReduceRULE_A_A67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_A_A97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ABS_H67_SIX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ABS_F97_Y_TO_THE_XTH97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ADDITION_ADDITION35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ADDITION_ADDITION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ADDITION_ADDITION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCCOS_ARC35_COS35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCCOS_G67_FIVE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCCOS_F97_COS97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCSIN_ARC35_SIN35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCSIN_G67_FOUR67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCSIN_F97_SIN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCTAN_ARC35_TAN35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCTAN_G67_SIX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ARCTAN_F97_TAN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_B_B67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_B_B97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_BST_H67_SST67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_BST_BST97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_C_C67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_C_C97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CF_H67_ADDITION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CF_F97_GTO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CHS_CHS35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CHS_CHS67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CHS_CHS97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CL_PRGM_F67_CLX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CL_PRGM_F97_THREE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CL_REG_F67_EEX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CL_REG_F97_TWO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CLR_CLR35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CLX_CLX35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CLX_CLX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_CLX_CLX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_COS_COS35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_COS_F67_FIVE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_COS_COS97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_D_D67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_D_D97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DEG_H67_ENTER67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DEG_F97_ENTER97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DEL_H67_CLX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DEL_F97_ONE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DISPLAY_X_F67_R_S67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DISPLAY_X_DISPLAY_X97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIVISION_DIVISION35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIVISION_DIVISION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIVISION_DIVISION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DSP_DSP67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DSP_DSP97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DSZ_SUB_I_G67_STO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DSZ_SUB_I_F97_BST97_SUB_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DSZ_F67_STO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DSZ_F97_BST97_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_E_E67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_E_E97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EEX_EEX35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EEX_EEX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EEX_EEX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EIGHT_EIGHT35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EIGHT_EIGHT67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EIGHT_EIGHT97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ENG_H67_DSP67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ENG_ENG97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ENTER_ENTER35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ENTER_ENTER67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ENTER_ENTER97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EXP_EXP35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EXP_G67_SEVEN67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_EXP_EXP97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_F_F67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_F_F97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_F_TEST_H67_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_F_TEST_F97_GSB97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FACTORIAL_H67_DIVISION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FACTORIAL_F97_RECIPROCAL97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FIVE_FIVE35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FIVE_FIVE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FIVE_FIVE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FIX_F67_DSP67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FIX_FIX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FOUR_FOUR35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FOUR_FOUR67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FOUR_FOUR97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FRAC_G67_PERIOD67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FRAC_F97_TO_RECTANGULAR97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GRD_H67_EEX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GRD_F97_EEX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GSB_LC_67_G67_GTO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GSB_F67_GTO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GSB_GSB97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GTO_GTO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GTO_GTO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_HMS_PLUS_H67_PERIOD67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_HMS_PLUS_F97_ADDITION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_I_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_INT_F67_PERIOD67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_INT_F97_TO_POLAR97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ISZ_SUB_I_G67_RCL67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ISZ_SUB_I_F97_SST97_SUB_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ISZ_F67_RCL67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ISZ_F97_SST97_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LBL_LC_67_G67_SST67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LBL_F67_SST67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LBL_LBL97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LN_LN35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LN_F67_SEVEN67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LN_LN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOG_LOG35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOG_F67_EIGHT67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOG_F97_LN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LST_X_H67_ZERO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LST_X_F97_DSP97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MERGE_G67_ENTER67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MERGE_F97_PERIOD97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MULTIPLICATION_MULTIPLICATION35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MULTIPLICATION_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MULTIPLICATION_MULTIPLICATION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NINE_NINE35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NINE_NINE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NINE_NINE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ONE_ONE35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ONE_ONE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ONE_ONE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_P_EXCHANGE_S_F67_CHS67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_P_EXCHANGE_S_F97_CLX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PAUSE_H67_ONE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PAUSE_F97_R_S97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PERCENT_CHANGE_G67_ZERO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PERCENT_CHANGE_F97_PERCENT97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PERCENT_F67_ZERO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PERCENT_PERCENT97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PERIOD_PERIOD35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PERIOD_PERIOD67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PERIOD_PERIOD97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PI_PI35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PI_H67_TWO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PI_F97_DIVISION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_PRINT_PRGM_F97_SCI97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_R_DOWN_R_DOWN35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_R_DOWN_H67_EIGHT67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_R_DOWN_R_DOWN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_R_S_R_S67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_R_S_R_S97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_R_UP_H67_NINE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_R_UP_F97_R_DOWN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RAD_H67_CHS67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RAD_F97_CHS97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RC_I_67_H67_RCL67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RCL_NULLARY_RCL35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RCL_RCL67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RCL_RCL97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RECIPROCAL_RECIPROCAL35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RECIPROCAL_H67_FOUR67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RECIPROCAL_RECIPROCAL97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_REG_H67_THREE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_REG_F97_ENG97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RND_F67_SUB_I67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RND_F97_RTN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RTN_H67_GTO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RTN_RTN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_S_G67_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_S_F97_SQRT97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SCI_G67_DSP67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SCI_SCI97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SEVEN_SEVEN35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SEVEN_SEVEN67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SEVEN_SEVEN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SF_H67_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SF_F97_LBL97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIGMA_MINUS_H67_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIGMA_MINUS_F97_SIGMA_PLUS97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIN_SIN35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIN_F67_FOUR67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIN_SIN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIX_SIX35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIX_SIX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SIX_SIX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SPACE_H67_R_S67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SPACE_F97_FIX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SQRT_SQRT35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SQRT_F67_NINE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SQRT_SQRT97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SQUARE_G67_NINE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SQUARE_SQUARE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SST_SST67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SST_SST97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_STK_G67_R_S67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_STK_F97_DISPLAY_X97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ST_I_67_H67_STO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_STO_NULLARY_STO35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_STO_STO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_STO_STO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SUB_I_SUB_I67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SUB_I_SUB_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SUBTRACTION_SUBTRACTION35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SUBTRACTION_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_SUBTRACTION_SUBTRACTION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TAN_TAN35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TAN_F67_SIX67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TAN_TAN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TEN_TO_THE_XTH_G67_EIGHT67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TEN_TO_THE_XTH_F97_EXP97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_THREE_THREE35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_THREE_THREE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_THREE_THREE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_DEGREES_F67_TWO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_DEGREES_F97_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_HMS_G67_THREE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_HMS_F97_STO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_HOURS_F67_THREE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_HOURS_F97_RCL97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_POLAR_G67_ONE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_POLAR_TO_POLAR97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_RADIANS_G67_TWO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_RADIANS_F97_SUB_I97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_RECTANGULAR_F67_ONE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TO_RECTANGULAR_TO_RECTANGULAR97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TWO_TWO35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TWO_TWO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TWO_TWO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_W_DATA_F67_ENTER67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_W_DATA_F97_ZERO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_AVERAGE_F67_SIGMA_PLUS67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_AVERAGE_F97_SQUARE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EQ_0_F67_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EQ_0_F97_FIVE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EQ_Y_G67_SUBTRACTION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EQ_Y_F97_EIGHT97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EXCHANGE_I_H67_SUB_I67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_Y35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EXCHANGE_Y_H67_SEVEN67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_Y97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_GT_0_F67_DIVISION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_GT_0_F97_SIX97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_GT_Y_G67_DIVISION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_GT_Y_F97_NINE97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_LE_Y_G67_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_LE_Y_F97_MULTIPLICATION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_LT_0_F67_MULTIPLICATION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_LT_0_F97_SUBTRACTION97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_NE_0_F67_ADDITION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_NE_0_F97_FOUR97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_NE_Y_G67_ADDITION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_NE_Y_F97_SEVEN97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_X_TO_THE_YTH_X_TO_THE_YTH35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_Y_TO_THE_XTH_H67_FIVE67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_Y_TO_THE_XTH_Y_TO_THE_XTH97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ZERO_ZERO35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ZERO_ZERO67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_ZERO_ZERO97 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_INSTRUCTION2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_INSTRUCTION3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_INSTRUCTION4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GSB_LC_SHORTCUT (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GSB_UC_SHORTCUT (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RCL_I_SHORTCUT (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RCL_SUB_I_SHORTCUT (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION5 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION6 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION7 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION8 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION9 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION10 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION11 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION12 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION13 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION14 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION15 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION16 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION17 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION18 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION19 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION20 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION21 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION22 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION23 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION24 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION25 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION26 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION27 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION28 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION29 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION30 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION31 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION32 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION33 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION34 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION35 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION36 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION37 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION38 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION39 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION40 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION41 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION42 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION43 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION44 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION45 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION46 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION47 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION48 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION49 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION50 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION51 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION52 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION53 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION54 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION55 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION56 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION57 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION58 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION59 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION60 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION61 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION62 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION63 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION64 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION65 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION66 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION67 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION68 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION69 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION70 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION71 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION72 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION73 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION74 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION75 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION76 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION77 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION78 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION79 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION80 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION81 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION82 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION83 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION84 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION85 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION86 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION87 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION88 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION89 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION90 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_NULLARY_INSTRUCTION91 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION5 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION6 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION7 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION8 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION9 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION10 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION11 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION12 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UNARY_INSTRUCTION13 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_BINARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_TERNARY_INSTRUCTION (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_RCL_SIGMA_PLUS (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_GTO_PERIOD (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_OPERATOR (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_OPERATOR2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_OPERATOR3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_OPERATOR4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT5 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT6 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT7 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT8 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT9 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT10 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT_COUNT (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT_COUNT2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FLAG (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FLAG2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FLAG3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_FLAG4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UPPERCASE_LETTER (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UPPERCASE_LETTER2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UPPERCASE_LETTER3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UPPERCASE_LETTER4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UPPERCASE_LETTER5 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LC_A (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LC_B (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LC_C (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LC_D (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LC_E (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_UPPERCASE_LETTER_LABEL (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOWERCASE_LETTER_LABEL (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOWERCASE_LETTER_LABEL2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOWERCASE_LETTER_LABEL3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOWERCASE_LETTER_LABEL4 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LOWERCASE_LETTER_LABEL5 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LETTER_LABEL (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LETTER_LABEL2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_DIGIT_LABEL (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LABEL (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LABEL2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_LABEL3 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_OPERABLE_MEMORY (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_OPERABLE_MEMORY2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MEMORY (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MEMORY2 (Reader reader, Token token, Token [] tokens, object state);
        void ReduceRULE_MEMORY3 (Reader reader, Token token, Token [] tokens, object state);
    }

    public class Parser
    {
		private static TraceSwitch classTraceSwitch = 
			new TraceSwitch ("Mockingbird.HP.Parser.Parser", "Automatically generated parser");

        private IActions actions;
        private string input;
        private LALRParser parser;
        private Reader reader;
        private object state;

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"ReduceEvent: Reducing " + args.Rule.ToString (), 
				classTraceSwitch.DisplayName);
				
		    // By default, copy the user object from the first token on the rhs.  This will take
		    // care of most of the reductions, where we just pass the information along.
            if (args.Token.Tokens.Length >= 1)
            {
                args.Token.UserObject = args.Token.Tokens [0].UserObject;
            }
            
            try {
				switch ((RuleConstants) args.Token.Rule.Id)
				{
					case RuleConstants.RULE_A_A67 :
						// <A> ::= 'A67'
						actions.ReduceRULE_A_A67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_A_A97 :
						// <A> ::= 'A97'
						actions.ReduceRULE_A_A97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ABS_H67_SIX67 :
						// <Abs> ::= 'h67' 'Six67'
						actions.ReduceRULE_ABS_H67_SIX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ABS_F97_Y_TO_THE_XTH97 :
						// <Abs> ::= 'f97' 'Y_To_The_Xth97'
						actions.ReduceRULE_ABS_F97_Y_TO_THE_XTH97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ADDITION_ADDITION35 :
						// <Addition> ::= 'Addition35'
						actions.ReduceRULE_ADDITION_ADDITION35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ADDITION_ADDITION67 :
						// <Addition> ::= 'Addition67'
						actions.ReduceRULE_ADDITION_ADDITION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ADDITION_ADDITION97 :
						// <Addition> ::= 'Addition97'
						actions.ReduceRULE_ADDITION_ADDITION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCCOS_ARC35_COS35 :
						// <Arccos> ::= 'Arc35' 'Cos35'
						actions.ReduceRULE_ARCCOS_ARC35_COS35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCCOS_G67_FIVE67 :
						// <Arccos> ::= 'g67' 'Five67'
						actions.ReduceRULE_ARCCOS_G67_FIVE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCCOS_F97_COS97 :
						// <Arccos> ::= 'f97' 'Cos97'
						actions.ReduceRULE_ARCCOS_F97_COS97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCSIN_ARC35_SIN35 :
						// <Arcsin> ::= 'Arc35' 'Sin35'
						actions.ReduceRULE_ARCSIN_ARC35_SIN35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCSIN_G67_FOUR67 :
						// <Arcsin> ::= 'g67' 'Four67'
						actions.ReduceRULE_ARCSIN_G67_FOUR67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCSIN_F97_SIN97 :
						// <Arcsin> ::= 'f97' 'Sin97'
						actions.ReduceRULE_ARCSIN_F97_SIN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCTAN_ARC35_TAN35 :
						// <Arctan> ::= 'Arc35' 'Tan35'
						actions.ReduceRULE_ARCTAN_ARC35_TAN35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCTAN_G67_SIX67 :
						// <Arctan> ::= 'g67' 'Six67'
						actions.ReduceRULE_ARCTAN_G67_SIX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ARCTAN_F97_TAN97 :
						// <Arctan> ::= 'f97' 'Tan97'
						actions.ReduceRULE_ARCTAN_F97_TAN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_B_B67 :
						// <B> ::= 'B67'
						actions.ReduceRULE_B_B67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_B_B97 :
						// <B> ::= 'B97'
						actions.ReduceRULE_B_B97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_BST_H67_SST67 :
						// <Bst> ::= 'h67' 'Sst67'
						actions.ReduceRULE_BST_H67_SST67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_BST_BST97 :
						// <Bst> ::= 'Bst97'
						actions.ReduceRULE_BST_BST97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_C_C67 :
						// <C> ::= 'C67'
						actions.ReduceRULE_C_C67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_C_C97 :
						// <C> ::= 'C97'
						actions.ReduceRULE_C_C97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CF_H67_ADDITION67 :
						// <CF> ::= 'h67' 'Addition67'
						actions.ReduceRULE_CF_H67_ADDITION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CF_F97_GTO97 :
						// <CF> ::= 'f97' 'Gto97'
						actions.ReduceRULE_CF_F97_GTO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CHS_CHS35 :
						// <Chs> ::= 'Chs35'
						actions.ReduceRULE_CHS_CHS35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CHS_CHS67 :
						// <Chs> ::= 'Chs67'
						actions.ReduceRULE_CHS_CHS67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CHS_CHS97 :
						// <Chs> ::= 'Chs97'
						actions.ReduceRULE_CHS_CHS97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CL_PRGM_F67_CLX67 :
						// <Cl_Prgm> ::= 'f67' 'Clx67'
						actions.ReduceRULE_CL_PRGM_F67_CLX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CL_PRGM_F97_THREE97 :
						// <Cl_Prgm> ::= 'f97' 'Three97'
						actions.ReduceRULE_CL_PRGM_F97_THREE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CL_REG_F67_EEX67 :
						// <Cl_Reg> ::= 'f67' 'Eex67'
						actions.ReduceRULE_CL_REG_F67_EEX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CL_REG_F97_TWO97 :
						// <Cl_Reg> ::= 'f97' 'Two97'
						actions.ReduceRULE_CL_REG_F97_TWO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CLR_CLR35 :
						// <Clr> ::= 'Clr35'
						actions.ReduceRULE_CLR_CLR35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CLX_CLX35 :
						// <Clx> ::= 'Clx35'
						actions.ReduceRULE_CLX_CLX35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CLX_CLX67 :
						// <Clx> ::= 'Clx67'
						actions.ReduceRULE_CLX_CLX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_CLX_CLX97 :
						// <Clx> ::= 'Clx97'
						actions.ReduceRULE_CLX_CLX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_COS_COS35 :
						// <Cos> ::= 'Cos35'
						actions.ReduceRULE_COS_COS35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_COS_F67_FIVE67 :
						// <Cos> ::= 'f67' 'Five67'
						actions.ReduceRULE_COS_F67_FIVE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_COS_COS97 :
						// <Cos> ::= 'Cos97'
						actions.ReduceRULE_COS_COS97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_D_D67 :
						// <D> ::= 'D67'
						actions.ReduceRULE_D_D67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_D_D97 :
						// <D> ::= 'D97'
						actions.ReduceRULE_D_D97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DEG_H67_ENTER67 :
						// <Deg> ::= 'h67' 'Enter67'
						actions.ReduceRULE_DEG_H67_ENTER67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DEG_F97_ENTER97 :
						// <Deg> ::= 'f97' 'Enter97'
						actions.ReduceRULE_DEG_F97_ENTER97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DEL_H67_CLX67 :
						// <Del> ::= 'h67' 'Clx67'
						actions.ReduceRULE_DEL_H67_CLX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DEL_F97_ONE97 :
						// <Del> ::= 'f97' 'One97'
						actions.ReduceRULE_DEL_F97_ONE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DISPLAY_X_F67_R_S67 :
						// <Display_X> ::= 'f67' 'R_S67'
						actions.ReduceRULE_DISPLAY_X_F67_R_S67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DISPLAY_X_DISPLAY_X97 :
						// <Display_X> ::= 'Display_X97'
						actions.ReduceRULE_DISPLAY_X_DISPLAY_X97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIVISION_DIVISION35 :
						// <Division> ::= 'Division35'
						actions.ReduceRULE_DIVISION_DIVISION35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIVISION_DIVISION67 :
						// <Division> ::= 'Division67'
						actions.ReduceRULE_DIVISION_DIVISION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIVISION_DIVISION97 :
						// <Division> ::= 'Division97'
						actions.ReduceRULE_DIVISION_DIVISION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DSP_DSP67 :
						// <Dsp> ::= 'Dsp67'
						actions.ReduceRULE_DSP_DSP67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DSP_DSP97 :
						// <Dsp> ::= 'Dsp97'
						actions.ReduceRULE_DSP_DSP97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DSZ_SUB_I_G67_STO67 :
						// <Dsz_Sub_I> ::= 'g67' 'Sto67'
						actions.ReduceRULE_DSZ_SUB_I_G67_STO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DSZ_SUB_I_F97_BST97_SUB_I97 :
						// <Dsz_Sub_I> ::= 'f97' 'Bst97' 'Sub_I97'
						actions.ReduceRULE_DSZ_SUB_I_F97_BST97_SUB_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DSZ_F67_STO67 :
						// <Dsz> ::= 'f67' 'Sto67'
						actions.ReduceRULE_DSZ_F67_STO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DSZ_F97_BST97_I97 :
						// <Dsz> ::= 'f97' 'Bst97' 'I97'
						actions.ReduceRULE_DSZ_F97_BST97_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_E_E67 :
						// <E> ::= 'E67'
						actions.ReduceRULE_E_E67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_E_E97 :
						// <E> ::= 'E97'
						actions.ReduceRULE_E_E97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EEX_EEX35 :
						// <Eex> ::= 'Eex35'
						actions.ReduceRULE_EEX_EEX35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EEX_EEX67 :
						// <Eex> ::= 'Eex67'
						actions.ReduceRULE_EEX_EEX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EEX_EEX97 :
						// <Eex> ::= 'Eex97'
						actions.ReduceRULE_EEX_EEX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EIGHT_EIGHT35 :
						// <Eight> ::= 'Eight35'
						actions.ReduceRULE_EIGHT_EIGHT35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EIGHT_EIGHT67 :
						// <Eight> ::= 'Eight67'
						actions.ReduceRULE_EIGHT_EIGHT67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EIGHT_EIGHT97 :
						// <Eight> ::= 'Eight97'
						actions.ReduceRULE_EIGHT_EIGHT97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ENG_H67_DSP67 :
						// <Eng> ::= 'h67' 'Dsp67'
						actions.ReduceRULE_ENG_H67_DSP67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ENG_ENG97 :
						// <Eng> ::= 'Eng97'
						actions.ReduceRULE_ENG_ENG97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ENTER_ENTER35 :
						// <Enter> ::= 'Enter35'
						actions.ReduceRULE_ENTER_ENTER35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ENTER_ENTER67 :
						// <Enter> ::= 'Enter67'
						actions.ReduceRULE_ENTER_ENTER67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ENTER_ENTER97 :
						// <Enter> ::= 'Enter97'
						actions.ReduceRULE_ENTER_ENTER97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EXP_EXP35 :
						// <Exp> ::= 'Exp35'
						actions.ReduceRULE_EXP_EXP35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EXP_G67_SEVEN67 :
						// <Exp> ::= 'g67' 'Seven67'
						actions.ReduceRULE_EXP_G67_SEVEN67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_EXP_EXP97 :
						// <Exp> ::= 'Exp97'
						actions.ReduceRULE_EXP_EXP97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_F_F67 :
						// <f> ::= 'f67'
						actions.ReduceRULE_F_F67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_F_F97 :
						// <f> ::= 'f97'
						actions.ReduceRULE_F_F97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_F_TEST_H67_MULTIPLICATION67 :
						// <F_Test> ::= 'h67' 'Multiplication67'
						actions.ReduceRULE_F_TEST_H67_MULTIPLICATION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_F_TEST_F97_GSB97 :
						// <F_Test> ::= 'f97' 'Gsb97'
						actions.ReduceRULE_F_TEST_F97_GSB97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FACTORIAL_H67_DIVISION67 :
						// <Factorial> ::= 'h67' 'Division67'
						actions.ReduceRULE_FACTORIAL_H67_DIVISION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FACTORIAL_F97_RECIPROCAL97 :
						// <Factorial> ::= 'f97' 'Reciprocal97'
						actions.ReduceRULE_FACTORIAL_F97_RECIPROCAL97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FIVE_FIVE35 :
						// <Five> ::= 'Five35'
						actions.ReduceRULE_FIVE_FIVE35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FIVE_FIVE67 :
						// <Five> ::= 'Five67'
						actions.ReduceRULE_FIVE_FIVE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FIVE_FIVE97 :
						// <Five> ::= 'Five97'
						actions.ReduceRULE_FIVE_FIVE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FIX_F67_DSP67 :
						// <Fix> ::= 'f67' 'Dsp67'
						actions.ReduceRULE_FIX_F67_DSP67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FIX_FIX97 :
						// <Fix> ::= 'Fix97'
						actions.ReduceRULE_FIX_FIX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FOUR_FOUR35 :
						// <Four> ::= 'Four35'
						actions.ReduceRULE_FOUR_FOUR35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FOUR_FOUR67 :
						// <Four> ::= 'Four67'
						actions.ReduceRULE_FOUR_FOUR67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FOUR_FOUR97 :
						// <Four> ::= 'Four97'
						actions.ReduceRULE_FOUR_FOUR97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FRAC_G67_PERIOD67 :
						// <Frac> ::= 'g67' 'Period67'
						actions.ReduceRULE_FRAC_G67_PERIOD67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FRAC_F97_TO_RECTANGULAR97 :
						// <Frac> ::= 'f97' 'To_Rectangular97'
						actions.ReduceRULE_FRAC_F97_TO_RECTANGULAR97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GRD_H67_EEX67 :
						// <Grd> ::= 'h67' 'Eex67'
						actions.ReduceRULE_GRD_H67_EEX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GRD_F97_EEX97 :
						// <Grd> ::= 'f97' 'Eex97'
						actions.ReduceRULE_GRD_F97_EEX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GSB_LC_67_G67_GTO67 :
						// <Gsb_LC_67> ::= 'g67' 'Gto67'
						actions.ReduceRULE_GSB_LC_67_G67_GTO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GSB_F67_GTO67 :
						// <Gsb> ::= 'f67' 'Gto67'
						actions.ReduceRULE_GSB_F67_GTO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GSB_GSB97 :
						// <Gsb> ::= 'Gsb97'
						actions.ReduceRULE_GSB_GSB97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GTO_GTO67 :
						// <Gto> ::= 'Gto67'
						actions.ReduceRULE_GTO_GTO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GTO_GTO97 :
						// <Gto> ::= 'Gto97'
						actions.ReduceRULE_GTO_GTO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_HMS_PLUS_H67_PERIOD67 :
						// <HMS_Plus> ::= 'h67' 'Period67'
						actions.ReduceRULE_HMS_PLUS_H67_PERIOD67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_HMS_PLUS_F97_ADDITION97 :
						// <HMS_Plus> ::= 'f97' 'Addition97'
						actions.ReduceRULE_HMS_PLUS_F97_ADDITION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_I_I97 :
						// <I> ::= 'I97'
						actions.ReduceRULE_I_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_INT_F67_PERIOD67 :
						// <Int> ::= 'f67' 'Period67'
						actions.ReduceRULE_INT_F67_PERIOD67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_INT_F97_TO_POLAR97 :
						// <Int> ::= 'f97' 'To_Polar97'
						actions.ReduceRULE_INT_F97_TO_POLAR97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ISZ_SUB_I_G67_RCL67 :
						// <Isz_Sub_I> ::= 'g67' 'Rcl67'
						actions.ReduceRULE_ISZ_SUB_I_G67_RCL67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ISZ_SUB_I_F97_SST97_SUB_I97 :
						// <Isz_Sub_I> ::= 'f97' 'Sst97' 'Sub_I97'
						actions.ReduceRULE_ISZ_SUB_I_F97_SST97_SUB_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ISZ_F67_RCL67 :
						// <Isz> ::= 'f67' 'Rcl67'
						actions.ReduceRULE_ISZ_F67_RCL67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ISZ_F97_SST97_I97 :
						// <Isz> ::= 'f97' 'Sst97' 'I97'
						actions.ReduceRULE_ISZ_F97_SST97_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LBL_LC_67_G67_SST67 :
						// <Lbl_LC_67> ::= 'g67' 'Sst67'
						actions.ReduceRULE_LBL_LC_67_G67_SST67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LBL_F67_SST67 :
						// <Lbl> ::= 'f67' 'Sst67'
						actions.ReduceRULE_LBL_F67_SST67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LBL_LBL97 :
						// <Lbl> ::= 'Lbl97'
						actions.ReduceRULE_LBL_LBL97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LN_LN35 :
						// <Ln> ::= 'Ln35'
						actions.ReduceRULE_LN_LN35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LN_F67_SEVEN67 :
						// <Ln> ::= 'f67' 'Seven67'
						actions.ReduceRULE_LN_F67_SEVEN67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LN_LN97 :
						// <Ln> ::= 'Ln97'
						actions.ReduceRULE_LN_LN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOG_LOG35 :
						// <Log> ::= 'Log35'
						actions.ReduceRULE_LOG_LOG35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOG_F67_EIGHT67 :
						// <Log> ::= 'f67' 'Eight67'
						actions.ReduceRULE_LOG_F67_EIGHT67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOG_F97_LN97 :
						// <Log> ::= 'f97' 'Ln97'
						actions.ReduceRULE_LOG_F97_LN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LST_X_H67_ZERO67 :
						// <Lst_X> ::= 'h67' 'Zero67'
						actions.ReduceRULE_LST_X_H67_ZERO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LST_X_F97_DSP97 :
						// <Lst_X> ::= 'f97' 'Dsp97'
						actions.ReduceRULE_LST_X_F97_DSP97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MERGE_G67_ENTER67 :
						// <Merge> ::= 'g67' 'Enter67'
						actions.ReduceRULE_MERGE_G67_ENTER67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MERGE_F97_PERIOD97 :
						// <Merge> ::= 'f97' 'Period97'
						actions.ReduceRULE_MERGE_F97_PERIOD97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MULTIPLICATION_MULTIPLICATION35 :
						// <Multiplication> ::= 'Multiplication35'
						actions.ReduceRULE_MULTIPLICATION_MULTIPLICATION35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MULTIPLICATION_MULTIPLICATION67 :
						// <Multiplication> ::= 'Multiplication67'
						actions.ReduceRULE_MULTIPLICATION_MULTIPLICATION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MULTIPLICATION_MULTIPLICATION97 :
						// <Multiplication> ::= 'Multiplication97'
						actions.ReduceRULE_MULTIPLICATION_MULTIPLICATION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NINE_NINE35 :
						// <Nine> ::= 'Nine35'
						actions.ReduceRULE_NINE_NINE35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NINE_NINE67 :
						// <Nine> ::= 'Nine67'
						actions.ReduceRULE_NINE_NINE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NINE_NINE97 :
						// <Nine> ::= 'Nine97'
						actions.ReduceRULE_NINE_NINE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ONE_ONE35 :
						// <One> ::= 'One35'
						actions.ReduceRULE_ONE_ONE35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ONE_ONE67 :
						// <One> ::= 'One67'
						actions.ReduceRULE_ONE_ONE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ONE_ONE97 :
						// <One> ::= 'One97'
						actions.ReduceRULE_ONE_ONE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_P_EXCHANGE_S_F67_CHS67 :
						// <P_Exchange_S> ::= 'f67' 'Chs67'
						actions.ReduceRULE_P_EXCHANGE_S_F67_CHS67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_P_EXCHANGE_S_F97_CLX97 :
						// <P_Exchange_S> ::= 'f97' 'Clx97'
						actions.ReduceRULE_P_EXCHANGE_S_F97_CLX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PAUSE_H67_ONE67 :
						// <Pause> ::= 'h67' 'One67'
						actions.ReduceRULE_PAUSE_H67_ONE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PAUSE_F97_R_S97 :
						// <Pause> ::= 'f97' 'R_S97'
						actions.ReduceRULE_PAUSE_F97_R_S97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PERCENT_CHANGE_G67_ZERO67 :
						// <Percent_Change> ::= 'g67' 'Zero67'
						actions.ReduceRULE_PERCENT_CHANGE_G67_ZERO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PERCENT_CHANGE_F97_PERCENT97 :
						// <Percent_Change> ::= 'f97' 'Percent97'
						actions.ReduceRULE_PERCENT_CHANGE_F97_PERCENT97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PERCENT_F67_ZERO67 :
						// <Percent> ::= 'f67' 'Zero67'
						actions.ReduceRULE_PERCENT_F67_ZERO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PERCENT_PERCENT97 :
						// <Percent> ::= 'Percent97'
						actions.ReduceRULE_PERCENT_PERCENT97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PERIOD_PERIOD35 :
						// <Period> ::= 'Period35'
						actions.ReduceRULE_PERIOD_PERIOD35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PERIOD_PERIOD67 :
						// <Period> ::= 'Period67'
						actions.ReduceRULE_PERIOD_PERIOD67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PERIOD_PERIOD97 :
						// <Period> ::= 'Period97'
						actions.ReduceRULE_PERIOD_PERIOD97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PI_PI35 :
						// <Pi> ::= 'Pi35'
						actions.ReduceRULE_PI_PI35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PI_H67_TWO67 :
						// <Pi> ::= 'h67' 'Two67'
						actions.ReduceRULE_PI_H67_TWO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PI_F97_DIVISION97 :
						// <Pi> ::= 'f97' 'Division97'
						actions.ReduceRULE_PI_F97_DIVISION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_PRINT_PRGM_F97_SCI97 :
						// <Print_Prgm> ::= 'f97' 'Sci97'
						actions.ReduceRULE_PRINT_PRGM_F97_SCI97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_R_DOWN_R_DOWN35 :
						// <R_Down> ::= 'R_Down35'
						actions.ReduceRULE_R_DOWN_R_DOWN35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_R_DOWN_H67_EIGHT67 :
						// <R_Down> ::= 'h67' 'Eight67'
						actions.ReduceRULE_R_DOWN_H67_EIGHT67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_R_DOWN_R_DOWN97 :
						// <R_Down> ::= 'R_Down97'
						actions.ReduceRULE_R_DOWN_R_DOWN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_R_S_R_S67 :
						// <R_S> ::= 'R_S67'
						actions.ReduceRULE_R_S_R_S67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_R_S_R_S97 :
						// <R_S> ::= 'R_S97'
						actions.ReduceRULE_R_S_R_S97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_R_UP_H67_NINE67 :
						// <R_Up> ::= 'h67' 'Nine67'
						actions.ReduceRULE_R_UP_H67_NINE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_R_UP_F97_R_DOWN97 :
						// <R_Up> ::= 'f97' 'R_Down97'
						actions.ReduceRULE_R_UP_F97_R_DOWN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RAD_H67_CHS67 :
						// <Rad> ::= 'h67' 'Chs67'
						actions.ReduceRULE_RAD_H67_CHS67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RAD_F97_CHS97 :
						// <Rad> ::= 'f97' 'Chs97'
						actions.ReduceRULE_RAD_F97_CHS97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RC_I_67_H67_RCL67 :
						// <Rc_I_67> ::= 'h67' 'Rcl67'
						actions.ReduceRULE_RC_I_67_H67_RCL67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RCL_NULLARY_RCL35 :
						// <Rcl_Nullary> ::= 'Rcl35'
						actions.ReduceRULE_RCL_NULLARY_RCL35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RCL_RCL67 :
						// <Rcl> ::= 'Rcl67'
						actions.ReduceRULE_RCL_RCL67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RCL_RCL97 :
						// <Rcl> ::= 'Rcl97'
						actions.ReduceRULE_RCL_RCL97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RECIPROCAL_RECIPROCAL35 :
						// <Reciprocal> ::= 'Reciprocal35'
						actions.ReduceRULE_RECIPROCAL_RECIPROCAL35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RECIPROCAL_H67_FOUR67 :
						// <Reciprocal> ::= 'h67' 'Four67'
						actions.ReduceRULE_RECIPROCAL_H67_FOUR67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RECIPROCAL_RECIPROCAL97 :
						// <Reciprocal> ::= 'Reciprocal97'
						actions.ReduceRULE_RECIPROCAL_RECIPROCAL97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_REG_H67_THREE67 :
						// <Reg> ::= 'h67' 'Three67'
						actions.ReduceRULE_REG_H67_THREE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_REG_F97_ENG97 :
						// <Reg> ::= 'f97' 'Eng97'
						actions.ReduceRULE_REG_F97_ENG97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RND_F67_SUB_I67 :
						// <Rnd> ::= 'f67' 'Sub_I67'
						actions.ReduceRULE_RND_F67_SUB_I67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RND_F97_RTN97 :
						// <Rnd> ::= 'f97' 'Rtn97'
						actions.ReduceRULE_RND_F97_RTN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RTN_H67_GTO67 :
						// <Rtn> ::= 'h67' 'Gto67'
						actions.ReduceRULE_RTN_H67_GTO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RTN_RTN97 :
						// <Rtn> ::= 'Rtn97'
						actions.ReduceRULE_RTN_RTN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_S_G67_SIGMA_PLUS67 :
						// <S> ::= 'g67' 'Sigma_Plus67'
						actions.ReduceRULE_S_G67_SIGMA_PLUS67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_S_F97_SQRT97 :
						// <S> ::= 'f97' 'Sqrt97'
						actions.ReduceRULE_S_F97_SQRT97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SCI_G67_DSP67 :
						// <Sci> ::= 'g67' 'Dsp67'
						actions.ReduceRULE_SCI_G67_DSP67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SCI_SCI97 :
						// <Sci> ::= 'Sci97'
						actions.ReduceRULE_SCI_SCI97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SEVEN_SEVEN35 :
						// <Seven> ::= 'Seven35'
						actions.ReduceRULE_SEVEN_SEVEN35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SEVEN_SEVEN67 :
						// <Seven> ::= 'Seven67'
						actions.ReduceRULE_SEVEN_SEVEN67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SEVEN_SEVEN97 :
						// <Seven> ::= 'Seven97'
						actions.ReduceRULE_SEVEN_SEVEN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SF_H67_SUBTRACTION67 :
						// <SF> ::= 'h67' 'Subtraction67'
						actions.ReduceRULE_SF_H67_SUBTRACTION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SF_F97_LBL97 :
						// <SF> ::= 'f97' 'Lbl97'
						actions.ReduceRULE_SF_F97_LBL97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIGMA_MINUS_H67_SIGMA_PLUS67 :
						// <Sigma_Minus> ::= 'h67' 'Sigma_Plus67'
						actions.ReduceRULE_SIGMA_MINUS_H67_SIGMA_PLUS67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIGMA_MINUS_F97_SIGMA_PLUS97 :
						// <Sigma_Minus> ::= 'f97' 'Sigma_Plus97'
						actions.ReduceRULE_SIGMA_MINUS_F97_SIGMA_PLUS97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIGMA_PLUS_SIGMA_PLUS67 :
						// <Sigma_Plus> ::= 'Sigma_Plus67'
						actions.ReduceRULE_SIGMA_PLUS_SIGMA_PLUS67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIGMA_PLUS_SIGMA_PLUS97 :
						// <Sigma_Plus> ::= 'Sigma_Plus97'
						actions.ReduceRULE_SIGMA_PLUS_SIGMA_PLUS97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIN_SIN35 :
						// <Sin> ::= 'Sin35'
						actions.ReduceRULE_SIN_SIN35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIN_F67_FOUR67 :
						// <Sin> ::= 'f67' 'Four67'
						actions.ReduceRULE_SIN_F67_FOUR67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIN_SIN97 :
						// <Sin> ::= 'Sin97'
						actions.ReduceRULE_SIN_SIN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIX_SIX35 :
						// <Six> ::= 'Six35'
						actions.ReduceRULE_SIX_SIX35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIX_SIX67 :
						// <Six> ::= 'Six67'
						actions.ReduceRULE_SIX_SIX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SIX_SIX97 :
						// <Six> ::= 'Six97'
						actions.ReduceRULE_SIX_SIX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SPACE_H67_R_S67 :
						// <Space> ::= 'h67' 'R_S67'
						actions.ReduceRULE_SPACE_H67_R_S67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SPACE_F97_FIX97 :
						// <Space> ::= 'f97' 'Fix97'
						actions.ReduceRULE_SPACE_F97_FIX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SQRT_SQRT35 :
						// <Sqrt> ::= 'Sqrt35'
						actions.ReduceRULE_SQRT_SQRT35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SQRT_F67_NINE67 :
						// <Sqrt> ::= 'f67' 'Nine67'
						actions.ReduceRULE_SQRT_F67_NINE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SQRT_SQRT97 :
						// <Sqrt> ::= 'Sqrt97'
						actions.ReduceRULE_SQRT_SQRT97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SQUARE_G67_NINE67 :
						// <Square> ::= 'g67' 'Nine67'
						actions.ReduceRULE_SQUARE_G67_NINE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SQUARE_SQUARE97 :
						// <Square> ::= 'Square97'
						actions.ReduceRULE_SQUARE_SQUARE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SST_SST67 :
						// <Sst> ::= 'Sst67'
						actions.ReduceRULE_SST_SST67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SST_SST97 :
						// <Sst> ::= 'Sst97'
						actions.ReduceRULE_SST_SST97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_STK_G67_R_S67 :
						// <Stk> ::= 'g67' 'R_S67'
						actions.ReduceRULE_STK_G67_R_S67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_STK_F97_DISPLAY_X97 :
						// <Stk> ::= 'f97' 'Display_X97'
						actions.ReduceRULE_STK_F97_DISPLAY_X97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ST_I_67_H67_STO67 :
						// <St_I_67> ::= 'h67' 'Sto67'
						actions.ReduceRULE_ST_I_67_H67_STO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_STO_NULLARY_STO35 :
						// <Sto_Nullary> ::= 'Sto35'
						actions.ReduceRULE_STO_NULLARY_STO35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_STO_STO67 :
						// <Sto> ::= 'Sto67'
						actions.ReduceRULE_STO_STO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_STO_STO97 :
						// <Sto> ::= 'Sto97'
						actions.ReduceRULE_STO_STO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SUB_I_SUB_I67 :
						// <Sub_I> ::= 'Sub_I67'
						actions.ReduceRULE_SUB_I_SUB_I67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SUB_I_SUB_I97 :
						// <Sub_I> ::= 'Sub_I97'
						actions.ReduceRULE_SUB_I_SUB_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SUBTRACTION_SUBTRACTION35 :
						// <Subtraction> ::= 'Subtraction35'
						actions.ReduceRULE_SUBTRACTION_SUBTRACTION35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SUBTRACTION_SUBTRACTION67 :
						// <Subtraction> ::= 'Subtraction67'
						actions.ReduceRULE_SUBTRACTION_SUBTRACTION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_SUBTRACTION_SUBTRACTION97 :
						// <Subtraction> ::= 'Subtraction97'
						actions.ReduceRULE_SUBTRACTION_SUBTRACTION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TAN_TAN35 :
						// <Tan> ::= 'Tan35'
						actions.ReduceRULE_TAN_TAN35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TAN_F67_SIX67 :
						// <Tan> ::= 'f67' 'Six67'
						actions.ReduceRULE_TAN_F67_SIX67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TAN_TAN97 :
						// <Tan> ::= 'Tan97'
						actions.ReduceRULE_TAN_TAN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TEN_TO_THE_XTH_G67_EIGHT67 :
						// <Ten_To_The_Xth> ::= 'g67' 'Eight67'
						actions.ReduceRULE_TEN_TO_THE_XTH_G67_EIGHT67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TEN_TO_THE_XTH_F97_EXP97 :
						// <Ten_To_The_Xth> ::= 'f97' 'Exp97'
						actions.ReduceRULE_TEN_TO_THE_XTH_F97_EXP97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_THREE_THREE35 :
						// <Three> ::= 'Three35'
						actions.ReduceRULE_THREE_THREE35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_THREE_THREE67 :
						// <Three> ::= 'Three67'
						actions.ReduceRULE_THREE_THREE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_THREE_THREE97 :
						// <Three> ::= 'Three97'
						actions.ReduceRULE_THREE_THREE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_DEGREES_F67_TWO67 :
						// <To_Degrees> ::= 'f67' 'Two67'
						actions.ReduceRULE_TO_DEGREES_F67_TWO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_DEGREES_F97_I97 :
						// <To_Degrees> ::= 'f97' 'I97'
						actions.ReduceRULE_TO_DEGREES_F97_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_HMS_G67_THREE67 :
						// <To_HMS> ::= 'g67' 'Three67'
						actions.ReduceRULE_TO_HMS_G67_THREE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_HMS_F97_STO97 :
						// <To_HMS> ::= 'f97' 'Sto97'
						actions.ReduceRULE_TO_HMS_F97_STO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_HOURS_F67_THREE67 :
						// <To_Hours> ::= 'f67' 'Three67'
						actions.ReduceRULE_TO_HOURS_F67_THREE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_HOURS_F97_RCL97 :
						// <To_Hours> ::= 'f97' 'Rcl97'
						actions.ReduceRULE_TO_HOURS_F97_RCL97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_POLAR_G67_ONE67 :
						// <To_Polar> ::= 'g67' 'One67'
						actions.ReduceRULE_TO_POLAR_G67_ONE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_POLAR_TO_POLAR97 :
						// <To_Polar> ::= 'To_Polar97'
						actions.ReduceRULE_TO_POLAR_TO_POLAR97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_RADIANS_G67_TWO67 :
						// <To_Radians> ::= 'g67' 'Two67'
						actions.ReduceRULE_TO_RADIANS_G67_TWO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_RADIANS_F97_SUB_I97 :
						// <To_Radians> ::= 'f97' 'Sub_I97'
						actions.ReduceRULE_TO_RADIANS_F97_SUB_I97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_RECTANGULAR_F67_ONE67 :
						// <To_Rectangular> ::= 'f67' 'One67'
						actions.ReduceRULE_TO_RECTANGULAR_F67_ONE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TO_RECTANGULAR_TO_RECTANGULAR97 :
						// <To_Rectangular> ::= 'To_Rectangular97'
						actions.ReduceRULE_TO_RECTANGULAR_TO_RECTANGULAR97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TWO_TWO35 :
						// <Two> ::= 'Two35'
						actions.ReduceRULE_TWO_TWO35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TWO_TWO67 :
						// <Two> ::= 'Two67'
						actions.ReduceRULE_TWO_TWO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TWO_TWO97 :
						// <Two> ::= 'Two97'
						actions.ReduceRULE_TWO_TWO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_W_DATA_F67_ENTER67 :
						// <W_Data> ::= 'f67' 'Enter67'
						actions.ReduceRULE_W_DATA_F67_ENTER67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_W_DATA_F97_ZERO97 :
						// <W_Data> ::= 'f97' 'Zero97'
						actions.ReduceRULE_W_DATA_F97_ZERO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_AVERAGE_F67_SIGMA_PLUS67 :
						// <X_Average> ::= 'f67' 'Sigma_Plus67'
						actions.ReduceRULE_X_AVERAGE_F67_SIGMA_PLUS67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_AVERAGE_F97_SQUARE97 :
						// <X_Average> ::= 'f97' 'Square97'
						actions.ReduceRULE_X_AVERAGE_F97_SQUARE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EQ_0_F67_SUBTRACTION67 :
						// <X_EQ_0> ::= 'f67' 'Subtraction67'
						actions.ReduceRULE_X_EQ_0_F67_SUBTRACTION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EQ_0_F97_FIVE97 :
						// <X_EQ_0> ::= 'f97' 'Five97'
						actions.ReduceRULE_X_EQ_0_F97_FIVE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EQ_Y_G67_SUBTRACTION67 :
						// <X_EQ_Y> ::= 'g67' 'Subtraction67'
						actions.ReduceRULE_X_EQ_Y_G67_SUBTRACTION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EQ_Y_F97_EIGHT97 :
						// <X_EQ_Y> ::= 'f97' 'Eight97'
						actions.ReduceRULE_X_EQ_Y_F97_EIGHT97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EXCHANGE_I_H67_SUB_I67 :
						// <X_Exchange_I> ::= 'h67' 'Sub_I67'
						actions.ReduceRULE_X_EXCHANGE_I_H67_SUB_I67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 :
						// <X_Exchange_I> ::= 'f97' 'X_Exchange_Y97'
						actions.ReduceRULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EXCHANGE_Y_X_EXCHANGE_Y35 :
						// <X_Exchange_Y> ::= 'X_Exchange_Y35'
						actions.ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_Y35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EXCHANGE_Y_H67_SEVEN67 :
						// <X_Exchange_Y> ::= 'h67' 'Seven67'
						actions.ReduceRULE_X_EXCHANGE_Y_H67_SEVEN67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_EXCHANGE_Y_X_EXCHANGE_Y97 :
						// <X_Exchange_Y> ::= 'X_Exchange_Y97'
						actions.ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_Y97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_GT_0_F67_DIVISION67 :
						// <X_GT_0> ::= 'f67' 'Division67'
						actions.ReduceRULE_X_GT_0_F67_DIVISION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_GT_0_F97_SIX97 :
						// <X_GT_0> ::= 'f97' 'Six97'
						actions.ReduceRULE_X_GT_0_F97_SIX97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_GT_Y_G67_DIVISION67 :
						// <X_GT_Y> ::= 'g67' 'Division67'
						actions.ReduceRULE_X_GT_Y_G67_DIVISION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_GT_Y_F97_NINE97 :
						// <X_GT_Y> ::= 'f97' 'Nine97'
						actions.ReduceRULE_X_GT_Y_F97_NINE97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_LE_Y_G67_MULTIPLICATION67 :
						// <X_LE_Y> ::= 'g67' 'Multiplication67'
						actions.ReduceRULE_X_LE_Y_G67_MULTIPLICATION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_LE_Y_F97_MULTIPLICATION97 :
						// <X_LE_Y> ::= 'f97' 'Multiplication97'
						actions.ReduceRULE_X_LE_Y_F97_MULTIPLICATION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_LT_0_F67_MULTIPLICATION67 :
						// <X_LT_0> ::= 'f67' 'Multiplication67'
						actions.ReduceRULE_X_LT_0_F67_MULTIPLICATION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_LT_0_F97_SUBTRACTION97 :
						// <X_LT_0> ::= 'f97' 'Subtraction97'
						actions.ReduceRULE_X_LT_0_F97_SUBTRACTION97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_NE_0_F67_ADDITION67 :
						// <X_NE_0> ::= 'f67' 'Addition67'
						actions.ReduceRULE_X_NE_0_F67_ADDITION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_NE_0_F97_FOUR97 :
						// <X_NE_0> ::= 'f97' 'Four97'
						actions.ReduceRULE_X_NE_0_F97_FOUR97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_NE_Y_G67_ADDITION67 :
						// <X_NE_Y> ::= 'g67' 'Addition67'
						actions.ReduceRULE_X_NE_Y_G67_ADDITION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_NE_Y_F97_SEVEN97 :
						// <X_NE_Y> ::= 'f97' 'Seven97'
						actions.ReduceRULE_X_NE_Y_F97_SEVEN97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_X_TO_THE_YTH_X_TO_THE_YTH35 :
						// <X_To_The_Yth> ::= 'X_To_The_Yth35'
						actions.ReduceRULE_X_TO_THE_YTH_X_TO_THE_YTH35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_Y_TO_THE_XTH_H67_FIVE67 :
						// <Y_To_The_Xth> ::= 'h67' 'Five67'
						actions.ReduceRULE_Y_TO_THE_XTH_H67_FIVE67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_Y_TO_THE_XTH_Y_TO_THE_XTH97 :
						// <Y_To_The_Xth> ::= 'Y_To_The_Xth97'
						actions.ReduceRULE_Y_TO_THE_XTH_Y_TO_THE_XTH97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ZERO_ZERO35 :
						// <Zero> ::= 'Zero35'
						actions.ReduceRULE_ZERO_ZERO35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ZERO_ZERO67 :
						// <Zero> ::= 'Zero67'
						actions.ReduceRULE_ZERO_ZERO67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_ZERO_ZERO97 :
						// <Zero> ::= 'Zero97'
						actions.ReduceRULE_ZERO_ZERO97 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_INSTRUCTION :
						// <Instruction> ::= <Nullary_Instruction>
						actions.ReduceRULE_INSTRUCTION (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_INSTRUCTION2 :
						// <Instruction> ::= <Unary_Instruction>
						actions.ReduceRULE_INSTRUCTION2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_INSTRUCTION3 :
						// <Instruction> ::= <Binary_Instruction>
						actions.ReduceRULE_INSTRUCTION3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_INSTRUCTION4 :
						// <Instruction> ::= <Ternary_Instruction>
						actions.ReduceRULE_INSTRUCTION4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GSB_LC_SHORTCUT :
						// <Gsb_LC_Shortcut> ::= <Lowercase_Letter_Label>
						actions.ReduceRULE_GSB_LC_SHORTCUT (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GSB_UC_SHORTCUT :
						// <Gsb_UC_Shortcut> ::= <Uppercase_Letter_Label>
						actions.ReduceRULE_GSB_UC_SHORTCUT (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RCL_I_SHORTCUT :
						// <Rcl_I_Shortcut> ::= <I>
						actions.ReduceRULE_RCL_I_SHORTCUT (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RCL_SUB_I_SHORTCUT :
						// <Rcl_Sub_I_Shortcut> ::= <Sub_I>
						actions.ReduceRULE_RCL_SUB_I_SHORTCUT (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION :
						// <Nullary_Instruction> ::= <Abs>
						actions.ReduceRULE_NULLARY_INSTRUCTION (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION2 :
						// <Nullary_Instruction> ::= <Addition>
						actions.ReduceRULE_NULLARY_INSTRUCTION2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION3 :
						// <Nullary_Instruction> ::= <Arccos>
						actions.ReduceRULE_NULLARY_INSTRUCTION3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION4 :
						// <Nullary_Instruction> ::= <Arcsin>
						actions.ReduceRULE_NULLARY_INSTRUCTION4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION5 :
						// <Nullary_Instruction> ::= <Arctan>
						actions.ReduceRULE_NULLARY_INSTRUCTION5 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION6 :
						// <Nullary_Instruction> ::= <Bst>
						actions.ReduceRULE_NULLARY_INSTRUCTION6 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION7 :
						// <Nullary_Instruction> ::= <Chs>
						actions.ReduceRULE_NULLARY_INSTRUCTION7 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION8 :
						// <Nullary_Instruction> ::= <Cl_Prgm>
						actions.ReduceRULE_NULLARY_INSTRUCTION8 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION9 :
						// <Nullary_Instruction> ::= <Cl_Reg>
						actions.ReduceRULE_NULLARY_INSTRUCTION9 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION10 :
						// <Nullary_Instruction> ::= <Clr>
						actions.ReduceRULE_NULLARY_INSTRUCTION10 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION11 :
						// <Nullary_Instruction> ::= <Clx>
						actions.ReduceRULE_NULLARY_INSTRUCTION11 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION12 :
						// <Nullary_Instruction> ::= <Cos>
						actions.ReduceRULE_NULLARY_INSTRUCTION12 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION13 :
						// <Nullary_Instruction> ::= <Deg>
						actions.ReduceRULE_NULLARY_INSTRUCTION13 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION14 :
						// <Nullary_Instruction> ::= <Del>
						actions.ReduceRULE_NULLARY_INSTRUCTION14 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION15 :
						// <Nullary_Instruction> ::= <Digit>
						actions.ReduceRULE_NULLARY_INSTRUCTION15 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION16 :
						// <Nullary_Instruction> ::= <Display_X>
						actions.ReduceRULE_NULLARY_INSTRUCTION16 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION17 :
						// <Nullary_Instruction> ::= <Division>
						actions.ReduceRULE_NULLARY_INSTRUCTION17 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION18 :
						// <Nullary_Instruction> ::= <Dsz_Sub_I>
						actions.ReduceRULE_NULLARY_INSTRUCTION18 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION19 :
						// <Nullary_Instruction> ::= <Dsz>
						actions.ReduceRULE_NULLARY_INSTRUCTION19 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION20 :
						// <Nullary_Instruction> ::= <Eex>
						actions.ReduceRULE_NULLARY_INSTRUCTION20 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION21 :
						// <Nullary_Instruction> ::= <Eng>
						actions.ReduceRULE_NULLARY_INSTRUCTION21 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION22 :
						// <Nullary_Instruction> ::= <Enter>
						actions.ReduceRULE_NULLARY_INSTRUCTION22 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION23 :
						// <Nullary_Instruction> ::= <Exp>
						actions.ReduceRULE_NULLARY_INSTRUCTION23 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION24 :
						// <Nullary_Instruction> ::= <Factorial>
						actions.ReduceRULE_NULLARY_INSTRUCTION24 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION25 :
						// <Nullary_Instruction> ::= <Fix>
						actions.ReduceRULE_NULLARY_INSTRUCTION25 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION26 :
						// <Nullary_Instruction> ::= <Frac>
						actions.ReduceRULE_NULLARY_INSTRUCTION26 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION27 :
						// <Nullary_Instruction> ::= <Grd>
						actions.ReduceRULE_NULLARY_INSTRUCTION27 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION28 :
						// <Nullary_Instruction> ::= <HMS_Plus>
						actions.ReduceRULE_NULLARY_INSTRUCTION28 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION29 :
						// <Nullary_Instruction> ::= <Int>
						actions.ReduceRULE_NULLARY_INSTRUCTION29 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION30 :
						// <Nullary_Instruction> ::= <Isz_Sub_I>
						actions.ReduceRULE_NULLARY_INSTRUCTION30 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION31 :
						// <Nullary_Instruction> ::= <Isz>
						actions.ReduceRULE_NULLARY_INSTRUCTION31 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION32 :
						// <Nullary_Instruction> ::= <Ln>
						actions.ReduceRULE_NULLARY_INSTRUCTION32 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION33 :
						// <Nullary_Instruction> ::= <Log>
						actions.ReduceRULE_NULLARY_INSTRUCTION33 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION34 :
						// <Nullary_Instruction> ::= <Lst_X>
						actions.ReduceRULE_NULLARY_INSTRUCTION34 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION35 :
						// <Nullary_Instruction> ::= <Merge>
						actions.ReduceRULE_NULLARY_INSTRUCTION35 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION36 :
						// <Nullary_Instruction> ::= <Multiplication>
						actions.ReduceRULE_NULLARY_INSTRUCTION36 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION37 :
						// <Nullary_Instruction> ::= <P_Exchange_S>
						actions.ReduceRULE_NULLARY_INSTRUCTION37 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION38 :
						// <Nullary_Instruction> ::= <Pause>
						actions.ReduceRULE_NULLARY_INSTRUCTION38 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION39 :
						// <Nullary_Instruction> ::= <Percent_Change>
						actions.ReduceRULE_NULLARY_INSTRUCTION39 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION40 :
						// <Nullary_Instruction> ::= <Percent>
						actions.ReduceRULE_NULLARY_INSTRUCTION40 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION41 :
						// <Nullary_Instruction> ::= <Period>
						actions.ReduceRULE_NULLARY_INSTRUCTION41 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION42 :
						// <Nullary_Instruction> ::= <Pi>
						actions.ReduceRULE_NULLARY_INSTRUCTION42 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION43 :
						// <Nullary_Instruction> ::= <Print_Prgm>
						actions.ReduceRULE_NULLARY_INSTRUCTION43 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION44 :
						// <Nullary_Instruction> ::= <R_Down>
						actions.ReduceRULE_NULLARY_INSTRUCTION44 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION45 :
						// <Nullary_Instruction> ::= <R_S>
						actions.ReduceRULE_NULLARY_INSTRUCTION45 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION46 :
						// <Nullary_Instruction> ::= <R_Up>
						actions.ReduceRULE_NULLARY_INSTRUCTION46 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION47 :
						// <Nullary_Instruction> ::= <Rad>
						actions.ReduceRULE_NULLARY_INSTRUCTION47 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION48 :
						// <Nullary_Instruction> ::= <Rc_I_67>
						actions.ReduceRULE_NULLARY_INSTRUCTION48 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION49 :
						// <Nullary_Instruction> ::= <Rcl_I_Shortcut>
						actions.ReduceRULE_NULLARY_INSTRUCTION49 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION50 :
						// <Nullary_Instruction> ::= <Rcl_Nullary>
						actions.ReduceRULE_NULLARY_INSTRUCTION50 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION51 :
						// <Nullary_Instruction> ::= <Rcl_Sigma_Plus>
						actions.ReduceRULE_NULLARY_INSTRUCTION51 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION52 :
						// <Nullary_Instruction> ::= <Rcl_Sub_I_Shortcut>
						actions.ReduceRULE_NULLARY_INSTRUCTION52 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION53 :
						// <Nullary_Instruction> ::= <Reciprocal>
						actions.ReduceRULE_NULLARY_INSTRUCTION53 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION54 :
						// <Nullary_Instruction> ::= <Reg>
						actions.ReduceRULE_NULLARY_INSTRUCTION54 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION55 :
						// <Nullary_Instruction> ::= <Rnd>
						actions.ReduceRULE_NULLARY_INSTRUCTION55 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION56 :
						// <Nullary_Instruction> ::= <Rtn>
						actions.ReduceRULE_NULLARY_INSTRUCTION56 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION57 :
						// <Nullary_Instruction> ::= <S>
						actions.ReduceRULE_NULLARY_INSTRUCTION57 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION58 :
						// <Nullary_Instruction> ::= <Sci>
						actions.ReduceRULE_NULLARY_INSTRUCTION58 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION59 :
						// <Nullary_Instruction> ::= <Sigma_Minus>
						actions.ReduceRULE_NULLARY_INSTRUCTION59 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION60 :
						// <Nullary_Instruction> ::= <Sigma_Plus>
						actions.ReduceRULE_NULLARY_INSTRUCTION60 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION61 :
						// <Nullary_Instruction> ::= <Sin>
						actions.ReduceRULE_NULLARY_INSTRUCTION61 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION62 :
						// <Nullary_Instruction> ::= <Space>
						actions.ReduceRULE_NULLARY_INSTRUCTION62 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION63 :
						// <Nullary_Instruction> ::= <Sqrt>
						actions.ReduceRULE_NULLARY_INSTRUCTION63 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION64 :
						// <Nullary_Instruction> ::= <Square>
						actions.ReduceRULE_NULLARY_INSTRUCTION64 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION65 :
						// <Nullary_Instruction> ::= <Sst>
						actions.ReduceRULE_NULLARY_INSTRUCTION65 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION66 :
						// <Nullary_Instruction> ::= <St_I_67>
						actions.ReduceRULE_NULLARY_INSTRUCTION66 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION67 :
						// <Nullary_Instruction> ::= <Sto_Nullary>
						actions.ReduceRULE_NULLARY_INSTRUCTION67 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION68 :
						// <Nullary_Instruction> ::= <Stk>
						actions.ReduceRULE_NULLARY_INSTRUCTION68 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION69 :
						// <Nullary_Instruction> ::= <Subtraction>
						actions.ReduceRULE_NULLARY_INSTRUCTION69 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION70 :
						// <Nullary_Instruction> ::= <Tan>
						actions.ReduceRULE_NULLARY_INSTRUCTION70 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION71 :
						// <Nullary_Instruction> ::= <Ten_To_The_Xth>
						actions.ReduceRULE_NULLARY_INSTRUCTION71 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION72 :
						// <Nullary_Instruction> ::= <To_Degrees>
						actions.ReduceRULE_NULLARY_INSTRUCTION72 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION73 :
						// <Nullary_Instruction> ::= <To_HMS>
						actions.ReduceRULE_NULLARY_INSTRUCTION73 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION74 :
						// <Nullary_Instruction> ::= <To_Hours>
						actions.ReduceRULE_NULLARY_INSTRUCTION74 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION75 :
						// <Nullary_Instruction> ::= <To_Polar>
						actions.ReduceRULE_NULLARY_INSTRUCTION75 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION76 :
						// <Nullary_Instruction> ::= <To_Radians>
						actions.ReduceRULE_NULLARY_INSTRUCTION76 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION77 :
						// <Nullary_Instruction> ::= <To_Rectangular>
						actions.ReduceRULE_NULLARY_INSTRUCTION77 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION78 :
						// <Nullary_Instruction> ::= <W_Data>
						actions.ReduceRULE_NULLARY_INSTRUCTION78 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION79 :
						// <Nullary_Instruction> ::= <X_Average>
						actions.ReduceRULE_NULLARY_INSTRUCTION79 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION80 :
						// <Nullary_Instruction> ::= <X_EQ_0>
						actions.ReduceRULE_NULLARY_INSTRUCTION80 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION81 :
						// <Nullary_Instruction> ::= <X_EQ_Y>
						actions.ReduceRULE_NULLARY_INSTRUCTION81 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION82 :
						// <Nullary_Instruction> ::= <X_Exchange_I>
						actions.ReduceRULE_NULLARY_INSTRUCTION82 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION83 :
						// <Nullary_Instruction> ::= <X_Exchange_Y>
						actions.ReduceRULE_NULLARY_INSTRUCTION83 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION84 :
						// <Nullary_Instruction> ::= <X_GT_0>
						actions.ReduceRULE_NULLARY_INSTRUCTION84 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION85 :
						// <Nullary_Instruction> ::= <X_GT_Y>
						actions.ReduceRULE_NULLARY_INSTRUCTION85 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION86 :
						// <Nullary_Instruction> ::= <X_LE_Y>
						actions.ReduceRULE_NULLARY_INSTRUCTION86 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION87 :
						// <Nullary_Instruction> ::= <X_LT_0>
						actions.ReduceRULE_NULLARY_INSTRUCTION87 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION88 :
						// <Nullary_Instruction> ::= <X_NE_0>
						actions.ReduceRULE_NULLARY_INSTRUCTION88 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION89 :
						// <Nullary_Instruction> ::= <X_NE_Y>
						actions.ReduceRULE_NULLARY_INSTRUCTION89 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION90 :
						// <Nullary_Instruction> ::= <X_To_The_Yth>
						actions.ReduceRULE_NULLARY_INSTRUCTION90 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_NULLARY_INSTRUCTION91 :
						// <Nullary_Instruction> ::= <Y_To_The_Xth>
						actions.ReduceRULE_NULLARY_INSTRUCTION91 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION :
						// <Unary_Instruction> ::= <CF> <Flag>
						actions.ReduceRULE_UNARY_INSTRUCTION (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION2 :
						// <Unary_Instruction> ::= <Dsp> <Digit_Count>
						actions.ReduceRULE_UNARY_INSTRUCTION2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION3 :
						// <Unary_Instruction> ::= <F_Test> <Flag>
						actions.ReduceRULE_UNARY_INSTRUCTION3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION4 :
						// <Unary_Instruction> ::= <Gsb> <Label>
						actions.ReduceRULE_UNARY_INSTRUCTION4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION5 :
						// <Unary_Instruction> ::= <Gsb_LC_67> <Uppercase_Letter_Label>
						actions.ReduceRULE_UNARY_INSTRUCTION5 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION6 :
						// <Unary_Instruction> ::= <Gsb_LC_Shortcut>
						actions.ReduceRULE_UNARY_INSTRUCTION6 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION7 :
						// <Unary_Instruction> ::= <Gsb_UC_Shortcut>
						actions.ReduceRULE_UNARY_INSTRUCTION7 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION8 :
						// <Unary_Instruction> ::= <Gto> <Label>
						actions.ReduceRULE_UNARY_INSTRUCTION8 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION9 :
						// <Unary_Instruction> ::= <Lbl> <Label>
						actions.ReduceRULE_UNARY_INSTRUCTION9 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION10 :
						// <Unary_Instruction> ::= <Lbl_LC_67> <Uppercase_Letter_Label>
						actions.ReduceRULE_UNARY_INSTRUCTION10 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION11 :
						// <Unary_Instruction> ::= <Rcl> <Memory>
						actions.ReduceRULE_UNARY_INSTRUCTION11 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION12 :
						// <Unary_Instruction> ::= <SF> <Flag>
						actions.ReduceRULE_UNARY_INSTRUCTION12 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UNARY_INSTRUCTION13 :
						// <Unary_Instruction> ::= <Sto> <Memory>
						actions.ReduceRULE_UNARY_INSTRUCTION13 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_BINARY_INSTRUCTION :
						// <Binary_Instruction> ::= <Sto> <Operator> <Operable_Memory>
						actions.ReduceRULE_BINARY_INSTRUCTION (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_TERNARY_INSTRUCTION :
						// <Ternary_Instruction> ::= <Gto_Period> <Digit> <Digit> <Digit>
						actions.ReduceRULE_TERNARY_INSTRUCTION (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_RCL_SIGMA_PLUS :
						// <Rcl_Sigma_Plus> ::= <Rcl> <Sigma_Plus>
						actions.ReduceRULE_RCL_SIGMA_PLUS (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_GTO_PERIOD :
						// <Gto_Period> ::= <Gto> <Period>
						actions.ReduceRULE_GTO_PERIOD (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_OPERATOR :
						// <Operator> ::= <Subtraction>
						actions.ReduceRULE_OPERATOR (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_OPERATOR2 :
						// <Operator> ::= <Addition>
						actions.ReduceRULE_OPERATOR2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_OPERATOR3 :
						// <Operator> ::= <Multiplication>
						actions.ReduceRULE_OPERATOR3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_OPERATOR4 :
						// <Operator> ::= <Division>
						actions.ReduceRULE_OPERATOR4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT :
						// <Digit> ::= <Zero>
						actions.ReduceRULE_DIGIT (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT2 :
						// <Digit> ::= <One>
						actions.ReduceRULE_DIGIT2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT3 :
						// <Digit> ::= <Two>
						actions.ReduceRULE_DIGIT3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT4 :
						// <Digit> ::= <Three>
						actions.ReduceRULE_DIGIT4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT5 :
						// <Digit> ::= <Four>
						actions.ReduceRULE_DIGIT5 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT6 :
						// <Digit> ::= <Five>
						actions.ReduceRULE_DIGIT6 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT7 :
						// <Digit> ::= <Six>
						actions.ReduceRULE_DIGIT7 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT8 :
						// <Digit> ::= <Seven>
						actions.ReduceRULE_DIGIT8 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT9 :
						// <Digit> ::= <Eight>
						actions.ReduceRULE_DIGIT9 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT10 :
						// <Digit> ::= <Nine>
						actions.ReduceRULE_DIGIT10 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT_COUNT :
						// <Digit_Count> ::= <Digit>
						actions.ReduceRULE_DIGIT_COUNT (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT_COUNT2 :
						// <Digit_Count> ::= <Sub_I>
						actions.ReduceRULE_DIGIT_COUNT2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FLAG :
						// <Flag> ::= <Zero>
						actions.ReduceRULE_FLAG (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FLAG2 :
						// <Flag> ::= <One>
						actions.ReduceRULE_FLAG2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FLAG3 :
						// <Flag> ::= <Two>
						actions.ReduceRULE_FLAG3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_FLAG4 :
						// <Flag> ::= <Three>
						actions.ReduceRULE_FLAG4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UPPERCASE_LETTER :
						// <Uppercase_Letter> ::= <A>
						actions.ReduceRULE_UPPERCASE_LETTER (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UPPERCASE_LETTER2 :
						// <Uppercase_Letter> ::= <B>
						actions.ReduceRULE_UPPERCASE_LETTER2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UPPERCASE_LETTER3 :
						// <Uppercase_Letter> ::= <C>
						actions.ReduceRULE_UPPERCASE_LETTER3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UPPERCASE_LETTER4 :
						// <Uppercase_Letter> ::= <D>
						actions.ReduceRULE_UPPERCASE_LETTER4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UPPERCASE_LETTER5 :
						// <Uppercase_Letter> ::= <E>
						actions.ReduceRULE_UPPERCASE_LETTER5 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LC_A :
						// <LC_a> ::= <f> <A>
						actions.ReduceRULE_LC_A (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LC_B :
						// <LC_b> ::= <f> <B>
						actions.ReduceRULE_LC_B (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LC_C :
						// <LC_c> ::= <f> <C>
						actions.ReduceRULE_LC_C (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LC_D :
						// <LC_d> ::= <f> <D>
						actions.ReduceRULE_LC_D (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LC_E :
						// <LC_e> ::= <f> <E>
						actions.ReduceRULE_LC_E (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_UPPERCASE_LETTER_LABEL :
						// <Uppercase_Letter_Label> ::= <Uppercase_Letter>
						actions.ReduceRULE_UPPERCASE_LETTER_LABEL (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOWERCASE_LETTER_LABEL :
						// <Lowercase_Letter_Label> ::= <LC_a>
						actions.ReduceRULE_LOWERCASE_LETTER_LABEL (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOWERCASE_LETTER_LABEL2 :
						// <Lowercase_Letter_Label> ::= <LC_b>
						actions.ReduceRULE_LOWERCASE_LETTER_LABEL2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOWERCASE_LETTER_LABEL3 :
						// <Lowercase_Letter_Label> ::= <LC_c>
						actions.ReduceRULE_LOWERCASE_LETTER_LABEL3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOWERCASE_LETTER_LABEL4 :
						// <Lowercase_Letter_Label> ::= <LC_d>
						actions.ReduceRULE_LOWERCASE_LETTER_LABEL4 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LOWERCASE_LETTER_LABEL5 :
						// <Lowercase_Letter_Label> ::= <LC_e>
						actions.ReduceRULE_LOWERCASE_LETTER_LABEL5 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LETTER_LABEL :
						// <Letter_Label> ::= <Lowercase_Letter_Label>
						actions.ReduceRULE_LETTER_LABEL (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LETTER_LABEL2 :
						// <Letter_Label> ::= <Uppercase_Letter_Label>
						actions.ReduceRULE_LETTER_LABEL2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_DIGIT_LABEL :
						// <Digit_Label> ::= <Digit>
						actions.ReduceRULE_DIGIT_LABEL (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LABEL :
						// <Label> ::= <Digit_Label>
						actions.ReduceRULE_LABEL (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LABEL2 :
						// <Label> ::= <Letter_Label>
						actions.ReduceRULE_LABEL2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_LABEL3 :
						// <Label> ::= <Sub_I>
						actions.ReduceRULE_LABEL3 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_OPERABLE_MEMORY :
						// <Operable_Memory> ::= <Digit>
						actions.ReduceRULE_OPERABLE_MEMORY (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_OPERABLE_MEMORY2 :
						// <Operable_Memory> ::= <Sub_I>
						actions.ReduceRULE_OPERABLE_MEMORY2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MEMORY :
						// <Memory> ::= <Operable_Memory>
						actions.ReduceRULE_MEMORY (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MEMORY2 :
						// <Memory> ::= <Uppercase_Letter>
						actions.ReduceRULE_MEMORY2 (reader, args.Token, args.Token.Tokens, state);
						return;
					case RuleConstants.RULE_MEMORY3 :
						// <Memory> ::= <I>
						actions.ReduceRULE_MEMORY3 (reader, args.Token, args.Token.Tokens, state);
						return;
				}
            }
            catch (SyntaxError ex) {
				args.Continue = false;
				actions.ParserError (input, ex.UnexpectedToken);
				Trace.WriteLineIf (classTraceSwitch.TraceInfo,
					"ReduceEvent: Exception " + ex.ToString (), 
					classTraceSwitch.DisplayName);
            }
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
			actions.ParserAccept ();
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
			Trace.Assert (false);
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
			actions.ParserError (input, args.UnexpectedToken);
        }

        public Parser (Reader reader, object state, IActions a)
        {
			this.state = state;
			this.reader = reader;
            parser = reader.CreateNewParser ();
            parser.TrimReductions = false; 

			// We need to store the tokens so as to be able to locate the faulty terminal in the
			// case where the error is detected by the actions.
            parser.StoreTokens = LALRParser.StoreTokensMode.Always;
            
            parser.OnReduce += new LALRParser.ReduceHandler (ReduceEvent);
            parser.OnAccept += new LALRParser.AcceptHandler (AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler (TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler (ParseErrorEvent);
            actions = a;
        }

        public void Parse (string s)
        {
			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"Parse: called with '" + s + "'",
				classTraceSwitch.DisplayName);

			input = actions.RemainingText + " " + s;

			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"Parse: analyzing '" + input + "'",
				classTraceSwitch.DisplayName);

            parser.Parse (input);
            while (actions.Retry) {
				input = actions.RemainingText;

				Trace.WriteLineIf (classTraceSwitch.TraceInfo,
					"Parse: retrying analysis with '" + input + "'", 
					classTraceSwitch.DisplayName);
				
				parser.Parse (input);
            }
        }
        
    }
}
