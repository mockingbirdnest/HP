REM Construction of the grammar-related files.
set GOLDDIR=C:\Program Files (x86)\GOLD Parser Builder\Cmd
set PATH=%GOLDDIR%;%PATH%
call goldbuilder HP.grm HP.cgt
call createskelprog HP.cgt "C-Sharp - Calitha Interface Based.pgt" Parser.cs
call createskelprog HP.cgt "C-Sharp - Calitha Interface Implementation.pgt" Template.cs
REM resxgen /i:HP.cgt /o:Parser.resx /n:CGT