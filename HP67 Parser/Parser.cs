
using com.calitha.commons;
using com.calitha.goldparser;
using com.calitha.goldparser.lalr;
using System;
using System.Diagnostics;
using System.IO;

namespace HP67_Parser
{

    public enum SymbolConstants : int
    {
        SYMBOL_EOF                           = 0  , // (EOF)
        SYMBOL_ERROR                         = 1  , // (Error)
        SYMBOL_WHITESPACE                    = 2  , // (Whitespace)
        SYMBOL_A                             = 3  , // A
        SYMBOL_ADDITION                      = 4  , // Addition
        SYMBOL_B                             = 5  , // B
        SYMBOL_C                             = 6  , // C
        SYMBOL_CHS                           = 7  , // Chs
        SYMBOL_CLX                           = 8  , // Clx
        SYMBOL_D                             = 9  , // D
        SYMBOL_DIVISION                      = 10 , // Division
        SYMBOL_DSP                           = 11 , // Dsp
        SYMBOL_E                             = 12 , // E
        SYMBOL_EEX                           = 13 , // Eex
        SYMBOL_EIGHT                         = 14 , // Eight
        SYMBOL_ENTER                         = 15 , // Enter
        SYMBOL_F                             = 16 , // f
        SYMBOL_FIVE                          = 17 , // Five
        SYMBOL_FOUR                          = 18 , // Four
        SYMBOL_G                             = 19 , // g
        SYMBOL_GTO                           = 20 , // Gto
        SYMBOL_H                             = 21 , // h
        SYMBOL_MULTIPLICATION                = 22 , // Multiplication
        SYMBOL_NINE                          = 23 , // Nine
        SYMBOL_ONE                           = 24 , // One
        SYMBOL_PERIOD                        = 25 , // Period
        SYMBOL_R_S                           = 26 , // 'R_S'
        SYMBOL_RCL                           = 27 , // Rcl
        SYMBOL_SEVEN                         = 28 , // Seven
        SYMBOL_SIGMA_PLUS                    = 29 , // 'Sigma_Plus'
        SYMBOL_SIX                           = 30 , // Six
        SYMBOL_SST                           = 31 , // Sst
        SYMBOL_STO                           = 32 , // Sto
        SYMBOL_SUB_I                         = 33 , // 'Sub_I'
        SYMBOL_SUBTRACTION                   = 34 , // Subtraction
        SYMBOL_THREE                         = 35 , // Three
        SYMBOL_TWO                           = 36 , // Two
        SYMBOL_ZERO                          = 37 , // Zero
        SYMBOL_ABS                           = 38 , // <Abs>
        SYMBOL_ARCCOS                        = 39 , // <Arccos>
        SYMBOL_ARCSIN                        = 40 , // <Arcsin>
        SYMBOL_ARCTAN                        = 41 , // <Arctan>
        SYMBOL_BINARY_UNSHIFTED_INSTRUCTION  = 42 , // <Binary_Unshifted_Instruction>
        SYMBOL_BST                           = 43 , // <Bst>
        SYMBOL_CF                            = 44 , // <CF>
        SYMBOL_CL_PRGM                       = 45 , // <Cl_Prgm>
        SYMBOL_CL_REG                        = 46 , // <Cl_Reg>
        SYMBOL_COS                           = 47 , // <Cos>
        SYMBOL_DEG                           = 48 , // <Deg>
        SYMBOL_DEL                           = 49 , // <Del>
        SYMBOL_DIGIT                         = 50 , // <Digit>
        SYMBOL_DIGIT_COUNT                   = 51 , // <Digit_Count>
        SYMBOL_DIGIT_LABEL                   = 52 , // <Digit_Label>
        SYMBOL_DISPLAY_X                     = 53 , // <Display_X>
        SYMBOL_DSZ                           = 54 , // <Dsz>
        SYMBOL_DSZ_SUB_I                     = 55 , // <Dsz_Sub_I>
        SYMBOL_ENG                           = 56 , // <Eng>
        SYMBOL_EXP                           = 57 , // <Exp>
        SYMBOL_F_SHIFTED_INSTRUCTION         = 58 , // <F_Shifted_Instruction>
        SYMBOL_F_SHIFTED_SHORTCUT            = 59 , // <F_Shifted_Shortcut>
        SYMBOL_F_TEST                        = 60 , // <F_Test>
        SYMBOL_FACTORIAL                     = 61 , // <Factorial>
        SYMBOL_FIX                           = 62 , // <Fix>
        SYMBOL_FRAC                          = 63 , // <Frac>
        SYMBOL_G_SHIFTED_INSTRUCTION         = 64 , // <G_Shifted_Instruction>
        SYMBOL_GRD                           = 65 , // <Grd>
        SYMBOL_GSB                           = 66 , // <Gsb>
        SYMBOL_GSB_F                         = 67 , // <Gsb_f>
        SYMBOL_GSB_SHORTCUT                  = 68 , // <Gsb_Shortcut>
        SYMBOL_H_SHIFTED_INSTRUCTION         = 69 , // <H_Shifted_Instruction>
        SYMBOL_HMS_PLUS                      = 70 , // <HMS_Plus>
        SYMBOL_INSTRUCTION                   = 71 , // <Instruction>
        SYMBOL_INT                           = 72 , // <Int>
        SYMBOL_ISZ                           = 73 , // <Isz>
        SYMBOL_ISZ_SUB_I                     = 74 , // <Isz_Sub_I>
        SYMBOL_LABEL                         = 75 , // <Label>
        SYMBOL_LBL                           = 76 , // <Lbl>
        SYMBOL_LBL_F                         = 77 , // <Lbl_f>
        SYMBOL_LETTER                        = 78 , // <Letter>
        SYMBOL_LETTER_LABEL                  = 79 , // <Letter_Label>
        SYMBOL_LN                            = 80 , // <Ln>
        SYMBOL_LOG                           = 81 , // <Log>
        SYMBOL_LST_X                         = 82 , // <Lst_X>
        SYMBOL_MEMORY                        = 83 , // <Memory>
        SYMBOL_MEMORY_SHORTCUT               = 84 , // <Memory_Shortcut>
        SYMBOL_MERGE                         = 85 , // <Merge>
        SYMBOL_NULLARY_F_SHIFTED_INSTRUCTION = 86 , // <Nullary_F_Shifted_Instruction>
        SYMBOL_NULLARY_G_SHIFTED_INSTRUCTION = 87 , // <Nullary_G_Shifted_Instruction>
        SYMBOL_NULLARY_H_SHIFTED_INSTRUCTION = 88 , // <Nullary_H_Shifted_Instruction>
        SYMBOL_NULLARY_UNSHIFTED_INSTRUCTION = 89 , // <Nullary_Unshifted_Instruction>
        SYMBOL_OPERABLE_MEMORY               = 90 , // <Operable_Memory>
        SYMBOL_OPERATOR                      = 91 , // <Operator>
        SYMBOL_P_EXCHANGE_S                  = 92 , // <P_Exchange_S>
        SYMBOL_PAUSE                         = 93 , // <Pause>
        SYMBOL_PERCENT                       = 94 , // <Percent>
        SYMBOL_PERCENT_CHANGE                = 95 , // <Percent_Change>
        SYMBOL_PI                            = 96 , // <Pi>
        SYMBOL_R_DOWN                        = 97 , // <R_Down>
        SYMBOL_R_UP                          = 98 , // <R_Up>
        SYMBOL_RAD                           = 99 , // <Rad>
        SYMBOL_RC_I                          = 100, // <Rc_I>
        SYMBOL_RCL_SIGMA_PLUS                = 101, // <Rcl_Sigma_Plus>
        SYMBOL_RECIPROCAL                    = 102, // <Reciprocal>
        SYMBOL_REG                           = 103, // <Reg>
        SYMBOL_RND                           = 104, // <Rnd>
        SYMBOL_RTN                           = 105, // <Rtn>
        SYMBOL_S                             = 106, // <S>
        SYMBOL_SCI                           = 107, // <Sci>
        SYMBOL_SF                            = 108, // <SF>
        SYMBOL_SHORTCUT                      = 109, // <Shortcut>
        SYMBOL_SIGMA_MINUS                   = 110, // <Sigma_Minus>
        SYMBOL_SIN                           = 111, // <Sin>
        SYMBOL_SPACE                         = 112, // <Space>
        SYMBOL_SQRT                          = 113, // <Sqrt>
        SYMBOL_SQUARE                        = 114, // <Square>
        SYMBOL_ST_I                          = 115, // <St_I>
        SYMBOL_STK                           = 116, // <Stk>
        SYMBOL_TAN                           = 117, // <Tan>
        SYMBOL_TEN_TO_THE_XTH                = 118, // <Ten_To_The_Xth>
        SYMBOL_TERNARY_UNSHIFTED_INSTRUCTION = 119, // <Ternary_Unshifted_Instruction>
        SYMBOL_TO_DEGREES                    = 120, // <To_Degrees>
        SYMBOL_TO_HMS                        = 121, // <To_HMS>
        SYMBOL_TO_HOURS                      = 122, // <To_Hours>
        SYMBOL_TO_POLAR                      = 123, // <To_Polar>
        SYMBOL_TO_RADIANS                    = 124, // <To_Radians>
        SYMBOL_TO_RECTANGULAR                = 125, // <To_Rectangular>
        SYMBOL_UNARY_F_SHIFTED_INSTRUCTION   = 126, // <Unary_F_Shifted_Instruction>
        SYMBOL_UNARY_G_SHIFTED_INSTRUCTION   = 127, // <Unary_G_Shifted_Instruction>
        SYMBOL_UNARY_UNSHIFTED_INSTRUCTION   = 128, // <Unary_Unshifted_Instruction>
        SYMBOL_UNSHIFTED_INSTRUCTION         = 129, // <Unshifted_Instruction>
        SYMBOL_UNSHIFTED_SHORTCUT            = 130, // <Unshifted_Shortcut>
        SYMBOL_W_DATA                        = 131, // <W_Data>
        SYMBOL_X_AVERAGE                     = 132, // <X_Average>
        SYMBOL_X_EQ_0                        = 133, // <X_EQ_0>
        SYMBOL_X_EQ_Y                        = 134, // <X_EQ_Y>
        SYMBOL_X_EXCHANGE_I                  = 135, // <X_Exchange_I>
        SYMBOL_X_EXCHANGE_Y                  = 136, // <X_Exchange_Y>
        SYMBOL_X_GT_0                        = 137, // <X_GT_0>
        SYMBOL_X_GT_Y                        = 138, // <X_GT_Y>
        SYMBOL_X_LE_Y                        = 139, // <X_LE_Y>
        SYMBOL_X_LT_0                        = 140, // <X_LT_0>
        SYMBOL_X_NE_0                        = 141, // <X_NE_0>
        SYMBOL_X_NE_Y                        = 142, // <X_NE_Y>
        SYMBOL_Y_TO_THE_XTH                  = 143  // <Y_To_The_Xth>
    };

