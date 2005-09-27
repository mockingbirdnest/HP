
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
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
        SYMBOL_COMMAND                       = 47 , // <Command>
        SYMBOL_COS                           = 48 , // <Cos>
        SYMBOL_DEG                           = 49 , // <Deg>
        SYMBOL_DEL                           = 50 , // <Del>
        SYMBOL_DIGIT                         = 51 , // <Digit>
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
        SYMBOL_RECIPROCAL                    = 101, // <Reciprocal>
        SYMBOL_REG                           = 102, // <Reg>
        SYMBOL_RND                           = 103, // <Rnd>
        SYMBOL_RTN                           = 104, // <Rtn>
        SYMBOL_S                             = 105, // <S>
        SYMBOL_SCI                           = 106, // <Sci>
        SYMBOL_SF                            = 107, // <SF>
        SYMBOL_SHORTCUT                      = 108, // <Shortcut>
        SYMBOL_SIGMA_MINUS                   = 109, // <Sigma_Minus>
        SYMBOL_SIN                           = 110, // <Sin>
        SYMBOL_SPACE                         = 111, // <Space>
        SYMBOL_SQRT                          = 112, // <Sqrt>
        SYMBOL_SQUARE                        = 113, // <Square>
        SYMBOL_ST_I                          = 114, // <St_I>
        SYMBOL_STK                           = 115, // <Stk>
        SYMBOL_TAN                           = 116, // <Tan>
        SYMBOL_TEN_TO_THE_XTH                = 117, // <Ten_To_The_Xth>
        SYMBOL_TO_DEGREES                    = 118, // <To_Degrees>
        SYMBOL_TO_HMS                        = 119, // <To_HMS>
        SYMBOL_TO_HOURS                      = 120, // <To_Hours>
        SYMBOL_TO_POLAR                      = 121, // <To_Polar>
        SYMBOL_TO_RADIANS                    = 122, // <To_Radians>
        SYMBOL_TO_RECTANGULAR                = 123, // <To_Rectangular>
        SYMBOL_UNARY_F_SHIFTED_INSTRUCTION   = 124, // <Unary_F_Shifted_Instruction>
        SYMBOL_UNARY_G_SHIFTED_INSTRUCTION   = 125, // <Unary_G_Shifted_Instruction>
        SYMBOL_UNARY_H_SHIFTED_INSTRUCTION   = 126, // <Unary_H_Shifted_Instruction>
        SYMBOL_UNARY_UNSHIFTED_INSTRUCTION   = 127, // <Unary_Unshifted_Instruction>
        SYMBOL_UNSHIFTED_INSTRUCTION         = 128, // <Unshifted_Instruction>
        SYMBOL_UNSHIFTED_SHORTCUT            = 129, // <Unshifted_Shortcut>
        SYMBOL_W_DATA                        = 130, // <W_Data>
        SYMBOL_X_AVERAGE                     = 131, // <X_Average>
        SYMBOL_X_EQ_0                        = 132, // <X_EQ_0>
        SYMBOL_X_EQ_Y                        = 133, // <X_EQ_Y>
        SYMBOL_X_EXCHANGE_I                  = 134, // <X_Exchange_I>
        SYMBOL_X_EXCHANGE_Y                  = 135, // <X_Exchange_Y>
        SYMBOL_X_GT_0                        = 136, // <X_GT_0>
        SYMBOL_X_GT_Y                        = 137, // <X_GT_Y>
        SYMBOL_X_LE_Y                        = 138, // <X_LE_Y>
        SYMBOL_X_LT_0                        = 139, // <X_LT_0>
        SYMBOL_X_NE_0                        = 140, // <X_NE_0>
        SYMBOL_X_NE_Y                        = 141, // <X_NE_Y>
        SYMBOL_Y_TO_THE_XTH                  = 142  // <Y_To_The_Xth>
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
        RULE_INSTRUCTION                                  = 77 , // <Instruction> ::= <Command>
        RULE_INSTRUCTION2                                 = 78 , // <Instruction> ::= <Shortcut>
        RULE_INSTRUCTION3                                 = 79 , // <Instruction> ::= <Unshifted_Instruction>
        RULE_INSTRUCTION4                                 = 80 , // <Instruction> ::= <F_Shifted_Instruction>
        RULE_INSTRUCTION5                                 = 81 , // <Instruction> ::= <G_Shifted_Instruction>
        RULE_INSTRUCTION6                                 = 82 , // <Instruction> ::= <H_Shifted_Instruction>
        RULE_COMMAND_SST                                  = 83 , // <Command> ::= Sst
        RULE_COMMAND_H                                    = 84 , // <Command> ::= h <Bst>
        RULE_COMMAND_H2                                   = 85 , // <Command> ::= h <Del>
        RULE_COMMAND_F                                    = 86 , // <Command> ::= f <Cl_Prgm>
        RULE_COMMAND_GTO_PERIOD                           = 87 , // <Command> ::= Gto Period <Digit> <Digit> <Digit>
        RULE_SHORTCUT                                     = 88 , // <Shortcut> ::= <Unshifted_Shortcut>
        RULE_SHORTCUT2                                    = 89 , // <Shortcut> ::= <F_Shifted_Shortcut>
        RULE_UNSHIFTED_SHORTCUT                           = 90 , // <Unshifted_Shortcut> ::= <Gsb_Shortcut>
        RULE_UNSHIFTED_SHORTCUT2                          = 91 , // <Unshifted_Shortcut> ::= <Memory_Shortcut>
        RULE_F_SHIFTED_SHORTCUT_F                         = 92 , // <F_Shifted_Shortcut> ::= f <Gsb_Shortcut>
        RULE_GSB_SHORTCUT                                 = 93 , // <Gsb_Shortcut> ::= <Letter>
        RULE_MEMORY_SHORTCUT_SUB_I                        = 94 , // <Memory_Shortcut> ::= 'Sub_I'
        RULE_UNSHIFTED_INSTRUCTION                        = 95 , // <Unshifted_Instruction> ::= <Nullary_Unshifted_Instruction>
        RULE_UNSHIFTED_INSTRUCTION2                       = 96 , // <Unshifted_Instruction> ::= <Unary_Unshifted_Instruction>
        RULE_UNSHIFTED_INSTRUCTION3                       = 97 , // <Unshifted_Instruction> ::= <Binary_Unshifted_Instruction>
        RULE_F_SHIFTED_INSTRUCTION_F                      = 98 , // <F_Shifted_Instruction> ::= f <Nullary_F_Shifted_Instruction>
        RULE_F_SHIFTED_INSTRUCTION_F2                     = 99 , // <F_Shifted_Instruction> ::= f <Unary_F_Shifted_Instruction>
        RULE_G_SHIFTED_INSTRUCTION_G                      = 100, // <G_Shifted_Instruction> ::= g <Nullary_G_Shifted_Instruction>
        RULE_G_SHIFTED_INSTRUCTION_G2                     = 101, // <G_Shifted_Instruction> ::= g <Unary_G_Shifted_Instruction>
        RULE_H_SHIFTED_INSTRUCTION_H                      = 102, // <H_Shifted_Instruction> ::= h <Nullary_H_Shifted_Instruction>
        RULE_H_SHIFTED_INSTRUCTION_H2                     = 103, // <H_Shifted_Instruction> ::= h <Unary_H_Shifted_Instruction>
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS     = 104, // <Nullary_Unshifted_Instruction> ::= 'Sigma_Plus'
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER          = 105, // <Nullary_Unshifted_Instruction> ::= Enter
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS            = 106, // <Nullary_Unshifted_Instruction> ::= Chs
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX            = 107, // <Nullary_Unshifted_Instruction> ::= Eex
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX            = 108, // <Nullary_Unshifted_Instruction> ::= Clx
        RULE_NULLARY_UNSHIFTED_INSTRUCTION                = 109, // <Nullary_Unshifted_Instruction> ::= <Digit>
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION    = 110, // <Nullary_Unshifted_Instruction> ::= Subtraction
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION       = 111, // <Nullary_Unshifted_Instruction> ::= Addition
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION = 112, // <Nullary_Unshifted_Instruction> ::= Multiplication
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION       = 113, // <Nullary_Unshifted_Instruction> ::= Division
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD         = 114, // <Nullary_Unshifted_Instruction> ::= Period
        RULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S            = 115, // <Nullary_Unshifted_Instruction> ::= 'R_S'
        RULE_UNARY_UNSHIFTED_INSTRUCTION_GTO              = 116, // <Unary_Unshifted_Instruction> ::= Gto <Label>
        RULE_UNARY_UNSHIFTED_INSTRUCTION_DSP              = 117, // <Unary_Unshifted_Instruction> ::= Dsp <Digit>
        RULE_UNARY_UNSHIFTED_INSTRUCTION_STO              = 118, // <Unary_Unshifted_Instruction> ::= Sto <Memory>
        RULE_UNARY_UNSHIFTED_INSTRUCTION_RCL              = 119, // <Unary_Unshifted_Instruction> ::= Rcl <Memory>
        RULE_BINARY_UNSHIFTED_INSTRUCTION_STO             = 120, // <Binary_Unshifted_Instruction> ::= Sto <Operator> <Operable_Memory>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION                = 121, // <Nullary_F_Shifted_Instruction> ::= <X_Average>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION2               = 122, // <Nullary_F_Shifted_Instruction> ::= <Fix>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION3               = 123, // <Nullary_F_Shifted_Instruction> ::= <Rnd>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION4               = 124, // <Nullary_F_Shifted_Instruction> ::= <Dsz>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION5               = 125, // <Nullary_F_Shifted_Instruction> ::= <Isz>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION6               = 126, // <Nullary_F_Shifted_Instruction> ::= <W_Data>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION7               = 127, // <Nullary_F_Shifted_Instruction> ::= <P_Exchange_S>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION8               = 128, // <Nullary_F_Shifted_Instruction> ::= <Cl_Reg>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION9               = 129, // <Nullary_F_Shifted_Instruction> ::= <X_EQ_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION10              = 130, // <Nullary_F_Shifted_Instruction> ::= <Ln>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION11              = 131, // <Nullary_F_Shifted_Instruction> ::= <Log>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION12              = 132, // <Nullary_F_Shifted_Instruction> ::= <Sqrt>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION13              = 133, // <Nullary_F_Shifted_Instruction> ::= <X_NE_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION14              = 134, // <Nullary_F_Shifted_Instruction> ::= <Sin>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION15              = 135, // <Nullary_F_Shifted_Instruction> ::= <Cos>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION16              = 136, // <Nullary_F_Shifted_Instruction> ::= <Tan>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION17              = 137, // <Nullary_F_Shifted_Instruction> ::= <X_LT_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION18              = 138, // <Nullary_F_Shifted_Instruction> ::= <To_Rectangular>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION19              = 139, // <Nullary_F_Shifted_Instruction> ::= <To_Degrees>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION20              = 140, // <Nullary_F_Shifted_Instruction> ::= <To_Hours>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION21              = 141, // <Nullary_F_Shifted_Instruction> ::= <X_GT_0>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION22              = 142, // <Nullary_F_Shifted_Instruction> ::= <Percent>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION23              = 143, // <Nullary_F_Shifted_Instruction> ::= <Int>
        RULE_NULLARY_F_SHIFTED_INSTRUCTION24              = 144, // <Nullary_F_Shifted_Instruction> ::= <Display_X>
        RULE_UNARY_F_SHIFTED_INSTRUCTION                  = 145, // <Unary_F_Shifted_Instruction> ::= <Gsb> <Label>
        RULE_UNARY_F_SHIFTED_INSTRUCTION2                 = 146, // <Unary_F_Shifted_Instruction> ::= <Lbl> <Label>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION                = 147, // <Nullary_G_Shifted_Instruction> ::= <S>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION2               = 148, // <Nullary_G_Shifted_Instruction> ::= <Sci>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION3               = 149, // <Nullary_G_Shifted_Instruction> ::= <Dsz_Sub_I>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION4               = 150, // <Nullary_G_Shifted_Instruction> ::= <Isz_Sub_I>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION5               = 151, // <Nullary_G_Shifted_Instruction> ::= <Merge>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION6               = 152, // <Nullary_G_Shifted_Instruction> ::= <X_EQ_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION7               = 153, // <Nullary_G_Shifted_Instruction> ::= <Exp>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION8               = 154, // <Nullary_G_Shifted_Instruction> ::= <Ten_To_The_Xth>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION9               = 155, // <Nullary_G_Shifted_Instruction> ::= <Square>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION10              = 156, // <Nullary_G_Shifted_Instruction> ::= <X_NE_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION11              = 157, // <Nullary_G_Shifted_Instruction> ::= <Arcsin>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION12              = 158, // <Nullary_G_Shifted_Instruction> ::= <Arccos>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION13              = 159, // <Nullary_G_Shifted_Instruction> ::= <Arctan>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION14              = 160, // <Nullary_G_Shifted_Instruction> ::= <X_LE_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION15              = 161, // <Nullary_G_Shifted_Instruction> ::= <To_Polar>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION16              = 162, // <Nullary_G_Shifted_Instruction> ::= <To_Radians>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION17              = 163, // <Nullary_G_Shifted_Instruction> ::= <To_HMS>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION18              = 164, // <Nullary_G_Shifted_Instruction> ::= <X_GT_Y>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION19              = 165, // <Nullary_G_Shifted_Instruction> ::= <Percent_Change>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION20              = 166, // <Nullary_G_Shifted_Instruction> ::= <Frac>
        RULE_NULLARY_G_SHIFTED_INSTRUCTION21              = 167, // <Nullary_G_Shifted_Instruction> ::= <Stk>
        RULE_UNARY_G_SHIFTED_INSTRUCTION                  = 168, // <Unary_G_Shifted_Instruction> ::= <Gsb_f> <Letter_Label>
        RULE_UNARY_G_SHIFTED_INSTRUCTION2                 = 169, // <Unary_G_Shifted_Instruction> ::= <Lbl_f> <Letter_Label>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION                = 170, // <Nullary_H_Shifted_Instruction> ::= <Sigma_Minus>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION2               = 171, // <Nullary_H_Shifted_Instruction> ::= <Rtn>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION3               = 172, // <Nullary_H_Shifted_Instruction> ::= <Eng>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION4               = 173, // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_I>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION5               = 174, // <Nullary_H_Shifted_Instruction> ::= <St_I>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION6               = 175, // <Nullary_H_Shifted_Instruction> ::= <Rc_I>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION7               = 176, // <Nullary_H_Shifted_Instruction> ::= <Deg>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION8               = 177, // <Nullary_H_Shifted_Instruction> ::= <Rad>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION9               = 178, // <Nullary_H_Shifted_Instruction> ::= <Grd>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION10              = 179, // <Nullary_H_Shifted_Instruction> ::= <SF>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION11              = 180, // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_Y>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION12              = 181, // <Nullary_H_Shifted_Instruction> ::= <R_Down>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION13              = 182, // <Nullary_H_Shifted_Instruction> ::= <R_Up>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION14              = 183, // <Nullary_H_Shifted_Instruction> ::= <CF>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION15              = 184, // <Nullary_H_Shifted_Instruction> ::= <Reciprocal>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION16              = 185, // <Nullary_H_Shifted_Instruction> ::= <Y_To_The_Xth>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION17              = 186, // <Nullary_H_Shifted_Instruction> ::= <Abs>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION18              = 187, // <Nullary_H_Shifted_Instruction> ::= <F_Test>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION19              = 188, // <Nullary_H_Shifted_Instruction> ::= <Pause>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION20              = 189, // <Nullary_H_Shifted_Instruction> ::= <Pi>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION21              = 190, // <Nullary_H_Shifted_Instruction> ::= <Reg>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION22              = 191, // <Nullary_H_Shifted_Instruction> ::= <Factorial>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION23              = 192, // <Nullary_H_Shifted_Instruction> ::= <Lst_X>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION24              = 193, // <Nullary_H_Shifted_Instruction> ::= <HMS_Plus>
        RULE_NULLARY_H_SHIFTED_INSTRUCTION25              = 194, // <Nullary_H_Shifted_Instruction> ::= <Space>
        RULE_UNARY_H_SHIFTED_INSTRUCTION                  = 195, // <Unary_H_Shifted_Instruction> ::= 
        RULE_OPERATOR_SUBTRACTION                         = 196, // <Operator> ::= Subtraction
        RULE_OPERATOR_ADDITION                            = 197, // <Operator> ::= Addition
        RULE_OPERATOR_MULTIPLICATION                      = 198, // <Operator> ::= Multiplication
        RULE_OPERATOR_DIVISION                            = 199, // <Operator> ::= Division
        RULE_DIGIT_ZERO                                   = 200, // <Digit> ::= Zero
        RULE_DIGIT_ONE                                    = 201, // <Digit> ::= One
        RULE_DIGIT_TWO                                    = 202, // <Digit> ::= Two
        RULE_DIGIT_THREE                                  = 203, // <Digit> ::= Three
        RULE_DIGIT_FOUR                                   = 204, // <Digit> ::= Four
        RULE_DIGIT_FIVE                                   = 205, // <Digit> ::= Five
        RULE_DIGIT_SIX                                    = 206, // <Digit> ::= Six
        RULE_DIGIT_SEVEN                                  = 207, // <Digit> ::= Seven
        RULE_DIGIT_EIGHT                                  = 208, // <Digit> ::= Eight
        RULE_DIGIT_NINE                                   = 209, // <Digit> ::= Nine
        RULE_LETTER_A                                     = 210, // <Letter> ::= A
        RULE_LETTER_B                                     = 211, // <Letter> ::= B
        RULE_LETTER_C                                     = 212, // <Letter> ::= C
        RULE_LETTER_D                                     = 213, // <Letter> ::= D
        RULE_LETTER_E                                     = 214, // <Letter> ::= E
        RULE_LETTER_LABEL                                 = 215, // <Letter_Label> ::= <Letter>
        RULE_DIGIT_LABEL                                  = 216, // <Digit_Label> ::= <Digit>
        RULE_LABEL                                        = 217, // <Label> ::= <Digit_Label>
        RULE_LABEL2                                       = 218, // <Label> ::= <Letter_Label>
        RULE_OPERABLE_MEMORY                              = 219, // <Operable_Memory> ::= <Digit>
        RULE_OPERABLE_MEMORY_SUB_I                        = 220, // <Operable_Memory> ::= 'Sub_I'
        RULE_MEMORY                                       = 221, // <Memory> ::= <Operable_Memory>
        RULE_MEMORY2                                      = 222  // <Memory> ::= <Letter>
    };

    public interface IHP67ParserActions
    {
        void RULE_X_AVERAGE_SIGMA_PLUS (Rule rule, Token [] tokens);
        void RULE_GSB_GTO (Rule rule, Token [] tokens);
        void RULE_FIX_DSP (Rule rule, Token [] tokens);
        void RULE_RND_SUB_I (Rule rule, Token [] tokens);
        void RULE_LBL_SST (Rule rule, Token [] tokens);
        void RULE_DSZ_STO (Rule rule, Token [] tokens);
        void RULE_ISZ_RCL (Rule rule, Token [] tokens);
        void RULE_W_DATA_ENTER (Rule rule, Token [] tokens);
        void RULE_P_EXCHANGE_S_CHS (Rule rule, Token [] tokens);
        void RULE_CL_REG_EEX (Rule rule, Token [] tokens);
        void RULE_CL_PRGM_CLX (Rule rule, Token [] tokens);
        void RULE_X_EQ_0_SUBTRACTION (Rule rule, Token [] tokens);
        void RULE_LN_SEVEN (Rule rule, Token [] tokens);
        void RULE_LOG_EIGHT (Rule rule, Token [] tokens);
        void RULE_SQRT_NINE (Rule rule, Token [] tokens);
        void RULE_X_NE_0_ADDITION (Rule rule, Token [] tokens);
        void RULE_SIN_FOUR (Rule rule, Token [] tokens);
        void RULE_COS_FIVE (Rule rule, Token [] tokens);
        void RULE_TAN_SIX (Rule rule, Token [] tokens);
        void RULE_X_LT_0_MULTIPLICATION (Rule rule, Token [] tokens);
        void RULE_TO_RECTANGULAR_ONE (Rule rule, Token [] tokens);
        void RULE_TO_DEGREES_TWO (Rule rule, Token [] tokens);
        void RULE_TO_HOURS_THREE (Rule rule, Token [] tokens);
        void RULE_X_GT_0_DIVISION (Rule rule, Token [] tokens);
        void RULE_PERCENT_ZERO (Rule rule, Token [] tokens);
        void RULE_INT_PERIOD (Rule rule, Token [] tokens);
        void RULE_DISPLAY_X_R_S (Rule rule, Token [] tokens);
        void RULE_S_SIGMA_PLUS (Rule rule, Token [] tokens);
        void RULE_GSB_F_GTO (Rule rule, Token [] tokens);
        void RULE_SCI_DSP (Rule rule, Token [] tokens);
        void RULE_LBL_F_SST (Rule rule, Token [] tokens);
        void RULE_DSZ_SUB_I_STO (Rule rule, Token [] tokens);
        void RULE_ISZ_SUB_I_RCL (Rule rule, Token [] tokens);
        void RULE_MERGE_ENTER (Rule rule, Token [] tokens);
        void RULE_X_EQ_Y_SUBTRACTION (Rule rule, Token [] tokens);
        void RULE_EXP_SEVEN (Rule rule, Token [] tokens);
        void RULE_TEN_TO_THE_XTH_EIGHT (Rule rule, Token [] tokens);
        void RULE_SQUARE_NINE (Rule rule, Token [] tokens);
        void RULE_X_NE_Y_ADDITION (Rule rule, Token [] tokens);
        void RULE_ARCSIN_FOUR (Rule rule, Token [] tokens);
        void RULE_ARCCOS_FIVE (Rule rule, Token [] tokens);
        void RULE_ARCTAN_SIX (Rule rule, Token [] tokens);
        void RULE_X_LE_Y_MULTIPLICATION (Rule rule, Token [] tokens);
        void RULE_TO_POLAR_ONE (Rule rule, Token [] tokens);
        void RULE_TO_RADIANS_TWO (Rule rule, Token [] tokens);
        void RULE_TO_HMS_THREE (Rule rule, Token [] tokens);
        void RULE_X_GT_Y_DIVISION (Rule rule, Token [] tokens);
        void RULE_PERCENT_CHANGE_ZERO (Rule rule, Token [] tokens);
        void RULE_FRAC_PERIOD (Rule rule, Token [] tokens);
        void RULE_STK_R_S (Rule rule, Token [] tokens);
        void RULE_SIGMA_MINUS_SIGMA_PLUS (Rule rule, Token [] tokens);
        void RULE_RTN_GTO (Rule rule, Token [] tokens);
        void RULE_ENG_DSP (Rule rule, Token [] tokens);
        void RULE_X_EXCHANGE_I_SUB_I (Rule rule, Token [] tokens);
        void RULE_BST_SST (Rule rule, Token [] tokens);
        void RULE_ST_I_STO (Rule rule, Token [] tokens);
        void RULE_RC_I_RCL (Rule rule, Token [] tokens);
        void RULE_DEG_ENTER (Rule rule, Token [] tokens);
        void RULE_RAD_CHS (Rule rule, Token [] tokens);
        void RULE_GRD_EEX (Rule rule, Token [] tokens);
        void RULE_DEL_CLX (Rule rule, Token [] tokens);
        void RULE_SF_SUBTRACTION (Rule rule, Token [] tokens);
        void RULE_X_EXCHANGE_Y_SEVEN (Rule rule, Token [] tokens);
        void RULE_R_DOWN_EIGHT (Rule rule, Token [] tokens);
        void RULE_R_UP_NINE (Rule rule, Token [] tokens);
        void RULE_CF_ADDITION (Rule rule, Token [] tokens);
        void RULE_RECIPROCAL_FOUR (Rule rule, Token [] tokens);
        void RULE_Y_TO_THE_XTH_FIVE (Rule rule, Token [] tokens);
        void RULE_ABS_SIX (Rule rule, Token [] tokens);
        void RULE_F_TEST_MULTIPLICATION (Rule rule, Token [] tokens);
        void RULE_PAUSE_ONE (Rule rule, Token [] tokens);
        void RULE_PI_TWO (Rule rule, Token [] tokens);
        void RULE_REG_THREE (Rule rule, Token [] tokens);
        void RULE_FACTORIAL_DIVISION (Rule rule, Token [] tokens);
        void RULE_LST_X_ZERO (Rule rule, Token [] tokens);
        void RULE_HMS_PLUS_PERIOD (Rule rule, Token [] tokens);
        void RULE_SPACE_R_S (Rule rule, Token [] tokens);
        void RULE_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_INSTRUCTION2 (Rule rule, Token [] tokens);
        void RULE_INSTRUCTION3 (Rule rule, Token [] tokens);
        void RULE_INSTRUCTION4 (Rule rule, Token [] tokens);
        void RULE_INSTRUCTION5 (Rule rule, Token [] tokens);
        void RULE_INSTRUCTION6 (Rule rule, Token [] tokens);
        void RULE_COMMAND_SST (Rule rule, Token [] tokens);
        void RULE_COMMAND_H (Rule rule, Token [] tokens);
        void RULE_COMMAND_H2 (Rule rule, Token [] tokens);
        void RULE_COMMAND_F (Rule rule, Token [] tokens);
        void RULE_COMMAND_GTO_PERIOD (Rule rule, Token [] tokens);
        void RULE_SHORTCUT (Rule rule, Token [] tokens);
        void RULE_SHORTCUT2 (Rule rule, Token [] tokens);
        void RULE_UNSHIFTED_SHORTCUT (Rule rule, Token [] tokens);
        void RULE_UNSHIFTED_SHORTCUT2 (Rule rule, Token [] tokens);
        void RULE_F_SHIFTED_SHORTCUT_F (Rule rule, Token [] tokens);
        void RULE_GSB_SHORTCUT (Rule rule, Token [] tokens);
        void RULE_MEMORY_SHORTCUT_SUB_I (Rule rule, Token [] tokens);
        void RULE_UNSHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_UNSHIFTED_INSTRUCTION2 (Rule rule, Token [] tokens);
        void RULE_UNSHIFTED_INSTRUCTION3 (Rule rule, Token [] tokens);
        void RULE_F_SHIFTED_INSTRUCTION_F (Rule rule, Token [] tokens);
        void RULE_F_SHIFTED_INSTRUCTION_F2 (Rule rule, Token [] tokens);
        void RULE_G_SHIFTED_INSTRUCTION_G (Rule rule, Token [] tokens);
        void RULE_G_SHIFTED_INSTRUCTION_G2 (Rule rule, Token [] tokens);
        void RULE_H_SHIFTED_INSTRUCTION_H (Rule rule, Token [] tokens);
        void RULE_H_SHIFTED_INSTRUCTION_H2 (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD (Rule rule, Token [] tokens);
        void RULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S (Rule rule, Token [] tokens);
        void RULE_UNARY_UNSHIFTED_INSTRUCTION_GTO (Rule rule, Token [] tokens);
        void RULE_UNARY_UNSHIFTED_INSTRUCTION_DSP (Rule rule, Token [] tokens);
        void RULE_UNARY_UNSHIFTED_INSTRUCTION_STO (Rule rule, Token [] tokens);
        void RULE_UNARY_UNSHIFTED_INSTRUCTION_RCL (Rule rule, Token [] tokens);
        void RULE_BINARY_UNSHIFTED_INSTRUCTION_STO (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION2 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION3 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION4 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION5 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION6 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION7 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION8 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION9 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION10 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION11 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION12 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION13 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION14 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION15 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION16 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION17 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION18 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION19 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION20 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION21 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION22 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION23 (Rule rule, Token [] tokens);
        void RULE_NULLARY_F_SHIFTED_INSTRUCTION24 (Rule rule, Token [] tokens);
        void RULE_UNARY_F_SHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_UNARY_F_SHIFTED_INSTRUCTION2 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION2 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION3 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION4 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION5 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION6 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION7 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION8 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION9 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION10 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION11 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION12 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION13 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION14 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION15 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION16 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION17 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION18 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION19 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION20 (Rule rule, Token [] tokens);
        void RULE_NULLARY_G_SHIFTED_INSTRUCTION21 (Rule rule, Token [] tokens);
        void RULE_UNARY_G_SHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_UNARY_G_SHIFTED_INSTRUCTION2 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION2 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION3 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION4 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION5 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION6 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION7 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION8 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION9 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION10 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION11 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION12 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION13 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION14 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION15 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION16 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION17 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION18 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION19 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION20 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION21 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION22 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION23 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION24 (Rule rule, Token [] tokens);
        void RULE_NULLARY_H_SHIFTED_INSTRUCTION25 (Rule rule, Token [] tokens);
        void RULE_UNARY_H_SHIFTED_INSTRUCTION (Rule rule, Token [] tokens);
        void RULE_OPERATOR_SUBTRACTION (Rule rule, Token [] tokens);
        void RULE_OPERATOR_ADDITION (Rule rule, Token [] tokens);
        void RULE_OPERATOR_MULTIPLICATION (Rule rule, Token [] tokens);
        void RULE_OPERATOR_DIVISION (Rule rule, Token [] tokens);
        void RULE_DIGIT_ZERO (Rule rule, Token [] tokens);
        void RULE_DIGIT_ONE (Rule rule, Token [] tokens);
        void RULE_DIGIT_TWO (Rule rule, Token [] tokens);
        void RULE_DIGIT_THREE (Rule rule, Token [] tokens);
        void RULE_DIGIT_FOUR (Rule rule, Token [] tokens);
        void RULE_DIGIT_FIVE (Rule rule, Token [] tokens);
        void RULE_DIGIT_SIX (Rule rule, Token [] tokens);
        void RULE_DIGIT_SEVEN (Rule rule, Token [] tokens);
        void RULE_DIGIT_EIGHT (Rule rule, Token [] tokens);
        void RULE_DIGIT_NINE (Rule rule, Token [] tokens);
        void RULE_LETTER_A (Rule rule, Token [] tokens);
        void RULE_LETTER_B (Rule rule, Token [] tokens);
        void RULE_LETTER_C (Rule rule, Token [] tokens);
        void RULE_LETTER_D (Rule rule, Token [] tokens);
        void RULE_LETTER_E (Rule rule, Token [] tokens);
        void RULE_LETTER_LABEL (Rule rule, Token [] tokens);
        void RULE_DIGIT_LABEL (Rule rule, Token [] tokens);
        void RULE_LABEL (Rule rule, Token [] tokens);
        void RULE_LABEL2 (Rule rule, Token [] tokens);
        void RULE_OPERABLE_MEMORY (Rule rule, Token [] tokens);
        void RULE_OPERABLE_MEMORY_SUB_I (Rule rule, Token [] tokens);
        void RULE_MEMORY (Rule rule, Token [] tokens);
        void RULE_MEMORY2 (Rule rule, Token [] tokens);
    }

    public class HP67Parser
    {
        private LALRParser parser;
        private IHP67ParserActions actions;

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
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
                    actions.RULE_X_AVERAGE_SIGMA_PLUS (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GSB_GTO :
                    // <Gsb> ::= Gto
                    actions.RULE_GSB_GTO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_FIX_DSP :
                    // <Fix> ::= Dsp
                    actions.RULE_FIX_DSP (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RND_SUB_I :
                    // <Rnd> ::= 'Sub_I'
                    actions.RULE_RND_SUB_I (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LBL_SST :
                    // <Lbl> ::= Sst
                    actions.RULE_LBL_SST (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DSZ_STO :
                    // <Dsz> ::= Sto
                    actions.RULE_DSZ_STO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ISZ_RCL :
                    // <Isz> ::= Rcl
                    actions.RULE_ISZ_RCL (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_W_DATA_ENTER :
                    // <W_Data> ::= Enter
                    actions.RULE_W_DATA_ENTER (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_P_EXCHANGE_S_CHS :
                    // <P_Exchange_S> ::= Chs
                    actions.RULE_P_EXCHANGE_S_CHS (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_CL_REG_EEX :
                    // <Cl_Reg> ::= Eex
                    actions.RULE_CL_REG_EEX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_CL_PRGM_CLX :
                    // <Cl_Prgm> ::= Clx
                    actions.RULE_CL_PRGM_CLX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EQ_0_SUBTRACTION :
                    // <X_EQ_0> ::= Subtraction
                    actions.RULE_X_EQ_0_SUBTRACTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LN_SEVEN :
                    // <Ln> ::= Seven
                    actions.RULE_LN_SEVEN (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LOG_EIGHT :
                    // <Log> ::= Eight
                    actions.RULE_LOG_EIGHT (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SQRT_NINE :
                    // <Sqrt> ::= Nine
                    actions.RULE_SQRT_NINE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_NE_0_ADDITION :
                    // <X_NE_0> ::= Addition
                    actions.RULE_X_NE_0_ADDITION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SIN_FOUR :
                    // <Sin> ::= Four
                    actions.RULE_SIN_FOUR (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_COS_FIVE :
                    // <Cos> ::= Five
                    actions.RULE_COS_FIVE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TAN_SIX :
                    // <Tan> ::= Six
                    actions.RULE_TAN_SIX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_LT_0_MULTIPLICATION :
                    // <X_LT_0> ::= Multiplication
                    actions.RULE_X_LT_0_MULTIPLICATION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_RECTANGULAR_ONE :
                    // <To_Rectangular> ::= One
                    actions.RULE_TO_RECTANGULAR_ONE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_DEGREES_TWO :
                    // <To_Degrees> ::= Two
                    actions.RULE_TO_DEGREES_TWO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_HOURS_THREE :
                    // <To_Hours> ::= Three
                    actions.RULE_TO_HOURS_THREE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_GT_0_DIVISION :
                    // <X_GT_0> ::= Division
                    actions.RULE_X_GT_0_DIVISION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PERCENT_ZERO :
                    // <Percent> ::= Zero
                    actions.RULE_PERCENT_ZERO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INT_PERIOD :
                    // <Int> ::= Period
                    actions.RULE_INT_PERIOD (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DISPLAY_X_R_S :
                    // <Display_X> ::= 'R_S'
                    actions.RULE_DISPLAY_X_R_S (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_S_SIGMA_PLUS :
                    // <S> ::= 'Sigma_Plus'
                    actions.RULE_S_SIGMA_PLUS (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GSB_F_GTO :
                    // <Gsb_f> ::= Gto
                    actions.RULE_GSB_F_GTO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SCI_DSP :
                    // <Sci> ::= Dsp
                    actions.RULE_SCI_DSP (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LBL_F_SST :
                    // <Lbl_f> ::= Sst
                    actions.RULE_LBL_F_SST (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DSZ_SUB_I_STO :
                    // <Dsz_Sub_I> ::= Sto
                    actions.RULE_DSZ_SUB_I_STO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ISZ_SUB_I_RCL :
                    // <Isz_Sub_I> ::= Rcl
                    actions.RULE_ISZ_SUB_I_RCL (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MERGE_ENTER :
                    // <Merge> ::= Enter
                    actions.RULE_MERGE_ENTER (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EQ_Y_SUBTRACTION :
                    // <X_EQ_Y> ::= Subtraction
                    actions.RULE_X_EQ_Y_SUBTRACTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_EXP_SEVEN :
                    // <Exp> ::= Seven
                    actions.RULE_EXP_SEVEN (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TEN_TO_THE_XTH_EIGHT :
                    // <Ten_To_The_Xth> ::= Eight
                    actions.RULE_TEN_TO_THE_XTH_EIGHT (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SQUARE_NINE :
                    // <Square> ::= Nine
                    actions.RULE_SQUARE_NINE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_NE_Y_ADDITION :
                    // <X_NE_Y> ::= Addition
                    actions.RULE_X_NE_Y_ADDITION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ARCSIN_FOUR :
                    // <Arcsin> ::= Four
                    actions.RULE_ARCSIN_FOUR (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ARCCOS_FIVE :
                    // <Arccos> ::= Five
                    actions.RULE_ARCCOS_FIVE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ARCTAN_SIX :
                    // <Arctan> ::= Six
                    actions.RULE_ARCTAN_SIX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_LE_Y_MULTIPLICATION :
                    // <X_LE_Y> ::= Multiplication
                    actions.RULE_X_LE_Y_MULTIPLICATION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_POLAR_ONE :
                    // <To_Polar> ::= One
                    actions.RULE_TO_POLAR_ONE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_RADIANS_TWO :
                    // <To_Radians> ::= Two
                    actions.RULE_TO_RADIANS_TWO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_TO_HMS_THREE :
                    // <To_HMS> ::= Three
                    actions.RULE_TO_HMS_THREE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_GT_Y_DIVISION :
                    // <X_GT_Y> ::= Division
                    actions.RULE_X_GT_Y_DIVISION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PERCENT_CHANGE_ZERO :
                    // <Percent_Change> ::= Zero
                    actions.RULE_PERCENT_CHANGE_ZERO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_FRAC_PERIOD :
                    // <Frac> ::= Period
                    actions.RULE_FRAC_PERIOD (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_STK_R_S :
                    // <Stk> ::= 'R_S'
                    actions.RULE_STK_R_S (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SIGMA_MINUS_SIGMA_PLUS :
                    // <Sigma_Minus> ::= 'Sigma_Plus'
                    actions.RULE_SIGMA_MINUS_SIGMA_PLUS (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RTN_GTO :
                    // <Rtn> ::= Gto
                    actions.RULE_RTN_GTO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ENG_DSP :
                    // <Eng> ::= Dsp
                    actions.RULE_ENG_DSP (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EXCHANGE_I_SUB_I :
                    // <X_Exchange_I> ::= 'Sub_I'
                    actions.RULE_X_EXCHANGE_I_SUB_I (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_BST_SST :
                    // <Bst> ::= Sst
                    actions.RULE_BST_SST (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ST_I_STO :
                    // <St_I> ::= Sto
                    actions.RULE_ST_I_STO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RC_I_RCL :
                    // <Rc_I> ::= Rcl
                    actions.RULE_RC_I_RCL (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DEG_ENTER :
                    // <Deg> ::= Enter
                    actions.RULE_DEG_ENTER (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RAD_CHS :
                    // <Rad> ::= Chs
                    actions.RULE_RAD_CHS (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GRD_EEX :
                    // <Grd> ::= Eex
                    actions.RULE_GRD_EEX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DEL_CLX :
                    // <Del> ::= Clx
                    actions.RULE_DEL_CLX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SF_SUBTRACTION :
                    // <SF> ::= Subtraction
                    actions.RULE_SF_SUBTRACTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_X_EXCHANGE_Y_SEVEN :
                    // <X_Exchange_Y> ::= Seven
                    actions.RULE_X_EXCHANGE_Y_SEVEN (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_R_DOWN_EIGHT :
                    // <R_Down> ::= Eight
                    actions.RULE_R_DOWN_EIGHT (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_R_UP_NINE :
                    // <R_Up> ::= Nine
                    actions.RULE_R_UP_NINE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_CF_ADDITION :
                    // <CF> ::= Addition
                    actions.RULE_CF_ADDITION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_RECIPROCAL_FOUR :
                    // <Reciprocal> ::= Four
                    actions.RULE_RECIPROCAL_FOUR (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_Y_TO_THE_XTH_FIVE :
                    // <Y_To_The_Xth> ::= Five
                    actions.RULE_Y_TO_THE_XTH_FIVE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_ABS_SIX :
                    // <Abs> ::= Six
                    actions.RULE_ABS_SIX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_TEST_MULTIPLICATION :
                    // <F_Test> ::= Multiplication
                    actions.RULE_F_TEST_MULTIPLICATION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PAUSE_ONE :
                    // <Pause> ::= One
                    actions.RULE_PAUSE_ONE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_PI_TWO :
                    // <Pi> ::= Two
                    actions.RULE_PI_TWO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_REG_THREE :
                    // <Reg> ::= Three
                    actions.RULE_REG_THREE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_FACTORIAL_DIVISION :
                    // <Factorial> ::= Division
                    actions.RULE_FACTORIAL_DIVISION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LST_X_ZERO :
                    // <Lst_X> ::= Zero
                    actions.RULE_LST_X_ZERO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_HMS_PLUS_PERIOD :
                    // <HMS_Plus> ::= Period
                    actions.RULE_HMS_PLUS_PERIOD (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SPACE_R_S :
                    // <Space> ::= 'R_S'
                    actions.RULE_SPACE_R_S (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION :
                    // <Instruction> ::= <Command>
                    actions.RULE_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION2 :
                    // <Instruction> ::= <Shortcut>
                    actions.RULE_INSTRUCTION2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION3 :
                    // <Instruction> ::= <Unshifted_Instruction>
                    actions.RULE_INSTRUCTION3 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION4 :
                    // <Instruction> ::= <F_Shifted_Instruction>
                    actions.RULE_INSTRUCTION4 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION5 :
                    // <Instruction> ::= <G_Shifted_Instruction>
                    actions.RULE_INSTRUCTION5 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_INSTRUCTION6 :
                    // <Instruction> ::= <H_Shifted_Instruction>
                    actions.RULE_INSTRUCTION6 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_COMMAND_SST :
                    // <Command> ::= Sst
                    actions.RULE_COMMAND_SST (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_COMMAND_H :
                    // <Command> ::= h <Bst>
                    actions.RULE_COMMAND_H (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_COMMAND_H2 :
                    // <Command> ::= h <Del>
                    actions.RULE_COMMAND_H2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_COMMAND_F :
                    // <Command> ::= f <Cl_Prgm>
                    actions.RULE_COMMAND_F (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_COMMAND_GTO_PERIOD :
                    // <Command> ::= Gto Period <Digit> <Digit> <Digit>
                    actions.RULE_COMMAND_GTO_PERIOD (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SHORTCUT :
                    // <Shortcut> ::= <Unshifted_Shortcut>
                    actions.RULE_SHORTCUT (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_SHORTCUT2 :
                    // <Shortcut> ::= <F_Shifted_Shortcut>
                    actions.RULE_SHORTCUT2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_SHORTCUT :
                    // <Unshifted_Shortcut> ::= <Gsb_Shortcut>
                    actions.RULE_UNSHIFTED_SHORTCUT (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_SHORTCUT2 :
                    // <Unshifted_Shortcut> ::= <Memory_Shortcut>
                    actions.RULE_UNSHIFTED_SHORTCUT2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_SHIFTED_SHORTCUT_F :
                    // <F_Shifted_Shortcut> ::= f <Gsb_Shortcut>
                    actions.RULE_F_SHIFTED_SHORTCUT_F (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_GSB_SHORTCUT :
                    // <Gsb_Shortcut> ::= <Letter>
                    actions.RULE_GSB_SHORTCUT (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MEMORY_SHORTCUT_SUB_I :
                    // <Memory_Shortcut> ::= 'Sub_I'
                    actions.RULE_MEMORY_SHORTCUT_SUB_I (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_INSTRUCTION :
                    // <Unshifted_Instruction> ::= <Nullary_Unshifted_Instruction>
                    actions.RULE_UNSHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_INSTRUCTION2 :
                    // <Unshifted_Instruction> ::= <Unary_Unshifted_Instruction>
                    actions.RULE_UNSHIFTED_INSTRUCTION2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNSHIFTED_INSTRUCTION3 :
                    // <Unshifted_Instruction> ::= <Binary_Unshifted_Instruction>
                    actions.RULE_UNSHIFTED_INSTRUCTION3 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_SHIFTED_INSTRUCTION_F :
                    // <F_Shifted_Instruction> ::= f <Nullary_F_Shifted_Instruction>
                    actions.RULE_F_SHIFTED_INSTRUCTION_F (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_F_SHIFTED_INSTRUCTION_F2 :
                    // <F_Shifted_Instruction> ::= f <Unary_F_Shifted_Instruction>
                    actions.RULE_F_SHIFTED_INSTRUCTION_F2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_G_SHIFTED_INSTRUCTION_G :
                    // <G_Shifted_Instruction> ::= g <Nullary_G_Shifted_Instruction>
                    actions.RULE_G_SHIFTED_INSTRUCTION_G (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_G_SHIFTED_INSTRUCTION_G2 :
                    // <G_Shifted_Instruction> ::= g <Unary_G_Shifted_Instruction>
                    actions.RULE_G_SHIFTED_INSTRUCTION_G2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_H_SHIFTED_INSTRUCTION_H :
                    // <H_Shifted_Instruction> ::= h <Nullary_H_Shifted_Instruction>
                    actions.RULE_H_SHIFTED_INSTRUCTION_H (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_H_SHIFTED_INSTRUCTION_H2 :
                    // <H_Shifted_Instruction> ::= h <Unary_H_Shifted_Instruction>
                    actions.RULE_H_SHIFTED_INSTRUCTION_H2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS :
                    // <Nullary_Unshifted_Instruction> ::= 'Sigma_Plus'
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_SIGMA_PLUS (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER :
                    // <Nullary_Unshifted_Instruction> ::= Enter
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_ENTER (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS :
                    // <Nullary_Unshifted_Instruction> ::= Chs
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_CHS (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX :
                    // <Nullary_Unshifted_Instruction> ::= Eex
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_EEX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX :
                    // <Nullary_Unshifted_Instruction> ::= Clx
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_CLX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION :
                    // <Nullary_Unshifted_Instruction> ::= <Digit>
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION :
                    // <Nullary_Unshifted_Instruction> ::= Subtraction
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_SUBTRACTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION :
                    // <Nullary_Unshifted_Instruction> ::= Addition
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_ADDITION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION :
                    // <Nullary_Unshifted_Instruction> ::= Multiplication
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_MULTIPLICATION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION :
                    // <Nullary_Unshifted_Instruction> ::= Division
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_DIVISION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD :
                    // <Nullary_Unshifted_Instruction> ::= Period
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_PERIOD (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S :
                    // <Nullary_Unshifted_Instruction> ::= 'R_S'
                    actions.RULE_NULLARY_UNSHIFTED_INSTRUCTION_R_S (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_GTO :
                    // <Unary_Unshifted_Instruction> ::= Gto <Label>
                    actions.RULE_UNARY_UNSHIFTED_INSTRUCTION_GTO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_DSP :
                    // <Unary_Unshifted_Instruction> ::= Dsp <Digit>
                    actions.RULE_UNARY_UNSHIFTED_INSTRUCTION_DSP (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_STO :
                    // <Unary_Unshifted_Instruction> ::= Sto <Memory>
                    actions.RULE_UNARY_UNSHIFTED_INSTRUCTION_STO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_UNSHIFTED_INSTRUCTION_RCL :
                    // <Unary_Unshifted_Instruction> ::= Rcl <Memory>
                    actions.RULE_UNARY_UNSHIFTED_INSTRUCTION_RCL (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_BINARY_UNSHIFTED_INSTRUCTION_STO :
                    // <Binary_Unshifted_Instruction> ::= Sto <Operator> <Operable_Memory>
                    actions.RULE_BINARY_UNSHIFTED_INSTRUCTION_STO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION :
                    // <Nullary_F_Shifted_Instruction> ::= <X_Average>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION2 :
                    // <Nullary_F_Shifted_Instruction> ::= <Fix>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION3 :
                    // <Nullary_F_Shifted_Instruction> ::= <Rnd>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION3 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION4 :
                    // <Nullary_F_Shifted_Instruction> ::= <Dsz>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION4 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION5 :
                    // <Nullary_F_Shifted_Instruction> ::= <Isz>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION5 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION6 :
                    // <Nullary_F_Shifted_Instruction> ::= <W_Data>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION6 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION7 :
                    // <Nullary_F_Shifted_Instruction> ::= <P_Exchange_S>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION7 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION8 :
                    // <Nullary_F_Shifted_Instruction> ::= <Cl_Reg>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION8 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION9 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_EQ_0>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION9 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION10 :
                    // <Nullary_F_Shifted_Instruction> ::= <Ln>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION10 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION11 :
                    // <Nullary_F_Shifted_Instruction> ::= <Log>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION11 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION12 :
                    // <Nullary_F_Shifted_Instruction> ::= <Sqrt>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION12 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION13 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_NE_0>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION13 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION14 :
                    // <Nullary_F_Shifted_Instruction> ::= <Sin>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION14 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION15 :
                    // <Nullary_F_Shifted_Instruction> ::= <Cos>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION15 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION16 :
                    // <Nullary_F_Shifted_Instruction> ::= <Tan>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION16 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION17 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_LT_0>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION17 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION18 :
                    // <Nullary_F_Shifted_Instruction> ::= <To_Rectangular>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION18 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION19 :
                    // <Nullary_F_Shifted_Instruction> ::= <To_Degrees>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION19 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION20 :
                    // <Nullary_F_Shifted_Instruction> ::= <To_Hours>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION20 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION21 :
                    // <Nullary_F_Shifted_Instruction> ::= <X_GT_0>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION21 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION22 :
                    // <Nullary_F_Shifted_Instruction> ::= <Percent>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION22 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION23 :
                    // <Nullary_F_Shifted_Instruction> ::= <Int>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION23 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_F_SHIFTED_INSTRUCTION24 :
                    // <Nullary_F_Shifted_Instruction> ::= <Display_X>
                    actions.RULE_NULLARY_F_SHIFTED_INSTRUCTION24 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_F_SHIFTED_INSTRUCTION :
                    // <Unary_F_Shifted_Instruction> ::= <Gsb> <Label>
                    actions.RULE_UNARY_F_SHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_F_SHIFTED_INSTRUCTION2 :
                    // <Unary_F_Shifted_Instruction> ::= <Lbl> <Label>
                    actions.RULE_UNARY_F_SHIFTED_INSTRUCTION2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION :
                    // <Nullary_G_Shifted_Instruction> ::= <S>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION2 :
                    // <Nullary_G_Shifted_Instruction> ::= <Sci>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION3 :
                    // <Nullary_G_Shifted_Instruction> ::= <Dsz_Sub_I>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION3 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION4 :
                    // <Nullary_G_Shifted_Instruction> ::= <Isz_Sub_I>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION4 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION5 :
                    // <Nullary_G_Shifted_Instruction> ::= <Merge>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION5 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION6 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_EQ_Y>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION6 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION7 :
                    // <Nullary_G_Shifted_Instruction> ::= <Exp>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION7 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION8 :
                    // <Nullary_G_Shifted_Instruction> ::= <Ten_To_The_Xth>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION8 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION9 :
                    // <Nullary_G_Shifted_Instruction> ::= <Square>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION9 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION10 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_NE_Y>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION10 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION11 :
                    // <Nullary_G_Shifted_Instruction> ::= <Arcsin>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION11 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION12 :
                    // <Nullary_G_Shifted_Instruction> ::= <Arccos>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION12 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION13 :
                    // <Nullary_G_Shifted_Instruction> ::= <Arctan>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION13 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION14 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_LE_Y>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION14 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION15 :
                    // <Nullary_G_Shifted_Instruction> ::= <To_Polar>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION15 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION16 :
                    // <Nullary_G_Shifted_Instruction> ::= <To_Radians>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION16 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION17 :
                    // <Nullary_G_Shifted_Instruction> ::= <To_HMS>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION17 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION18 :
                    // <Nullary_G_Shifted_Instruction> ::= <X_GT_Y>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION18 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION19 :
                    // <Nullary_G_Shifted_Instruction> ::= <Percent_Change>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION19 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION20 :
                    // <Nullary_G_Shifted_Instruction> ::= <Frac>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION20 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_G_SHIFTED_INSTRUCTION21 :
                    // <Nullary_G_Shifted_Instruction> ::= <Stk>
                    actions.RULE_NULLARY_G_SHIFTED_INSTRUCTION21 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_G_SHIFTED_INSTRUCTION :
                    // <Unary_G_Shifted_Instruction> ::= <Gsb_f> <Letter_Label>
                    actions.RULE_UNARY_G_SHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_G_SHIFTED_INSTRUCTION2 :
                    // <Unary_G_Shifted_Instruction> ::= <Lbl_f> <Letter_Label>
                    actions.RULE_UNARY_G_SHIFTED_INSTRUCTION2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION :
                    // <Nullary_H_Shifted_Instruction> ::= <Sigma_Minus>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION2 :
                    // <Nullary_H_Shifted_Instruction> ::= <Rtn>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION3 :
                    // <Nullary_H_Shifted_Instruction> ::= <Eng>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION3 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION4 :
                    // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_I>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION4 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION5 :
                    // <Nullary_H_Shifted_Instruction> ::= <St_I>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION5 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION6 :
                    // <Nullary_H_Shifted_Instruction> ::= <Rc_I>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION6 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION7 :
                    // <Nullary_H_Shifted_Instruction> ::= <Deg>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION7 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION8 :
                    // <Nullary_H_Shifted_Instruction> ::= <Rad>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION8 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION9 :
                    // <Nullary_H_Shifted_Instruction> ::= <Grd>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION9 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION10 :
                    // <Nullary_H_Shifted_Instruction> ::= <SF>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION10 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION11 :
                    // <Nullary_H_Shifted_Instruction> ::= <X_Exchange_Y>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION11 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION12 :
                    // <Nullary_H_Shifted_Instruction> ::= <R_Down>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION12 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION13 :
                    // <Nullary_H_Shifted_Instruction> ::= <R_Up>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION13 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION14 :
                    // <Nullary_H_Shifted_Instruction> ::= <CF>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION14 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION15 :
                    // <Nullary_H_Shifted_Instruction> ::= <Reciprocal>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION15 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION16 :
                    // <Nullary_H_Shifted_Instruction> ::= <Y_To_The_Xth>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION16 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION17 :
                    // <Nullary_H_Shifted_Instruction> ::= <Abs>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION17 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION18 :
                    // <Nullary_H_Shifted_Instruction> ::= <F_Test>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION18 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION19 :
                    // <Nullary_H_Shifted_Instruction> ::= <Pause>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION19 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION20 :
                    // <Nullary_H_Shifted_Instruction> ::= <Pi>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION20 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION21 :
                    // <Nullary_H_Shifted_Instruction> ::= <Reg>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION21 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION22 :
                    // <Nullary_H_Shifted_Instruction> ::= <Factorial>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION22 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION23 :
                    // <Nullary_H_Shifted_Instruction> ::= <Lst_X>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION23 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION24 :
                    // <Nullary_H_Shifted_Instruction> ::= <HMS_Plus>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION24 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_NULLARY_H_SHIFTED_INSTRUCTION25 :
                    // <Nullary_H_Shifted_Instruction> ::= <Space>
                    actions.RULE_NULLARY_H_SHIFTED_INSTRUCTION25 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_UNARY_H_SHIFTED_INSTRUCTION :
                    // <Unary_H_Shifted_Instruction> ::= 
                    actions.RULE_UNARY_H_SHIFTED_INSTRUCTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_SUBTRACTION :
                    // <Operator> ::= Subtraction
                    actions.RULE_OPERATOR_SUBTRACTION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_ADDITION :
                    // <Operator> ::= Addition
                    actions.RULE_OPERATOR_ADDITION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_MULTIPLICATION :
                    // <Operator> ::= Multiplication
                    actions.RULE_OPERATOR_MULTIPLICATION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERATOR_DIVISION :
                    // <Operator> ::= Division
                    actions.RULE_OPERATOR_DIVISION (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_ZERO :
                    // <Digit> ::= Zero
                    actions.RULE_DIGIT_ZERO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_ONE :
                    // <Digit> ::= One
                    actions.RULE_DIGIT_ONE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_TWO :
                    // <Digit> ::= Two
                    actions.RULE_DIGIT_TWO (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_THREE :
                    // <Digit> ::= Three
                    actions.RULE_DIGIT_THREE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_FOUR :
                    // <Digit> ::= Four
                    actions.RULE_DIGIT_FOUR (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_FIVE :
                    // <Digit> ::= Five
                    actions.RULE_DIGIT_FIVE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_SIX :
                    // <Digit> ::= Six
                    actions.RULE_DIGIT_SIX (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_SEVEN :
                    // <Digit> ::= Seven
                    actions.RULE_DIGIT_SEVEN (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_EIGHT :
                    // <Digit> ::= Eight
                    actions.RULE_DIGIT_EIGHT (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_NINE :
                    // <Digit> ::= Nine
                    actions.RULE_DIGIT_NINE (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_A :
                    // <Letter> ::= A
                    actions.RULE_LETTER_A (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_B :
                    // <Letter> ::= B
                    actions.RULE_LETTER_B (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_C :
                    // <Letter> ::= C
                    actions.RULE_LETTER_C (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_D :
                    // <Letter> ::= D
                    actions.RULE_LETTER_D (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_E :
                    // <Letter> ::= E
                    actions.RULE_LETTER_E (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LETTER_LABEL :
                    // <Letter_Label> ::= <Letter>
                    actions.RULE_LETTER_LABEL (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_DIGIT_LABEL :
                    // <Digit_Label> ::= <Digit>
                    actions.RULE_DIGIT_LABEL (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LABEL :
                    // <Label> ::= <Digit_Label>
                    actions.RULE_LABEL (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_LABEL2 :
                    // <Label> ::= <Letter_Label>
                    actions.RULE_LABEL2 (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERABLE_MEMORY :
                    // <Operable_Memory> ::= <Digit>
                    actions.RULE_OPERABLE_MEMORY (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_OPERABLE_MEMORY_SUB_I :
                    // <Operable_Memory> ::= 'Sub_I'
                    actions.RULE_OPERABLE_MEMORY_SUB_I (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MEMORY :
                    // <Memory> ::= <Operable_Memory>
                    actions.RULE_MEMORY (args.Token.Rule, args.Token.Tokens);
                    return;

                case (int)RuleConstants.RULE_MEMORY2 :
                    // <Memory> ::= <Letter>
                    actions.RULE_MEMORY2 (args.Token.Rule, args.Token.Tokens);
                    return;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

        private void Initialize (Stream stream)
        {
            CGTReader reader = new CGTReader (stream);
            parser = reader.CreateNewParser ();
            parser.TrimReductions = false; 
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler (ReduceEvent);
            parser.OnAccept += new LALRParser.AcceptHandler (AcceptEvent);
            parser.OnTokenError +=
                new LALRParser.TokenErrorHandler (TokenErrorEvent);
            parser.OnParseError +=
                new LALRParser.ParseErrorHandler (ParseErrorEvent);
        }

        public HP67Parser (string filename)
        {
            FileStream stream = new FileStream (filename,
                                                FileMode.Open, 
                                                FileAccess.Read, 
                                                FileShare.Read);
            Initialize (stream);
            stream.Close ();
        }

        public HP67Parser (string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource
               (System.Reflection.Assembly.GetExecutingAssembly (),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream (buffer);
            Initialize (stream);
            stream.Close ();
        }

        public HP67Parser (Stream stream)
        {
            Initialize (stream);
        }

        public void Parse (string source, IHP67ParserActions a)
        {
            actions = a;
            parser.Parse (source);
        }

    }
}
