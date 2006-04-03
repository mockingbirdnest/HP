
using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace HP_Parser
{

    public enum SymbolConstants : int
    {
        SYMBOL_EOF                    = 0  , // (EOF)
        SYMBOL_ERROR                  = 1  , // (Error)
        SYMBOL_WHITESPACE             = 2  , // (Whitespace)
        SYMBOL_A67                    = 3  , // 'A67'
        SYMBOL_A97                    = 4  , // 'A97'
        SYMBOL_ADDITION67             = 5  , // 'Addition67'
        SYMBOL_ADDITION97             = 6  , // 'Addition97'
        SYMBOL_B67                    = 7  , // 'B67'
        SYMBOL_B97                    = 8  , // 'B97'
        SYMBOL_BST97                  = 9  , // 'Bst97'
        SYMBOL_C67                    = 10 , // 'C67'
        SYMBOL_C97                    = 11 , // 'C97'
        SYMBOL_CHS67                  = 12 , // 'Chs67'
        SYMBOL_CHS97                  = 13 , // 'Chs97'
        SYMBOL_CLX67                  = 14 , // 'Clx67'
        SYMBOL_CLX97                  = 15 , // 'Clx97'
        SYMBOL_COS97                  = 16 , // 'Cos97'
        SYMBOL_D67                    = 17 , // 'D67'
        SYMBOL_D97                    = 18 , // 'D97'
        SYMBOL_DIPLAY_X97             = 19 , // 'Diplay_X97'
        SYMBOL_DISPLAY_X97            = 20 , // 'Display_X97'
        SYMBOL_DIVISION67             = 21 , // 'Division67'
        SYMBOL_DIVISION97             = 22 , // 'Division97'
        SYMBOL_DSP67                  = 23 , // 'Dsp67'
        SYMBOL_DSP97                  = 24 , // 'Dsp97'
        SYMBOL_E67                    = 25 , // 'E67'
        SYMBOL_E97                    = 26 , // 'E97'
        SYMBOL_EEX67                  = 27 , // 'Eex67'
        SYMBOL_EEX97                  = 28 , // 'Eex97'
        SYMBOL_EIGHT67                = 29 , // 'Eight67'
        SYMBOL_EIGHT97                = 30 , // 'Eight97'
        SYMBOL_ENG97                  = 31 , // 'Eng97'
        SYMBOL_ENTER67                = 32 , // 'Enter67'
        SYMBOL_ENTER97                = 33 , // 'Enter97'
        SYMBOL_EXP97                  = 34 , // 'Exp97'
        SYMBOL_F67                    = 35 , // 'f67'
        SYMBOL_F97                    = 36 , // 'f97'
        SYMBOL_FIVE67                 = 37 , // 'Five67'
        SYMBOL_FIVE97                 = 38 , // 'Five97'
        SYMBOL_FIX97                  = 39 , // 'Fix97'
        SYMBOL_FOUR67                 = 40 , // 'Four67'
        SYMBOL_FOUR97                 = 41 , // 'Four97'
        SYMBOL_G67                    = 42 , // 'g67'
        SYMBOL_GSB97                  = 43 , // 'Gsb97'
        SYMBOL_GTO67                  = 44 , // 'Gto67'
        SYMBOL_GTO97                  = 45 , // 'Gto97'
        SYMBOL_H67                    = 46 , // 'h67'
        SYMBOL_I97                    = 47 , // 'I97'
        SYMBOL_LBL97                  = 48 , // 'Lbl97'
        SYMBOL_LN97                   = 49 , // 'Ln97'
        SYMBOL_MULTIPLICATION67       = 50 , // 'Multiplication67'
        SYMBOL_MULTIPLICATION97       = 51 , // 'Multiplication97'
        SYMBOL_NINE67                 = 52 , // 'Nine67'
        SYMBOL_NINE97                 = 53 , // 'Nine97'
        SYMBOL_ONE67                  = 54 , // 'One67'
        SYMBOL_ONE97                  = 55 , // 'One97'
        SYMBOL_PERCENT97              = 56 , // 'Percent97'
        SYMBOL_PERIOD67               = 57 , // 'Period67'
        SYMBOL_PERIOD97               = 58 , // 'Period97'
        SYMBOL_R_DOWN97               = 59 , // 'R_Down97'
        SYMBOL_R_S67                  = 60 , // 'R_S67'
        SYMBOL_R_S97                  = 61 , // 'R_S97'
        SYMBOL_RCL67                  = 62 , // 'Rcl67'
        SYMBOL_RCL97                  = 63 , // 'Rcl97'
        SYMBOL_RECIPROCAL97           = 64 , // 'Reciprocal97'
        SYMBOL_RTN97                  = 65 , // 'Rtn97'
        SYMBOL_SCI97                  = 66 , // 'Sci97'
        SYMBOL_SEVEN67                = 67 , // 'Seven67'
        SYMBOL_SEVEN97                = 68 , // 'Seven97'
        SYMBOL_SIGMA_PLUS67           = 69 , // 'Sigma_Plus67'
        SYMBOL_SIGMA_PLUS97           = 70 , // 'Sigma_Plus97'
        SYMBOL_SIN97                  = 71 , // 'Sin97'
        SYMBOL_SIX67                  = 72 , // 'Six67'
        SYMBOL_SIX97                  = 73 , // 'Six97'
        SYMBOL_SQRT97                 = 74 , // 'Sqrt97'
        SYMBOL_SQUARE97               = 75 , // 'Square97'
        SYMBOL_SST67                  = 76 , // 'Sst67'
        SYMBOL_SST97                  = 77 , // 'Sst97'
        SYMBOL_STO67                  = 78 , // 'Sto67'
        SYMBOL_STO97                  = 79 , // 'Sto97'
        SYMBOL_SUB_I67                = 80 , // 'Sub_I67'
        SYMBOL_SUB_I97                = 81 , // 'Sub_I97'
        SYMBOL_SUBTRACTION67          = 82 , // 'Subtraction67'
        SYMBOL_SUBTRACTION97          = 83 , // 'Subtraction97'
        SYMBOL_TAN97                  = 84 , // 'Tan97'
        SYMBOL_THREE67                = 85 , // 'Three67'
        SYMBOL_THREE97                = 86 , // 'Three97'
        SYMBOL_TO_POLAR97             = 87 , // 'To_Polar97'
        SYMBOL_TO_RECTANGULAR97       = 88 , // 'To_Rectangular97'
        SYMBOL_TWO67                  = 89 , // 'Two67'
        SYMBOL_TWO97                  = 90 , // 'Two97'
        SYMBOL_X_EXCHANGE_97          = 91 , // 'X_Exchange_97'
        SYMBOL_X_EXCHANGE_Y97         = 92 , // 'X_Exchange_Y97'
        SYMBOL_Y_TO_THE_XTH           = 93 , // 'Y_To_The_Xth'
        SYMBOL_Y_TO_THE_XTH97         = 94 , // 'Y_To_The_Xth97'
        SYMBOL_ZERO67                 = 95 , // 'Zero67'
        SYMBOL_ZERO97                 = 96 , // 'Zero97'
        SYMBOL_A                      = 97 , // <A>
        SYMBOL_ABS                    = 98 , // <Abs>
        SYMBOL_ADDITION               = 99 , // <Addition>
        SYMBOL_ARCCOS                 = 100, // <Arccos>
        SYMBOL_ARCSIN                 = 101, // <Arcsin>
        SYMBOL_ARCTAN                 = 102, // <Arctan>
        SYMBOL_B                      = 103, // <B>
        SYMBOL_BINARY_INSTRUCTION     = 104, // <Binary_Instruction>
        SYMBOL_BST                    = 105, // <Bst>
        SYMBOL_C                      = 106, // <C>
        SYMBOL_CF                     = 107, // <CF>
        SYMBOL_CHS                    = 108, // <Chs>
        SYMBOL_CL_PRGM                = 109, // <Cl_Prgm>
        SYMBOL_CL_REG                 = 110, // <Cl_Reg>
        SYMBOL_CLX                    = 111, // <Clx>
        SYMBOL_COS                    = 112, // <Cos>
        SYMBOL_D                      = 113, // <D>
        SYMBOL_DEG                    = 114, // <Deg>
        SYMBOL_DEL                    = 115, // <Del>
        SYMBOL_DIGIT                  = 116, // <Digit>
        SYMBOL_DIGIT_COUNT            = 117, // <Digit_Count>
        SYMBOL_DIGIT_LABEL            = 118, // <Digit_Label>
        SYMBOL_DISPLAY_X              = 119, // <Display_X>
        SYMBOL_DIVISION               = 120, // <Division>
        SYMBOL_DSP                    = 121, // <Dsp>
        SYMBOL_DSZ                    = 122, // <Dsz>
        SYMBOL_DSZ_SUB_I              = 123, // <Dsz_Sub_I>
        SYMBOL_E                      = 124, // <E>
        SYMBOL_EEX                    = 125, // <Eex>
        SYMBOL_EIGHT                  = 126, // <Eight>
        SYMBOL_ENG                    = 127, // <Eng>
        SYMBOL_ENTER                  = 128, // <Enter>
        SYMBOL_EXP                    = 129, // <Exp>
        SYMBOL_F                      = 130, // <f>
        SYMBOL_F_TEST                 = 131, // <F_Test>
        SYMBOL_FACTORIAL              = 132, // <Factorial>
        SYMBOL_FIVE                   = 133, // <Five>
        SYMBOL_FIX                    = 134, // <Fix>
        SYMBOL_FLAG                   = 135, // <Flag>
        SYMBOL_FOUR                   = 136, // <Four>
        SYMBOL_FRAC                   = 137, // <Frac>
        SYMBOL_GRD                    = 138, // <Grd>
        SYMBOL_GSB                    = 139, // <Gsb>
        SYMBOL_GSB_F                  = 140, // <Gsb_f>
        SYMBOL_GSB_SHORTCUT           = 141, // <Gsb_Shortcut>
        SYMBOL_GTO                    = 142, // <Gto>
        SYMBOL_GTO_PERIOD             = 143, // <Gto_Period>
        SYMBOL_HMS_PLUS               = 144, // <HMS_Plus>
        SYMBOL_INSTRUCTION            = 145, // <Instruction>
        SYMBOL_INT                    = 146, // <Int>
        SYMBOL_ISZ                    = 147, // <Isz>
        SYMBOL_ISZ_SUB_I              = 148, // <Isz_Sub_I>
        SYMBOL_LABEL                  = 149, // <Label>
        SYMBOL_LBL                    = 150, // <Lbl>
        SYMBOL_LBL_F                  = 151, // <Lbl_f>
        SYMBOL_LETTER                 = 152, // <Letter>
        SYMBOL_LETTER_LABEL           = 153, // <Letter_Label>
        SYMBOL_LN                     = 154, // <Ln>
        SYMBOL_LOG                    = 155, // <Log>
        SYMBOL_LOWERCASE_LETTER_LABEL = 156, // <Lowercase_Letter_Label>
        SYMBOL_LST_X                  = 157, // <Lst_X>
        SYMBOL_MEMORY                 = 158, // <Memory>
        SYMBOL_MEMORY_SHORTCUT        = 159, // <Memory_Shortcut>
        SYMBOL_MERGE                  = 160, // <Merge>
        SYMBOL_MULTIPLICATION         = 161, // <Multiplication>
        SYMBOL_NINE                   = 162, // <Nine>
        SYMBOL_NON_LOWERCASE_LABEL    = 163, // <Non_Lowercase_Label>
        SYMBOL_NULLARY_INSTRUCTION    = 164, // <Nullary_Instruction>
        SYMBOL_ONE                    = 165, // <One>
        SYMBOL_OPERABLE_MEMORY        = 166, // <Operable_Memory>
        SYMBOL_OPERATOR               = 167, // <Operator>
        SYMBOL_P_EXCHANGE_S           = 168, // <P_Exchange_S>
        SYMBOL_PAUSE                  = 169, // <Pause>
        SYMBOL_PERCENT                = 170, // <Percent>
        SYMBOL_PERCENT_CHANGE         = 171, // <Percent_Change>
        SYMBOL_PERIOD                 = 172, // <Period>
        SYMBOL_PI                     = 173, // <Pi>
        SYMBOL_PRINT_PRGM             = 174, // <Print_Prgm>
        SYMBOL_R_DOWN                 = 175, // <R_Down>
        SYMBOL_R_S                    = 176, // <R_S>
        SYMBOL_R_UP                   = 177, // <R_Up>
        SYMBOL_RAD                    = 178, // <Rad>
        SYMBOL_RC_I                   = 179, // <Rc_I>
        SYMBOL_RCL                    = 180, // <Rcl>
        SYMBOL_RCL_SIGMA_PLUS         = 181, // <Rcl_Sigma_Plus>
        SYMBOL_RECIPROCAL             = 182, // <Reciprocal>
        SYMBOL_REG                    = 183, // <Reg>
        SYMBOL_RND                    = 184, // <Rnd>
        SYMBOL_RTN                    = 185, // <Rtn>
        SYMBOL_S                      = 186, // <S>
        SYMBOL_SCI                    = 187, // <Sci>
        SYMBOL_SEVEN                  = 188, // <Seven>
        SYMBOL_SF                     = 189, // <SF>
        SYMBOL_SHORTCUT               = 190, // <Shortcut>
        SYMBOL_SIGMA_MINUS            = 191, // <Sigma_Minus>
        SYMBOL_SIGMA_PLUS             = 192, // <Sigma_Plus>
        SYMBOL_SIN                    = 193, // <Sin>
        SYMBOL_SIX                    = 194, // <Six>
        SYMBOL_SPACE                  = 195, // <Space>
        SYMBOL_SQRT                   = 196, // <Sqrt>
        SYMBOL_SQUARE                 = 197, // <Square>
        SYMBOL_SST                    = 198, // <Sst>
        SYMBOL_ST_I                   = 199, // <St_I>
        SYMBOL_STK                    = 200, // <Stk>
        SYMBOL_STO                    = 201, // <Sto>
        SYMBOL_SUB_I                  = 202, // <Sub_I>
        SYMBOL_SUBTRACTION            = 203, // <Subtraction>
        SYMBOL_TAN                    = 204, // <Tan>
        SYMBOL_TEN_TO_THE_XTH         = 205, // <Ten_To_The_Xth>
        SYMBOL_TERNARY_INSTRUCTION    = 206, // <Ternary_Instruction>
        SYMBOL_THREE                  = 207, // <Three>
        SYMBOL_TO_DEGREES             = 208, // <To_Degrees>
        SYMBOL_TO_HMS                 = 209, // <To_HMS>
        SYMBOL_TO_HOURS               = 210, // <To_Hours>
        SYMBOL_TO_POLAR               = 211, // <To_Polar>
        SYMBOL_TO_RADIANS             = 212, // <To_Radians>
        SYMBOL_TO_RECTANGULAR         = 213, // <To_Rectangular>
        SYMBOL_TWO                    = 214, // <Two>
        SYMBOL_UNARY_INSTRUCTION      = 215, // <Unary_Instruction>
        SYMBOL_UPPERCASE_LETTER_LABEL = 216, // <Uppercase_Letter_Label>
        SYMBOL_W_DATA                 = 217, // <W_Data>
        SYMBOL_X_AVERAGE              = 218, // <X_Average>
        SYMBOL_X_EQ_0                 = 219, // <X_EQ_0>
        SYMBOL_X_EQ_Y                 = 220, // <X_EQ_Y>
        SYMBOL_X_EXCHANGE_I           = 221, // <X_Exchange_I>
        SYMBOL_X_EXCHANGE_Y           = 222, // <X_Exchange_Y>
        SYMBOL_X_GT_0                 = 223, // <X_GT_0>
        SYMBOL_X_GT_Y                 = 224, // <X_GT_Y>
        SYMBOL_X_LE_Y                 = 225, // <X_LE_Y>
        SYMBOL_X_LT_0                 = 226, // <X_LT_0>
        SYMBOL_X_NE_0                 = 227, // <X_NE_0>
        SYMBOL_X_NE_Y                 = 228, // <X_NE_Y>
        SYMBOL_Y_TO_THE_XTH2          = 229, // <Y_To_The_Xth>
        SYMBOL_ZERO                   = 230  // <Zero>
    };

    enum RuleConstants : int
    {
        RULE_A_A67                           = 0  , // <A> ::= 'A67'
        RULE_A_A97                           = 1  , // <A> ::= 'A97'
        RULE_ABS_H67_SIX67                   = 2  , // <Abs> ::= 'h67' 'Six67'
        RULE_ABS_F97_Y_TO_THE_XTH97          = 3  , // <Abs> ::= 'f97' 'Y_To_The_Xth97'
        RULE_ADDITION_ADDITION67             = 4  , // <Addition> ::= 'Addition67'
        RULE_ADDITION_ADDITION97             = 5  , // <Addition> ::= 'Addition97'
        RULE_ARCCOS_G67_FIVE67               = 6  , // <Arccos> ::= 'g67' 'Five67'
        RULE_ARCCOS_F97_COS97                = 7  , // <Arccos> ::= 'f97' 'Cos97'
        RULE_ARCSIN_G67_FOUR67               = 8  , // <Arcsin> ::= 'g67' 'Four67'
        RULE_ARCSIN_F97_SIN97                = 9  , // <Arcsin> ::= 'f97' 'Sin97'
        RULE_ARCTAN_G67_SIX67                = 10 , // <Arctan> ::= 'g67' 'Six67'
        RULE_ARCTAN_F97_TAN97                = 11 , // <Arctan> ::= 'f97' 'Tan97'
        RULE_B_B67                           = 12 , // <B> ::= 'B67'
        RULE_B_B97                           = 13 , // <B> ::= 'B97'
        RULE_BST_H67_SST67                   = 14 , // <Bst> ::= 'h67' 'Sst67'
        RULE_BST_BST97                       = 15 , // <Bst> ::= 'Bst97'
        RULE_C_C67                           = 16 , // <C> ::= 'C67'
        RULE_C_C97                           = 17 , // <C> ::= 'C97'
        RULE_CF_H67_ADDITION67               = 18 , // <CF> ::= 'h67' 'Addition67'
        RULE_CF_F97_GTO97                    = 19 , // <CF> ::= 'f97' 'Gto97'
        RULE_CHS_CHS67                       = 20 , // <Chs> ::= 'Chs67'
        RULE_CHS_CHS97                       = 21 , // <Chs> ::= 'Chs97'
        RULE_CL_PRGM_F67_CLX67               = 22 , // <Cl_Prgm> ::= 'f67' 'Clx67'
        RULE_CL_PRGM_F97_THREE97             = 23 , // <Cl_Prgm> ::= 'f97' 'Three97'
        RULE_CL_REG_F67_EEX67                = 24 , // <Cl_Reg> ::= 'f67' 'Eex67'
        RULE_CL_REG_F97_TWO97                = 25 , // <Cl_Reg> ::= 'f97' 'Two97'
        RULE_CLX_CLX67                       = 26 , // <Clx> ::= 'Clx67'
        RULE_CLX_CLX97                       = 27 , // <Clx> ::= 'Clx97'
        RULE_COS_F67_FIVE67                  = 28 , // <Cos> ::= 'f67' 'Five67'
        RULE_COS_COS97                       = 29 , // <Cos> ::= 'Cos97'
        RULE_D_D67                           = 30 , // <D> ::= 'D67'
        RULE_D_D97                           = 31 , // <D> ::= 'D97'
        RULE_DEG_H67_ENTER67                 = 32 , // <Deg> ::= 'h67' 'Enter67'
        RULE_DEG_F97_ENTER97                 = 33 , // <Deg> ::= 'f97' 'Enter97'
        RULE_DEL_H67_CLX67                   = 34 , // <Del> ::= 'h67' 'Clx67'
        RULE_DEL_F97_ONE97                   = 35 , // <Del> ::= 'f97' 'One97'
        RULE_DISPLAY_X_F67_R_S67             = 36 , // <Display_X> ::= 'f67' 'R_S67'
        RULE_DISPLAY_X_DISPLAY_X97           = 37 , // <Display_X> ::= 'Display_X97'
        RULE_DIVISION_DIVISION67             = 38 , // <Division> ::= 'Division67'
        RULE_DIVISION_DIVISION97             = 39 , // <Division> ::= 'Division97'
        RULE_DSP_DSP67                       = 40 , // <Dsp> ::= 'Dsp67'
        RULE_DSP_DSP97                       = 41 , // <Dsp> ::= 'Dsp97'
        RULE_DSZ_SUB_I_G67_STO67             = 42 , // <Dsz_Sub_I> ::= 'g67' 'Sto67'
        RULE_DSZ_SUB_I_F97_BST97_SUB_I97     = 43 , // <Dsz_Sub_I> ::= 'f97' 'Bst97' 'Sub_I97'
        RULE_DSZ_F67_STO67                   = 44 , // <Dsz> ::= 'f67' 'Sto67'
        RULE_DSZ_F97_BST97_I97               = 45 , // <Dsz> ::= 'f97' 'Bst97' 'I97'
        RULE_E_E67                           = 46 , // <E> ::= 'E67'
        RULE_E_E97                           = 47 , // <E> ::= 'E97'
        RULE_EEX_EEX67                       = 48 , // <Eex> ::= 'Eex67'
        RULE_EEX_EEX97                       = 49 , // <Eex> ::= 'Eex97'
        RULE_EIGHT_EIGHT67                   = 50 , // <Eight> ::= 'Eight67'
        RULE_EIGHT_EIGHT97                   = 51 , // <Eight> ::= 'Eight97'
        RULE_ENG_H67_DSP67                   = 52 , // <Eng> ::= 'h67' 'Dsp67'
        RULE_ENG_ENG97                       = 53 , // <Eng> ::= 'Eng97'
        RULE_ENTER_ENTER67                   = 54 , // <Enter> ::= 'Enter67'
        RULE_ENTER_ENTER97                   = 55 , // <Enter> ::= 'Enter97'
        RULE_EXP_G67_SEVEN67                 = 56 , // <Exp> ::= 'g67' 'Seven67'
        RULE_EXP_EXP97                       = 57 , // <Exp> ::= 'Exp97'
        RULE_F_F67                           = 58 , // <f> ::= 'f67'
        RULE_F_F97                           = 59 , // <f> ::= 'f97'
        RULE_F_TEST_H67_MULTIPLICATION67     = 60 , // <F_Test> ::= 'h67' 'Multiplication67'
        RULE_F_TEST_F97_GSB97                = 61 , // <F_Test> ::= 'f97' 'Gsb97'
        RULE_FACTORIAL_H67_DIVISION67        = 62 , // <Factorial> ::= 'h67' 'Division67'
        RULE_FACTORIAL_F97_RECIPROCAL97      = 63 , // <Factorial> ::= 'f97' 'Reciprocal97'
        RULE_FIVE_FIVE67                     = 64 , // <Five> ::= 'Five67'
        RULE_FIVE_FIVE97                     = 65 , // <Five> ::= 'Five97'
        RULE_FIX_F67_DSP67                   = 66 , // <Fix> ::= 'f67' 'Dsp67'
        RULE_FIX_FIX97                       = 67 , // <Fix> ::= 'Fix97'
        RULE_FOUR_FOUR67                     = 68 , // <Four> ::= 'Four67'
        RULE_FOUR_FOUR97                     = 69 , // <Four> ::= 'Four97'
        RULE_FRAC_G67_PERIOD67               = 70 , // <Frac> ::= 'g67' 'Period67'
        RULE_FRAC_F97_TO_RECTANGULAR97       = 71 , // <Frac> ::= 'f97' 'To_Rectangular97'
        RULE_GRD_H67_EEX67                   = 72 , // <Grd> ::= 'h67' 'Eex67'
        RULE_GRD_F97_EEX97                   = 73 , // <Grd> ::= 'f97' 'Eex97'
        RULE_GSB_F_G67_GTO67                 = 74 , // <Gsb_f> ::= 'g67' 'Gto67'
        RULE_GSB_F67_GTO67                   = 75 , // <Gsb> ::= 'f67' 'Gto67'
        RULE_GSB_GSB97                       = 76 , // <Gsb> ::= 'Gsb97'
        RULE_GTO_GTO67                       = 77 , // <Gto> ::= 'Gto67'
        RULE_GTO_GTO97                       = 78 , // <Gto> ::= 'Gto97'
        RULE_HMS_PLUS_H67_PERIOD67           = 79 , // <HMS_Plus> ::= 'h67' 'Period67'
        RULE_HMS_PLUS_F97_ADDITION97         = 80 , // <HMS_Plus> ::= 'f97' 'Addition97'
        RULE_INT_F67_PERIOD67                = 81 , // <Int> ::= 'f67' 'Period67'
        RULE_INT_F97_TO_POLAR97              = 82 , // <Int> ::= 'f97' 'To_Polar97'
        RULE_ISZ_SUB_I_G67_RCL67             = 83 , // <Isz_Sub_I> ::= 'g67' 'Rcl67'
        RULE_ISZ_SUB_I_F97_SST97_SUB_I97     = 84 , // <Isz_Sub_I> ::= 'f97' 'Sst97' 'Sub_I97'
        RULE_ISZ_F67_RCL67                   = 85 , // <Isz> ::= 'f67' 'Rcl67'
        RULE_ISZ_F97_SST97_I97               = 86 , // <Isz> ::= 'f97' 'Sst97' 'I97'
        RULE_LBL_F_G67_SST67                 = 87 , // <Lbl_f> ::= 'g67' 'Sst67'
        RULE_LBL_F67_SST67                   = 88 , // <Lbl> ::= 'f67' 'Sst67'
        RULE_LBL_LBL97                       = 89 , // <Lbl> ::= 'Lbl97'
        RULE_LN_F67_SEVEN67                  = 90 , // <Ln> ::= 'f67' 'Seven67'
        RULE_LN_LN97                         = 91 , // <Ln> ::= 'Ln97'
        RULE_LOG_F67_EIGHT67                 = 92 , // <Log> ::= 'f67' 'Eight67'
        RULE_LOG_F97_LN97                    = 93 , // <Log> ::= 'f97' 'Ln97'
        RULE_LST_X_H67_ZERO67                = 94 , // <Lst_X> ::= 'h67' 'Zero67'
        RULE_LST_X_F97_DSP97                 = 95 , // <Lst_X> ::= 'f97' 'Dsp97'
        RULE_MERGE_G67_ENTER67               = 96 , // <Merge> ::= 'g67' 'Enter67'
        RULE_MERGE_F97_PERIOD97              = 97 , // <Merge> ::= 'f97' 'Period97'
        RULE_MULTIPLICATION_MULTIPLICATION67 = 98 , // <Multiplication> ::= 'Multiplication67'
        RULE_MULTIPLICATION_MULTIPLICATION97 = 99 , // <Multiplication> ::= 'Multiplication97'
        RULE_NINE_NINE67                     = 100, // <Nine> ::= 'Nine67'
        RULE_NINE_NINE97                     = 101, // <Nine> ::= 'Nine97'
        RULE_ONE_ONE67                       = 102, // <One> ::= 'One67'
        RULE_ONE_ONE97                       = 103, // <One> ::= 'One97'
        RULE_P_EXCHANGE_S_F67_CHS67          = 104, // <P_Exchange_S> ::= 'f67' 'Chs67'
        RULE_P_EXCHANGE_S_F97_CLX97          = 105, // <P_Exchange_S> ::= 'f97' 'Clx97'
        RULE_PAUSE_H67_ONE67                 = 106, // <Pause> ::= 'h67' 'One67'
        RULE_PAUSE_F97_R_S97                 = 107, // <Pause> ::= 'f97' 'R_S97'
        RULE_PERCENT_CHANGE_G67_ZERO67       = 108, // <Percent_Change> ::= 'g67' 'Zero67'
        RULE_PERCENT_CHANGE_F97_PERCENT97    = 109, // <Percent_Change> ::= 'f97' 'Percent97'
        RULE_PERCENT_F67_ZERO67              = 110, // <Percent> ::= 'f67' 'Zero67'
        RULE_PERCENT_PERCENT97               = 111, // <Percent> ::= 'Percent97'
        RULE_PERIOD_PERIOD67                 = 112, // <Period> ::= 'Period67'
        RULE_PERIOD_PERIOD97                 = 113, // <Period> ::= 'Period97'
        RULE_PI_H67_TWO67                    = 114, // <Pi> ::= 'h67' 'Two67'
        RULE_PI_F97_DIVISION97               = 115, // <Pi> ::= 'f97' 'Division97'
        RULE_PRINT_PRGM_F97_SCI97            = 116, // <Print_Prgm> ::= 'f97' 'Sci97'
        RULE_R_DOWN_H67_EIGHT67              = 117, // <R_Down> ::= 'h67' 'Eight67'
        RULE_R_DOWN_R_DOWN97                 = 118, // <R_Down> ::= 'R_Down97'
        RULE_R_S_R_S67                       = 119, // <R_S> ::= 'R_S67'
        RULE_R_S_R_S97                       = 120, // <R_S> ::= 'R_S97'
        RULE_R_UP_H67_NINE67                 = 121, // <R_Up> ::= 'h67' 'Nine67'
        RULE_R_UP_F97_R_DOWN97               = 122, // <R_Up> ::= 'f97' 'R_Down97'
        RULE_RAD_H67_CHS67                   = 123, // <Rad> ::= 'h67' 'Chs67'
        RULE_RAD_F97_CHS97                   = 124, // <Rad> ::= 'f97' 'Chs97'
        RULE_RC_I_H67_RCL67                  = 125, // <Rc_I> ::= 'h67' 'Rcl67'
        RULE_RC_I_RCL97_I97                  = 126, // <Rc_I> ::= 'Rcl97' 'I97'
        RULE_RCL_RCL67                       = 127, // <Rcl> ::= 'Rcl67'
        RULE_RCL_RCL97                       = 128, // <Rcl> ::= 'Rcl97'
        RULE_RECIPROCAL_H67_FOUR67           = 129, // <Reciprocal> ::= 'h67' 'Four67'
        RULE_RECIPROCAL_RECIPROCAL97         = 130, // <Reciprocal> ::= 'Reciprocal97'
        RULE_REG_H67_THREE67                 = 131, // <Reg> ::= 'h67' 'Three67'
        RULE_REG_F97_ENG97                   = 132, // <Reg> ::= 'f97' 'Eng97'
        RULE_RND_F67_SUB_I67                 = 133, // <Rnd> ::= 'f67' 'Sub_I67'
        RULE_RND_F97_RTN97                   = 134, // <Rnd> ::= 'f97' 'Rtn97'
        RULE_RTN_H67_GTO67                   = 135, // <Rtn> ::= 'h67' 'Gto67'
        RULE_RTN_RTN97                       = 136, // <Rtn> ::= 'Rtn97'
        RULE_S_G67_SIGMA_PLUS67              = 137, // <S> ::= 'g67' 'Sigma_Plus67'
        RULE_S_F97_SQRT97                    = 138, // <S> ::= 'f97' 'Sqrt97'
        RULE_SCI_G67_DSP67                   = 139, // <Sci> ::= 'g67' 'Dsp67'
        RULE_SCI_SCI97                       = 140, // <Sci> ::= 'Sci97'
        RULE_SEVEN_SEVEN67                   = 141, // <Seven> ::= 'Seven67'
        RULE_SEVEN_SEVEN97                   = 142, // <Seven> ::= 'Seven97'
        RULE_SF_H67_SUBTRACTION67            = 143, // <SF> ::= 'h67' 'Subtraction67'
        RULE_SF_F97_LBL97                    = 144, // <SF> ::= 'f97' 'Lbl97'
        RULE_SIGMA_MINUS_H67_SIGMA_PLUS67    = 145, // <Sigma_Minus> ::= 'h67' 'Sigma_Plus67'
        RULE_SIGMA_MINUS_F97_SIGMA_PLUS97    = 146, // <Sigma_Minus> ::= 'f97' 'Sigma_Plus97'
        RULE_SIGMA_PLUS_SIGMA_PLUS67         = 147, // <Sigma_Plus> ::= 'Sigma_Plus67'
        RULE_SIGMA_PLUS_SIGMA_PLUS97         = 148, // <Sigma_Plus> ::= 'Sigma_Plus97'
        RULE_SIN_F67_FOUR67                  = 149, // <Sin> ::= 'f67' 'Four67'
        RULE_SIN_SIN97                       = 150, // <Sin> ::= 'Sin97'
        RULE_SIX_SIX67                       = 151, // <Six> ::= 'Six67'
        RULE_SIX_SIX97                       = 152, // <Six> ::= 'Six97'
        RULE_SPACE_H67_R_S67                 = 153, // <Space> ::= 'h67' 'R_S67'
        RULE_SPACE_F97_FIX97                 = 154, // <Space> ::= 'f97' 'Fix97'
        RULE_SQRT_F67_NINE67                 = 155, // <Sqrt> ::= 'f67' 'Nine67'
        RULE_SQRT_SQRT97                     = 156, // <Sqrt> ::= 'Sqrt97'
        RULE_SQUARE_G67_NINE67               = 157, // <Square> ::= 'g67' 'Nine67'
        RULE_SQUARE_SQUARE97                 = 158, // <Square> ::= 'Square97'
        RULE_SST_SST67                       = 159, // <Sst> ::= 'Sst67'
        RULE_SST_SST97                       = 160, // <Sst> ::= 'Sst97'
        RULE_ST_I_H67_STO67                  = 161, // <St_I> ::= 'h67' 'Sto67'
        RULE_ST_I_STO97_I97                  = 162, // <St_I> ::= 'Sto97' 'I97'
        RULE_STK_G67_R_S67                   = 163, // <Stk> ::= 'g67' 'R_S67'
        RULE_STK_F97_DIPLAY_X97              = 164, // <Stk> ::= 'f97' 'Diplay_X97'
        RULE_STO_STO67                       = 165, // <Sto> ::= 'Sto67'
        RULE_STO_STO97                       = 166, // <Sto> ::= 'Sto97'
        RULE_SUB_I_SUB_I67                   = 167, // <Sub_I> ::= 'Sub_I67'
        RULE_SUB_I_SUB_I97                   = 168, // <Sub_I> ::= 'Sub_I97'
        RULE_SUBTRACTION_SUBTRACTION67       = 169, // <Subtraction> ::= 'Subtraction67'
        RULE_SUBTRACTION_SUBTRACTION97       = 170, // <Subtraction> ::= 'Subtraction97'
        RULE_TAN_F67_SIX67                   = 171, // <Tan> ::= 'f67' 'Six67'
        RULE_TAN_TAN97                       = 172, // <Tan> ::= 'Tan97'
        RULE_TEN_TO_THE_XTH_G67_EIGHT67      = 173, // <Ten_To_The_Xth> ::= 'g67' 'Eight67'
        RULE_TEN_TO_THE_XTH_F97_EXP97        = 174, // <Ten_To_The_Xth> ::= 'f97' 'Exp97'
        RULE_THREE_THREE67                   = 175, // <Three> ::= 'Three67'
        RULE_THREE_THREE97                   = 176, // <Three> ::= 'Three97'
        RULE_TO_DEGREES_F67_TWO67            = 177, // <To_Degrees> ::= 'f67' 'Two67'
        RULE_TO_DEGREES_F97_I97              = 178, // <To_Degrees> ::= 'f97' 'I97'
        RULE_TO_HMS_G67_THREE67              = 179, // <To_HMS> ::= 'g67' 'Three67'
        RULE_TO_HMS_F97_STO97                = 180, // <To_HMS> ::= 'f97' 'Sto97'
        RULE_TO_HOURS_F67_THREE67            = 181, // <To_Hours> ::= 'f67' 'Three67'
        RULE_TO_HOURS_F97_RCL97              = 182, // <To_Hours> ::= 'f97' 'Rcl97'
        RULE_TO_POLAR_G67_ONE67              = 183, // <To_Polar> ::= 'g67' 'One67'
        RULE_TO_POLAR_TO_POLAR97             = 184, // <To_Polar> ::= 'To_Polar97'
        RULE_TO_RADIANS_G67_TWO67            = 185, // <To_Radians> ::= 'g67' 'Two67'
        RULE_TO_RADIANS_F97_SUB_I97          = 186, // <To_Radians> ::= 'f97' 'Sub_I97'
        RULE_TO_RECTANGULAR_F67_ONE67        = 187, // <To_Rectangular> ::= 'f67' 'One67'
        RULE_TO_RECTANGULAR_TO_RECTANGULAR97 = 188, // <To_Rectangular> ::= 'To_Rectangular97'
        RULE_TWO_TWO67                       = 189, // <Two> ::= 'Two67'
        RULE_TWO_TWO97                       = 190, // <Two> ::= 'Two97'
        RULE_W_DATA_F67_ENTER67              = 191, // <W_Data> ::= 'f67' 'Enter67'
        RULE_W_DATA_F97_ZERO97               = 192, // <W_Data> ::= 'f97' 'Zero97'
        RULE_X_AVERAGE_F67_SIGMA_PLUS67      = 193, // <X_Average> ::= 'f67' 'Sigma_Plus67'
        RULE_X_AVERAGE_F97_SQUARE97          = 194, // <X_Average> ::= 'f97' 'Square97'
        RULE_X_EQ_0_F67_SUBTRACTION67        = 195, // <X_EQ_0> ::= 'f67' 'Subtraction67'
        RULE_X_EQ_0_F97_FIVE97               = 196, // <X_EQ_0> ::= 'f97' 'Five97'
        RULE_X_EQ_Y_G67_SUBTRACTION67        = 197, // <X_EQ_Y> ::= 'g67' 'Subtraction67'
        RULE_X_EQ_Y_F97_EIGHT97              = 198, // <X_EQ_Y> ::= 'f97' 'Eight97'
        RULE_X_EXCHANGE_I_H67_SUB_I67        = 199, // <X_Exchange_I> ::= 'h67' 'Sub_I67'
        RULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 = 200, // <X_Exchange_I> ::= 'f97' 'X_Exchange_Y97'
        RULE_X_EXCHANGE_Y_H67_SEVEN67        = 201, // <X_Exchange_Y> ::= 'h67' 'Seven67'
        RULE_X_EXCHANGE_Y_X_EXCHANGE_97      = 202, // <X_Exchange_Y> ::= 'X_Exchange_97'
        RULE_X_GT_0_F67_DIVISION67           = 203, // <X_GT_0> ::= 'f67' 'Division67'
        RULE_X_GT_0_F97_SIX97                = 204, // <X_GT_0> ::= 'f97' 'Six97'
        RULE_X_GT_Y_G67_DIVISION67           = 205, // <X_GT_Y> ::= 'g67' 'Division67'
        RULE_X_GT_Y_F97_NINE97               = 206, // <X_GT_Y> ::= 'f97' 'Nine97'
        RULE_X_LE_Y_G67_MULTIPLICATION67     = 207, // <X_LE_Y> ::= 'g67' 'Multiplication67'
        RULE_X_LE_Y_F97_MULTIPLICATION97     = 208, // <X_LE_Y> ::= 'f97' 'Multiplication97'
        RULE_X_LT_0_F67_MULTIPLICATION67     = 209, // <X_LT_0> ::= 'f67' 'Multiplication67'
        RULE_X_LT_0_F97_SUBTRACTION97        = 210, // <X_LT_0> ::= 'f97' 'Subtraction97'
        RULE_X_NE_0_F67_ADDITION67           = 211, // <X_NE_0> ::= 'f67' 'Addition67'
        RULE_X_NE_0_F97_FOUR97               = 212, // <X_NE_0> ::= 'f97' 'Four97'
        RULE_X_NE_Y_G67_ADDITION67           = 213, // <X_NE_Y> ::= 'g67' 'Addition67'
        RULE_X_NE_Y_F97_SEVEN97              = 214, // <X_NE_Y> ::= 'f97' 'Seven97'
        RULE_Y_TO_THE_XTH_H67_FIVE67         = 215, // <Y_To_The_Xth> ::= 'h67' 'Five67'
        RULE_Y_TO_THE_XTH_Y_TO_THE_XTH       = 216, // <Y_To_The_Xth> ::= 'Y_To_The_Xth'
        RULE_ZERO_ZERO67                     = 217, // <Zero> ::= 'Zero67'
        RULE_ZERO_ZERO97                     = 218, // <Zero> ::= 'Zero97'
        RULE_INSTRUCTION                     = 219, // <Instruction> ::= <Shortcut>
        RULE_INSTRUCTION2                    = 220, // <Instruction> ::= <Nullary_Instruction>
        RULE_INSTRUCTION3                    = 221, // <Instruction> ::= <Unary_Instruction>
        RULE_INSTRUCTION4                    = 222, // <Instruction> ::= <Binary_Instruction>
        RULE_INSTRUCTION5                    = 223, // <Instruction> ::= <Ternary_Instruction>
        RULE_SHORTCUT                        = 224, // <Shortcut> ::= <Gsb_Shortcut>
        RULE_SHORTCUT2                       = 225, // <Shortcut> ::= <Memory_Shortcut>
        RULE_GSB_SHORTCUT                    = 226, // <Gsb_Shortcut> ::= <Letter_Label>
        RULE_MEMORY_SHORTCUT                 = 227, // <Memory_Shortcut> ::= <Sub_I>
        RULE_NULLARY_INSTRUCTION             = 228, // <Nullary_Instruction> ::= <Abs>
        RULE_NULLARY_INSTRUCTION2            = 229, // <Nullary_Instruction> ::= <Addition>
        RULE_NULLARY_INSTRUCTION3            = 230, // <Nullary_Instruction> ::= <Arccos>
        RULE_NULLARY_INSTRUCTION4            = 231, // <Nullary_Instruction> ::= <Arcsin>
        RULE_NULLARY_INSTRUCTION5            = 232, // <Nullary_Instruction> ::= <Arctan>
        RULE_NULLARY_INSTRUCTION6            = 233, // <Nullary_Instruction> ::= <Bst>
        RULE_NULLARY_INSTRUCTION7            = 234, // <Nullary_Instruction> ::= <Chs>
        RULE_NULLARY_INSTRUCTION8            = 235, // <Nullary_Instruction> ::= <Cl_Prgm>
        RULE_NULLARY_INSTRUCTION9            = 236, // <Nullary_Instruction> ::= <Cl_Reg>
        RULE_NULLARY_INSTRUCTION10           = 237, // <Nullary_Instruction> ::= <Clx>
        RULE_NULLARY_INSTRUCTION11           = 238, // <Nullary_Instruction> ::= <Cos>
        RULE_NULLARY_INSTRUCTION12           = 239, // <Nullary_Instruction> ::= <Deg>
        RULE_NULLARY_INSTRUCTION13           = 240, // <Nullary_Instruction> ::= <Del>
        RULE_NULLARY_INSTRUCTION14           = 241, // <Nullary_Instruction> ::= <Digit>
        RULE_NULLARY_INSTRUCTION15           = 242, // <Nullary_Instruction> ::= <Display_X>
        RULE_NULLARY_INSTRUCTION16           = 243, // <Nullary_Instruction> ::= <Division>
        RULE_NULLARY_INSTRUCTION17           = 244, // <Nullary_Instruction> ::= <Dsz_Sub_I>
        RULE_NULLARY_INSTRUCTION18           = 245, // <Nullary_Instruction> ::= <Dsz>
        RULE_NULLARY_INSTRUCTION19           = 246, // <Nullary_Instruction> ::= <Eex>
        RULE_NULLARY_INSTRUCTION20           = 247, // <Nullary_Instruction> ::= <Eng>
        RULE_NULLARY_INSTRUCTION21           = 248, // <Nullary_Instruction> ::= <Enter>
        RULE_NULLARY_INSTRUCTION22           = 249, // <Nullary_Instruction> ::= <Exp>
        RULE_NULLARY_INSTRUCTION23           = 250, // <Nullary_Instruction> ::= <Factorial>
        RULE_NULLARY_INSTRUCTION24           = 251, // <Nullary_Instruction> ::= <Fix>
        RULE_NULLARY_INSTRUCTION25           = 252, // <Nullary_Instruction> ::= <Frac>
        RULE_NULLARY_INSTRUCTION26           = 253, // <Nullary_Instruction> ::= <Grd>
        RULE_NULLARY_INSTRUCTION27           = 254, // <Nullary_Instruction> ::= <HMS_Plus>
        RULE_NULLARY_INSTRUCTION28           = 255, // <Nullary_Instruction> ::= <Int>
        RULE_NULLARY_INSTRUCTION29           = 256, // <Nullary_Instruction> ::= <Isz_Sub_I>
        RULE_NULLARY_INSTRUCTION30           = 257, // <Nullary_Instruction> ::= <Isz>
        RULE_NULLARY_INSTRUCTION31           = 258, // <Nullary_Instruction> ::= <Ln>
        RULE_NULLARY_INSTRUCTION32           = 259, // <Nullary_Instruction> ::= <Log>
        RULE_NULLARY_INSTRUCTION33           = 260, // <Nullary_Instruction> ::= <Lst_X>
        RULE_NULLARY_INSTRUCTION34           = 261, // <Nullary_Instruction> ::= <Merge>
        RULE_NULLARY_INSTRUCTION35           = 262, // <Nullary_Instruction> ::= <Multiplication>
        RULE_NULLARY_INSTRUCTION36           = 263, // <Nullary_Instruction> ::= <P_Exchange_S>
        RULE_NULLARY_INSTRUCTION37           = 264, // <Nullary_Instruction> ::= <Pause>
        RULE_NULLARY_INSTRUCTION38           = 265, // <Nullary_Instruction> ::= <Percent_Change>
        RULE_NULLARY_INSTRUCTION39           = 266, // <Nullary_Instruction> ::= <Percent>
        RULE_NULLARY_INSTRUCTION40           = 267, // <Nullary_Instruction> ::= <Period>
        RULE_NULLARY_INSTRUCTION41           = 268, // <Nullary_Instruction> ::= <Pi>
        RULE_NULLARY_INSTRUCTION42           = 269, // <Nullary_Instruction> ::= <Print_Prgm>
        RULE_NULLARY_INSTRUCTION43           = 270, // <Nullary_Instruction> ::= <R_Down>
        RULE_NULLARY_INSTRUCTION44           = 271, // <Nullary_Instruction> ::= <R_S>
        RULE_NULLARY_INSTRUCTION45           = 272, // <Nullary_Instruction> ::= <R_Up>
        RULE_NULLARY_INSTRUCTION46           = 273, // <Nullary_Instruction> ::= <Rad>
        RULE_NULLARY_INSTRUCTION47           = 274, // <Nullary_Instruction> ::= <Rc_I>
        RULE_NULLARY_INSTRUCTION48           = 275, // <Nullary_Instruction> ::= <Rcl_Sigma_Plus>
        RULE_NULLARY_INSTRUCTION49           = 276, // <Nullary_Instruction> ::= <Reciprocal>
        RULE_NULLARY_INSTRUCTION50           = 277, // <Nullary_Instruction> ::= <Reg>
        RULE_NULLARY_INSTRUCTION51           = 278, // <Nullary_Instruction> ::= <Rnd>
        RULE_NULLARY_INSTRUCTION52           = 279, // <Nullary_Instruction> ::= <Rtn>
        RULE_NULLARY_INSTRUCTION53           = 280, // <Nullary_Instruction> ::= <S>
        RULE_NULLARY_INSTRUCTION54           = 281, // <Nullary_Instruction> ::= <Sci>
        RULE_NULLARY_INSTRUCTION55           = 282, // <Nullary_Instruction> ::= <Sigma_Minus>
        RULE_NULLARY_INSTRUCTION56           = 283, // <Nullary_Instruction> ::= <Sigma_Plus>
        RULE_NULLARY_INSTRUCTION57           = 284, // <Nullary_Instruction> ::= <Sin>
        RULE_NULLARY_INSTRUCTION58           = 285, // <Nullary_Instruction> ::= <Space>
        RULE_NULLARY_INSTRUCTION59           = 286, // <Nullary_Instruction> ::= <Sqrt>
        RULE_NULLARY_INSTRUCTION60           = 287, // <Nullary_Instruction> ::= <Square>
        RULE_NULLARY_INSTRUCTION61           = 288, // <Nullary_Instruction> ::= <Sst>
        RULE_NULLARY_INSTRUCTION62           = 289, // <Nullary_Instruction> ::= <St_I>
        RULE_NULLARY_INSTRUCTION63           = 290, // <Nullary_Instruction> ::= <Stk>
        RULE_NULLARY_INSTRUCTION64           = 291, // <Nullary_Instruction> ::= <Subtraction>
        RULE_NULLARY_INSTRUCTION65           = 292, // <Nullary_Instruction> ::= <Tan>
        RULE_NULLARY_INSTRUCTION66           = 293, // <Nullary_Instruction> ::= <Ten_To_The_Xth>
        RULE_NULLARY_INSTRUCTION67           = 294, // <Nullary_Instruction> ::= <To_Degrees>
        RULE_NULLARY_INSTRUCTION68           = 295, // <Nullary_Instruction> ::= <To_HMS>
        RULE_NULLARY_INSTRUCTION69           = 296, // <Nullary_Instruction> ::= <To_Hours>
        RULE_NULLARY_INSTRUCTION70           = 297, // <Nullary_Instruction> ::= <To_Polar>
        RULE_NULLARY_INSTRUCTION71           = 298, // <Nullary_Instruction> ::= <To_Radians>
        RULE_NULLARY_INSTRUCTION72           = 299, // <Nullary_Instruction> ::= <To_Rectangular>
        RULE_NULLARY_INSTRUCTION73           = 300, // <Nullary_Instruction> ::= <W_Data>
        RULE_NULLARY_INSTRUCTION74           = 301, // <Nullary_Instruction> ::= <X_Average>
        RULE_NULLARY_INSTRUCTION75           = 302, // <Nullary_Instruction> ::= <X_EQ_0>
        RULE_NULLARY_INSTRUCTION76           = 303, // <Nullary_Instruction> ::= <X_EQ_Y>
        RULE_NULLARY_INSTRUCTION77           = 304, // <Nullary_Instruction> ::= <X_Exchange_I>
        RULE_NULLARY_INSTRUCTION78           = 305, // <Nullary_Instruction> ::= <X_Exchange_Y>
        RULE_NULLARY_INSTRUCTION79           = 306, // <Nullary_Instruction> ::= <X_GT_0>
        RULE_NULLARY_INSTRUCTION80           = 307, // <Nullary_Instruction> ::= <X_GT_Y>
        RULE_NULLARY_INSTRUCTION81           = 308, // <Nullary_Instruction> ::= <X_LE_Y>
        RULE_NULLARY_INSTRUCTION82           = 309, // <Nullary_Instruction> ::= <X_LT_0>
        RULE_NULLARY_INSTRUCTION83           = 310, // <Nullary_Instruction> ::= <X_NE_0>
        RULE_NULLARY_INSTRUCTION84           = 311, // <Nullary_Instruction> ::= <X_NE_Y>
        RULE_NULLARY_INSTRUCTION85           = 312, // <Nullary_Instruction> ::= <Y_To_The_Xth>
        RULE_UNARY_INSTRUCTION               = 313, // <Unary_Instruction> ::= <CF> <Flag>
        RULE_UNARY_INSTRUCTION2              = 314, // <Unary_Instruction> ::= <Dsp> <Digit_Count>
        RULE_UNARY_INSTRUCTION3              = 315, // <Unary_Instruction> ::= <F_Test> <Flag>
        RULE_UNARY_INSTRUCTION4              = 316, // <Unary_Instruction> ::= <Gsb> <Non_Lowercase_Label>
        RULE_UNARY_INSTRUCTION5              = 317, // <Unary_Instruction> ::= <Gsb_f> <Uppercase_Letter_Label>
        RULE_UNARY_INSTRUCTION_GSB97         = 318, // <Unary_Instruction> ::= 'Gsb97' <Lowercase_Letter_Label>
        RULE_UNARY_INSTRUCTION6              = 319, // <Unary_Instruction> ::= <Gto> <Label>
        RULE_UNARY_INSTRUCTION7              = 320, // <Unary_Instruction> ::= <Lbl> <Non_Lowercase_Label>
        RULE_UNARY_INSTRUCTION8              = 321, // <Unary_Instruction> ::= <Lbl_f> <Uppercase_Letter_Label>
        RULE_UNARY_INSTRUCTION_LBL97         = 322, // <Unary_Instruction> ::= 'Lbl97' <Lowercase_Letter_Label>
        RULE_UNARY_INSTRUCTION9              = 323, // <Unary_Instruction> ::= <Rcl> <Memory>
        RULE_UNARY_INSTRUCTION10             = 324, // <Unary_Instruction> ::= <SF> <Flag>
        RULE_UNARY_INSTRUCTION11             = 325, // <Unary_Instruction> ::= <Sto> <Memory>
        RULE_BINARY_INSTRUCTION              = 326, // <Binary_Instruction> ::= <Sto> <Operator> <Operable_Memory>
        RULE_TERNARY_INSTRUCTION             = 327, // <Ternary_Instruction> ::= <Gto_Period> <Digit> <Digit> <Digit>
        RULE_RCL_SIGMA_PLUS                  = 328, // <Rcl_Sigma_Plus> ::= <Rcl> <Sigma_Plus>
        RULE_GTO_PERIOD                      = 329, // <Gto_Period> ::= <Gto> <Period>
        RULE_OPERATOR                        = 330, // <Operator> ::= <Subtraction>
        RULE_OPERATOR2                       = 331, // <Operator> ::= <Addition>
        RULE_OPERATOR3                       = 332, // <Operator> ::= <Multiplication>
        RULE_OPERATOR4                       = 333, // <Operator> ::= <Division>
        RULE_DIGIT                           = 334, // <Digit> ::= <Zero>
        RULE_DIGIT2                          = 335, // <Digit> ::= <One>
        RULE_DIGIT3                          = 336, // <Digit> ::= <Two>
        RULE_DIGIT4                          = 337, // <Digit> ::= <Three>
        RULE_DIGIT5                          = 338, // <Digit> ::= <Four>
        RULE_DIGIT6                          = 339, // <Digit> ::= <Five>
        RULE_DIGIT7                          = 340, // <Digit> ::= <Six>
        RULE_DIGIT8                          = 341, // <Digit> ::= <Seven>
        RULE_DIGIT9                          = 342, // <Digit> ::= <Eight>
        RULE_DIGIT10                         = 343, // <Digit> ::= <Nine>
        RULE_DIGIT_COUNT                     = 344, // <Digit_Count> ::= <Digit>
        RULE_DIGIT_COUNT2                    = 345, // <Digit_Count> ::= <Sub_I>
        RULE_FLAG                            = 346, // <Flag> ::= <Zero>
        RULE_FLAG2                           = 347, // <Flag> ::= <One>
        RULE_FLAG3                           = 348, // <Flag> ::= <Two>
        RULE_FLAG4                           = 349, // <Flag> ::= <Three>
        RULE_LETTER                          = 350, // <Letter> ::= <A>
        RULE_LETTER2                         = 351, // <Letter> ::= <B>
        RULE_LETTER3                         = 352, // <Letter> ::= <C>
        RULE_LETTER4                         = 353, // <Letter> ::= <D>
        RULE_LETTER5                         = 354, // <Letter> ::= <E>
        RULE_UPPERCASE_LETTER_LABEL          = 355, // <Uppercase_Letter_Label> ::= <Letter>
        RULE_LOWERCASE_LETTER_LABEL          = 356, // <Lowercase_Letter_Label> ::= <f> <Letter>
        RULE_LETTER_LABEL                    = 357, // <Letter_Label> ::= <Lowercase_Letter_Label>
        RULE_LETTER_LABEL2                   = 358, // <Letter_Label> ::= <Uppercase_Letter_Label>
        RULE_DIGIT_LABEL                     = 359, // <Digit_Label> ::= <Digit>
        RULE_NON_LOWERCASE_LABEL             = 360, // <Non_Lowercase_Label> ::= <Digit_Label>
        RULE_NON_LOWERCASE_LABEL2            = 361, // <Non_Lowercase_Label> ::= <Uppercase_Letter_Label>
        RULE_NON_LOWERCASE_LABEL3            = 362, // <Non_Lowercase_Label> ::= <Sub_I>
        RULE_LABEL                           = 363, // <Label> ::= <Digit_Label>
        RULE_LABEL2                          = 364, // <Label> ::= <Letter_Label>
        RULE_LABEL3                          = 365, // <Label> ::= <Sub_I>
        RULE_OPERABLE_MEMORY                 = 366, // <Operable_Memory> ::= <Digit>
        RULE_OPERABLE_MEMORY2                = 367, // <Operable_Memory> ::= <Sub_I>
        RULE_MEMORY                          = 368, // <Memory> ::= <Operable_Memory>
        RULE_MEMORY2                         = 369  // <Memory> ::= <Letter>
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
        
        void ReduceRULE_A_A67 (string input, Token token, Token [] tokens);
        void ReduceRULE_A_A97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ABS_H67_SIX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ABS_F97_Y_TO_THE_XTH97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ADDITION_ADDITION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ADDITION_ADDITION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCCOS_G67_FIVE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCCOS_F97_COS97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCSIN_G67_FOUR67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCSIN_F97_SIN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCTAN_G67_SIX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCTAN_F97_TAN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_B_B67 (string input, Token token, Token [] tokens);
        void ReduceRULE_B_B97 (string input, Token token, Token [] tokens);
        void ReduceRULE_BST_H67_SST67 (string input, Token token, Token [] tokens);
        void ReduceRULE_BST_BST97 (string input, Token token, Token [] tokens);
        void ReduceRULE_C_C67 (string input, Token token, Token [] tokens);
        void ReduceRULE_C_C97 (string input, Token token, Token [] tokens);
        void ReduceRULE_CF_H67_ADDITION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_CF_F97_GTO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_CHS_CHS67 (string input, Token token, Token [] tokens);
        void ReduceRULE_CHS_CHS97 (string input, Token token, Token [] tokens);
        void ReduceRULE_CL_PRGM_F67_CLX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_CL_PRGM_F97_THREE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_CL_REG_F67_EEX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_CL_REG_F97_TWO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_CLX_CLX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_CLX_CLX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_COS_F67_FIVE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_COS_COS97 (string input, Token token, Token [] tokens);
        void ReduceRULE_D_D67 (string input, Token token, Token [] tokens);
        void ReduceRULE_D_D97 (string input, Token token, Token [] tokens);
        void ReduceRULE_DEG_H67_ENTER67 (string input, Token token, Token [] tokens);
        void ReduceRULE_DEG_F97_ENTER97 (string input, Token token, Token [] tokens);
        void ReduceRULE_DEL_H67_CLX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_DEL_F97_ONE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_DISPLAY_X_F67_R_S67 (string input, Token token, Token [] tokens);
        void ReduceRULE_DISPLAY_X_DISPLAY_X97 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIVISION_DIVISION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIVISION_DIVISION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_DSP_DSP67 (string input, Token token, Token [] tokens);
        void ReduceRULE_DSP_DSP97 (string input, Token token, Token [] tokens);
        void ReduceRULE_DSZ_SUB_I_G67_STO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_DSZ_SUB_I_F97_BST97_SUB_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_DSZ_F67_STO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_DSZ_F97_BST97_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_E_E67 (string input, Token token, Token [] tokens);
        void ReduceRULE_E_E97 (string input, Token token, Token [] tokens);
        void ReduceRULE_EEX_EEX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_EEX_EEX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_EIGHT_EIGHT67 (string input, Token token, Token [] tokens);
        void ReduceRULE_EIGHT_EIGHT97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ENG_H67_DSP67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ENG_ENG97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ENTER_ENTER67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ENTER_ENTER97 (string input, Token token, Token [] tokens);
        void ReduceRULE_EXP_G67_SEVEN67 (string input, Token token, Token [] tokens);
        void ReduceRULE_EXP_EXP97 (string input, Token token, Token [] tokens);
        void ReduceRULE_F_F67 (string input, Token token, Token [] tokens);
        void ReduceRULE_F_F97 (string input, Token token, Token [] tokens);
        void ReduceRULE_F_TEST_H67_MULTIPLICATION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_F_TEST_F97_GSB97 (string input, Token token, Token [] tokens);
        void ReduceRULE_FACTORIAL_H67_DIVISION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_FACTORIAL_F97_RECIPROCAL97 (string input, Token token, Token [] tokens);
        void ReduceRULE_FIVE_FIVE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_FIVE_FIVE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_FIX_F67_DSP67 (string input, Token token, Token [] tokens);
        void ReduceRULE_FIX_FIX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_FOUR_FOUR67 (string input, Token token, Token [] tokens);
        void ReduceRULE_FOUR_FOUR97 (string input, Token token, Token [] tokens);
        void ReduceRULE_FRAC_G67_PERIOD67 (string input, Token token, Token [] tokens);
        void ReduceRULE_FRAC_F97_TO_RECTANGULAR97 (string input, Token token, Token [] tokens);
        void ReduceRULE_GRD_H67_EEX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_GRD_F97_EEX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_GSB_F_G67_GTO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_GSB_F67_GTO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_GSB_GSB97 (string input, Token token, Token [] tokens);
        void ReduceRULE_GTO_GTO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_GTO_GTO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_HMS_PLUS_H67_PERIOD67 (string input, Token token, Token [] tokens);
        void ReduceRULE_HMS_PLUS_F97_ADDITION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_INT_F67_PERIOD67 (string input, Token token, Token [] tokens);
        void ReduceRULE_INT_F97_TO_POLAR97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ISZ_SUB_I_G67_RCL67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ISZ_SUB_I_F97_SST97_SUB_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ISZ_F67_RCL67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ISZ_F97_SST97_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_LBL_F_G67_SST67 (string input, Token token, Token [] tokens);
        void ReduceRULE_LBL_F67_SST67 (string input, Token token, Token [] tokens);
        void ReduceRULE_LBL_LBL97 (string input, Token token, Token [] tokens);
        void ReduceRULE_LN_F67_SEVEN67 (string input, Token token, Token [] tokens);
        void ReduceRULE_LN_LN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_LOG_F67_EIGHT67 (string input, Token token, Token [] tokens);
        void ReduceRULE_LOG_F97_LN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_LST_X_H67_ZERO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_LST_X_F97_DSP97 (string input, Token token, Token [] tokens);
        void ReduceRULE_MERGE_G67_ENTER67 (string input, Token token, Token [] tokens);
        void ReduceRULE_MERGE_F97_PERIOD97 (string input, Token token, Token [] tokens);
        void ReduceRULE_MULTIPLICATION_MULTIPLICATION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_MULTIPLICATION_MULTIPLICATION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_NINE_NINE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_NINE_NINE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ONE_ONE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ONE_ONE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_P_EXCHANGE_S_F67_CHS67 (string input, Token token, Token [] tokens);
        void ReduceRULE_P_EXCHANGE_S_F97_CLX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_PAUSE_H67_ONE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_PAUSE_F97_R_S97 (string input, Token token, Token [] tokens);
        void ReduceRULE_PERCENT_CHANGE_G67_ZERO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_PERCENT_CHANGE_F97_PERCENT97 (string input, Token token, Token [] tokens);
        void ReduceRULE_PERCENT_F67_ZERO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_PERCENT_PERCENT97 (string input, Token token, Token [] tokens);
        void ReduceRULE_PERIOD_PERIOD67 (string input, Token token, Token [] tokens);
        void ReduceRULE_PERIOD_PERIOD97 (string input, Token token, Token [] tokens);
        void ReduceRULE_PI_H67_TWO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_PI_F97_DIVISION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_PRINT_PRGM_F97_SCI97 (string input, Token token, Token [] tokens);
        void ReduceRULE_R_DOWN_H67_EIGHT67 (string input, Token token, Token [] tokens);
        void ReduceRULE_R_DOWN_R_DOWN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_R_S_R_S67 (string input, Token token, Token [] tokens);
        void ReduceRULE_R_S_R_S97 (string input, Token token, Token [] tokens);
        void ReduceRULE_R_UP_H67_NINE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_R_UP_F97_R_DOWN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_RAD_H67_CHS67 (string input, Token token, Token [] tokens);
        void ReduceRULE_RAD_F97_CHS97 (string input, Token token, Token [] tokens);
        void ReduceRULE_RC_I_H67_RCL67 (string input, Token token, Token [] tokens);
        void ReduceRULE_RC_I_RCL97_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_RCL_RCL67 (string input, Token token, Token [] tokens);
        void ReduceRULE_RCL_RCL97 (string input, Token token, Token [] tokens);
        void ReduceRULE_RECIPROCAL_H67_FOUR67 (string input, Token token, Token [] tokens);
        void ReduceRULE_RECIPROCAL_RECIPROCAL97 (string input, Token token, Token [] tokens);
        void ReduceRULE_REG_H67_THREE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_REG_F97_ENG97 (string input, Token token, Token [] tokens);
        void ReduceRULE_RND_F67_SUB_I67 (string input, Token token, Token [] tokens);
        void ReduceRULE_RND_F97_RTN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_RTN_H67_GTO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_RTN_RTN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_S_G67_SIGMA_PLUS67 (string input, Token token, Token [] tokens);
        void ReduceRULE_S_F97_SQRT97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SCI_G67_DSP67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SCI_SCI97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SEVEN_SEVEN67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SEVEN_SEVEN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SF_H67_SUBTRACTION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SF_F97_LBL97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIGMA_MINUS_H67_SIGMA_PLUS67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIGMA_MINUS_F97_SIGMA_PLUS97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIGMA_PLUS_SIGMA_PLUS97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIN_F67_FOUR67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIN_SIN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIX_SIX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SIX_SIX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SPACE_H67_R_S67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SPACE_F97_FIX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SQRT_F67_NINE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SQRT_SQRT97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SQUARE_G67_NINE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SQUARE_SQUARE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SST_SST67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SST_SST97 (string input, Token token, Token [] tokens);
        void ReduceRULE_ST_I_H67_STO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ST_I_STO97_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_STK_G67_R_S67 (string input, Token token, Token [] tokens);
        void ReduceRULE_STK_F97_DIPLAY_X97 (string input, Token token, Token [] tokens);
        void ReduceRULE_STO_STO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_STO_STO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SUB_I_SUB_I67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SUB_I_SUB_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_SUBTRACTION_SUBTRACTION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_SUBTRACTION_SUBTRACTION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TAN_F67_SIX67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TAN_TAN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TEN_TO_THE_XTH_G67_EIGHT67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TEN_TO_THE_XTH_F97_EXP97 (string input, Token token, Token [] tokens);
        void ReduceRULE_THREE_THREE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_THREE_THREE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_DEGREES_F67_TWO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_DEGREES_F97_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_HMS_G67_THREE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_HMS_F97_STO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_HOURS_F67_THREE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_HOURS_F97_RCL97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_POLAR_G67_ONE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_POLAR_TO_POLAR97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_RADIANS_G67_TWO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_RADIANS_F97_SUB_I97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_RECTANGULAR_F67_ONE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_RECTANGULAR_TO_RECTANGULAR97 (string input, Token token, Token [] tokens);
        void ReduceRULE_TWO_TWO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_TWO_TWO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_W_DATA_F67_ENTER67 (string input, Token token, Token [] tokens);
        void ReduceRULE_W_DATA_F97_ZERO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_AVERAGE_F67_SIGMA_PLUS67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_AVERAGE_F97_SQUARE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EQ_0_F67_SUBTRACTION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EQ_0_F97_FIVE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EQ_Y_G67_SUBTRACTION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EQ_Y_F97_EIGHT97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EXCHANGE_I_H67_SUB_I67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EXCHANGE_Y_H67_SEVEN67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_GT_0_F67_DIVISION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_GT_0_F97_SIX97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_GT_Y_G67_DIVISION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_GT_Y_F97_NINE97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_LE_Y_G67_MULTIPLICATION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_LE_Y_F97_MULTIPLICATION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_LT_0_F67_MULTIPLICATION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_LT_0_F97_SUBTRACTION97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_NE_0_F67_ADDITION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_NE_0_F97_FOUR97 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_NE_Y_G67_ADDITION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_X_NE_Y_F97_SEVEN97 (string input, Token token, Token [] tokens);
        void ReduceRULE_Y_TO_THE_XTH_H67_FIVE67 (string input, Token token, Token [] tokens);
        void ReduceRULE_Y_TO_THE_XTH_Y_TO_THE_XTH (string input, Token token, Token [] tokens);
        void ReduceRULE_ZERO_ZERO67 (string input, Token token, Token [] tokens);
        void ReduceRULE_ZERO_ZERO97 (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION4 (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION5 (string input, Token token, Token [] tokens);
        void ReduceRULE_SHORTCUT (string input, Token token, Token [] tokens);
        void ReduceRULE_SHORTCUT2 (string input, Token token, Token [] tokens);
        void ReduceRULE_GSB_SHORTCUT (string input, Token token, Token [] tokens);
        void ReduceRULE_MEMORY_SHORTCUT (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION4 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION5 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION6 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION7 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION8 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION9 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION10 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION11 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION12 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION13 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION14 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION15 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION16 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION17 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION18 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION19 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION20 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION21 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION22 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION23 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION24 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION25 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION26 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION27 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION28 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION29 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION30 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION31 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION32 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION33 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION34 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION35 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION36 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION37 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION38 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION39 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION40 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION41 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION42 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION43 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION44 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION45 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION46 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION47 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION48 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION49 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION50 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION51 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION52 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION53 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION54 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION55 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION56 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION57 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION58 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION59 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION60 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION61 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION62 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION63 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION64 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION65 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION66 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION67 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION68 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION69 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION70 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION71 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION72 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION73 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION74 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION75 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION76 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION77 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION78 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION79 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION80 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION81 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION82 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION83 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION84 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_INSTRUCTION85 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION4 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION5 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION_GSB97 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION6 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION7 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION8 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION_LBL97 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION9 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION10 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_INSTRUCTION11 (string input, Token token, Token [] tokens);
        void ReduceRULE_BINARY_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_TERNARY_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_RCL_SIGMA_PLUS (string input, Token token, Token [] tokens);
        void ReduceRULE_GTO_PERIOD (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR2 (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR3 (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR4 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT2 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT3 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT4 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT5 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT6 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT7 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT8 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT9 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT10 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_COUNT (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_COUNT2 (string input, Token token, Token [] tokens);
        void ReduceRULE_FLAG (string input, Token token, Token [] tokens);
        void ReduceRULE_FLAG2 (string input, Token token, Token [] tokens);
        void ReduceRULE_FLAG3 (string input, Token token, Token [] tokens);
        void ReduceRULE_FLAG4 (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER2 (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER3 (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER4 (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER5 (string input, Token token, Token [] tokens);
        void ReduceRULE_UPPERCASE_LETTER_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_LOWERCASE_LETTER_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_LABEL2 (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_NON_LOWERCASE_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_NON_LOWERCASE_LABEL2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NON_LOWERCASE_LABEL3 (string input, Token token, Token [] tokens);
        void ReduceRULE_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_LABEL2 (string input, Token token, Token [] tokens);
        void ReduceRULE_LABEL3 (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERABLE_MEMORY (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERABLE_MEMORY2 (string input, Token token, Token [] tokens);
        void ReduceRULE_MEMORY (string input, Token token, Token [] tokens);
        void ReduceRULE_MEMORY2 (string input, Token token, Token [] tokens);
    }

    public class Parser
    {
		private static TraceSwitch classTraceSwitch = 
			new TraceSwitch ("HP_Parser.Parser", "Automatically generated parser");

        private IActions actions;
        private string input;
        private LALRParser parser;

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
			Trace.WriteLineIf (classTraceSwitch.TraceInfo,
				"ReduceEvent: reducing '" + args.Rule.ToString () + "'", 
				classTraceSwitch.DisplayName);
				
		    // By default, copy the user object from the first token on the rhs.  This will take
		    // care of most of the reductions, where we just pass the information along.
            if (args.Token.Tokens.Length >= 1)
            {
                args.Token.UserObject = args.Token.Tokens [0].UserObject;
            }
            
            switch ((RuleConstants) args.Token.Rule.Id)
            {
                case RuleConstants.RULE_A_A67 :
                    // <A> ::= 'A67'
                    actions.ReduceRULE_A_A67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_A_A97 :
                    // <A> ::= 'A97'
                    actions.ReduceRULE_A_A97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ABS_H67_SIX67 :
                    // <Abs> ::= 'h67' 'Six67'
                    actions.ReduceRULE_ABS_H67_SIX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ABS_F97_Y_TO_THE_XTH97 :
                    // <Abs> ::= 'f97' 'Y_To_The_Xth97'
                    actions.ReduceRULE_ABS_F97_Y_TO_THE_XTH97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ADDITION_ADDITION67 :
                    // <Addition> ::= 'Addition67'
                    actions.ReduceRULE_ADDITION_ADDITION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ADDITION_ADDITION97 :
                    // <Addition> ::= 'Addition97'
                    actions.ReduceRULE_ADDITION_ADDITION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ARCCOS_G67_FIVE67 :
                    // <Arccos> ::= 'g67' 'Five67'
                    actions.ReduceRULE_ARCCOS_G67_FIVE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ARCCOS_F97_COS97 :
                    // <Arccos> ::= 'f97' 'Cos97'
                    actions.ReduceRULE_ARCCOS_F97_COS97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ARCSIN_G67_FOUR67 :
                    // <Arcsin> ::= 'g67' 'Four67'
                    actions.ReduceRULE_ARCSIN_G67_FOUR67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ARCSIN_F97_SIN97 :
                    // <Arcsin> ::= 'f97' 'Sin97'
                    actions.ReduceRULE_ARCSIN_F97_SIN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ARCTAN_G67_SIX67 :
                    // <Arctan> ::= 'g67' 'Six67'
                    actions.ReduceRULE_ARCTAN_G67_SIX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ARCTAN_F97_TAN97 :
                    // <Arctan> ::= 'f97' 'Tan97'
                    actions.ReduceRULE_ARCTAN_F97_TAN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_B_B67 :
                    // <B> ::= 'B67'
                    actions.ReduceRULE_B_B67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_B_B97 :
                    // <B> ::= 'B97'
                    actions.ReduceRULE_B_B97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_BST_H67_SST67 :
                    // <Bst> ::= 'h67' 'Sst67'
                    actions.ReduceRULE_BST_H67_SST67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_BST_BST97 :
                    // <Bst> ::= 'Bst97'
                    actions.ReduceRULE_BST_BST97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_C_C67 :
                    // <C> ::= 'C67'
                    actions.ReduceRULE_C_C67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_C_C97 :
                    // <C> ::= 'C97'
                    actions.ReduceRULE_C_C97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CF_H67_ADDITION67 :
                    // <CF> ::= 'h67' 'Addition67'
                    actions.ReduceRULE_CF_H67_ADDITION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CF_F97_GTO97 :
                    // <CF> ::= 'f97' 'Gto97'
                    actions.ReduceRULE_CF_F97_GTO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CHS_CHS67 :
                    // <Chs> ::= 'Chs67'
                    actions.ReduceRULE_CHS_CHS67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CHS_CHS97 :
                    // <Chs> ::= 'Chs97'
                    actions.ReduceRULE_CHS_CHS97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CL_PRGM_F67_CLX67 :
                    // <Cl_Prgm> ::= 'f67' 'Clx67'
                    actions.ReduceRULE_CL_PRGM_F67_CLX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CL_PRGM_F97_THREE97 :
                    // <Cl_Prgm> ::= 'f97' 'Three97'
                    actions.ReduceRULE_CL_PRGM_F97_THREE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CL_REG_F67_EEX67 :
                    // <Cl_Reg> ::= 'f67' 'Eex67'
                    actions.ReduceRULE_CL_REG_F67_EEX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CL_REG_F97_TWO97 :
                    // <Cl_Reg> ::= 'f97' 'Two97'
                    actions.ReduceRULE_CL_REG_F97_TWO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CLX_CLX67 :
                    // <Clx> ::= 'Clx67'
                    actions.ReduceRULE_CLX_CLX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_CLX_CLX97 :
                    // <Clx> ::= 'Clx97'
                    actions.ReduceRULE_CLX_CLX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_COS_F67_FIVE67 :
                    // <Cos> ::= 'f67' 'Five67'
                    actions.ReduceRULE_COS_F67_FIVE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_COS_COS97 :
                    // <Cos> ::= 'Cos97'
                    actions.ReduceRULE_COS_COS97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_D_D67 :
                    // <D> ::= 'D67'
                    actions.ReduceRULE_D_D67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_D_D97 :
                    // <D> ::= 'D97'
                    actions.ReduceRULE_D_D97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DEG_H67_ENTER67 :
                    // <Deg> ::= 'h67' 'Enter67'
                    actions.ReduceRULE_DEG_H67_ENTER67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DEG_F97_ENTER97 :
                    // <Deg> ::= 'f97' 'Enter97'
                    actions.ReduceRULE_DEG_F97_ENTER97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DEL_H67_CLX67 :
                    // <Del> ::= 'h67' 'Clx67'
                    actions.ReduceRULE_DEL_H67_CLX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DEL_F97_ONE97 :
                    // <Del> ::= 'f97' 'One97'
                    actions.ReduceRULE_DEL_F97_ONE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DISPLAY_X_F67_R_S67 :
                    // <Display_X> ::= 'f67' 'R_S67'
                    actions.ReduceRULE_DISPLAY_X_F67_R_S67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DISPLAY_X_DISPLAY_X97 :
                    // <Display_X> ::= 'Display_X97'
                    actions.ReduceRULE_DISPLAY_X_DISPLAY_X97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIVISION_DIVISION67 :
                    // <Division> ::= 'Division67'
                    actions.ReduceRULE_DIVISION_DIVISION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIVISION_DIVISION97 :
                    // <Division> ::= 'Division97'
                    actions.ReduceRULE_DIVISION_DIVISION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DSP_DSP67 :
                    // <Dsp> ::= 'Dsp67'
                    actions.ReduceRULE_DSP_DSP67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DSP_DSP97 :
                    // <Dsp> ::= 'Dsp97'
                    actions.ReduceRULE_DSP_DSP97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DSZ_SUB_I_G67_STO67 :
                    // <Dsz_Sub_I> ::= 'g67' 'Sto67'
                    actions.ReduceRULE_DSZ_SUB_I_G67_STO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DSZ_SUB_I_F97_BST97_SUB_I97 :
                    // <Dsz_Sub_I> ::= 'f97' 'Bst97' 'Sub_I97'
                    actions.ReduceRULE_DSZ_SUB_I_F97_BST97_SUB_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DSZ_F67_STO67 :
                    // <Dsz> ::= 'f67' 'Sto67'
                    actions.ReduceRULE_DSZ_F67_STO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DSZ_F97_BST97_I97 :
                    // <Dsz> ::= 'f97' 'Bst97' 'I97'
                    actions.ReduceRULE_DSZ_F97_BST97_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_E_E67 :
                    // <E> ::= 'E67'
                    actions.ReduceRULE_E_E67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_E_E97 :
                    // <E> ::= 'E97'
                    actions.ReduceRULE_E_E97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_EEX_EEX67 :
                    // <Eex> ::= 'Eex67'
                    actions.ReduceRULE_EEX_EEX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_EEX_EEX97 :
                    // <Eex> ::= 'Eex97'
                    actions.ReduceRULE_EEX_EEX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_EIGHT_EIGHT67 :
                    // <Eight> ::= 'Eight67'
                    actions.ReduceRULE_EIGHT_EIGHT67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_EIGHT_EIGHT97 :
                    // <Eight> ::= 'Eight97'
                    actions.ReduceRULE_EIGHT_EIGHT97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ENG_H67_DSP67 :
                    // <Eng> ::= 'h67' 'Dsp67'
                    actions.ReduceRULE_ENG_H67_DSP67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ENG_ENG97 :
                    // <Eng> ::= 'Eng97'
                    actions.ReduceRULE_ENG_ENG97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ENTER_ENTER67 :
                    // <Enter> ::= 'Enter67'
                    actions.ReduceRULE_ENTER_ENTER67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ENTER_ENTER97 :
                    // <Enter> ::= 'Enter97'
                    actions.ReduceRULE_ENTER_ENTER97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_EXP_G67_SEVEN67 :
                    // <Exp> ::= 'g67' 'Seven67'
                    actions.ReduceRULE_EXP_G67_SEVEN67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_EXP_EXP97 :
                    // <Exp> ::= 'Exp97'
                    actions.ReduceRULE_EXP_EXP97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_F_F67 :
                    // <f> ::= 'f67'
                    actions.ReduceRULE_F_F67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_F_F97 :
                    // <f> ::= 'f97'
                    actions.ReduceRULE_F_F97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_F_TEST_H67_MULTIPLICATION67 :
                    // <F_Test> ::= 'h67' 'Multiplication67'
                    actions.ReduceRULE_F_TEST_H67_MULTIPLICATION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_F_TEST_F97_GSB97 :
                    // <F_Test> ::= 'f97' 'Gsb97'
                    actions.ReduceRULE_F_TEST_F97_GSB97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FACTORIAL_H67_DIVISION67 :
                    // <Factorial> ::= 'h67' 'Division67'
                    actions.ReduceRULE_FACTORIAL_H67_DIVISION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FACTORIAL_F97_RECIPROCAL97 :
                    // <Factorial> ::= 'f97' 'Reciprocal97'
                    actions.ReduceRULE_FACTORIAL_F97_RECIPROCAL97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FIVE_FIVE67 :
                    // <Five> ::= 'Five67'
                    actions.ReduceRULE_FIVE_FIVE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FIVE_FIVE97 :
                    // <Five> ::= 'Five97'
                    actions.ReduceRULE_FIVE_FIVE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FIX_F67_DSP67 :
                    // <Fix> ::= 'f67' 'Dsp67'
                    actions.ReduceRULE_FIX_F67_DSP67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FIX_FIX97 :
                    // <Fix> ::= 'Fix97'
                    actions.ReduceRULE_FIX_FIX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FOUR_FOUR67 :
                    // <Four> ::= 'Four67'
                    actions.ReduceRULE_FOUR_FOUR67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FOUR_FOUR97 :
                    // <Four> ::= 'Four97'
                    actions.ReduceRULE_FOUR_FOUR97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FRAC_G67_PERIOD67 :
                    // <Frac> ::= 'g67' 'Period67'
                    actions.ReduceRULE_FRAC_G67_PERIOD67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FRAC_F97_TO_RECTANGULAR97 :
                    // <Frac> ::= 'f97' 'To_Rectangular97'
                    actions.ReduceRULE_FRAC_F97_TO_RECTANGULAR97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GRD_H67_EEX67 :
                    // <Grd> ::= 'h67' 'Eex67'
                    actions.ReduceRULE_GRD_H67_EEX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GRD_F97_EEX97 :
                    // <Grd> ::= 'f97' 'Eex97'
                    actions.ReduceRULE_GRD_F97_EEX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GSB_F_G67_GTO67 :
                    // <Gsb_f> ::= 'g67' 'Gto67'
                    actions.ReduceRULE_GSB_F_G67_GTO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GSB_F67_GTO67 :
                    // <Gsb> ::= 'f67' 'Gto67'
                    actions.ReduceRULE_GSB_F67_GTO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GSB_GSB97 :
                    // <Gsb> ::= 'Gsb97'
                    actions.ReduceRULE_GSB_GSB97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GTO_GTO67 :
                    // <Gto> ::= 'Gto67'
                    actions.ReduceRULE_GTO_GTO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GTO_GTO97 :
                    // <Gto> ::= 'Gto97'
                    actions.ReduceRULE_GTO_GTO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_HMS_PLUS_H67_PERIOD67 :
                    // <HMS_Plus> ::= 'h67' 'Period67'
                    actions.ReduceRULE_HMS_PLUS_H67_PERIOD67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_HMS_PLUS_F97_ADDITION97 :
                    // <HMS_Plus> ::= 'f97' 'Addition97'
                    actions.ReduceRULE_HMS_PLUS_F97_ADDITION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_INT_F67_PERIOD67 :
                    // <Int> ::= 'f67' 'Period67'
                    actions.ReduceRULE_INT_F67_PERIOD67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_INT_F97_TO_POLAR97 :
                    // <Int> ::= 'f97' 'To_Polar97'
                    actions.ReduceRULE_INT_F97_TO_POLAR97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ISZ_SUB_I_G67_RCL67 :
                    // <Isz_Sub_I> ::= 'g67' 'Rcl67'
                    actions.ReduceRULE_ISZ_SUB_I_G67_RCL67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ISZ_SUB_I_F97_SST97_SUB_I97 :
                    // <Isz_Sub_I> ::= 'f97' 'Sst97' 'Sub_I97'
                    actions.ReduceRULE_ISZ_SUB_I_F97_SST97_SUB_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ISZ_F67_RCL67 :
                    // <Isz> ::= 'f67' 'Rcl67'
                    actions.ReduceRULE_ISZ_F67_RCL67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ISZ_F97_SST97_I97 :
                    // <Isz> ::= 'f97' 'Sst97' 'I97'
                    actions.ReduceRULE_ISZ_F97_SST97_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LBL_F_G67_SST67 :
                    // <Lbl_f> ::= 'g67' 'Sst67'
                    actions.ReduceRULE_LBL_F_G67_SST67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LBL_F67_SST67 :
                    // <Lbl> ::= 'f67' 'Sst67'
                    actions.ReduceRULE_LBL_F67_SST67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LBL_LBL97 :
                    // <Lbl> ::= 'Lbl97'
                    actions.ReduceRULE_LBL_LBL97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LN_F67_SEVEN67 :
                    // <Ln> ::= 'f67' 'Seven67'
                    actions.ReduceRULE_LN_F67_SEVEN67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LN_LN97 :
                    // <Ln> ::= 'Ln97'
                    actions.ReduceRULE_LN_LN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LOG_F67_EIGHT67 :
                    // <Log> ::= 'f67' 'Eight67'
                    actions.ReduceRULE_LOG_F67_EIGHT67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LOG_F97_LN97 :
                    // <Log> ::= 'f97' 'Ln97'
                    actions.ReduceRULE_LOG_F97_LN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LST_X_H67_ZERO67 :
                    // <Lst_X> ::= 'h67' 'Zero67'
                    actions.ReduceRULE_LST_X_H67_ZERO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LST_X_F97_DSP97 :
                    // <Lst_X> ::= 'f97' 'Dsp97'
                    actions.ReduceRULE_LST_X_F97_DSP97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_MERGE_G67_ENTER67 :
                    // <Merge> ::= 'g67' 'Enter67'
                    actions.ReduceRULE_MERGE_G67_ENTER67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_MERGE_F97_PERIOD97 :
                    // <Merge> ::= 'f97' 'Period97'
                    actions.ReduceRULE_MERGE_F97_PERIOD97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_MULTIPLICATION_MULTIPLICATION67 :
                    // <Multiplication> ::= 'Multiplication67'
                    actions.ReduceRULE_MULTIPLICATION_MULTIPLICATION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_MULTIPLICATION_MULTIPLICATION97 :
                    // <Multiplication> ::= 'Multiplication97'
                    actions.ReduceRULE_MULTIPLICATION_MULTIPLICATION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NINE_NINE67 :
                    // <Nine> ::= 'Nine67'
                    actions.ReduceRULE_NINE_NINE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NINE_NINE97 :
                    // <Nine> ::= 'Nine97'
                    actions.ReduceRULE_NINE_NINE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ONE_ONE67 :
                    // <One> ::= 'One67'
                    actions.ReduceRULE_ONE_ONE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ONE_ONE97 :
                    // <One> ::= 'One97'
                    actions.ReduceRULE_ONE_ONE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_P_EXCHANGE_S_F67_CHS67 :
                    // <P_Exchange_S> ::= 'f67' 'Chs67'
                    actions.ReduceRULE_P_EXCHANGE_S_F67_CHS67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_P_EXCHANGE_S_F97_CLX97 :
                    // <P_Exchange_S> ::= 'f97' 'Clx97'
                    actions.ReduceRULE_P_EXCHANGE_S_F97_CLX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PAUSE_H67_ONE67 :
                    // <Pause> ::= 'h67' 'One67'
                    actions.ReduceRULE_PAUSE_H67_ONE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PAUSE_F97_R_S97 :
                    // <Pause> ::= 'f97' 'R_S97'
                    actions.ReduceRULE_PAUSE_F97_R_S97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PERCENT_CHANGE_G67_ZERO67 :
                    // <Percent_Change> ::= 'g67' 'Zero67'
                    actions.ReduceRULE_PERCENT_CHANGE_G67_ZERO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PERCENT_CHANGE_F97_PERCENT97 :
                    // <Percent_Change> ::= 'f97' 'Percent97'
                    actions.ReduceRULE_PERCENT_CHANGE_F97_PERCENT97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PERCENT_F67_ZERO67 :
                    // <Percent> ::= 'f67' 'Zero67'
                    actions.ReduceRULE_PERCENT_F67_ZERO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PERCENT_PERCENT97 :
                    // <Percent> ::= 'Percent97'
                    actions.ReduceRULE_PERCENT_PERCENT97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PERIOD_PERIOD67 :
                    // <Period> ::= 'Period67'
                    actions.ReduceRULE_PERIOD_PERIOD67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PERIOD_PERIOD97 :
                    // <Period> ::= 'Period97'
                    actions.ReduceRULE_PERIOD_PERIOD97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PI_H67_TWO67 :
                    // <Pi> ::= 'h67' 'Two67'
                    actions.ReduceRULE_PI_H67_TWO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PI_F97_DIVISION97 :
                    // <Pi> ::= 'f97' 'Division97'
                    actions.ReduceRULE_PI_F97_DIVISION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_PRINT_PRGM_F97_SCI97 :
                    // <Print_Prgm> ::= 'f97' 'Sci97'
                    actions.ReduceRULE_PRINT_PRGM_F97_SCI97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_R_DOWN_H67_EIGHT67 :
                    // <R_Down> ::= 'h67' 'Eight67'
                    actions.ReduceRULE_R_DOWN_H67_EIGHT67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_R_DOWN_R_DOWN97 :
                    // <R_Down> ::= 'R_Down97'
                    actions.ReduceRULE_R_DOWN_R_DOWN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_R_S_R_S67 :
                    // <R_S> ::= 'R_S67'
                    actions.ReduceRULE_R_S_R_S67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_R_S_R_S97 :
                    // <R_S> ::= 'R_S97'
                    actions.ReduceRULE_R_S_R_S97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_R_UP_H67_NINE67 :
                    // <R_Up> ::= 'h67' 'Nine67'
                    actions.ReduceRULE_R_UP_H67_NINE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_R_UP_F97_R_DOWN97 :
                    // <R_Up> ::= 'f97' 'R_Down97'
                    actions.ReduceRULE_R_UP_F97_R_DOWN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RAD_H67_CHS67 :
                    // <Rad> ::= 'h67' 'Chs67'
                    actions.ReduceRULE_RAD_H67_CHS67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RAD_F97_CHS97 :
                    // <Rad> ::= 'f97' 'Chs97'
                    actions.ReduceRULE_RAD_F97_CHS97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RC_I_H67_RCL67 :
                    // <Rc_I> ::= 'h67' 'Rcl67'
                    actions.ReduceRULE_RC_I_H67_RCL67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RC_I_RCL97_I97 :
                    // <Rc_I> ::= 'Rcl97' 'I97'
                    actions.ReduceRULE_RC_I_RCL97_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RCL_RCL67 :
                    // <Rcl> ::= 'Rcl67'
                    actions.ReduceRULE_RCL_RCL67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RCL_RCL97 :
                    // <Rcl> ::= 'Rcl97'
                    actions.ReduceRULE_RCL_RCL97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RECIPROCAL_H67_FOUR67 :
                    // <Reciprocal> ::= 'h67' 'Four67'
                    actions.ReduceRULE_RECIPROCAL_H67_FOUR67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RECIPROCAL_RECIPROCAL97 :
                    // <Reciprocal> ::= 'Reciprocal97'
                    actions.ReduceRULE_RECIPROCAL_RECIPROCAL97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_REG_H67_THREE67 :
                    // <Reg> ::= 'h67' 'Three67'
                    actions.ReduceRULE_REG_H67_THREE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_REG_F97_ENG97 :
                    // <Reg> ::= 'f97' 'Eng97'
                    actions.ReduceRULE_REG_F97_ENG97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RND_F67_SUB_I67 :
                    // <Rnd> ::= 'f67' 'Sub_I67'
                    actions.ReduceRULE_RND_F67_SUB_I67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RND_F97_RTN97 :
                    // <Rnd> ::= 'f97' 'Rtn97'
                    actions.ReduceRULE_RND_F97_RTN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RTN_H67_GTO67 :
                    // <Rtn> ::= 'h67' 'Gto67'
                    actions.ReduceRULE_RTN_H67_GTO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RTN_RTN97 :
                    // <Rtn> ::= 'Rtn97'
                    actions.ReduceRULE_RTN_RTN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_S_G67_SIGMA_PLUS67 :
                    // <S> ::= 'g67' 'Sigma_Plus67'
                    actions.ReduceRULE_S_G67_SIGMA_PLUS67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_S_F97_SQRT97 :
                    // <S> ::= 'f97' 'Sqrt97'
                    actions.ReduceRULE_S_F97_SQRT97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SCI_G67_DSP67 :
                    // <Sci> ::= 'g67' 'Dsp67'
                    actions.ReduceRULE_SCI_G67_DSP67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SCI_SCI97 :
                    // <Sci> ::= 'Sci97'
                    actions.ReduceRULE_SCI_SCI97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SEVEN_SEVEN67 :
                    // <Seven> ::= 'Seven67'
                    actions.ReduceRULE_SEVEN_SEVEN67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SEVEN_SEVEN97 :
                    // <Seven> ::= 'Seven97'
                    actions.ReduceRULE_SEVEN_SEVEN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SF_H67_SUBTRACTION67 :
                    // <SF> ::= 'h67' 'Subtraction67'
                    actions.ReduceRULE_SF_H67_SUBTRACTION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SF_F97_LBL97 :
                    // <SF> ::= 'f97' 'Lbl97'
                    actions.ReduceRULE_SF_F97_LBL97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIGMA_MINUS_H67_SIGMA_PLUS67 :
                    // <Sigma_Minus> ::= 'h67' 'Sigma_Plus67'
                    actions.ReduceRULE_SIGMA_MINUS_H67_SIGMA_PLUS67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIGMA_MINUS_F97_SIGMA_PLUS97 :
                    // <Sigma_Minus> ::= 'f97' 'Sigma_Plus97'
                    actions.ReduceRULE_SIGMA_MINUS_F97_SIGMA_PLUS97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIGMA_PLUS_SIGMA_PLUS67 :
                    // <Sigma_Plus> ::= 'Sigma_Plus67'
                    actions.ReduceRULE_SIGMA_PLUS_SIGMA_PLUS67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIGMA_PLUS_SIGMA_PLUS97 :
                    // <Sigma_Plus> ::= 'Sigma_Plus97'
                    actions.ReduceRULE_SIGMA_PLUS_SIGMA_PLUS97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIN_F67_FOUR67 :
                    // <Sin> ::= 'f67' 'Four67'
                    actions.ReduceRULE_SIN_F67_FOUR67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIN_SIN97 :
                    // <Sin> ::= 'Sin97'
                    actions.ReduceRULE_SIN_SIN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIX_SIX67 :
                    // <Six> ::= 'Six67'
                    actions.ReduceRULE_SIX_SIX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SIX_SIX97 :
                    // <Six> ::= 'Six97'
                    actions.ReduceRULE_SIX_SIX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SPACE_H67_R_S67 :
                    // <Space> ::= 'h67' 'R_S67'
                    actions.ReduceRULE_SPACE_H67_R_S67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SPACE_F97_FIX97 :
                    // <Space> ::= 'f97' 'Fix97'
                    actions.ReduceRULE_SPACE_F97_FIX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SQRT_F67_NINE67 :
                    // <Sqrt> ::= 'f67' 'Nine67'
                    actions.ReduceRULE_SQRT_F67_NINE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SQRT_SQRT97 :
                    // <Sqrt> ::= 'Sqrt97'
                    actions.ReduceRULE_SQRT_SQRT97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SQUARE_G67_NINE67 :
                    // <Square> ::= 'g67' 'Nine67'
                    actions.ReduceRULE_SQUARE_G67_NINE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SQUARE_SQUARE97 :
                    // <Square> ::= 'Square97'
                    actions.ReduceRULE_SQUARE_SQUARE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SST_SST67 :
                    // <Sst> ::= 'Sst67'
                    actions.ReduceRULE_SST_SST67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SST_SST97 :
                    // <Sst> ::= 'Sst97'
                    actions.ReduceRULE_SST_SST97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ST_I_H67_STO67 :
                    // <St_I> ::= 'h67' 'Sto67'
                    actions.ReduceRULE_ST_I_H67_STO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ST_I_STO97_I97 :
                    // <St_I> ::= 'Sto97' 'I97'
                    actions.ReduceRULE_ST_I_STO97_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_STK_G67_R_S67 :
                    // <Stk> ::= 'g67' 'R_S67'
                    actions.ReduceRULE_STK_G67_R_S67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_STK_F97_DIPLAY_X97 :
                    // <Stk> ::= 'f97' 'Diplay_X97'
                    actions.ReduceRULE_STK_F97_DIPLAY_X97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_STO_STO67 :
                    // <Sto> ::= 'Sto67'
                    actions.ReduceRULE_STO_STO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_STO_STO97 :
                    // <Sto> ::= 'Sto97'
                    actions.ReduceRULE_STO_STO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SUB_I_SUB_I67 :
                    // <Sub_I> ::= 'Sub_I67'
                    actions.ReduceRULE_SUB_I_SUB_I67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SUB_I_SUB_I97 :
                    // <Sub_I> ::= 'Sub_I97'
                    actions.ReduceRULE_SUB_I_SUB_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SUBTRACTION_SUBTRACTION67 :
                    // <Subtraction> ::= 'Subtraction67'
                    actions.ReduceRULE_SUBTRACTION_SUBTRACTION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SUBTRACTION_SUBTRACTION97 :
                    // <Subtraction> ::= 'Subtraction97'
                    actions.ReduceRULE_SUBTRACTION_SUBTRACTION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TAN_F67_SIX67 :
                    // <Tan> ::= 'f67' 'Six67'
                    actions.ReduceRULE_TAN_F67_SIX67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TAN_TAN97 :
                    // <Tan> ::= 'Tan97'
                    actions.ReduceRULE_TAN_TAN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TEN_TO_THE_XTH_G67_EIGHT67 :
                    // <Ten_To_The_Xth> ::= 'g67' 'Eight67'
                    actions.ReduceRULE_TEN_TO_THE_XTH_G67_EIGHT67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TEN_TO_THE_XTH_F97_EXP97 :
                    // <Ten_To_The_Xth> ::= 'f97' 'Exp97'
                    actions.ReduceRULE_TEN_TO_THE_XTH_F97_EXP97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_THREE_THREE67 :
                    // <Three> ::= 'Three67'
                    actions.ReduceRULE_THREE_THREE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_THREE_THREE97 :
                    // <Three> ::= 'Three97'
                    actions.ReduceRULE_THREE_THREE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_DEGREES_F67_TWO67 :
                    // <To_Degrees> ::= 'f67' 'Two67'
                    actions.ReduceRULE_TO_DEGREES_F67_TWO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_DEGREES_F97_I97 :
                    // <To_Degrees> ::= 'f97' 'I97'
                    actions.ReduceRULE_TO_DEGREES_F97_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_HMS_G67_THREE67 :
                    // <To_HMS> ::= 'g67' 'Three67'
                    actions.ReduceRULE_TO_HMS_G67_THREE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_HMS_F97_STO97 :
                    // <To_HMS> ::= 'f97' 'Sto97'
                    actions.ReduceRULE_TO_HMS_F97_STO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_HOURS_F67_THREE67 :
                    // <To_Hours> ::= 'f67' 'Three67'
                    actions.ReduceRULE_TO_HOURS_F67_THREE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_HOURS_F97_RCL97 :
                    // <To_Hours> ::= 'f97' 'Rcl97'
                    actions.ReduceRULE_TO_HOURS_F97_RCL97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_POLAR_G67_ONE67 :
                    // <To_Polar> ::= 'g67' 'One67'
                    actions.ReduceRULE_TO_POLAR_G67_ONE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_POLAR_TO_POLAR97 :
                    // <To_Polar> ::= 'To_Polar97'
                    actions.ReduceRULE_TO_POLAR_TO_POLAR97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_RADIANS_G67_TWO67 :
                    // <To_Radians> ::= 'g67' 'Two67'
                    actions.ReduceRULE_TO_RADIANS_G67_TWO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_RADIANS_F97_SUB_I97 :
                    // <To_Radians> ::= 'f97' 'Sub_I97'
                    actions.ReduceRULE_TO_RADIANS_F97_SUB_I97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_RECTANGULAR_F67_ONE67 :
                    // <To_Rectangular> ::= 'f67' 'One67'
                    actions.ReduceRULE_TO_RECTANGULAR_F67_ONE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TO_RECTANGULAR_TO_RECTANGULAR97 :
                    // <To_Rectangular> ::= 'To_Rectangular97'
                    actions.ReduceRULE_TO_RECTANGULAR_TO_RECTANGULAR97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TWO_TWO67 :
                    // <Two> ::= 'Two67'
                    actions.ReduceRULE_TWO_TWO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TWO_TWO97 :
                    // <Two> ::= 'Two97'
                    actions.ReduceRULE_TWO_TWO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_W_DATA_F67_ENTER67 :
                    // <W_Data> ::= 'f67' 'Enter67'
                    actions.ReduceRULE_W_DATA_F67_ENTER67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_W_DATA_F97_ZERO97 :
                    // <W_Data> ::= 'f97' 'Zero97'
                    actions.ReduceRULE_W_DATA_F97_ZERO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_AVERAGE_F67_SIGMA_PLUS67 :
                    // <X_Average> ::= 'f67' 'Sigma_Plus67'
                    actions.ReduceRULE_X_AVERAGE_F67_SIGMA_PLUS67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_AVERAGE_F97_SQUARE97 :
                    // <X_Average> ::= 'f97' 'Square97'
                    actions.ReduceRULE_X_AVERAGE_F97_SQUARE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EQ_0_F67_SUBTRACTION67 :
                    // <X_EQ_0> ::= 'f67' 'Subtraction67'
                    actions.ReduceRULE_X_EQ_0_F67_SUBTRACTION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EQ_0_F97_FIVE97 :
                    // <X_EQ_0> ::= 'f97' 'Five97'
                    actions.ReduceRULE_X_EQ_0_F97_FIVE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EQ_Y_G67_SUBTRACTION67 :
                    // <X_EQ_Y> ::= 'g67' 'Subtraction67'
                    actions.ReduceRULE_X_EQ_Y_G67_SUBTRACTION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EQ_Y_F97_EIGHT97 :
                    // <X_EQ_Y> ::= 'f97' 'Eight97'
                    actions.ReduceRULE_X_EQ_Y_F97_EIGHT97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EXCHANGE_I_H67_SUB_I67 :
                    // <X_Exchange_I> ::= 'h67' 'Sub_I67'
                    actions.ReduceRULE_X_EXCHANGE_I_H67_SUB_I67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 :
                    // <X_Exchange_I> ::= 'f97' 'X_Exchange_Y97'
                    actions.ReduceRULE_X_EXCHANGE_I_F97_X_EXCHANGE_Y97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EXCHANGE_Y_H67_SEVEN67 :
                    // <X_Exchange_Y> ::= 'h67' 'Seven67'
                    actions.ReduceRULE_X_EXCHANGE_Y_H67_SEVEN67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_EXCHANGE_Y_X_EXCHANGE_97 :
                    // <X_Exchange_Y> ::= 'X_Exchange_97'
                    actions.ReduceRULE_X_EXCHANGE_Y_X_EXCHANGE_97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_GT_0_F67_DIVISION67 :
                    // <X_GT_0> ::= 'f67' 'Division67'
                    actions.ReduceRULE_X_GT_0_F67_DIVISION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_GT_0_F97_SIX97 :
                    // <X_GT_0> ::= 'f97' 'Six97'
                    actions.ReduceRULE_X_GT_0_F97_SIX97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_GT_Y_G67_DIVISION67 :
                    // <X_GT_Y> ::= 'g67' 'Division67'
                    actions.ReduceRULE_X_GT_Y_G67_DIVISION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_GT_Y_F97_NINE97 :
                    // <X_GT_Y> ::= 'f97' 'Nine97'
                    actions.ReduceRULE_X_GT_Y_F97_NINE97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_LE_Y_G67_MULTIPLICATION67 :
                    // <X_LE_Y> ::= 'g67' 'Multiplication67'
                    actions.ReduceRULE_X_LE_Y_G67_MULTIPLICATION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_LE_Y_F97_MULTIPLICATION97 :
                    // <X_LE_Y> ::= 'f97' 'Multiplication97'
                    actions.ReduceRULE_X_LE_Y_F97_MULTIPLICATION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_LT_0_F67_MULTIPLICATION67 :
                    // <X_LT_0> ::= 'f67' 'Multiplication67'
                    actions.ReduceRULE_X_LT_0_F67_MULTIPLICATION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_LT_0_F97_SUBTRACTION97 :
                    // <X_LT_0> ::= 'f97' 'Subtraction97'
                    actions.ReduceRULE_X_LT_0_F97_SUBTRACTION97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_NE_0_F67_ADDITION67 :
                    // <X_NE_0> ::= 'f67' 'Addition67'
                    actions.ReduceRULE_X_NE_0_F67_ADDITION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_NE_0_F97_FOUR97 :
                    // <X_NE_0> ::= 'f97' 'Four97'
                    actions.ReduceRULE_X_NE_0_F97_FOUR97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_NE_Y_G67_ADDITION67 :
                    // <X_NE_Y> ::= 'g67' 'Addition67'
                    actions.ReduceRULE_X_NE_Y_G67_ADDITION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_X_NE_Y_F97_SEVEN97 :
                    // <X_NE_Y> ::= 'f97' 'Seven97'
                    actions.ReduceRULE_X_NE_Y_F97_SEVEN97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_Y_TO_THE_XTH_H67_FIVE67 :
                    // <Y_To_The_Xth> ::= 'h67' 'Five67'
                    actions.ReduceRULE_Y_TO_THE_XTH_H67_FIVE67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_Y_TO_THE_XTH_Y_TO_THE_XTH :
                    // <Y_To_The_Xth> ::= 'Y_To_The_Xth'
                    actions.ReduceRULE_Y_TO_THE_XTH_Y_TO_THE_XTH (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ZERO_ZERO67 :
                    // <Zero> ::= 'Zero67'
                    actions.ReduceRULE_ZERO_ZERO67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_ZERO_ZERO97 :
                    // <Zero> ::= 'Zero97'
                    actions.ReduceRULE_ZERO_ZERO97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_INSTRUCTION :
                    // <Instruction> ::= <Shortcut>
                    actions.ReduceRULE_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_INSTRUCTION2 :
                    // <Instruction> ::= <Nullary_Instruction>
                    actions.ReduceRULE_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_INSTRUCTION3 :
                    // <Instruction> ::= <Unary_Instruction>
                    actions.ReduceRULE_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_INSTRUCTION4 :
                    // <Instruction> ::= <Binary_Instruction>
                    actions.ReduceRULE_INSTRUCTION4 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_INSTRUCTION5 :
                    // <Instruction> ::= <Ternary_Instruction>
                    actions.ReduceRULE_INSTRUCTION5 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SHORTCUT :
                    // <Shortcut> ::= <Gsb_Shortcut>
                    actions.ReduceRULE_SHORTCUT (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_SHORTCUT2 :
                    // <Shortcut> ::= <Memory_Shortcut>
                    actions.ReduceRULE_SHORTCUT2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GSB_SHORTCUT :
                    // <Gsb_Shortcut> ::= <Letter_Label>
                    actions.ReduceRULE_GSB_SHORTCUT (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_MEMORY_SHORTCUT :
                    // <Memory_Shortcut> ::= <Sub_I>
                    actions.ReduceRULE_MEMORY_SHORTCUT (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION :
                    // <Nullary_Instruction> ::= <Abs>
                    actions.ReduceRULE_NULLARY_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION2 :
                    // <Nullary_Instruction> ::= <Addition>
                    actions.ReduceRULE_NULLARY_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION3 :
                    // <Nullary_Instruction> ::= <Arccos>
                    actions.ReduceRULE_NULLARY_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION4 :
                    // <Nullary_Instruction> ::= <Arcsin>
                    actions.ReduceRULE_NULLARY_INSTRUCTION4 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION5 :
                    // <Nullary_Instruction> ::= <Arctan>
                    actions.ReduceRULE_NULLARY_INSTRUCTION5 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION6 :
                    // <Nullary_Instruction> ::= <Bst>
                    actions.ReduceRULE_NULLARY_INSTRUCTION6 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION7 :
                    // <Nullary_Instruction> ::= <Chs>
                    actions.ReduceRULE_NULLARY_INSTRUCTION7 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION8 :
                    // <Nullary_Instruction> ::= <Cl_Prgm>
                    actions.ReduceRULE_NULLARY_INSTRUCTION8 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION9 :
                    // <Nullary_Instruction> ::= <Cl_Reg>
                    actions.ReduceRULE_NULLARY_INSTRUCTION9 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION10 :
                    // <Nullary_Instruction> ::= <Clx>
                    actions.ReduceRULE_NULLARY_INSTRUCTION10 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION11 :
                    // <Nullary_Instruction> ::= <Cos>
                    actions.ReduceRULE_NULLARY_INSTRUCTION11 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION12 :
                    // <Nullary_Instruction> ::= <Deg>
                    actions.ReduceRULE_NULLARY_INSTRUCTION12 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION13 :
                    // <Nullary_Instruction> ::= <Del>
                    actions.ReduceRULE_NULLARY_INSTRUCTION13 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION14 :
                    // <Nullary_Instruction> ::= <Digit>
                    actions.ReduceRULE_NULLARY_INSTRUCTION14 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION15 :
                    // <Nullary_Instruction> ::= <Display_X>
                    actions.ReduceRULE_NULLARY_INSTRUCTION15 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION16 :
                    // <Nullary_Instruction> ::= <Division>
                    actions.ReduceRULE_NULLARY_INSTRUCTION16 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION17 :
                    // <Nullary_Instruction> ::= <Dsz_Sub_I>
                    actions.ReduceRULE_NULLARY_INSTRUCTION17 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION18 :
                    // <Nullary_Instruction> ::= <Dsz>
                    actions.ReduceRULE_NULLARY_INSTRUCTION18 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION19 :
                    // <Nullary_Instruction> ::= <Eex>
                    actions.ReduceRULE_NULLARY_INSTRUCTION19 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION20 :
                    // <Nullary_Instruction> ::= <Eng>
                    actions.ReduceRULE_NULLARY_INSTRUCTION20 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION21 :
                    // <Nullary_Instruction> ::= <Enter>
                    actions.ReduceRULE_NULLARY_INSTRUCTION21 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION22 :
                    // <Nullary_Instruction> ::= <Exp>
                    actions.ReduceRULE_NULLARY_INSTRUCTION22 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION23 :
                    // <Nullary_Instruction> ::= <Factorial>
                    actions.ReduceRULE_NULLARY_INSTRUCTION23 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION24 :
                    // <Nullary_Instruction> ::= <Fix>
                    actions.ReduceRULE_NULLARY_INSTRUCTION24 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION25 :
                    // <Nullary_Instruction> ::= <Frac>
                    actions.ReduceRULE_NULLARY_INSTRUCTION25 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION26 :
                    // <Nullary_Instruction> ::= <Grd>
                    actions.ReduceRULE_NULLARY_INSTRUCTION26 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION27 :
                    // <Nullary_Instruction> ::= <HMS_Plus>
                    actions.ReduceRULE_NULLARY_INSTRUCTION27 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION28 :
                    // <Nullary_Instruction> ::= <Int>
                    actions.ReduceRULE_NULLARY_INSTRUCTION28 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION29 :
                    // <Nullary_Instruction> ::= <Isz_Sub_I>
                    actions.ReduceRULE_NULLARY_INSTRUCTION29 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION30 :
                    // <Nullary_Instruction> ::= <Isz>
                    actions.ReduceRULE_NULLARY_INSTRUCTION30 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION31 :
                    // <Nullary_Instruction> ::= <Ln>
                    actions.ReduceRULE_NULLARY_INSTRUCTION31 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION32 :
                    // <Nullary_Instruction> ::= <Log>
                    actions.ReduceRULE_NULLARY_INSTRUCTION32 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION33 :
                    // <Nullary_Instruction> ::= <Lst_X>
                    actions.ReduceRULE_NULLARY_INSTRUCTION33 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION34 :
                    // <Nullary_Instruction> ::= <Merge>
                    actions.ReduceRULE_NULLARY_INSTRUCTION34 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION35 :
                    // <Nullary_Instruction> ::= <Multiplication>
                    actions.ReduceRULE_NULLARY_INSTRUCTION35 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION36 :
                    // <Nullary_Instruction> ::= <P_Exchange_S>
                    actions.ReduceRULE_NULLARY_INSTRUCTION36 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION37 :
                    // <Nullary_Instruction> ::= <Pause>
                    actions.ReduceRULE_NULLARY_INSTRUCTION37 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION38 :
                    // <Nullary_Instruction> ::= <Percent_Change>
                    actions.ReduceRULE_NULLARY_INSTRUCTION38 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION39 :
                    // <Nullary_Instruction> ::= <Percent>
                    actions.ReduceRULE_NULLARY_INSTRUCTION39 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION40 :
                    // <Nullary_Instruction> ::= <Period>
                    actions.ReduceRULE_NULLARY_INSTRUCTION40 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION41 :
                    // <Nullary_Instruction> ::= <Pi>
                    actions.ReduceRULE_NULLARY_INSTRUCTION41 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION42 :
                    // <Nullary_Instruction> ::= <Print_Prgm>
                    actions.ReduceRULE_NULLARY_INSTRUCTION42 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION43 :
                    // <Nullary_Instruction> ::= <R_Down>
                    actions.ReduceRULE_NULLARY_INSTRUCTION43 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION44 :
                    // <Nullary_Instruction> ::= <R_S>
                    actions.ReduceRULE_NULLARY_INSTRUCTION44 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION45 :
                    // <Nullary_Instruction> ::= <R_Up>
                    actions.ReduceRULE_NULLARY_INSTRUCTION45 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION46 :
                    // <Nullary_Instruction> ::= <Rad>
                    actions.ReduceRULE_NULLARY_INSTRUCTION46 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION47 :
                    // <Nullary_Instruction> ::= <Rc_I>
                    actions.ReduceRULE_NULLARY_INSTRUCTION47 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION48 :
                    // <Nullary_Instruction> ::= <Rcl_Sigma_Plus>
                    actions.ReduceRULE_NULLARY_INSTRUCTION48 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION49 :
                    // <Nullary_Instruction> ::= <Reciprocal>
                    actions.ReduceRULE_NULLARY_INSTRUCTION49 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION50 :
                    // <Nullary_Instruction> ::= <Reg>
                    actions.ReduceRULE_NULLARY_INSTRUCTION50 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION51 :
                    // <Nullary_Instruction> ::= <Rnd>
                    actions.ReduceRULE_NULLARY_INSTRUCTION51 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION52 :
                    // <Nullary_Instruction> ::= <Rtn>
                    actions.ReduceRULE_NULLARY_INSTRUCTION52 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION53 :
                    // <Nullary_Instruction> ::= <S>
                    actions.ReduceRULE_NULLARY_INSTRUCTION53 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION54 :
                    // <Nullary_Instruction> ::= <Sci>
                    actions.ReduceRULE_NULLARY_INSTRUCTION54 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION55 :
                    // <Nullary_Instruction> ::= <Sigma_Minus>
                    actions.ReduceRULE_NULLARY_INSTRUCTION55 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION56 :
                    // <Nullary_Instruction> ::= <Sigma_Plus>
                    actions.ReduceRULE_NULLARY_INSTRUCTION56 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION57 :
                    // <Nullary_Instruction> ::= <Sin>
                    actions.ReduceRULE_NULLARY_INSTRUCTION57 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION58 :
                    // <Nullary_Instruction> ::= <Space>
                    actions.ReduceRULE_NULLARY_INSTRUCTION58 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION59 :
                    // <Nullary_Instruction> ::= <Sqrt>
                    actions.ReduceRULE_NULLARY_INSTRUCTION59 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION60 :
                    // <Nullary_Instruction> ::= <Square>
                    actions.ReduceRULE_NULLARY_INSTRUCTION60 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION61 :
                    // <Nullary_Instruction> ::= <Sst>
                    actions.ReduceRULE_NULLARY_INSTRUCTION61 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION62 :
                    // <Nullary_Instruction> ::= <St_I>
                    actions.ReduceRULE_NULLARY_INSTRUCTION62 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION63 :
                    // <Nullary_Instruction> ::= <Stk>
                    actions.ReduceRULE_NULLARY_INSTRUCTION63 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION64 :
                    // <Nullary_Instruction> ::= <Subtraction>
                    actions.ReduceRULE_NULLARY_INSTRUCTION64 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION65 :
                    // <Nullary_Instruction> ::= <Tan>
                    actions.ReduceRULE_NULLARY_INSTRUCTION65 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION66 :
                    // <Nullary_Instruction> ::= <Ten_To_The_Xth>
                    actions.ReduceRULE_NULLARY_INSTRUCTION66 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION67 :
                    // <Nullary_Instruction> ::= <To_Degrees>
                    actions.ReduceRULE_NULLARY_INSTRUCTION67 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION68 :
                    // <Nullary_Instruction> ::= <To_HMS>
                    actions.ReduceRULE_NULLARY_INSTRUCTION68 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION69 :
                    // <Nullary_Instruction> ::= <To_Hours>
                    actions.ReduceRULE_NULLARY_INSTRUCTION69 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION70 :
                    // <Nullary_Instruction> ::= <To_Polar>
                    actions.ReduceRULE_NULLARY_INSTRUCTION70 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION71 :
                    // <Nullary_Instruction> ::= <To_Radians>
                    actions.ReduceRULE_NULLARY_INSTRUCTION71 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION72 :
                    // <Nullary_Instruction> ::= <To_Rectangular>
                    actions.ReduceRULE_NULLARY_INSTRUCTION72 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION73 :
                    // <Nullary_Instruction> ::= <W_Data>
                    actions.ReduceRULE_NULLARY_INSTRUCTION73 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION74 :
                    // <Nullary_Instruction> ::= <X_Average>
                    actions.ReduceRULE_NULLARY_INSTRUCTION74 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION75 :
                    // <Nullary_Instruction> ::= <X_EQ_0>
                    actions.ReduceRULE_NULLARY_INSTRUCTION75 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION76 :
                    // <Nullary_Instruction> ::= <X_EQ_Y>
                    actions.ReduceRULE_NULLARY_INSTRUCTION76 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION77 :
                    // <Nullary_Instruction> ::= <X_Exchange_I>
                    actions.ReduceRULE_NULLARY_INSTRUCTION77 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION78 :
                    // <Nullary_Instruction> ::= <X_Exchange_Y>
                    actions.ReduceRULE_NULLARY_INSTRUCTION78 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION79 :
                    // <Nullary_Instruction> ::= <X_GT_0>
                    actions.ReduceRULE_NULLARY_INSTRUCTION79 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION80 :
                    // <Nullary_Instruction> ::= <X_GT_Y>
                    actions.ReduceRULE_NULLARY_INSTRUCTION80 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION81 :
                    // <Nullary_Instruction> ::= <X_LE_Y>
                    actions.ReduceRULE_NULLARY_INSTRUCTION81 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION82 :
                    // <Nullary_Instruction> ::= <X_LT_0>
                    actions.ReduceRULE_NULLARY_INSTRUCTION82 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION83 :
                    // <Nullary_Instruction> ::= <X_NE_0>
                    actions.ReduceRULE_NULLARY_INSTRUCTION83 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION84 :
                    // <Nullary_Instruction> ::= <X_NE_Y>
                    actions.ReduceRULE_NULLARY_INSTRUCTION84 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NULLARY_INSTRUCTION85 :
                    // <Nullary_Instruction> ::= <Y_To_The_Xth>
                    actions.ReduceRULE_NULLARY_INSTRUCTION85 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION :
                    // <Unary_Instruction> ::= <CF> <Flag>
                    actions.ReduceRULE_UNARY_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION2 :
                    // <Unary_Instruction> ::= <Dsp> <Digit_Count>
                    actions.ReduceRULE_UNARY_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION3 :
                    // <Unary_Instruction> ::= <F_Test> <Flag>
                    actions.ReduceRULE_UNARY_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION4 :
                    // <Unary_Instruction> ::= <Gsb> <Non_Lowercase_Label>
                    actions.ReduceRULE_UNARY_INSTRUCTION4 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION5 :
                    // <Unary_Instruction> ::= <Gsb_f> <Uppercase_Letter_Label>
                    actions.ReduceRULE_UNARY_INSTRUCTION5 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION_GSB97 :
                    // <Unary_Instruction> ::= 'Gsb97' <Lowercase_Letter_Label>
                    actions.ReduceRULE_UNARY_INSTRUCTION_GSB97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION6 :
                    // <Unary_Instruction> ::= <Gto> <Label>
                    actions.ReduceRULE_UNARY_INSTRUCTION6 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION7 :
                    // <Unary_Instruction> ::= <Lbl> <Non_Lowercase_Label>
                    actions.ReduceRULE_UNARY_INSTRUCTION7 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION8 :
                    // <Unary_Instruction> ::= <Lbl_f> <Uppercase_Letter_Label>
                    actions.ReduceRULE_UNARY_INSTRUCTION8 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION_LBL97 :
                    // <Unary_Instruction> ::= 'Lbl97' <Lowercase_Letter_Label>
                    actions.ReduceRULE_UNARY_INSTRUCTION_LBL97 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION9 :
                    // <Unary_Instruction> ::= <Rcl> <Memory>
                    actions.ReduceRULE_UNARY_INSTRUCTION9 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION10 :
                    // <Unary_Instruction> ::= <SF> <Flag>
                    actions.ReduceRULE_UNARY_INSTRUCTION10 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UNARY_INSTRUCTION11 :
                    // <Unary_Instruction> ::= <Sto> <Memory>
                    actions.ReduceRULE_UNARY_INSTRUCTION11 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_BINARY_INSTRUCTION :
                    // <Binary_Instruction> ::= <Sto> <Operator> <Operable_Memory>
                    actions.ReduceRULE_BINARY_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_TERNARY_INSTRUCTION :
                    // <Ternary_Instruction> ::= <Gto_Period> <Digit> <Digit> <Digit>
                    actions.ReduceRULE_TERNARY_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_RCL_SIGMA_PLUS :
                    // <Rcl_Sigma_Plus> ::= <Rcl> <Sigma_Plus>
                    actions.ReduceRULE_RCL_SIGMA_PLUS (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_GTO_PERIOD :
                    // <Gto_Period> ::= <Gto> <Period>
                    actions.ReduceRULE_GTO_PERIOD (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_OPERATOR :
                    // <Operator> ::= <Subtraction>
                    actions.ReduceRULE_OPERATOR (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_OPERATOR2 :
                    // <Operator> ::= <Addition>
                    actions.ReduceRULE_OPERATOR2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_OPERATOR3 :
                    // <Operator> ::= <Multiplication>
                    actions.ReduceRULE_OPERATOR3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_OPERATOR4 :
                    // <Operator> ::= <Division>
                    actions.ReduceRULE_OPERATOR4 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT :
                    // <Digit> ::= <Zero>
                    actions.ReduceRULE_DIGIT (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT2 :
                    // <Digit> ::= <One>
                    actions.ReduceRULE_DIGIT2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT3 :
                    // <Digit> ::= <Two>
                    actions.ReduceRULE_DIGIT3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT4 :
                    // <Digit> ::= <Three>
                    actions.ReduceRULE_DIGIT4 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT5 :
                    // <Digit> ::= <Four>
                    actions.ReduceRULE_DIGIT5 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT6 :
                    // <Digit> ::= <Five>
                    actions.ReduceRULE_DIGIT6 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT7 :
                    // <Digit> ::= <Six>
                    actions.ReduceRULE_DIGIT7 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT8 :
                    // <Digit> ::= <Seven>
                    actions.ReduceRULE_DIGIT8 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT9 :
                    // <Digit> ::= <Eight>
                    actions.ReduceRULE_DIGIT9 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT10 :
                    // <Digit> ::= <Nine>
                    actions.ReduceRULE_DIGIT10 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT_COUNT :
                    // <Digit_Count> ::= <Digit>
                    actions.ReduceRULE_DIGIT_COUNT (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT_COUNT2 :
                    // <Digit_Count> ::= <Sub_I>
                    actions.ReduceRULE_DIGIT_COUNT2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FLAG :
                    // <Flag> ::= <Zero>
                    actions.ReduceRULE_FLAG (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FLAG2 :
                    // <Flag> ::= <One>
                    actions.ReduceRULE_FLAG2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FLAG3 :
                    // <Flag> ::= <Two>
                    actions.ReduceRULE_FLAG3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_FLAG4 :
                    // <Flag> ::= <Three>
                    actions.ReduceRULE_FLAG4 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LETTER :
                    // <Letter> ::= <A>
                    actions.ReduceRULE_LETTER (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LETTER2 :
                    // <Letter> ::= <B>
                    actions.ReduceRULE_LETTER2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LETTER3 :
                    // <Letter> ::= <C>
                    actions.ReduceRULE_LETTER3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LETTER4 :
                    // <Letter> ::= <D>
                    actions.ReduceRULE_LETTER4 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LETTER5 :
                    // <Letter> ::= <E>
                    actions.ReduceRULE_LETTER5 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_UPPERCASE_LETTER_LABEL :
                    // <Uppercase_Letter_Label> ::= <Letter>
                    actions.ReduceRULE_UPPERCASE_LETTER_LABEL (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LOWERCASE_LETTER_LABEL :
                    // <Lowercase_Letter_Label> ::= <f> <Letter>
                    actions.ReduceRULE_LOWERCASE_LETTER_LABEL (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LETTER_LABEL :
                    // <Letter_Label> ::= <Lowercase_Letter_Label>
                    actions.ReduceRULE_LETTER_LABEL (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LETTER_LABEL2 :
                    // <Letter_Label> ::= <Uppercase_Letter_Label>
                    actions.ReduceRULE_LETTER_LABEL2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_DIGIT_LABEL :
                    // <Digit_Label> ::= <Digit>
                    actions.ReduceRULE_DIGIT_LABEL (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NON_LOWERCASE_LABEL :
                    // <Non_Lowercase_Label> ::= <Digit_Label>
                    actions.ReduceRULE_NON_LOWERCASE_LABEL (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NON_LOWERCASE_LABEL2 :
                    // <Non_Lowercase_Label> ::= <Uppercase_Letter_Label>
                    actions.ReduceRULE_NON_LOWERCASE_LABEL2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_NON_LOWERCASE_LABEL3 :
                    // <Non_Lowercase_Label> ::= <Sub_I>
                    actions.ReduceRULE_NON_LOWERCASE_LABEL3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LABEL :
                    // <Label> ::= <Digit_Label>
                    actions.ReduceRULE_LABEL (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LABEL2 :
                    // <Label> ::= <Letter_Label>
                    actions.ReduceRULE_LABEL2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_LABEL3 :
                    // <Label> ::= <Sub_I>
                    actions.ReduceRULE_LABEL3 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_OPERABLE_MEMORY :
                    // <Operable_Memory> ::= <Digit>
                    actions.ReduceRULE_OPERABLE_MEMORY (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_OPERABLE_MEMORY2 :
                    // <Operable_Memory> ::= <Sub_I>
                    actions.ReduceRULE_OPERABLE_MEMORY2 (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_MEMORY :
                    // <Memory> ::= <Operable_Memory>
                    actions.ReduceRULE_MEMORY (input, args.Token, args.Token.Tokens);
                    return;
                case RuleConstants.RULE_MEMORY2 :
                    // <Memory> ::= <Letter>
                    actions.ReduceRULE_MEMORY2 (input, args.Token, args.Token.Tokens);
                    return;
            }
			Trace.Assert (false);
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

        public Parser (Reader reader, IActions a)
        {
            parser = reader.CreateNewParser ();
            parser.TrimReductions = false; 
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

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