    enum RuleConstants : int
    {
        RULE_X_AVERAGE_SIGMA_PLUS                         = 0  , // <X_Average> ::= 'Sigma_Plus'
        RULE_GSB_GTO                                      = 1  , // <Gsb> ::= Gto
        RULE_FIX_DSP                                      = 2  , // <Fix> ::= Dsp
        RULE_RND_SUB_I                                    = 3  , // <Rnd> ::= 'Sub_I'
        RULE_LBL_SST                                      = 4  , // <Lbl> ::= Sst
        RULE_DSZ_STO                                      = 5  , // <Dsz> ::= Sto
        RULE_ISZ_RCL                                      = 6  , // <Isz> ::= Rcl
        RULE_W_DATA_ENTER                                 = 7  , // <W_Data> ::= Enter
        RULE_P_EXCHANGE_S_CHS                             = 8  , // <P_Exchange_S> ::= Chs
        RULE_CL_REG_EEX                                   = 9  , // <Cl_Reg> ::= Eex
        RULE_CL_PRGM_CLX                                  = 10 , // <Cl_Prgm> ::= Clx
        RULE_X_EQ_0_SUBTRACTION                           = 11 , // <X_EQ_0> ::= Subtraction
        RULE_LN_SEVEN                                     = 12 , // <Ln> ::= Seven
        RULE_LOG_EIGHT                                    = 13 , // <Log> ::= Eight
        RULE_SQRT_NINE                                    = 14 , // <Sqrt> ::= Nine
        RULE_X_NE_0_ADDITION                              = 15 , // <X_NE_0> ::= Addition
        RULE_SIN_FOUR                                     = 16 , // <Sin> ::= Four
        RULE_COS_FIVE                                     = 17 , // <Cos> ::= Five
        RULE_TAN_SIX                                      = 18 , // <Tan> ::= Six
        RULE_X_LT_0_MULTIPLICATION                        = 19 , // <X_LT_0> ::= Multiplication
        RULE_TO_RECTANGULAR_ONE                           = 20 , // <To_Rectangular> ::= One
        RULE_TO_DEGREES_TWO                               = 21 , // <To_Degrees> ::= Two
        RULE_TO_HOURS_THREE                               = 22 , // <To_Hours> ::= Three
        RULE_X_GT_0_DIVISION                              = 23 , // <X_GT_0> ::= Division
        RULE_PERCENT_ZERO                                 = 24 , // <Percent> ::= Zero
        RULE_INT_PERIOD                                   = 25 , // <Int> ::= Period
        RULE_DISPLAY_X_R_S                                = 26 , // <Display_X> ::= 'R_S'
        RULE_S_SIGMA_PLUS                                 = 27 , // <S> ::= 'Sigma_Plus'
        RULE_GSB_F_GTO                                    = 28 , // <Gsb_f> ::= Gto
        RULE_SCI_DSP                                      = 29 , // <Sci> ::= Dsp
        RULE_LBL_F_SST                                    = 30 , // <Lbl_f> ::= Sst
        RULE_DSZ_SUB_I_STO                                = 31 , // <Dsz_Sub_I> ::= Sto
        RULE_ISZ_SUB_I_RCL                                = 32 , // <Isz_Sub_I> ::= Rcl
        RULE_MERGE_ENTER                                  = 33 , // <Merge> ::= Enter
        RULE_X_EQ_Y_SUBTRACTION                           = 34 , // <X_EQ_Y> ::= Subtraction
        RULE_EXP_SEVEN                                    = 35 , // <Exp> ::= Seven
        RULE_TEN_TO_THE_XTH_EIGHT                         = 36 , // <Ten_To_The_Xth> ::= Eight
        RULE_SQUARE_NINE                                  = 37 , // <Square> ::= Nine
        RULE_X_NE_Y_ADDITION                              = 38 , // <X_NE_Y> ::= Addition
        RULE_ARCSIN_FOUR                                  = 39 , // <Arcsin> ::= Four
        RULE_ARCCOS_FIVE                                  = 40 , // <Arccos> ::= Five
        RULE_ARCTAN_SIX                                   = 41 , // <Arctan> ::= Six
        RULE_X_LE_Y_MULTIPLICATION                        = 42 , // <X_LE_Y> ::= Multiplication
        RULE_TO_POLAR_ONE                                 = 43 , // <To_Polar> ::= One
        RULE_TO_RADIANS_TWO                               = 44 , // <To_Radians> ::= Two
        RULE_TO_HMS_THREE                                 = 45 , // <To_HMS> ::= Three
        RULE_X_GT_Y_DIVISION                              = 46 , // <X_GT_Y> ::= Division
        RULE_PERCENT_CHANGE_ZERO                          = 47 , // <Percent_Change> ::= Zero
        RULE_FRAC_PERIOD                                  = 48 , // <Frac> ::= Period
        RULE_STK_R_S                                      = 49 , // <Stk> ::= 'R_S'
        RULE_SIGMA_MINUS_SIGMA_PLUS                       = 50 , // <Sigma_Minus> ::= 'Sigma_Plus'
        RULE_RTN_GTO                                      = 51 , // <Rtn> ::= Gto
        RULE_ENG_DSP                                      = 52 , // <Eng> ::= Dsp
        RULE_X_EXCHANGE_I_SUB_I                           = 53 , // <X_Exchange_I> ::= 'Sub_I'
        RULE_BST_SST                                      = 54 , // <Bst> ::= Sst
        RULE_ST_I_STO                                     = 55 , // <St_I> ::= Sto
        RULE_RC_I_RCL                                     = 56 , // <Rc_I> ::= Rcl
        RULE_DEG_ENTER                                    = 57 , // <Deg> ::= Enter
        RULE_RAD_CHS                                      = 58 , // <Rad> ::= Chs
        RULE_GRD_EEX                                      = 59 , // <Grd> ::= Eex
        RULE_DEL_CLX                                      = 60 , // <Del> ::= Clx
        RULE_SF_SUBTRACTION                               = 61 , // <SF> ::= Subtraction
        RULE_X_EXCHANGE_Y_SEVEN                           = 62 , // <X_Exchange_Y> ::= Seven
        RULE_R_DOWN_EIGHT                                 = 63 , // <R_Down> ::= Eight
        RULE_R_UP_NINE                                    = 64 , // <R_Up> ::= Nine
        RULE_CF_ADDITION                                  = 65 , // <CF> ::= Addition
        RULE_RECIPROCAL_FOUR                              = 66 , // <Reciprocal> ::= Four
        RULE_Y_TO_THE_XTH_FIVE                            = 67 , // <Y_To_The_Xth> ::= Five
        RULE_ABS_SIX                                      = 68 , // <Abs> ::= Six
        RULE_F_TEST_MULTIPLICATION                        = 69 , // <F_Test> ::= Multiplication
        RULE_PAUSE_ONE                                    = 70 , // <Pause> ::= One
        RULE_PI_TWO                                       = 71 , // <Pi> ::= Two
        RULE_REG_THREE                                    = 72 , // <Reg> ::= Three
        RULE_FACTORIAL_DIVISION                           = 73 , // <Factorial> ::= Division
        RULE_LST_X_ZERO                                   = 74 , // <Lst_X> ::= Zero
        RULE_HMS_PLUS_PERIOD                              = 75 , // <HMS_Plus> ::= Period
        RULE_SPACE_R_S                                    = 76 , // <Space> ::= 'R_S'
        RULE_INSTRUCTION                                  = 77 , // <Instruction> ::= <Shortcut>
        RULE_INSTRUCTION2                                 = 78 , // <Instruction> ::= <Unshifted_Instruction>
        RULE_INSTRUCTION3                                 = 79 , // <Instruction> ::= <F_Shifted_Instruction>
        RULE_INSTRUCTION4                                 = 80 , // <Instruction> ::= <G_Shifted_Instruction>
        RULE_INSTRUCTION5                                 = 81 , // <Instruction> ::= <H_Shifted_Instruction>
        RULE_SHORTCUT                                     = 82 , // <Shortcut> ::= <Unshifted_Shortcut>
        RULE_SHORTCUT2                                    = 83 , // <Shortcut> ::= <F_Shifted_Shortcut>
        RULE_UNSHIFTED_SHORTCUT                           = 84 , // <Unshifted_Shortcut> ::= <Gsb_Shortcut>
        RULE_UNSHIFTED_SHORTCUT2                          = 85 , // <Unshifted_Shortcut> ::= <Memory_Shortcut>
        RULE_F_SHIFTED_SHORTCUT_F                         = 86 , // <F_Shifted_Shortcut> ::= f <Gsb_Shortcut>
        RULE_GSB_SHORTCUT                                 = 87 , // <Gsb_Shortcut> ::= <Letter>
        RULE_MEMORY_SHORTCUT_SUB_I                        = 88 , // <Memory_Shortcut> ::= 'Sub_I'
        RULE_UNSHIFTED_INSTRUCTION                        = 89 , // <Unshifted_Instruction> ::= <Nullary_Unshifted_Instruction>
        RULE_UNSHIFTED_INSTRUCTION2                       = 90 , // <Unshifted_Instruction> ::= <Unary_Unshifted_Instruction>
        RULE_UNSHIFTED_INSTRUCTION3                       = 91 , // <Unshifted_Instruction> ::= <Binary_Unshifted_Instruction>
        RULE_F_SHIFTED_INSTRUCTION_F                      = 92 , // <F_Shifted_Instruction> ::= f <Nullary_F_Shifted_Instruction>
        RULE_F_SHIFTED_INSTRUCTION_F2                     = 93 , // <F_Shifted_Instruction> ::= f <Unary_F_Shifted_Instruction>
        RULE_G_SHIFTED_INSTRUCTION_G                      = 94 , // <G_Shifted_Instruction> ::= g <Nullary_G_Shifted_Instruction>
        RULE_G_SHIFTED_INSTRUCTION_G2                     = 95 , // <G_Shifted_Instruction> ::= g <Unary_G_Shifted_Instruction>
        RULE_H_SHIFTED_INSTRUCTION_H                      = 96 , // <H_Shifted_Instruction> ::= h <Nullary_H_Shifted_Instruction>
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS     = 97 , // <Nullary_Unshifted_Instruction> ::= 'Sigma_Plus'
        RULE_NULLARY_UNSHIFTED_INSTRUCTION                = 98 , // <Nullary_Unshifted_Instruction> ::= <Rcl_Sigma_Plus>
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_SST            = 99 , // <Nullary_Unshifted_Instruction> ::= Sst
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER          = 100, // <Nullary_Unshifted_Instruction> ::= Enter
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS            = 101, // <Nullary_Unshifted_Instruction> ::= Chs
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX            = 102, // <Nullary_Unshifted_Instruction> ::= Eex
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX            = 103, // <Nullary_Unshifted_Instruction> ::= Clx
        RULE_NULLARY_UNSHIFTED_INSTRUCTION2               = 104, // <Nullary_Unshifted_Instruction> ::= <Digit>
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION    = 105, // <Nullary_Unshifted_Instruction> ::= Subtraction
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION       = 106, // <Nullary_Unshifted_Instruction> ::= Addition
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION = 107, // <Nullary_Unshifted_Instruction> ::= Multiplication
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION       = 108, // <Nullary_Unshifted_Instruction> ::= Division
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD         = 109, // <Nullary_Unshifted_Instruction> ::= Period
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S            = 110, // <Nullary_Unshifted_Instruction> ::= 'R_S'
        RULE_UNARY_UNSHIFTED_INSTRUCTION_GTO              = 111, // <Unary_Unshifted_Instruction> ::= Gto <Label>
        RULE_UNARY_UNSHIFTED_INSTRUCTION_DSP              = 112, // <Unary_Unshifted_Instruction> ::= Dsp <Digit_Count>
        RULE_UNARY_UNSHIFTED_INSTRUCTION_STO              = 113, // <Unary_Unshifted_Instruction> ::= Sto <Memory>
        RULE_UNARY_UNSHIFTED_INSTRUCTION_RCL              = 114, // <Unary_Unshifted_Instruction> ::= Rcl <Memory>
        RULE_BINARY_UNSHIFTED_INSTRUCTION_STO             = 115, // <Binary_Unshifted_Instruction> ::= Sto <Operator> <Operable_Memory>
        RULE_TERNARY_UNSHIFTED_INSTRUCTION_GTO_PERIOD     = 116, // <Ternary_Unshifted_Instruction> ::= Gto Period <Digit> <Digit> <Digit>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION                = 117, // <Nullary_F_Shifted_Instruction> ::= <X_Average>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION2               = 118, // <Nullary_F_Shifted_Instruction> ::= <Fix>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION3               = 119, // <Nullary_F_Shifted_Instruction> ::= <Rnd>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION4               = 120, // <Nullary_F_Shifted_Instruction> ::= <Dsz>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION5               = 121, // <Nullary_F_Shifted_Instruction> ::= <Isz>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION6               = 122, // <Nullary_F_Shifted_Instruction> ::= <W_Data>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION7               = 123, // <Nullary_F_Shifted_Instruction> ::= <P_Exchange_S>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION8               = 124, // <Nullary_F_Shifted_Instruction> ::= <Cl_Reg>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION9               = 125, // <Nullary_F_Shifted_Instruction> ::= <Cl_Prgm>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION10              = 126, // <Nullary_F_Shifted_Instruction> ::= <X_EQ_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION11              = 127, // <Nullary_F_Shifted_Instruction> ::= <Ln>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION12              = 128, // <Nullary_F_Shifted_Instruction> ::= <Log>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION13              = 129, // <Nullary_F_Shifted_Instruction> ::= <Sqrt>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION14              = 130, // <Nullary_F_Shifted_Instruction> ::= <X_NE_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION15              = 131, // <Nullary_F_Shifted_Instruction> ::= <Sin>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION16              = 132, // <Nullary_F_Shifted_Instruction> ::= <Cos>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION17              = 133, // <Nullary_F_Shifted_Instruction> ::= <Tan>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION18              = 134, // <Nullary_F_Shifted_Instruction> ::= <X_LT_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION19              = 135, // <Nullary_F_Shifted_Instruction> ::= <To_Rectangular>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION20              = 136, // <Nullary_F_Shifted_Instruction> ::= <To_Degrees>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION21              = 137, // <Nullary_F_Shifted_Instruction> ::= <To_Hours>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION22              = 138, // <Nullary_F_Shifted_Instruction> ::= <X_GT_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION23              = 139, // <Nullary_F_Shifted_Instruction> ::= <Percent>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION24              = 140, // <Nullary_F_Shifted_Instruction> ::= <Int>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION25              = 141, // <Nullary_F_Shifted_Instruction> ::= <Display_X>
        RULE_UNARY_F_SHIFTED_INSTRUCTION                  = 142, // <Unary_F_Shifted_Instruction> ::= <Gsb> <Label>
        RULE_UNARY_F_SHIFTED_INSTRUCTION2                 = 143, // <Unary_F_Shifted_Instruction> ::= <Lbl> <Label>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION                = 144, // <Nullary_G_Shifted_Instruction> ::= <S>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION2               = 145, // <Nullary_G_Shifted_Instruction> ::= <Sci>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION3               = 146, // <Nullary_G_Shifted_Instruction> ::= <Dsz_Sub_I>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION4               = 147, // <Nullary_G_Shifted_Instruction> ::= <Isz_Sub_I>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION5               = 148, // <Nullary_G_Shifted_Instruction> ::= <Merge>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION6               = 149, // <Nullary_G_Shifted_Instruction> ::= <X_EQ_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION7               = 150, // <Nullary_G_Shifted_Instruction> ::= <Exp>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION8               = 151, // <Nullary_G_Shifted_Instruction> ::= <Ten_To_The_Xth>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION9               = 152, // <Nullary_G_Shifted_Instruction> ::= <Square>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION10              = 153, // <Nullary_G_Shifted_Instruction> ::= <X_NE_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION11              = 154, // <Nullary_G_Shifted_Instruction> ::= <Arcsin>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION12              = 155, // <Nullary_G_Shifted_Instruction> ::= <Arccos>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION13              = 156, // <Nullary_G_Shifted_Instruction> ::= <Arctan>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION14              = 157, // <Nullary_G_Shifted_Instruction> ::= <X_LE_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION15              = 158, // <Nullary_G_Shifted_Instruction> ::= <To_Polar>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION16              = 159, // <Nullary_G_Shifted_Instruction> ::= <To_Radians>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION17              = 160, // <Nullary_G_Shifted_Instruction> ::= <To_HMS>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION18              = 161, // <Nullary_G_Shifted_Instruction> ::= <X_GT_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION19              = 162, // <Nullary_G_Shifted_Instruction> ::= <Percent_Change>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION20              = 163, // <Nullary_G_Shifted_Instruction> ::= <Frac>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION21              = 164, // <Nullary_G_Shifted_Instruction> ::= <Stk>
        RULE_UNARY_G_SHIFTED_INSTRUCTION                  = 165, // <Unary_G_Shifted_Instruction> ::= <Gsb_f> <Letter_Label>
        RULE_UNARY_G_SHIFTED_INSTRUCTION2                 = 166, // <Unary_G_Shifted_Instruction> ::= <Lbl_f> <Letter_Label>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION                = 167, // <Nullary_H_Shifted_Instruction> ::= <Sigma_Minus>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION2               = 168, // <Nullary_H_Shifted_Instruction> ::= <Rtn>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION3               = 169, // <Nullary_H_Shifted_Instruction> ::= <Eng>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION4               = 170, // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_I>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION5               = 171, // <Nullary_H_Shifted_Instruction> ::= <Bst>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION6               = 172, // <Nullary_H_Shifted_Instruction> ::= <St_I>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION7               = 173, // <Nullary_H_Shifted_Instruction> ::= <Rc_I>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION8               = 174, // <Nullary_H_Shifted_Instruction> ::= <Deg>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION9               = 175, // <Nullary_H_Shifted_Instruction> ::= <Rad>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION10              = 176, // <Nullary_H_Shifted_Instruction> ::= <Grd>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION11              = 177, // <Nullary_H_Shifted_Instruction> ::= <Del>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION12              = 178, // <Nullary_H_Shifted_Instruction> ::= <SF>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION13              = 179, // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_Y>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION14              = 180, // <Nullary_H_Shifted_Instruction> ::= <R_Down>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION15              = 181, // <Nullary_H_Shifted_Instruction> ::= <R_Up>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION16              = 182, // <Nullary_H_Shifted_Instruction> ::= <CF>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION17              = 183, // <Nullary_H_Shifted_Instruction> ::= <Reciprocal>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION18              = 184, // <Nullary_H_Shifted_Instruction> ::= <Y_To_The_Xth>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION19              = 185, // <Nullary_H_Shifted_Instruction> ::= <Abs>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION20              = 186, // <Nullary_H_Shifted_Instruction> ::= <F_Test>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION21              = 187, // <Nullary_H_Shifted_Instruction> ::= <Pause>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION22              = 188, // <Nullary_H_Shifted_Instruction> ::= <Pi>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION23              = 189, // <Nullary_H_Shifted_Instruction> ::= <Reg>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION24              = 190, // <Nullary_H_Shifted_Instruction> ::= <Factorial>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION25              = 191, // <Nullary_H_Shifted_Instruction> ::= <Lst_X>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION26              = 192, // <Nullary_H_Shifted_Instruction> ::= <HMS_Plus>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION27              = 193, // <Nullary_H_Shifted_Instruction> ::= <Space>
        RULE_RCL_SIGMA_PLUS_RCL_SIGMA_PLUS                = 194, // <Rcl_Sigma_Plus> ::= Rcl 'Sigma_Plus'
        RULE_OPERATOR_SUBTRACTION                         = 195, // <Operator> ::= Subtraction
        RULE_OPERATOR_ADDITION                            = 196, // <Operator> ::= Addition
        RULE_OPERATOR_MULTIPLICATION                      = 197, // <Operator> ::= Multiplication
        RULE_OPERATOR_DIVISION                            = 198, // <Operator> ::= Division
        RULE_DIGIT_ZERO                                   = 199, // <Digit> ::= Zero
        RULE_DIGIT_ONE                                    = 200, // <Digit> ::= One
        RULE_DIGIT_TWO                                    = 201, // <Digit> ::= Two
        RULE_DIGIT_THREE                                  = 202, // <Digit> ::= Three
        RULE_DIGIT_FOUR                                   = 203, // <Digit> ::= Four
        RULE_DIGIT_FIVE                                   = 204, // <Digit> ::= Five
        RULE_DIGIT_SIX                                    = 205, // <Digit> ::= Six
        RULE_DIGIT_SEVEN                                  = 206, // <Digit> ::= Seven
        RULE_DIGIT_EIGHT                                  = 207, // <Digit> ::= Eight
        RULE_DIGIT_NINE                                   = 208, // <Digit> ::= Nine
        RULE_DIGIT_COUNT                                  = 209, // <Digit_Count> ::= <Digit>
        RULE_DIGIT_COUNT_SUB_I                            = 210, // <Digit_Count> ::= 'Sub_I'
        RULE_LETTER_A                                     = 211, // <Letter> ::= A
        RULE_LETTER_B                                     = 212, // <Letter> ::= B
        RULE_LETTER_C                                     = 213, // <Letter> ::= C
        RULE_LETTER_D                                     = 214, // <Letter> ::= D
        RULE_LETTER_E                                     = 215, // <Letter> ::= E
        RULE_LETTER_LABEL                                 = 216, // <Letter_Label> ::= <Letter>
        RULE_DIGIT_LABEL                                  = 217, // <Digit_Label> ::= <Digit>
        RULE_LABEL                                        = 218, // <Label> ::= <Digit_Label>
        RULE_LABEL2                                       = 219, // <Label> ::= <Letter_Label>
        RULE_LABEL_SUB_I                                  = 220, // <Label> ::= 'Sub_I'
        RULE_OPERABLE_MEMORY                              = 221, // <Operable_Memory> ::= <Digit>
        RULE_OPERABLE_MEMORY_SUB_I                        = 222, // <Operable_Memory> ::= 'Sub_I'
        RULE_MEMORY                                       = 223, // <Memory> ::= <Operable_Memory>
        RULE_MEMORY2                                      = 224  // <Memory> ::= <Letter>
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
        
