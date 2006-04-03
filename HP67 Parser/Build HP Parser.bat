REM Construction of the grammar-related files.
call goldbuilder HP.grm HP.cgt
call createskelprog HP.cgt "C-Sharp - Calitha Interface Based.pgt" Parser.cs
call createskelprog HP.cgt "C-Sharp - Calitha Interface Implementation.pgt" Template.cs
resxgen /i:HP.cgt /o:Parser.resx /n:CGT