        void ReduceRULE_X_AVERAGE_SIGMA_PLUS (string input, Token token, Token [] tokens);
        void ReduceRULE_GSB_GTO (string input, Token token, Token [] tokens);
        void ReduceRULE_FIX_DSP (string input, Token token, Token [] tokens);
        void ReduceRULE_RND_SUB_I (string input, Token token, Token [] tokens);
        void ReduceRULE_LBL_SST (string input, Token token, Token [] tokens);
        void ReduceRULE_DSZ_STO (string input, Token token, Token [] tokens);
        void ReduceRULE_ISZ_RCL (string input, Token token, Token [] tokens);
        void ReduceRULE_W_DATA_ENTER (string input, Token token, Token [] tokens);
        void ReduceRULE_P_EXCHANGE_S_CHS (string input, Token token, Token [] tokens);
        void ReduceRULE_CL_REG_EEX (string input, Token token, Token [] tokens);
        void ReduceRULE_CL_PRGM_CLX (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EQ_0_SUBTRACTION (string input, Token token, Token [] tokens);
        void ReduceRULE_LN_SEVEN (string input, Token token, Token [] tokens);
        void ReduceRULE_LOG_EIGHT (string input, Token token, Token [] tokens);
        void ReduceRULE_SQRT_NINE (string input, Token token, Token [] tokens);
        void ReduceRULE_X_NE_0_ADDITION (string input, Token token, Token [] tokens);
        void ReduceRULE_SIN_FOUR (string input, Token token, Token [] tokens);
        void ReduceRULE_COS_FIVE (string input, Token token, Token [] tokens);
        void ReduceRULE_TAN_SIX (string input, Token token, Token [] tokens);
        void ReduceRULE_X_LT_0_MULTIPLICATION (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_RECTANGULAR_ONE (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_DEGREES_TWO (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_HOURS_THREE (string input, Token token, Token [] tokens);
        void ReduceRULE_X_GT_0_DIVISION (string input, Token token, Token [] tokens);
        void ReduceRULE_PERCENT_ZERO (string input, Token token, Token [] tokens);
        void ReduceRULE_INT_PERIOD (string input, Token token, Token [] tokens);
        void ReduceRULE_DISPLAY_X_R_S (string input, Token token, Token [] tokens);
        void ReduceRULE_S_SIGMA_PLUS (string input, Token token, Token [] tokens);
        void ReduceRULE_GSB_F_GTO (string input, Token token, Token [] tokens);
        void ReduceRULE_SCI_DSP (string input, Token token, Token [] tokens);
        void ReduceRULE_LBL_F_SST (string input, Token token, Token [] tokens);
        void ReduceRULE_DSZ_SUB_I_STO (string input, Token token, Token [] tokens);
        void ReduceRULE_ISZ_SUB_I_RCL (string input, Token token, Token [] tokens);
        void ReduceRULE_MERGE_ENTER (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EQ_Y_SUBTRACTION (string input, Token token, Token [] tokens);
        void ReduceRULE_EXP_SEVEN (string input, Token token, Token [] tokens);
        void ReduceRULE_TEN_TO_THE_XTH_EIGHT (string input, Token token, Token [] tokens);
        void ReduceRULE_SQUARE_NINE (string input, Token token, Token [] tokens);
        void ReduceRULE_X_NE_Y_ADDITION (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCSIN_FOUR (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCCOS_FIVE (string input, Token token, Token [] tokens);
        void ReduceRULE_ARCTAN_SIX (string input, Token token, Token [] tokens);
        void ReduceRULE_X_LE_Y_MULTIPLICATION (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_POLAR_ONE (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_RADIANS_TWO (string input, Token token, Token [] tokens);
        void ReduceRULE_TO_HMS_THREE (string input, Token token, Token [] tokens);
        void ReduceRULE_X_GT_Y_DIVISION (string input, Token token, Token [] tokens);
        void ReduceRULE_PERCENT_CHANGE_ZERO (string input, Token token, Token [] tokens);
        void ReduceRULE_FRAC_PERIOD (string input, Token token, Token [] tokens);
        void ReduceRULE_STK_R_S (string input, Token token, Token [] tokens);
        void ReduceRULE_SIGMA_MINUS_SIGMA_PLUS (string input, Token token, Token [] tokens);
        void ReduceRULE_RTN_GTO (string input, Token token, Token [] tokens);
        void ReduceRULE_ENG_DSP (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EXCHANGE_I_SUB_I (string input, Token token, Token [] tokens);
        void ReduceRULE_BST_SST (string input, Token token, Token [] tokens);
        void ReduceRULE_ST_I_STO (string input, Token token, Token [] tokens);
        void ReduceRULE_RC_I_RCL (string input, Token token, Token [] tokens);
        void ReduceRULE_DEG_ENTER (string input, Token token, Token [] tokens);
        void ReduceRULE_RAD_CHS (string input, Token token, Token [] tokens);
        void ReduceRULE_GRD_EEX (string input, Token token, Token [] tokens);
        void ReduceRULE_DEL_CLX (string input, Token token, Token [] tokens);
        void ReduceRULE_SF_SUBTRACTION (string input, Token token, Token [] tokens);
        void ReduceRULE_X_EXCHANGE_Y_SEVEN (string input, Token token, Token [] tokens);
        void ReduceRULE_R_DOWN_EIGHT (string input, Token token, Token [] tokens);
        void ReduceRULE_R_UP_NINE (string input, Token token, Token [] tokens);
        void ReduceRULE_CF_ADDITION (string input, Token token, Token [] tokens);
        void ReduceRULE_RECIPROCAL_FOUR (string input, Token token, Token [] tokens);
        void ReduceRULE_Y_TO_THE_XTH_FIVE (string input, Token token, Token [] tokens);
        void ReduceRULE_ABS_SIX (string input, Token token, Token [] tokens);
        void ReduceRULE_F_TEST_MULTIPLICATION (string input, Token token, Token [] tokens);
        void ReduceRULE_PAUSE_ONE (string input, Token token, Token [] tokens);
        void ReduceRULE_PI_TWO (string input, Token token, Token [] tokens);
        void ReduceRULE_REG_THREE (string input, Token token, Token [] tokens);
        void ReduceRULE_FACTORIAL_DIVISION (string input, Token token, Token [] tokens);
        void ReduceRULE_LST_X_ZERO (string input, Token token, Token [] tokens);
        void ReduceRULE_HMS_PLUS_PERIOD (string input, Token token, Token [] tokens);
        void ReduceRULE_SPACE_R_S (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION4 (string input, Token token, Token [] tokens);
        void ReduceRULE_INSTRUCTION5 (string input, Token token, Token [] tokens);
        void ReduceRULE_SHORTCUT (string input, Token token, Token [] tokens);
        void ReduceRULE_SHORTCUT2 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNSHIFTED_SHORTCUT (string input, Token token, Token [] tokens);
        void ReduceRULE_UNSHIFTED_SHORTCUT2 (string input, Token token, Token [] tokens);
        void ReduceRULE_F_SHIFTED_SHORTCUT_F (string input, Token token, Token [] tokens);
        void ReduceRULE_GSB_SHORTCUT (string input, Token token, Token [] tokens);
        void ReduceRULE_MEMORY_SHORTCUT_SUB_I (string input, Token token, Token [] tokens);
        void ReduceRULE_UNSHIFTED_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_UNSHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNSHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_F_SHIFTED_INSTRUCTION_F (string input, Token token, Token [] tokens);
        void ReduceRULE_F_SHIFTED_INSTRUCTION_F2 (string input, Token token, Token [] tokens);
        void ReduceRULE_G_SHIFTED_INSTRUCTION_G (string input, Token token, Token [] tokens);
        void ReduceRULE_G_SHIFTED_INSTRUCTION_G2 (string input, Token token, Token [] tokens);
        void ReduceRULE_H_SHIFTED_INSTRUCTION_H (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SST (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_GTO (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_DSP (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_STO (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_RCL (string input, Token token, Token [] tokens);
        void ReduceRULE_BINARY_UNSHIFTED_INSTRUCTION_STO (string input, Token token, Token [] tokens);
        void ReduceRULE_TERNARY_UNSHIFTED_INSTRUCTION_GTO_PERIOD (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION4 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION5 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION6 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION7 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION8 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION9 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION10 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION11 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION12 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION13 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION14 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION15 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION16 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION17 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION18 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION19 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION20 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION21 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION22 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION23 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION24 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION25 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION4 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION5 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION6 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION7 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION8 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION9 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION10 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION11 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION12 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION13 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION14 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION15 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION16 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION17 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION18 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION19 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION20 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION21 (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION2 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION3 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION4 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION5 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION6 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION7 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION8 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION9 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION10 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION11 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION12 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION13 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION14 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION15 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION16 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION17 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION18 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION19 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION20 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION21 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION22 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION23 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION24 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION25 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION26 (string input, Token token, Token [] tokens);
        void ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION27 (string input, Token token, Token [] tokens);
        void ReduceRULE_RCL_SIGMA_PLUS_RCL_SIGMA_PLUS (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR_SUBTRACTION (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR_ADDITION (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR_MULTIPLICATION (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERATOR_DIVISION (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_ZERO (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_ONE (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_TWO (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_THREE (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_FOUR (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_FIVE (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_SIX (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_SEVEN (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_EIGHT (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_NINE (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_COUNT (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_COUNT_SUB_I (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_A (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_B (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_C (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_D (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_E (string input, Token token, Token [] tokens);
        void ReduceRULE_LETTER_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_DIGIT_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_LABEL (string input, Token token, Token [] tokens);
        void ReduceRULE_LABEL2 (string input, Token token, Token [] tokens);
        void ReduceRULE_LABEL_SUB_I (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERABLE_MEMORY (string input, Token token, Token [] tokens);
        void ReduceRULE_OPERABLE_MEMORY_SUB_I (string input, Token token, Token [] tokens);
        void ReduceRULE_MEMORY (string input, Token token, Token [] tokens);
        void ReduceRULE_MEMORY2 (string input, Token token, Token [] tokens);
    }

    public class Parser
    {
		private static TraceSwitch classTraceSwitch = 
			new TraceSwitch ("HP67_Parser.Parser", "Automatically generated parser");

        private IActions actions;
        private LALRParser parser;
        private string input;

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
            
            switch (args.Token.Rule.Id)
            {
                case (int)RuleConstants.RULE_X_AVERAGE_SIGMA_PLUS :
                    // <X_Average> ::= 'Sigma_Plus'
                    actions.ReduceRULE_X_AVERAGE_SIGMA_PLUS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GSB_GTO :
                    // <Gsb> ::= Gto
                    actions.ReduceRULE_GSB_GTO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_FIX_DSP :
                    // <Fix> ::= Dsp
                    actions.ReduceRULE_FIX_DSP (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RND_SUB_I :
                    // <Rnd> ::= 'Sub_I'
                    actions.ReduceRULE_RND_SUB_I (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LBL_SST :
                    // <Lbl> ::= Sst
                    actions.ReduceRULE_LBL_SST (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DSZ_STO :
                    // <Dsz> ::= Sto
                    actions.ReduceRULE_DSZ_STO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ISZ_RCL :
                    // <Isz> ::= Rcl
                    actions.ReduceRULE_ISZ_RCL (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_W_DATA_ENTER :
                    // <W_Data> ::= Enter
                    actions.ReduceRULE_W_DATA_ENTER (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_P_EXCHANGE_S_CHS :
                    // <P_Exchange_S> ::= Chs
                    actions.ReduceRULE_P_EXCHANGE_S_CHS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_CL_REG_EEX :
                    // <Cl_Reg> ::= Eex
                    actions.ReduceRULE_CL_REG_EEX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_CL_PRGM_CLX :
                    // <Cl_Prgm> ::= Clx
                    actions.ReduceRULE_CL_PRGM_CLX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EQ_0_SUBTRACTION :
                    // <X_EQ_0> ::= Subtraction
                    actions.ReduceRULE_X_EQ_0_SUBTRACTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LN_SEVEN :
                    // <Ln> ::= Seven
                    actions.ReduceRULE_LN_SEVEN (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LOG_EIGHT :
                    // <Log> ::= Eight
                    actions.ReduceRULE_LOG_EIGHT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SQRT_NINE :
                    // <Sqrt> ::= Nine
                    actions.ReduceRULE_SQRT_NINE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_NE_0_ADDITION :
                    // <X_NE_0> ::= Addition
                    actions.ReduceRULE_X_NE_0_ADDITION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SIN_FOUR :
                    // <Sin> ::= Four
                    actions.ReduceRULE_SIN_FOUR (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_COS_FIVE :
                    // <Cos> ::= Five
                    actions.ReduceRULE_COS_FIVE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TAN_SIX :
                    // <Tan> ::= Six
                    actions.ReduceRULE_TAN_SIX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_LT_0_MULTIPLICATION :
                    // <X_LT_0> ::= Multiplication
                    actions.ReduceRULE_X_LT_0_MULTIPLICATION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_RECTANGULAR_ONE :
                    // <To_Rectangular> ::= One
                    actions.ReduceRULE_TO_RECTANGULAR_ONE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_DEGREES_TWO :
                    // <To_Degrees> ::= Two
                    actions.ReduceRULE_TO_DEGREES_TWO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_HOURS_THREE :
                    // <To_Hours> ::= Three
                    actions.ReduceRULE_TO_HOURS_THREE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_GT_0_DIVISION :
                    // <X_GT_0> ::= Division
                    actions.ReduceRULE_X_GT_0_DIVISION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PERCENT_ZERO :
                    // <Percent> ::= Zero
                    actions.ReduceRULE_PERCENT_ZERO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INT_PERIOD :
                    // <Int> ::= Period
                    actions.ReduceRULE_INT_PERIOD (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DISPLAY_X_R_S :
                    // <Display_X> ::= 'R_S'
                    actions.ReduceRULE_DISPLAY_X_R_S (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_S_SIGMA_PLUS :
                    // <S> ::= 'Sigma_Plus'
                    actions.ReduceRULE_S_SIGMA_PLUS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GSB_F_GTO :
                    // <Gsb_f> ::= Gto
                    actions.ReduceRULE_GSB_F_GTO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SCI_DSP :
                    // <Sci> ::= Dsp
                    actions.ReduceRULE_SCI_DSP (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LBL_F_SST :
                    // <Lbl_f> ::= Sst
                    actions.ReduceRULE_LBL_F_SST (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DSZ_SUB_I_STO :
                    // <Dsz_Sub_I> ::= Sto
                    actions.ReduceRULE_DSZ_SUB_I_STO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ISZ_SUB_I_RCL :
                    // <Isz_Sub_I> ::= Rcl
                    actions.ReduceRULE_ISZ_SUB_I_RCL (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MERGE_ENTER :
                    // <Merge> ::= Enter
                    actions.ReduceRULE_MERGE_ENTER (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EQ_Y_SUBTRACTION :
                    // <X_EQ_Y> ::= Subtraction
                    actions.ReduceRULE_X_EQ_Y_SUBTRACTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_EXP_SEVEN :
                    // <Exp> ::= Seven
                    actions.ReduceRULE_EXP_SEVEN (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TEN_TO_THE_XTH_EIGHT :
                    // <Ten_To_The_Xth> ::= Eight
                    actions.ReduceRULE_TEN_TO_THE_XTH_EIGHT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SQUARE_NINE :
                    // <Square> ::= Nine
                    actions.ReduceRULE_SQUARE_NINE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_NE_Y_ADDITION :
                    // <X_NE_Y> ::= Addition
                    actions.ReduceRULE_X_NE_Y_ADDITION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ARCSIN_FOUR :
                    // <Arcsin> ::= Four
                    actions.ReduceRULE_ARCSIN_FOUR (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ARCCOS_FIVE :
                    // <Arccos> ::= Five
                    actions.ReduceRULE_ARCCOS_FIVE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ARCTAN_SIX :
                    // <Arctan> ::= Six
                    actions.ReduceRULE_ARCTAN_SIX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_LE_Y_MULTIPLICATION :
                    // <X_LE_Y> ::= Multiplication
                    actions.ReduceRULE_X_LE_Y_MULTIPLICATION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_POLAR_ONE :
                    // <To_Polar> ::= One
                    actions.ReduceRULE_TO_POLAR_ONE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_RADIANS_TWO :
                    // <To_Radians> ::= Two
                    actions.ReduceRULE_TO_RADIANS_TWO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_HMS_THREE :
                    // <To_HMS> ::= Three
                    actions.ReduceRULE_TO_HMS_THREE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_GT_Y_DIVISION :
                    // <X_GT_Y> ::= Division
                    actions.ReduceRULE_X_GT_Y_DIVISION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PERCENT_CHANGE_ZERO :
                    // <Percent_Change> ::= Zero
                    actions.ReduceRULE_PERCENT_CHANGE_ZERO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_FRAC_PERIOD :
                    // <Frac> ::= Period
                    actions.ReduceRULE_FRAC_PERIOD (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_STK_R_S :
                    // <Stk> ::= 'R_S'
                    actions.ReduceRULE_STK_R_S (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SIGMA_MINUS_SIGMA_PLUS :
                    // <Sigma_Minus> ::= 'Sigma_Plus'
                    actions.ReduceRULE_SIGMA_MINUS_SIGMA_PLUS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RTN_GTO :
                    // <Rtn> ::= Gto
                    actions.ReduceRULE_RTN_GTO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ENG_DSP :
                    // <Eng> ::= Dsp
                    actions.ReduceRULE_ENG_DSP (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EXCHANGE_I_SUB_I :
                    // <X_Exchange_I> ::= 'Sub_I'
                    actions.ReduceRULE_X_EXCHANGE_I_SUB_I (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_BST_SST :
                    // <Bst> ::= Sst
                    actions.ReduceRULE_BST_SST (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ST_I_STO :
                    // <St_I> ::= Sto
                    actions.ReduceRULE_ST_I_STO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RC_I_RCL :
                    // <Rc_I> ::= Rcl
                    actions.ReduceRULE_RC_I_RCL (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DEG_ENTER :
                    // <Deg> ::= Enter
                    actions.ReduceRULE_DEG_ENTER (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RAD_CHS :
                    // <Rad> ::= Chs
                    actions.ReduceRULE_RAD_CHS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GRD_EEX :
                    // <Grd> ::= Eex
                    actions.ReduceRULE_GRD_EEX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DEL_CLX :
                    // <Del> ::= Clx
                    actions.ReduceRULE_DEL_CLX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SF_SUBTRACTION :
                    // <SF> ::= Subtraction
                    actions.ReduceRULE_SF_SUBTRACTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EXCHANGE_Y_SEVEN :
                    // <X_Exchange_Y> ::= Seven
                    actions.ReduceRULE_X_EXCHANGE_Y_SEVEN (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_R_DOWN_EIGHT :
                    // <R_Down> ::= Eight
                    actions.ReduceRULE_R_DOWN_EIGHT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_R_UP_NINE :
                    // <R_Up> ::= Nine
                    actions.ReduceRULE_R_UP_NINE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_CF_ADDITION :
                    // <CF> ::= Addition
                    actions.ReduceRULE_CF_ADDITION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RECIPROCAL_FOUR :
                    // <Reciprocal> ::= Four
                    actions.ReduceRULE_RECIPROCAL_FOUR (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_Y_TO_THE_XTH_FIVE :
                    // <Y_To_The_Xth> ::= Five
                    actions.ReduceRULE_Y_TO_THE_XTH_FIVE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ABS_SIX :
                    // <Abs> ::= Six
                    actions.ReduceRULE_ABS_SIX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_TEST_MULTIPLICATION :
                    // <F_Test> ::= Multiplication
                    actions.ReduceRULE_F_TEST_MULTIPLICATION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PAUSE_ONE :
                    // <Pause> ::= One
                    actions.ReduceRULE_PAUSE_ONE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PI_TWO :
                    // <Pi> ::= Two
                    actions.ReduceRULE_PI_TWO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_REG_THREE :
                    // <Reg> ::= Three
                    actions.ReduceRULE_REG_THREE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_FACTORIAL_DIVISION :
                    // <Factorial> ::= Division
                    actions.ReduceRULE_FACTORIAL_DIVISION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LST_X_ZERO :
                    // <Lst_X> ::= Zero
                    actions.ReduceRULE_LST_X_ZERO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_HMS_PLUS_PERIOD :
                    // <HMS_Plus> ::= Period
                    actions.ReduceRULE_HMS_PLUS_PERIOD (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SPACE_R_S :
                    // <Space> ::= 'R_S'
                    actions.ReduceRULE_SPACE_R_S (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION :
                    // <Instruction> ::= <Shortcut>
                    actions.ReduceRULE_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION2 :
                    // <Instruction> ::= <Unshifted_Instruction>
                    actions.ReduceRULE_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION3 :
                    // <Instruction> ::= <F_Shifted_Instruction>
                    actions.ReduceRULE_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION4 :
                    // <Instruction> ::= <G_Shifted_Instruction>
                    actions.ReduceRULE_INSTRUCTION4 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION5 :
                    // <Instruction> ::= <H_Shifted_Instruction>
                    actions.ReduceRULE_INSTRUCTION5 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SHORTCUT :
                    // <Shortcut> ::= <Unshifted_Shortcut>
                    actions.ReduceRULE_SHORTCUT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SHORTCUT2 :
                    // <Shortcut> ::= <F_Shifted_Shortcut>
                    actions.ReduceRULE_SHORTCUT2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_SHORTCUT :
                    // <Unshifted_Shortcut> ::= <Gsb_Shortcut>
                    actions.ReduceRULE_UNSHIFTED_SHORTCUT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_SHORTCUT2 :
                    // <Unshifted_Shortcut> ::= <Memory_Shortcut>
                    actions.ReduceRULE_UNSHIFTED_SHORTCUT2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_SHIFTED_SHORTCUT_F :
                    // <F_Shifted_Shortcut> ::= f <Gsb_Shortcut>
                    actions.ReduceRULE_F_SHIFTED_SHORTCUT_F (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GSB_SHORTCUT :
                    // <Gsb_Shortcut> ::= <Letter>
                    actions.ReduceRULE_GSB_SHORTCUT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MEMORY_SHORTCUT_SUB_I :
                    // <Memory_Shortcut> ::= 'Sub_I'
                    actions.ReduceRULE_MEMORY_SHORTCUT_SUB_I (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_INSTRUCTION :
                    // <Unshifted_Instruction> ::= <Nullary_Unshifted_Instruction>
                    actions.ReduceRULE_UNSHIFTED_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_INSTRUCTION2 :
                    // <Unshifted_Instruction> ::= <Unary_Unshifted_Instruction>
                    actions.ReduceRULE_UNSHIFTED_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_INSTRUCTION3 :
                    // <Unshifted_Instruction> ::= <Binary_Unshifted_Instruction>
                    actions.ReduceRULE_UNSHIFTED_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_SHIFTED_INSTRUCTION_F :
                    // <F_Shifted_Instruction> ::= f <Nullary_F_Shifted_Instruction>
                    actions.ReduceRULE_F_SHIFTED_INSTRUCTION_F (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_SHIFTED_INSTRUCTION_F2 :
                    // <F_Shifted_Instruction> ::= f <Unary_F_Shifted_Instruction>
                    actions.ReduceRULE_F_SHIFTED_INSTRUCTION_F2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_G_SHIFTED_INSTRUCTION_G :
                    // <G_Shifted_Instruction> ::= g <Nullary_G_Shifted_Instruction>
                    actions.ReduceRULE_G_SHIFTED_INSTRUCTION_G (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_G_SHIFTED_INSTRUCTION_G2 :
                    // <G_Shifted_Instruction> ::= g <Unary_G_Shifted_Instruction>
                    actions.ReduceRULE_G_SHIFTED_INSTRUCTION_G2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_H_SHIFTED_INSTRUCTION_H :
                    // <H_Shifted_Instruction> ::= h <Nullary_H_Shifted_Instruction>
                    actions.ReduceRULE_H_SHIFTED_INSTRUCTION_H (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS :
                    // <Nullary_Unshifted_Instruction> ::= 'Sigma_Plus'
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION :
                    // <Nullary_Unshifted_Instruction> ::= <Rcl_Sigma_Plus>
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_SST :
                    // <Nullary_Unshifted_Instruction> ::= Sst
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SST (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER :
                    // <Nullary_Unshifted_Instruction> ::= Enter
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS :
                    // <Nullary_Unshifted_Instruction> ::= Chs
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX :
                    // <Nullary_Unshifted_Instruction> ::= Eex
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX :
                    // <Nullary_Unshifted_Instruction> ::= Clx
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION2 :
                    // <Nullary_Unshifted_Instruction> ::= <Digit>
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION :
                    // <Nullary_Unshifted_Instruction> ::= Subtraction
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION :
                    // <Nullary_Unshifted_Instruction> ::= Addition
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION :
                    // <Nullary_Unshifted_Instruction> ::= Multiplication
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION :
                    // <Nullary_Unshifted_Instruction> ::= Division
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD :
                    // <Nullary_Unshifted_Instruction> ::= Period
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S :
                    // <Nullary_Unshifted_Instruction> ::= 'R_S'
                    actions.ReduceRULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_GTO :
                    // <Unary_Unshifted_Instruction> ::= Gto <Label>
                    actions.ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_GTO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_DSP :
                    // <Unary_Unshifted_Instruction> ::= Dsp <Digit_Count>
                    actions.ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_DSP (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_STO :
                    // <Unary_Unshifted_Instruction> ::= Sto <Memory>
                    actions.ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_STO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_RCL :
                    // <Unary_Unshifted_Instruction> ::= Rcl <Memory>
                    actions.ReduceRULE_UNARY_UNSHIFTED_INSTRUCTION_RCL (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_BINARY_UNSHIFTED_INSTRUCTION_STO :
                    // <Binary_Unshifted_Instruction> ::= Sto <Operator> <Operable_Memory>
                    actions.ReduceRULE_BINARY_UNSHIFTED_INSTRUCTION_STO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TERNARY_UNSHIFTED_INSTRUCTION_GTO_PERIOD :
                    // <Ternary_Unshifted_Instruction> ::= Gto Period <Digit> <Digit> <Digit>
                    actions.ReduceRULE_TERNARY_UNSHIFTED_INSTRUCTION_GTO_PERIOD (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION :
                    // <Nullary_F_Shifted_Instruction> ::= <X_Average>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION2 :
                    // <Nullary_F_Shifted_Instruction> ::= <Fix>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION3 :
                    // <Nullary_F_Shifted_Instruction> ::= <Rnd>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION4 :
                    // <Nullary_F_Shifted_Instruction> ::= <Dsz>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION4 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION5 :
                    // <Nullary_F_Shifted_Instruction> ::= <Isz>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION5 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION6 :
                    // <Nullary_F_Shifted_Instruction> ::= <W_Data>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION6 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION7 :
                    // <Nullary_F_Shifted_Instruction> ::= <P_Exchange_S>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION7 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION8 :
                    // <Nullary_F_Shifted_Instruction> ::= <Cl_Reg>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION8 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION9 :
                    // <Nullary_F_Shifted_Instruction> ::= <Cl_Prgm>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION9 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION10 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_EQ_0>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION10 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION11 :
                    // <Nullary_F_Shifted_Instruction> ::= <Ln>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION11 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION12 :
                    // <Nullary_F_Shifted_Instruction> ::= <Log>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION12 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION13 :
                    // <Nullary_F_Shifted_Instruction> ::= <Sqrt>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION13 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION14 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_NE_0>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION14 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION15 :
                    // <Nullary_F_Shifted_Instruction> ::= <Sin>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION15 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION16 :
                    // <Nullary_F_Shifted_Instruction> ::= <Cos>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION16 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION17 :
                    // <Nullary_F_Shifted_Instruction> ::= <Tan>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION17 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION18 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_LT_0>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION18 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION19 :
                    // <Nullary_F_Shifted_Instruction> ::= <To_Rectangular>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION19 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION20 :
                    // <Nullary_F_Shifted_Instruction> ::= <To_Degrees>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION20 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION21 :
                    // <Nullary_F_Shifted_Instruction> ::= <To_Hours>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION21 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION22 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_GT_0>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION22 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION23 :
                    // <Nullary_F_Shifted_Instruction> ::= <Percent>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION23 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION24 :
                    // <Nullary_F_Shifted_Instruction> ::= <Int>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION24 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION25 :
                    // <Nullary_F_Shifted_Instruction> ::= <Display_X>
                    actions.ReduceRULE_NULLARY_F_SHIFTED_INSTRUCTION25 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_F_SHIFTED_INSTRUCTION :
                    // <Unary_F_Shifted_Instruction> ::= <Gsb> <Label>
                    actions.ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_F_SHIFTED_INSTRUCTION2 :
                    // <Unary_F_Shifted_Instruction> ::= <Lbl> <Label>
                    actions.ReduceRULE_UNARY_F_SHIFTED_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION :
                    // <Nullary_G_Shifted_Instruction> ::= <S>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION2 :
                    // <Nullary_G_Shifted_Instruction> ::= <Sci>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION3 :
                    // <Nullary_G_Shifted_Instruction> ::= <Dsz_Sub_I>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION4 :
                    // <Nullary_G_Shifted_Instruction> ::= <Isz_Sub_I>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION4 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION5 :
                    // <Nullary_G_Shifted_Instruction> ::= <Merge>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION5 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION6 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_EQ_Y>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION6 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION7 :
                    // <Nullary_G_Shifted_Instruction> ::= <Exp>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION7 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION8 :
                    // <Nullary_G_Shifted_Instruction> ::= <Ten_To_The_Xth>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION8 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION9 :
                    // <Nullary_G_Shifted_Instruction> ::= <Square>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION9 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION10 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_NE_Y>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION10 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION11 :
                    // <Nullary_G_Shifted_Instruction> ::= <Arcsin>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION11 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION12 :
                    // <Nullary_G_Shifted_Instruction> ::= <Arccos>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION12 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION13 :
                    // <Nullary_G_Shifted_Instruction> ::= <Arctan>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION13 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION14 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_LE_Y>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION14 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION15 :
                    // <Nullary_G_Shifted_Instruction> ::= <To_Polar>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION15 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION16 :
                    // <Nullary_G_Shifted_Instruction> ::= <To_Radians>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION16 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION17 :
                    // <Nullary_G_Shifted_Instruction> ::= <To_HMS>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION17 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION18 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_GT_Y>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION18 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION19 :
                    // <Nullary_G_Shifted_Instruction> ::= <Percent_Change>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION19 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION20 :
                    // <Nullary_G_Shifted_Instruction> ::= <Frac>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION20 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION21 :
                    // <Nullary_G_Shifted_Instruction> ::= <Stk>
                    actions.ReduceRULE_NULLARY_G_SHIFTED_INSTRUCTION21 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_G_SHIFTED_INSTRUCTION :
                    // <Unary_G_Shifted_Instruction> ::= <Gsb_f> <Letter_Label>
                    actions.ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_G_SHIFTED_INSTRUCTION2 :
                    // <Unary_G_Shifted_Instruction> ::= <Lbl_f> <Letter_Label>
                    actions.ReduceRULE_UNARY_G_SHIFTED_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION :
                    // <Nullary_H_Shifted_Instruction> ::= <Sigma_Minus>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION2 :
                    // <Nullary_H_Shifted_Instruction> ::= <Rtn>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION3 :
                    // <Nullary_H_Shifted_Instruction> ::= <Eng>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION3 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION4 :
                    // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_I>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION4 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION5 :
                    // <Nullary_H_Shifted_Instruction> ::= <Bst>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION5 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION6 :
                    // <Nullary_H_Shifted_Instruction> ::= <St_I>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION6 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION7 :
                    // <Nullary_H_Shifted_Instruction> ::= <Rc_I>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION7 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION8 :
                    // <Nullary_H_Shifted_Instruction> ::= <Deg>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION8 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION9 :
                    // <Nullary_H_Shifted_Instruction> ::= <Rad>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION9 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION10 :
                    // <Nullary_H_Shifted_Instruction> ::= <Grd>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION10 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION11 :
                    // <Nullary_H_Shifted_Instruction> ::= <Del>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION11 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION12 :
                    // <Nullary_H_Shifted_Instruction> ::= <SF>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION12 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION13 :
                    // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_Y>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION13 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION14 :
                    // <Nullary_H_Shifted_Instruction> ::= <R_Down>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION14 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION15 :
                    // <Nullary_H_Shifted_Instruction> ::= <R_Up>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION15 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION16 :
                    // <Nullary_H_Shifted_Instruction> ::= <CF>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION16 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION17 :
                    // <Nullary_H_Shifted_Instruction> ::= <Reciprocal>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION17 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION18 :
                    // <Nullary_H_Shifted_Instruction> ::= <Y_To_The_Xth>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION18 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION19 :
                    // <Nullary_H_Shifted_Instruction> ::= <Abs>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION19 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION20 :
                    // <Nullary_H_Shifted_Instruction> ::= <F_Test>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION20 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION21 :
                    // <Nullary_H_Shifted_Instruction> ::= <Pause>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION21 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION22 :
                    // <Nullary_H_Shifted_Instruction> ::= <Pi>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION22 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION23 :
                    // <Nullary_H_Shifted_Instruction> ::= <Reg>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION23 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION24 :
                    // <Nullary_H_Shifted_Instruction> ::= <Factorial>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION24 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION25 :
                    // <Nullary_H_Shifted_Instruction> ::= <Lst_X>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION25 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION26 :
                    // <Nullary_H_Shifted_Instruction> ::= <HMS_Plus>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION26 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION27 :
                    // <Nullary_H_Shifted_Instruction> ::= <Space>
                    actions.ReduceRULE_NULLARY_H_SHIFTED_INSTRUCTION27 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RCL_SIGMA_PLUS_RCL_SIGMA_PLUS :
                    // <Rcl_Sigma_Plus> ::= Rcl 'Sigma_Plus'
                    actions.ReduceRULE_RCL_SIGMA_PLUS_RCL_SIGMA_PLUS (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_SUBTRACTION :
                    // <Operator> ::= Subtraction
                    actions.ReduceRULE_OPERATOR_SUBTRACTION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_ADDITION :
                    // <Operator> ::= Addition
                    actions.ReduceRULE_OPERATOR_ADDITION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_MULTIPLICATION :
                    // <Operator> ::= Multiplication
                    actions.ReduceRULE_OPERATOR_MULTIPLICATION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_DIVISION :
                    // <Operator> ::= Division
                    actions.ReduceRULE_OPERATOR_DIVISION (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_ZERO :
                    // <Digit> ::= Zero
                    actions.ReduceRULE_DIGIT_ZERO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_ONE :
                    // <Digit> ::= One
                    actions.ReduceRULE_DIGIT_ONE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_TWO :
                    // <Digit> ::= Two
                    actions.ReduceRULE_DIGIT_TWO (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_THREE :
                    // <Digit> ::= Three
                    actions.ReduceRULE_DIGIT_THREE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_FOUR :
                    // <Digit> ::= Four
                    actions.ReduceRULE_DIGIT_FOUR (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_FIVE :
                    // <Digit> ::= Five
                    actions.ReduceRULE_DIGIT_FIVE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_SIX :
                    // <Digit> ::= Six
                    actions.ReduceRULE_DIGIT_SIX (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_SEVEN :
                    // <Digit> ::= Seven
                    actions.ReduceRULE_DIGIT_SEVEN (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_EIGHT :
                    // <Digit> ::= Eight
                    actions.ReduceRULE_DIGIT_EIGHT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_NINE :
                    // <Digit> ::= Nine
                    actions.ReduceRULE_DIGIT_NINE (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_COUNT :
                    // <Digit_Count> ::= <Digit>
                    actions.ReduceRULE_DIGIT_COUNT (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_COUNT_SUB_I :
                    // <Digit_Count> ::= 'Sub_I'
                    actions.ReduceRULE_DIGIT_COUNT_SUB_I (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_A :
                    // <Letter> ::= A
                    actions.ReduceRULE_LETTER_A (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_B :
                    // <Letter> ::= B
                    actions.ReduceRULE_LETTER_B (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_C :
                    // <Letter> ::= C
                    actions.ReduceRULE_LETTER_C (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_D :
                    // <Letter> ::= D
                    actions.ReduceRULE_LETTER_D (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_E :
                    // <Letter> ::= E
                    actions.ReduceRULE_LETTER_E (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_LABEL :
                    // <Letter_Label> ::= <Letter>
                    actions.ReduceRULE_LETTER_LABEL (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_LABEL :
                    // <Digit_Label> ::= <Digit>
                    actions.ReduceRULE_DIGIT_LABEL (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LABEL :
                    // <Label> ::= <Digit_Label>
                    actions.ReduceRULE_LABEL (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LABEL2 :
                    // <Label> ::= <Letter_Label>
                    actions.ReduceRULE_LABEL2 (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LABEL_SUB_I :
                    // <Label> ::= 'Sub_I'
                    actions.ReduceRULE_LABEL_SUB_I (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERABLE_MEMORY :
                    // <Operable_Memory> ::= <Digit>
                    actions.ReduceRULE_OPERABLE_MEMORY (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERABLE_MEMORY_SUB_I :
                    // <Operable_Memory> ::= 'Sub_I'
                    actions.ReduceRULE_OPERABLE_MEMORY_SUB_I (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MEMORY :
                    // <Memory> ::= <Operable_Memory>
                    actions.ReduceRULE_MEMORY (input, args.Token, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MEMORY2 :
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

        private void Initialize (Stream stream)
        {
            CGTReader reader = new CGTReader (stream);
            parser = reader.CreateNewParser ();
            parser.TrimReductions = false; 
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler (ReduceEvent);
            parser.OnAccept += new LALRParser.AcceptHandler (AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler (TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler (ParseErrorEvent);
        }

        public Parser (string filename, IActions a)
        {
            FileStream stream = new FileStream (filename,
                                                FileMode.Open, 
                                                FileAccess.Read, 
                                                FileShare.Read);
            Initialize (stream);
            stream.Close ();
            actions = a;
        }

        public Parser (string baseName, string resourceName, IActions a)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource
               (System.Reflection.Assembly.GetExecutingAssembly (),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream (buffer);
            Initialize (stream);
            stream.Close ();
            actions = a;
        }

        public Parser (Stream stream, IActions a)
        {
            Initialize (stream);
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
